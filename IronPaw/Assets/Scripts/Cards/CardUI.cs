using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public Card Card;

    //[SerializeField] ColorIdentity[] _colors = new ColorIdentity[2];

    [SerializeField] private RectTransform _container;
    private RectTransform _originalTransform;
    [SerializeField] private float _cardSelectedOffset;
    [SerializeField] private Image _artWorkDisplay;
    [SerializeField] private Image _cardFrame;
    [SerializeField] private Image _plateFrame;
    [SerializeField] private Image _rarityFrame;
    [SerializeField] private Image _typeFrame;

    [SerializeField] private TextMeshProUGUI _manaCostDisplay;
    [SerializeField] private TextMeshProUGUI _cardNameDisplay;
    [SerializeField] private TextMeshProUGUI _cardDescDisplay;
    [SerializeField] private TextMeshProUGUI _cardTypeDisplay;



    [SerializeField] private float _longPressTime = 1f;
    private float _mouseDownTime;
    private Coroutine _runningCoroutine;

    public Image ArtWorkDisplay { get => _artWorkDisplay; set => _artWorkDisplay = value; }
    public Image CardFrame { get => _cardFrame; set => _cardFrame = value; }
    public Image PlateFrame { get => _plateFrame; set => _plateFrame = value; }
    public Image RarityFrame { get => _rarityFrame; set => _rarityFrame = value; }
    public Image TypeFrame { get => _typeFrame; set => _typeFrame = value; }
    public TextMeshProUGUI CardDescDisplay { get => _cardDescDisplay; set => _cardDescDisplay = value; }
    public RectTransform Container { get => _container; set => _container = value; }
    public RectTransform OriginalTransform { get => _originalTransform; set => _originalTransform = value; }

    private void Start()
    {
        InitializeDisplay();
    }

    public void InitializeDisplay()
    {
        _originalTransform = Container;
        ArtWorkDisplay.sprite = Card.Artwork;
        _manaCostDisplay.text = Card.EnergyCost.ToString();
        _cardNameDisplay.text = Card.CardName;
        InitCardFrame();
        InitDescription();
        InitType(Card.CardType);
    }


    private string TurnStringToCapitalString(string allCapped)
    {
        string capital = allCapped.ToLower();
        char[] letters = capital.ToCharArray();
        capital = letters[0].ToString().ToUpper();
        for (int i = 1; i < letters.Length; i++)
        {
            if (letters[i] == '_')
            {
                capital += " ";
            }
            else
            {
                capital += letters[i];

            }
        }
        return capital;

    }
    private string TurnStringToCapitalString(KeyWords allCapped)
    {
        return TurnStringToCapitalString(allCapped.ToString());
    }

    private void InitDescription()
    {
        int numberOfKeyWordsAdded = 0;
        CardDescDisplay.text = "";

        // 1) ---------------  Adding Keywords that need to be added at start of card ------
        foreach (var keywordInCard in Card.Keywords)
        {
            foreach (var keywordToAdd in PrefabManager.Instance._keywordManager.KeywordsToAddToCardDescription)
            {
                if (keywordInCard == keywordToAdd)
                {
                    if (keywordInCard.ToString().Length > 2)
                    {
                        CardDescDisplay.text += TurnStringToCapitalString(keywordInCard);

                    }
                    else // Used for AP edge-case (and maybe for future 2-word Keywords
                    {
                        CardDescDisplay.text += keywordInCard.ToString(); 

                    }
                    numberOfKeyWordsAdded++;
                    CardDescDisplay.text += ", ";

                }
            }
        }

        // 1.1) ---------------  Removing excess coma + space, going down 1 line -----------
        if (numberOfKeyWordsAdded > 0)
        {
            for (int i = 0; i < 2; i++) // Remove the last coma + space that were added (line 95)
            {
                CardDescDisplay.text = CardDescDisplay.text.Remove(CardDescDisplay.text.Length - 1); 
            }

            /* Goind down one line. This will be deleted before the keywords are bolded (when the description is split to individual words),
             * but is still necessary, sine the string needs some space to diffrnitiate between the last Keyword added and the rest of the inspector-
             * fed description (added at line 116) */
            CardDescDisplay.text += "\n"; 
            
        }

        // 2) -----  Adding the card description text from the CardSO (from the inspector)--
        CardDescDisplay.text += Card.Description.ToString();

        // 3) -----------------------  Making Keywords Bold --------------------------------
        foreach (var keywordInCard in Card.Keywords)
        {
            string cappedKeyWord = "";

            if (keywordInCard.ToString().Length > 2)
            {
                 cappedKeyWord = TurnStringToCapitalString(keywordInCard);
            }
            else // Used for AP edge-case (and maybe for future 2-word Keywords)
            {
                cappedKeyWord = keywordInCard.ToString();
            }

            if (CardDescDisplay.text.Contains(cappedKeyWord)) 
            {
                string sentence = CardDescDisplay.text;
                CardDescDisplay.text = "";
                string[] words = sentence.Split();
                string temp = "";
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == cappedKeyWord)
                    {
                        temp = "<b>" + cappedKeyWord + "</b>";
                        CardDescDisplay.text += temp + " ";
                    }
                    else if (words[i] == cappedKeyWord + ",")
                    {
                        string trimmedWord = cappedKeyWord.TrimEnd(new char[] { ',' });
                        temp = "<b>" + trimmedWord + "</b>,";
                        CardDescDisplay.text += temp + " ";
                    }
                    else
                    {
                        CardDescDisplay.text += words[i] + " ";
                    }

                    if (numberOfKeyWordsAdded != 0 && i == numberOfKeyWordsAdded-1) // In the event where at least 1 keyword was added, go down one line
                    {
                        CardDescDisplay.text += "\n"; // Going down 1 line
                    }
                }
            }
        }

    }

    private void InitType(CardType type)
    {
        switch (type)
        {
            case CardType.Attack:
                _cardTypeDisplay.text = "Attack";
                break;

            case CardType.Guard:
                _cardTypeDisplay.text = "Guard";
                break;

            case CardType.Utility:
                _cardTypeDisplay.text = "Utility";
                break;

        }
    }

    public void DestroyTheHeretic()
    {
        Destroy(gameObject);
    }

    public void OnPressStart()
    {
        if (!TurnManager.Instance.LockInputs)
        {
            _runningCoroutine = StartCoroutine(CountTimeHeld());
        }
    }

    public void OnPressRelease()
    {
        if (TurnManager.Instance.LockInputs)
        {
            return;
        }
        StopHoldingMouse();

        _mouseDownTime = 0;
    }

    public void OnClick()
    {
        //play card normally
        if (Card.CheckCardValidity() && this != CombatManager.Instance.SelectedCardUI)
        {
            SelectCard();
            StartCoroutine(CombatManager.Instance.WaitUntilHeroIsClickedPlayCard(Card));
        }
        else
        {
            DeselectCard();
            // We dont want to play this sound inside of DeselectCard because SelectCard also invokes DeselectCard,
            // which will make the soundclip play twice
            AudioManager.Instance.Play(AudioManager.Instance.SfxClips[4]); 
            CombatManager.Instance.CancelCard();
        }
    }

    public void StopHoldingMouse()
    {
        if(_runningCoroutine != null)
        {
            StopCoroutine(_runningCoroutine);
        }        
    }

    private IEnumerator CountTimeHeld()
    {
        while (_mouseDownTime < _longPressTime)
        {
            _mouseDownTime += Time.deltaTime;
            yield return null;
        }
        // LongPress
        UIManager.Instance.ToggleCardZoomCanvas(Card, true, this);

    }

    private void InitCardFrame()
    {
        List<string> colorID = new List<string>();

        colorID.Add(Card.Colors[0].ToString());

        if (Card.Colors.Length > 1)
        {
            colorID.Add(Card.Colors[1].ToString());
        }

        CardFrame.sprite = PrefabManager.Instance.GetCardFrameByColor(colorID);
        PlateFrame.sprite = PrefabManager.Instance.GetCardPlateFrameByColor(colorID);


        RarityFrame.sprite = PrefabManager.Instance.GetCardRarityFrame(Card.Rarity);
        TypeFrame.sprite = PrefabManager.Instance.GetCardTypeFrame(Card.CardType);

    }

    public void SelectCard()
    {
        AudioManager.Instance.Play(AudioManager.Instance.SfxClips[4]);
        DeselectCard();
        
        CombatManager.Instance.SelectedCardUI = this;
        HighlightSelectedCard();
    }

    public void DeselectCard()
    {
        if (CombatManager.Instance.SelectedCardUI)
        {
            CombatManager.Instance.SelectedCardUI.DehighlightSelectedCard();
            CombatManager.Instance.SelectedCardUI = null;
        }
    }

    public void HighlightSelectedCard()
    {
        Container.localPosition += new Vector3(0, _cardSelectedOffset, 0);

    }

    public void DehighlightSelectedCard()
    {
        Container.localPosition -= new Vector3(0, _cardSelectedOffset, 0);
    }
}

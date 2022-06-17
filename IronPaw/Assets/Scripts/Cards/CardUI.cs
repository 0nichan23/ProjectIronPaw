using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public CardScriptableObject CardSO;

    [SerializeField] ColorIdentity[] _colors = new ColorIdentity[2];

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

    public void InitializeDisplay()
    {
        _originalTransform = Container;
        ArtWorkDisplay.sprite = CardSO.Artwork;
        _manaCostDisplay.text = CardSO.EnergyCost.ToString();
        _cardNameDisplay.text = CardSO.CardName;
        InitCardFrame();
        InitDescription();
        InitType(CardSO.CardType);
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
        foreach (var keywordInCard in CardSO.Keywords)
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
        CardDescDisplay.text += CardSO.Description.ToString();

        // 3) -----------------------  Making Keywords Bold --------------------------------
        foreach (var keywordInCard in CardSO.Keywords)
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
        if (CardSO.CheckCardValidity())
        {
            SelectCard();
            StartCoroutine(PartyManager.Instance.WaitUntilHeroIsClickedPlayCard(CardSO));
        }
        else
        {
            DeselectCard();
            PartyManager.Instance.CancelCard();
        }
    }

    public void StopHoldingMouse()
    {
        StopCoroutine(_runningCoroutine);
    }

    private IEnumerator CountTimeHeld()
    {
        while (_mouseDownTime < _longPressTime)
        {
            _mouseDownTime += Time.deltaTime;
            yield return null;
        }
        // LongPress
        UIManager.Instance.ToggleCardZoomCanvas(CardSO, true, this);

    }

    private void InitCardFrame()
    {
        List<string> colorID = new List<string>();

        colorID.Add(CardSO.Colors[0].ToString());

        if (CardSO.Colors.Length > 1)
        {
            colorID.Add(CardSO.Colors[1].ToString());
        }

        CardFrame.sprite = PrefabManager.Instance.GetCardFrameByColor(colorID);
        PlateFrame.sprite = PrefabManager.Instance.GetCardPlateFrameByColor(colorID);


        RarityFrame.sprite = PrefabManager.Instance.GetCardRarityFrame(CardSO.Rarity);
        TypeFrame.sprite = PrefabManager.Instance.GetCardTypeFrame(CardSO.CardType);

    }

    public void SelectCard()
    {
        AudioManager.Instance.Play(AudioManager.Instance.SfxClips[4]);
        DeselectCard();
        
        PartyManager.Instance.SelectedCardUI = this;
        HighlightSelectedCard();
    }

    public void DeselectCard()
    {
        if (PartyManager.Instance.SelectedCardUI)
        {
            PartyManager.Instance.SelectedCardUI.DehighlightSelectedCard();
            PartyManager.Instance.SelectedCardUI = null;
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

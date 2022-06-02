using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public CardScriptableObject CardSO;

    [SerializeField] Color[] _colors = new Color[2];

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

    public void InitializeDisplay()
    {
        ArtWorkDisplay.sprite = CardSO.Artwork;
        _manaCostDisplay.text = CardSO.EnergyCost.ToString();
        _cardNameDisplay.text = CardSO.CardName;
        _cardDescDisplay.text = $"" + CardSO.Description.ToString();
        InitCardFrame();
        InitType(CardSO.CardType);
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
        _runningCoroutine = StartCoroutine(CountTimeHeld());
    }

    public void OnPressRelease()
    {
        StopCoroutine(_runningCoroutine);
        if (_mouseDownTime < _longPressTime) //shotpress
        {
            //play card normally
            if (CardSO.CheckCardValidity())
            {
                StartCoroutine(PartyManager.Instance.WaitUntilHeroIsClickedPlayCard(CardSO));
            }
        }
        _mouseDownTime = 0;
    }

    private IEnumerator CountTimeHeld()
    {
        while (_mouseDownTime < _longPressTime)
        {
            _mouseDownTime += Time.deltaTime;
            yield return null;
        }
        // LongPress
        PlayerWrapper.Instance.PlayerController.ToggleCardCloseUpPanel(CardSO, true, this);
        
    }

    private void InitCardFrame()
    {
        List<string> colorID = new List<string>();

        colorID.Add(CardSO.Colors[0].ToString());
        
        if(CardSO.Colors.Length > 1)
        {
            colorID.Add(CardSO.Colors[1].ToString());
        }

        CardFrame.sprite = PrefabManager.Instance.GetCardFrameByColor(colorID);
        PlateFrame.sprite = PrefabManager.Instance.GetCardPlateFrameByColor(colorID);

        
        RarityFrame.sprite = PrefabManager.Instance.GetCardRarityFrame(CardSO.Rarity);
        TypeFrame.sprite = PrefabManager.Instance.GetCardTypeFrame(CardSO.CardType);

    }    
}

using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public CardScriptableObject CardSO;

    [SerializeField] Color[] _colors = new Color[2];

    [SerializeField]
    private Image _artWorkDisplay;
    [SerializeField] 
    private Image _cardFrame;
    [SerializeField]
    private TextMeshProUGUI _manaCostDisplay;
    [SerializeField]
    private TextMeshProUGUI _cardNameDisplay;
    [SerializeField]
    private TextMeshProUGUI _cardDescDisplay;
    [SerializeField]
    private TextMeshProUGUI _cardTypeDisplay;
    [SerializeField]
    private float _longPressTime = 1f;
    private float _mouseDownTime;
    private float _mouseUpTime;

    [SerializeField] private int[,] array = new int[5,3];
    
    public void InitializeDisplay()
    {
        _artWorkDisplay.sprite = CardSO.Artwork;
        _manaCostDisplay.text = CardSO.EnergyCost.ToString();
        _cardNameDisplay.text = CardSO.CardName;
        _cardDescDisplay.text = $"" + CardSO.Description.ToString();
        InitCardFrameSingleColor();
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

    public void OnPointerDown(PointerEventData eventData)
    {
        _mouseDownTime = Time.time;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _mouseUpTime = Time.time;
        if (_mouseUpTime - _mouseDownTime >= _longPressTime) //longpress 
        {
            //display card preview
            PlayerWrapper.Instance.PlayerController.ToggleCardCloseUpPanel(CardSO, true);
        }
        else //shotpress
        {
            //play card normally
            if (CardSO.CheckCardValidity())
            {
                StartCoroutine(PartyManager.Instance.WaitUntilHeroIsClickedPlayCard(CardSO));
            }
        }
    }

    private void InitCardFrameSingleColor()
    {
        List<string> colorID = new List<string>();

        colorID.Add(CardSO.Colors[0].ToString());
        
        if(CardSO.Colors.Length > 1)
        {
            colorID.Add(CardSO.Colors[1].ToString());
        }

        _cardFrame.sprite = PrefabManager.Instance.GetCardFrameByColor(colorID);
       
    }    
}

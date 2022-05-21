using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardCloseUp : MonoBehaviour, IPointerDownHandler
{
    public CardScriptableObject CardSO;

    [SerializeField]
    private Image _artWorkDisplay;

    [SerializeField]
    private TextMeshProUGUI _manaCostDisplay;
    [SerializeField]
    private TextMeshProUGUI _cardNameDisplay;
    [SerializeField]
    private TextMeshProUGUI _cardDescDisplay;
    [SerializeField]
    private TextMeshProUGUI _cardTypeDisplay;

    public void InitializeDisplay(CardScriptableObject givenCard)
    {
        CardSO = givenCard;
        _artWorkDisplay.sprite = CardSO.Artwork;
        _manaCostDisplay.text = CardSO.EnergyCost.ToString();
        _cardNameDisplay.text = CardSO.CardName;
        _cardDescDisplay.text = $"" + CardSO.Description.ToString();
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


    public void OnPointerDown(PointerEventData eventData)
    {
        PlayerWrapper.Instance.PlayerController.ToggleCardCloseUpPanel(null, false);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardCloseUp : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TextMeshProUGUI _manaCostDisplay;
    [SerializeField] private TextMeshProUGUI _cardNameDisplay;
    [SerializeField] private TextMeshProUGUI _cardDescDisplay;
    [SerializeField] private TextMeshProUGUI _cardTypeDisplay;

    [SerializeField] private Image _artWorkDisplay;
    [SerializeField] private Image _cardFrame;
    [SerializeField] private Image _plateFrame;
    [SerializeField] private Image _rarityFrame;
    [SerializeField] private Image _typeFrame;

    public void InitializeDisplay(CardScriptableObject givenCard, CardUI cardUIRef)
    { 

        _manaCostDisplay.text = givenCard.EnergyCost.ToString();
        _cardNameDisplay.text = givenCard.CardName;
        _cardDescDisplay.text = $"" + givenCard.Description.ToString();

        _artWorkDisplay.sprite = cardUIRef.ArtWorkDisplay.sprite;
        _cardFrame.sprite = cardUIRef.CardFrame.sprite;
        _plateFrame.sprite = cardUIRef.PlateFrame.sprite;
        _rarityFrame.sprite = cardUIRef.RarityFrame.sprite;
        _typeFrame.sprite = cardUIRef.TypeFrame.sprite;

        InitType(givenCard.CardType);
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
        PlayerWrapper.Instance.PlayerController.ToggleCardCloseUpPanel(null, false, null);
    }



}

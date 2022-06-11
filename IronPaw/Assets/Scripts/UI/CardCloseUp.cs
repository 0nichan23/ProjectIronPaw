using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class CardCloseUp : MonoBehaviour
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
    [SerializeField] private GameObject _toolTipScroll;


    public void InitializeDisplay(CardScriptableObject givenCard, CardUI cardUIRef)
    { 

        _manaCostDisplay.text = givenCard.EnergyCost.ToString();
        _cardNameDisplay.text = givenCard.CardName;
        _cardDescDisplay.text = cardUIRef.CardDescDisplay.text;

        _artWorkDisplay.sprite = cardUIRef.ArtWorkDisplay.sprite;
        _cardFrame.sprite = cardUIRef.CardFrame.sprite;
        _plateFrame.sprite = cardUIRef.PlateFrame.sprite;
        _rarityFrame.sprite = cardUIRef.RarityFrame.sprite;
        _typeFrame.sprite = cardUIRef.TypeFrame.sprite;


        InitCardToolTips(givenCard);
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

    private void InitCardToolTips(CardScriptableObject givenCard)
    {
        for (int i = 0; i < _toolTipScroll.transform.childCount; i++)
        {
            _toolTipScroll.transform.GetChild(i).gameObject.SetActive(false);
        }
        foreach (var item in givenCard.Keywords)
        {
            _toolTipScroll.transform.GetChild(((int)item)).gameObject.SetActive(true);
        }
    }



}

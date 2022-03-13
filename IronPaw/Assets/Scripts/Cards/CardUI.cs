using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardUI : MonoBehaviour
{
    public CardSO CardSO;

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

    public void InitializeDisplay()
    {
        _artWorkDisplay.sprite = CardSO.Artwork;
        _manaCostDisplay.text = CardSO.ManaCost.ToString();
        _cardNameDisplay.text = CardSO.CardName;
        _cardDescDisplay.text = CardSO.Description;
        InitType(CardSO.CardType);
    }

    private void InitType(CardType type)
    {
        switch(type)
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
}

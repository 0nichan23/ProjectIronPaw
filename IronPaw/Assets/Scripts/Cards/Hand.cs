using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public List<CardScriptableObject> Cards = new List<CardScriptableObject>();

    [SerializeField] public DiscardPile DiscardPile;

    bool DiscardAtTurnEnd;
    [SerializeField] private int _drawAmount;

    public int DrawAmount { get => _drawAmount; set => _drawAmount = value; }

    public void AddCard(CardScriptableObject givenCard)
    {
        Cards.Add(givenCard);
    }

    public void RemoveCard(CardScriptableObject givenCard)
    {
        Cards.Remove(givenCard);
    }

    public void ClearCard(CardScriptableObject card)
    {
        Destroy(card.CardDisplay);
        RemoveCard(card);
        DiscardPile.AddCardToPile(card);
    }

    public void ClearHand()
    {
        while(Cards.Count > 0)
        {
            ClearCard(Cards[0]);
        }
    }
}

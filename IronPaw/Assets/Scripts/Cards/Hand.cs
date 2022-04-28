using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public List<CardSO> Cards = new List<CardSO>();

    [SerializeField] public DiscardPile DiscardPile;

    bool DiscardAtTurnEnd;
    [SerializeField] private int _drawAmount;

    public int DrawAmount { get => _drawAmount; set => _drawAmount = value; }

    public void AddCard(CardSO givenCard)
    {
        Cards.Add(givenCard);
    }

    public void RemoveCard(CardSO givenCard)
    {
        Cards.Remove(givenCard);
    }

    public void DiscardCard(CardSO card)
    {
        Destroy(card.CardDisplay);
        RemoveCard(card);
        DiscardPile.Cards.Push(card);
    }

    public void DiscardHand()
    {
        //foreach (var card in Cards)
        //{
        //    DiscardCard(card);
        //}

        while(Cards.Count > 0)
        {
            DiscardCard(Cards[0]);
        }
    }
    void ExileCard(CardSO card)
    {

    }
    void ReturnCardToDeck(CardSO card)
    {

    }
}

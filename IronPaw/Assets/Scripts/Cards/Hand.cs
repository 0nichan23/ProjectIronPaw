using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    public List<CardSO> Cards = new List<CardSO>();

    bool DiscardAtTurnEnd;
    int DrawAmount;

    public void AddCard(CardSO givenCard)
    {
        Cards.Add(givenCard);
    }

    public void RemoveCard(CardSO givenCard)
    {
        Cards.Remove(givenCard);
    }

    void DiscardCard(CardSO _card)
    {

    }
    void ExileCard(CardSO _card)
    {

    }
    void ReturnCardToDeck(CardSO _card)
    {

    }
}

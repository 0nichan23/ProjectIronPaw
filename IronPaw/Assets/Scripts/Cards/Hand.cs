using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    [SerializeField]
    private List<CardSO> _cards = new List<CardSO>();

    bool DiscardAtTurnEnd;
    int DrawAmount;

    public void AddCard(CardSO givenCard)
    {
        _cards.Add(givenCard);
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

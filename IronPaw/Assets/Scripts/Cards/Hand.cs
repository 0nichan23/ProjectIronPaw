using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<CardSO> _cards;

    bool DiscardAtTurnEnd;
    int DrawAmount;

    public List<CardSO> Cards { get => _cards; set => _cards = value; }

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private List<CardSo> _cards;

    bool DiscardAtTurnEnd;
    int DrawAmount;

    public List<CardSo> Cards { get => _cards; set => _cards = value; }

    void DiscardCard(CardSo _card)
    {

    }
    void ExileCard(CardSo _card)
    {

    }
    void ReturnCardToDeck(CardSo _card)
    {

    }
}

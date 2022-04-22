using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Controller : MonoBehaviour
{
    public List<Character> ControllerChracters;
    public DataTracker TurnTracker = new DataTracker();
    public DataTracker CombatTracker = new DataTracker();
    public DataTracker RunTracker = new DataTracker();


    public Action<CardSO> OnPlayCard;

    private void Start()
    {
        OnPlayCard += UpdateAllDataTrackers;
    }


    private void UpdateAllDataTrackers(CardSO card)
    {
        UpdateDataTracker(card, TurnTracker);
        UpdateDataTracker(card, CombatTracker);
        UpdateDataTracker(card, RunTracker);

        Debug.Log("Number of cards played this turn: " + TurnTracker.NumberOfCardsPlayed);
    }

    private void UpdateDataTracker(CardSO card, DataTracker dataTracker)
    {
        dataTracker.NumberOfCardsPlayed++;
        switch(card.CardType)
        {
            case CardType.Attack:
                dataTracker.NumberOfAttacksPlayed++;
                    break;

            case CardType.Guard:
                dataTracker.NumberOfGuardsPlayed++;
                break;

            case CardType.Utility:
                dataTracker.NumberOfUtilitiesPlayed++;
                break;
        }
    }
}

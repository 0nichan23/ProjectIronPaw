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

    public Action OnStartTurn;
    public Action OnEndTurn;

    public Action<CardScriptableObject> OnPlayCard;

    private void Start()
    {
        OnPlayCard += UpdateAllDataTrackers;
        OnEndTurn += CombatTracker.ResetData;
    }


    private void UpdateAllDataTrackers(CardScriptableObject card)
    {
        UpdateDataTracker(card, TurnTracker);
        UpdateDataTracker(card, CombatTracker);
        UpdateDataTracker(card, RunTracker);

        Debug.Log("Number of cards played this turn: " + TurnTracker.NumberOfCardsPlayed);
    }

    private void UpdateDataTracker(CardScriptableObject card, DataTracker dataTracker)
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

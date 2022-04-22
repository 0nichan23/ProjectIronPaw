using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Controller
{

    public Hand Hand;
    public Deck Deck;
    public DiscardPile DiscardPile;
    public ExiledPile ExiledPile;

    public Button UltimateButton;

    public float UltimateCharge;
    public float MaximumUltimateCharge = 10;
    public int MaxEnergy;
    public int CurrentEnergy;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            ControllerChracters.Add(transform.GetChild(i).GetComponentInChildren<Hero>());
        }

        TurnManager.Instance.OnStartPlayerTurn += BasicStartOfTurnTasks;
        TurnManager.Instance.OnEndPlayerTurn += BasicEndOfTurnTasks;

        ToggleUltButton(false);
        TurnOnUltButtonOnSufficientUltCharge();
    }

    private void BasicStartOfTurnTasks()
    {
        StartOfTurnDraw();
        StartOfTurnEnergyRegen();
    }



    private void StartOfTurnDraw()
    {
        for (int i = 0; i < Hand.DrawAmount; i++)
        {
            Deck.Draw();
        }
    }

    private void StartOfTurnEnergyRegen()
    {
        CurrentEnergy = MaxEnergy;
    }

    private void BasicEndOfTurnTasks()
    {
        Hand.DiscardHand();
    }

    public void GainUltimateCharge(int amountToGain)
    {
        if(UltimateCharge + amountToGain >= MaximumUltimateCharge)
        {
            UltimateCharge = MaximumUltimateCharge;
            ToggleUltButton(true);
        }
        else
        {
            UltimateCharge += amountToGain;
        }
    }

    public void ResetUltimateCharge()
    {
        UltimateCharge = 0;
        ToggleUltButton(false);
    }

    private void ToggleUltButton(bool state)
    {
        UltimateButton.gameObject.SetActive(state);
    }

    private void TurnOnUltButtonOnSufficientUltCharge()
    {
        if(UltimateCharge == MaximumUltimateCharge)
        {
            ToggleUltButton(true);
        }
    }


}

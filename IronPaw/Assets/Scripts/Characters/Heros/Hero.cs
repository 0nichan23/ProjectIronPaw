using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : Character
{
    [SerializeField] GameObject ElectricityEffect;

    public override void Subscribe()
    {
        Controller.OnStartTurn += InvokeStartTurn;
        Controller.OnEndTurn += InvokeEndTurn;
        OnRecieveTaunt += PartyManager.Instance.EnemiesRerollTargetsForNewTaunts;
        SubscribePassive();
    }
    public override void UnSubscribe()
    {
        Controller.OnStartTurn -= InvokeStartTurn;
        Controller.OnEndTurn -= InvokeEndTurn;
        UnSubscribePassive();
    }

    public abstract void SubscribePassive();
    public abstract void UnSubscribePassive();

    public void PerformUltimate()
    {
        PlayerWrapper.Instance.PlayerController.ResetUltimateCharge();
        ElectricityEffect.SetActive(true);
        Ultimate();
    }

    public abstract void Ultimate();

    protected override void DetermineController()
    {
        Controller = PlayerWrapper.Instance.PlayerController;
        Hand = ((PlayerController)Controller).Hand;
        Deck = ((PlayerController)Controller).Deck;
        DiscardPile = ((PlayerController)Controller).DiscardPile;
        ExiledPile = ((PlayerController)Controller).ExiledPile;
    }
}

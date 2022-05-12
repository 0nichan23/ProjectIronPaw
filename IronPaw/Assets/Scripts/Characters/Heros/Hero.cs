using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : Character
{
    private bool _selectable;

    public bool Selectable { get => _selectable; set => _selectable = value; }

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

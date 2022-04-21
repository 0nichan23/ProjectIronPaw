using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hero : Character
{
    private bool _selectable;

    public bool Selectable { get => _selectable; set => _selectable = value; }

    public override void Subscribe()
    {
        TurnManager.Instance.OnStartPlayerTurn += InvokeStartTurn;
        TurnManager.Instance.OnEndPlayerTurn += InvokeEndTurn;
        SubscribePassive();
    }
    public override void UnSubscribe()
    {
        TurnManager.Instance.OnStartPlayerTurn -= InvokeStartTurn;
        TurnManager.Instance.OnEndPlayerTurn -= InvokeEndTurn;
        UnSubscribePassive();
    }

    public abstract void SubscribePassive();
    public abstract void UnSubscribePassive();

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

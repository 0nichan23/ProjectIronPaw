using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : Character
{
    [SerializeField] GameObject ElectricityEffect;


    public override void Subscribe()
    {
        Controller.OnStartTurn += InvokeStartTurn;
        Controller.OnEndTurn += InvokeEndTurn;
        OnRecieveTaunt += PartyManager.Instance.EnemiesRerollTargetsForNewTaunts;

        _profile.SubscribePassive();
    }
    public override void UnSubscribe()
    {
        Controller.OnStartTurn -= InvokeStartTurn;
        Controller.OnEndTurn -= InvokeEndTurn;

        _profile.UnSubscribePassive();
    }



    public void PerformUltimate()
    {
        PlayerWrapper.Instance.PlayerController.ResetUltimateCharge();
        ElectricityEffect.SetActive(true);
        _profile.Ultimate();
    }

    

    protected override void DetermineController()
    {
        Controller = PlayerWrapper.Instance.PlayerController;
        Hand = ((PlayerController)Controller).Hand;
        Deck = ((PlayerController)Controller).Deck;
        DiscardPile = ((PlayerController)Controller).DiscardPile;
        ExiledPile = ((PlayerController)Controller).ExiledPile;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private int baseUltChargeGain = 1;
    //aquire target

    public List<Character> Targets = new List<Character>();

    public override void Subscribe()
    {
        Controller.OnStartTurn += InvokeStartTurn;
        Controller.OnEndTurn += InvokeEndTurn;
        OnDeath += ChargePlayerUltBar;

    }

    public override void UnSubscribe()
    {
        Controller.OnStartTurn -= InvokeStartTurn;
        Controller.OnEndTurn -= InvokeEndTurn;
    }

    protected override void DetermineController()
    {
        Controller = EnemyWrapper.Instance.EnemyController;
    }

    private void ChargePlayerUltBar()
    {
        int totalPartyIntelligence = 0;
        PlayerController playerController = PlayerWrapper.Instance.PlayerController;
        foreach (var hero in playerController.ControllerChracters)
        {
            if(hero.CurrentHP > 0)
            {
                totalPartyIntelligence += hero.Stats.Intelligence;
            }
        }

        playerController.GainUltimateCharge(baseUltChargeGain + totalPartyIntelligence);
    }

    public override void UpdateUi()
    {
        base.UpdateUi();
        if (RefSlot != null && Hand.Cards.Count > 0)
        {
            RefSlot.IntentionDisplayer.DisplayIntention(Targets, Hand.Cards[0], this);
        }
    }

}

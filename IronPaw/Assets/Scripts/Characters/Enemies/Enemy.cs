using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    private int baseUltChargeGain = 1;
    //aquire target
    public override void Subscribe()
    {
        TurnManager.Instance.OnStartEnemyTurn += InvokeStartTurn;
        TurnManager.Instance.OnEndEnemyTurn += InvokeEndTurn;
        OnDeath += ChargePlayerUltBar;

    }
    public override void UnSubscribe()
    {
        TurnManager.Instance.OnStartEnemyTurn -= InvokeStartTurn;
        TurnManager.Instance.OnEndEnemyTurn -= InvokeEndTurn;
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
}

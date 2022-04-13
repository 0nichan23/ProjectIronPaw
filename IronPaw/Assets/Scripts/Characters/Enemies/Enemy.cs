using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{  

    //aquire target
    public override void Subscribe()
    {
        TurnManager.Instance.OnStartEnemyTurn += InvokeStartTurn;
        TurnManager.Instance.OnEndEnemyTurn += InvokeEndTurn;

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
}

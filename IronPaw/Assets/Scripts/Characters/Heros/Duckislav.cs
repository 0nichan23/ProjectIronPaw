using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckislav : Hero
{
    [SerializeField] private int _numberOfCardsToProcc = 4;
    [SerializeField] private int _passiveDamage = 6;

    public void DuckislavPassive(CardSO card)
    {
        Debug.Log(Controller.TurnTracker.NumberOfCardsPlayed);
        if(Controller.TurnTracker.NumberOfCardsPlayed == _numberOfCardsToProcc)
        {
            List<Character> enemies = EnemyWrapper.Instance.EnemyController.ControllerChracters;
            Character randomEnemy = enemies[new System.Random().Next(0, enemies.Count)];
            Debug.Log(randomEnemy.CurrentHP);
            randomEnemy.TakeDmg(new Damage(_passiveDamage, this, false));
            Debug.Log(randomEnemy.CurrentHP);
        }
    }

    public override void SubscribePassive()
    {
        Controller.OnPlayCard += DuckislavPassive;
    }

    public override void UnSubscribePassive()
    {
        Controller.OnPlayCard -= DuckislavPassive;
    }

    public override void Ultimate()
    {
        MaxAp++;
        OnStartTurn += DuckislavBuff;
    }

    private void DuckislavBuff()
    {
        Deck.Draw();
    }
}

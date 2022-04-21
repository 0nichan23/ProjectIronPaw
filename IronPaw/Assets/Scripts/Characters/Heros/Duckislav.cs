using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckislav : Hero
{
    [SerializeField] private int _numberOfCardsToProcc;
    [SerializeField] private int _passiveDamage;

    public void Passive(CardSO card)
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
        Controller.OnPlayCard += Passive;
    }

    public override void UnSubscribePassive()
    {
        Controller.OnPlayCard -= Passive;
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

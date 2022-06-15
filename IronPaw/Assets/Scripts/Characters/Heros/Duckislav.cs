using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duckislav : Hero
{
    [SerializeField] private int _numberOfCardsToProccPassive = 4;
    [SerializeField] private int _passiveDamage = 6;


    

    public void DuckislavPassive(CardScriptableObject card)
    {
        if(Controller.TurnTracker.NumberOfCardsPlayed == _numberOfCardsToProccPassive)
        {
            List<Character> enemies = new List<Character>();
            foreach (var enemy in EnemyWrapper.Instance.EnemyController.ControllerChracters)
            {
                if(enemy.CurrentHP > 0)
                {
                    enemies.Add(enemy);
                }
            }
            Character randomEnemy = enemies[new System.Random().Next(0, enemies.Count)];
            randomEnemy.TakeDmg(new Damage(_passiveDamage, this, false));
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
        _animator.SetTrigger("Ult");
        MaxAp++;
        OnStartTurn += DuckislavBuff;
    }

    private void DuckislavBuff()
    {
        Deck.Draw();
    }
    
}

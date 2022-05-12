using System.Collections;
using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField]
    float timeBetweenTurns;

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            ControllerChracters.Add(transform.GetChild(i).GetComponentInChildren<Enemy>());
        }

    }

    public void PlayTurn()
    {
        StartCoroutine(TurnSpacing());
    }

    IEnumerator TurnSpacing()
    {
        foreach (Enemy enemy in ControllerChracters)
        {
            if (enemy.IsAlive)
            {
                if (enemy.Hand.Cards.Count > 0)
                {
                    PartyManager.Instance.EnemyPlayCard(enemy, enemy.Hand.Cards[0]);
                }
            }

            yield return new WaitForSeconds(timeBetweenTurns);
        }

        RevealIntentions();
        TurnManager.Instance.EndTurn();
    }

    public void RevealIntentions()
    {
        foreach (Enemy enemy in ControllerChracters)
        {
            if(enemy.CurrentHP > 0)
            {
                enemy.Deck.Draw();
                if(enemy.Hand.Cards.Count > 0)
                {
                    PartyManager.Instance.EnemyAcquireTargets(enemy, enemy.Hand.Cards[0]);
                    // shows the enemy's intent (symbol (+number if relevant) + Hero Portrait) 
                }
            }            
        }
    }

}

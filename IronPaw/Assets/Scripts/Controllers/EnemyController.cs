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
            if (enemy.CurrentHP > 0)
            {
                if (enemy.Hand.Cards.Count > 0)
                {
                    PartyManager.Instance.EnemyPlayCard(enemy, enemy.Hand.Cards[0]);
                }
            }

            yield return new WaitForSeconds(timeBetweenTurns);
        }

        RevealIntentions();
    }

    public void RevealIntentions()
    {
        //shows the player the next played card?
        foreach (Character enemy in ControllerChracters)
        {
            if(enemy.CurrentHP > 0)
            {
                enemy.Deck.Draw();
                if(enemy.Hand.Cards.Count > 0)
                {
                    PartyManager.Instance.EnemyAcquireTargets(enemy, enemy.Hand.Cards[0]);
                    ShowTargets(enemy.Hand.Cards[0].CardEffect);
                }
                
                // shows the enemy's intent (symbol (+number if relevant) + Hero Portrait) 

                
            }            
        }
    }

    private void ShowTargets(CardEffect cardEffect)
    {
        foreach (var target in cardEffect.Targets)
        {
            Debug.Log("Target of " + cardEffect.name + ": " + target.CharacterName);

        }
    }


}

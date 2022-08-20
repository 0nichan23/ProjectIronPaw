using System.Collections;
using UnityEngine;

public class EnemyController : Controller
{
    [SerializeField]
    float timeBetweenTurns;

    public bool EnemiesDoneCalculating = false;

    private bool _currentEnemyDonePlaying = false;

    public bool CurrentEnemyDonePlaying { get => _currentEnemyDonePlaying; set => _currentEnemyDonePlaying = value; }

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).gameObject.activeSelf)
            {
                ControllerChracters.Add(transform.GetChild(i).GetComponentInChildren<Enemy>());

            }
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
            CurrentEnemyDonePlaying = false;
            CardScriptableObject playedCard = null;

            if (enemy.IsAlive)
            {
                if (enemy.Hand.Cards.Count > 0)
                {
                    playedCard = enemy.Hand.Cards[0];
                    // if(targets still legal) => 
                    if(enemy.AreTargetsStillAlive()) // Skip current enemy turn if  no legal targets
                    {
                        CombatManager.Instance.EnemyPlayCard(enemy, playedCard);
                    }
                    else
                    {
                        CurrentEnemyDonePlaying = true;
                    }
                }
            }
            if (playedCard != null && playedCard.CardType == CardType.Attack)
            {
                yield return new WaitUntil(() => CurrentEnemyDonePlaying);
            }
        }
        StartCoroutine(RevealIntentions());
        //RevealIntentions();
        TurnManager.Instance.EndTurn();
    }

    /*public void RevealIntentions()
    {
        foreach (Enemy enemy in ControllerChracters)
        {
            if(enemy.CurrentHP > 0)
            {
                enemy.Deck.Draw();
                if(enemy.Hand.Cards.Count > 0)
                {
                    CombatManager.Instance.EnemyAcquireTargets(enemy, enemy.Hand.Cards[0]);
                    if (enemy.RefSlot.IntentionDisplayer != null)
                    {
                        enemy.RefSlot.IntentionDisplayer.DisplayIntention(enemy.Targets, enemy.Hand.Cards[0]);
                    }
                    // shows the enemy's intent (symbol (+number if relevant) + Hero Portrait) 
                }
            }            
        }
    }*/



    public IEnumerator RevealIntentions()
    {
        EnemiesDoneCalculating = false;
        foreach (Enemy enemy in ControllerChracters)
        {
            if (enemy.CurrentHP > 0)
            {
                enemy.Deck.Draw();
                if (enemy.Hand.Cards.Count > 0)
                {
                    enemy.Hand.Cards[0].CardEffect.InitializePlayEffect(enemy);
                    CombatManager.Instance.EnemyAcquireTargets(enemy, enemy.Hand.Cards[0]);
                    if (enemy.RefSlot.IntentionDisplayer != null)
                    {
                        enemy.RefSlot.IntentionDisplayer.DisplayIntention(enemy.Targets, enemy.Hand.Cards[0], enemy);
                    }
                    // shows the enemy's intent (symbol (+number if relevant) + Hero Portrait) 
                }

            }
            yield return new WaitForSeconds(0.3f);
        }
        EnemiesDoneCalculating = true;
    }

}

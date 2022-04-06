using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
    public List<Character> Enemies;
    [SerializeField]
    float timeBetweenTurns;

    private void Awake()
    {
        Enemies = new List<Character>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Enemies.Add(transform.GetChild(i).GetComponent<Enemy>());
        }

    }


    public void PlayTurn()
    {
        StartCoroutine(TurnSpacing());

    }

    IEnumerator TurnSpacing()
    {
        foreach (Enemy item in Enemies)
        {
            if (item.CurrentHP <= 0)
            {
                continue;
            }
            PartyManager.Instance.PlayCard(item, item.Hand.Cards[0]);
            yield return new WaitForSeconds(timeBetweenTurns);
        }
        RevealIntentions();
    }



    public void RevealIntentions()
    {
        //shows the player the next played card?
        foreach (Enemy item in Enemies)
        {
            item.Deck.Draw();
        }

        //show
    }


}

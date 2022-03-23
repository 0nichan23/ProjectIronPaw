using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Controller
{
    public List<Character> Enemies;

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
        foreach (Enemy item in Enemies)
        {
            item.Hand.Cards[0].PlayCard(item);
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

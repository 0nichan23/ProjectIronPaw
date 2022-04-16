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
        foreach (Enemy item in ControllerChracters)
        {
            if (item.CurrentHP <= 0)
            {
                continue;
            }

            if(item.Hand.Cards.Count > 0)
            {
                PartyManager.Instance.PlayCard(item, item.Hand.Cards[0]);
            }
            
            yield return new WaitForSeconds(timeBetweenTurns);
        }
        //RevealIntentions();
    }



    public void RevealIntentions()
    {
        //shows the player the next played card?
        foreach (Character item in ControllerChracters)
        {
            item.Deck.Draw();
        }

        //show
    }


}

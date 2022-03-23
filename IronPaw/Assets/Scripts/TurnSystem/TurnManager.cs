using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class TurnManager : Singleton<TurnManager>
{
    //player starts 
    //end turn buttong clicked
    //lock player inputs
    //loop over enemies and play 
    //turn goes back to player
    //unlock player imputs

    List<Enemy> _enemies = new List<Enemy>();
    public bool LockInputs;
    bool _endTurn;
    public GameObject EndTurnButton;
    bool firstTurn = true;
    private void Start()
    {
        foreach (Enemy enemy in PartyManager.Instance.BadGuys)
        {
            _enemies.Add(enemy);
        }
        StartCoroutine(TurnLoop());
    }



    IEnumerator TurnLoop()
    {
        while (true /*win condition*/ )
        {
            if (firstTurn)
            {
                Debug.Log("enemies set up");
                firstTurn = false;
                EnemyWrapper.Instance.EnemyController.RevealIntentions();
            }
            LockInputs = false;
            EndTurnButton.SetActive(true);
            yield return new WaitUntil(() => _endTurn);
            _endTurn = false;
            EndTurnButton.SetActive(false);
            LockInputs = true;
            enemyturn();
        }
    }
    


    public void EndTurn()
    {
        _endTurn = true;
    }

    public void enemyturn()
    {
        EnemyWrapper.Instance.EnemyController.PlayTurn();        
    }






}

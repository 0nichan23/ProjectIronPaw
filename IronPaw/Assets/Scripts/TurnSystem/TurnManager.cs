using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Action OnStartPlayerTurn;
    public Action OnEndPlayerTurn;
    public Action OnStartEnemyTurn;
    public Action OnEndEnemyTurn;


    private void Start()
    {
        foreach (Enemy enemy in PartyManager.Instance.Enemies)
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
                firstTurn = false;
                //EnemyWrapper.Instance.EnemyController.RevealIntentions();
            }
            //onstartplayer
            OnStartPlayerTurn?.Invoke();
            LockInputs = false;
            EndTurnButton.SetActive(true);
            yield return new WaitUntil(() => _endTurn);
            //onendPlayerturn
            OnEndPlayerTurn?.Invoke();
            //onstartenemy
            OnStartEnemyTurn?.Invoke();
            _endTurn = false;
            EndTurnButton.SetActive(false);
            LockInputs = true;
            enemyturn();
            //onendround
            OnEndEnemyTurn?.Invoke();
        }
    }

    public void EndTurn()
    {
        _endTurn = true;
    }

    public void enemyturn()
    {
        EnemyWrapper.Instance.EnemyController.PlayTurn();
        Debug.Log("very cool enemy yes");
    }
}

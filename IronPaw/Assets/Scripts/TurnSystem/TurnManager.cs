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
    List<Hero> _heros = new List<Hero>();
    public bool LockInputs;
    bool _endTurn;
    public GameObject EndTurnButton;
    bool firstTurn = true;

    private Controller _playerController;
    private Controller _enemyController;


    private void Start()
    {
        _playerController = PlayerWrapper.Instance.PlayerController;
        _enemyController = EnemyWrapper.Instance.EnemyController;

        foreach (Enemy enemy in PartyManager.Instance.Enemies)
        {
            _enemies.Add(enemy);
            _enemyController.OnEndTurn += enemy.UpdateUi;
        }
        foreach (Hero hero in PartyManager.Instance.Heroes)
        {
            _heros.Add(hero);
            _playerController.OnEndTurn += hero.UpdateUi;
        }
        _enemyController.OnEndTurn += PartyManager.Instance.ResetRerollForTaunt;
        _playerController.OnEndTurn += PartyManager.Instance.ResetRerollForTaunt;
        StartCoroutine(TurnLoop());
    }



    IEnumerator TurnLoop()
    {
        while (true /*win condition*/ )
        {
            if (firstTurn)
            {
                firstTurn = false;
                StartCoroutine(EnemyWrapper.Instance.EnemyController.RevealIntentions());
            }
            yield return new WaitUntil(() => EnemyWrapper.Instance.EnemyController.EnemiesDoneCalculating);
            // Player Turn
            _playerController.OnStartTurn?.Invoke();
            LockInputs = false;
            _endTurn = false;
            EndTurnButton.SetActive(true);
            yield return new WaitUntil(() => _endTurn);
            _playerController.OnEndTurn?.Invoke();

            // Enemy Turn
            EndTurnButton.SetActive(false);
            _enemyController.OnStartTurn?.Invoke();
            _endTurn = false;
            LockInputs = true;
            EnemyWrapper.Instance.EnemyController.PlayTurn();
            yield return new WaitUntil(() => _endTurn);
            _enemyController.OnEndTurn?.Invoke();
        }
    }

    public void EndTurn()
    {
        _endTurn = true;
    }
}

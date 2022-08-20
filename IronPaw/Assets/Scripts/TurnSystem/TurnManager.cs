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

    private List<Enemy> _enemies = new List<Enemy>();
    private List<Hero> _heroes = new List<Hero>();
    public bool LockInputs;
    bool _endTurn;
    public GameObject EndTurnButton;
    bool firstTurn = true;
    bool gameOnGoing = true;
    private Controller _playerController;
    private Controller _enemyController;
    [SerializeField]
    private GameOverUI _gameOverPanel;
    private Coroutine _runningTurnLoop;

    private void Start()
    {
        _playerController = PlayerWrapper.Instance.PlayerController;
        _enemyController = EnemyWrapper.Instance.EnemyController;

        foreach (Enemy enemy in CombatManager.Instance.Enemies)
        {
            _enemies.Add(enemy);
        }
        foreach (Hero hero in CombatManager.Instance.Heroes)
        {
            _heroes.Add(hero);
        }
        _enemyController.OnEndTurn += CombatManager.Instance.ResetRerollForTaunt;
        _playerController.OnEndTurn += CombatManager.Instance.ResetRerollForTaunt;
        _runningTurnLoop = StartCoroutine(TurnLoop());
    }



    IEnumerator TurnLoop()
    {
        yield return new WaitForEndOfFrame();
        while (gameOnGoing /*win condition*/ )
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

    public void LoseGame()
    {
        AudioManager.Instance.StopBg(AudioManager.Instance.BgMusic);
        StopTurnLoop();
        ToggleGameOverUI(true);
        AudioManager.Instance.PlayPlayer(AudioManager.Instance.LoseSound);
        _gameOverPanel.SetGameOverUI("DEFEAT", "Return To Base", false);
        //stop turn loop
        //turn ui window
        //set ui win/lose

    }
    public void WinGame()
    {
        AudioManager.Instance.StopBg(AudioManager.Instance.BgMusic);
        StopTurnLoop();
        ToggleGameOverUI(true);
        AudioManager.Instance.PlayPlayer(AudioManager.Instance.WinSound);
        _gameOverPanel.SetGameOverUI("GLORIOUS VICTORY", "Continue", true);
    }
    private void StopTurnLoop()
    {
        gameOnGoing = false;
        StopCoroutine(_runningTurnLoop);
    }
    private void ToggleGameOverUI(bool state)
    {
        _gameOverPanel.gameObject.SetActive(state);
    }
   
}

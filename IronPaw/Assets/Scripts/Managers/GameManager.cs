using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
        TargetScript.AliveEnemy = 3;
    }
}

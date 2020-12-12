using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Made by Joey Docter
//game over
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    //end game
    public void EndGame()
    {
        if(gameHasEnded == false)
        {
            gameHasEnded = true;
            Restart();
        }
    }

    //reset to scene 1
    void Restart()
    {
        SceneManager.LoadScene(0);

        SwitchScene.levelIndex = 0;
        PlayerPrefs.SetInt("LastLevel", SwitchScene.levelIndex);
        PlayerPrefs.Save();

        TargetScript.AliveEnemy = 50;
    }
}

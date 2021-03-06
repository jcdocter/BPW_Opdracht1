﻿using UnityEngine;
using UnityEngine.SceneManagement;

//made by Joey Docter
//switch and save scenes
public class SwitchScene : MonoBehaviour
{
    public static int levelIndex;
    private static bool loaded = false;

    void Start()
    {
        //start level on last entered scene
        if (!loaded)
        {
            loaded = true;
            levelIndex = PlayerPrefs.GetInt("LastLevel");
            SceneManager.LoadScene(levelIndex);
        }
    }

    void OnTriggerStay(Collider other)
    {
        //move to next level
        if (Input.GetKey("space") && other.tag == Tags.PLAYER_TAG && TargetScript.AliveEnemy == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                   levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
                   PlayerPrefs.SetInt("LastLevel", levelIndex);
                   PlayerPrefs.Save();
            
            // reset value
            TargetScript.AliveEnemy = 50;
            GenerateEnemies.enemyLeft = 50;
        }

        // end game
        if(levelIndex == 3)
        {
            FindObjectOfType<GameManager>().EndGame();
            Application.Quit();

            
        }
    }
}

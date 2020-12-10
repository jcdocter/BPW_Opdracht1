using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{
    public int levelIndex;
    private static bool loaded = false;

    void Start()
    {
        // activate later
      /*  if (!loaded)
        {
            loaded = true;
            levelIndex = PlayerPrefs.GetInt("LastLevel");
            SceneManager.LoadScene(levelIndex);
        }*/
    }

    void OnTriggerStay(Collider other)
    {

        if (TargetScript.AliveEnemy == 0 && Input.GetKey("space") && other.tag == Tags.PLAYER_TAG)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            // activate later
            /*       levelIndex = SceneManager.GetActiveScene().buildIndex + 1;
                   PlayerPrefs.SetInt("LastLevel", levelIndex);
                   PlayerPrefs.Save();
            */
            TargetScript.AliveEnemy = 50;
        }
    }
}

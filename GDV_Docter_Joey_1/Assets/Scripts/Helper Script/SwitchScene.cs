using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour
{

    void OnTriggerStay(Collider other)
    {
        if (TargetScript.AliveEnemy == 0 && Input.GetKey("space") && other.tag == Tags.PLAYER_TAG)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

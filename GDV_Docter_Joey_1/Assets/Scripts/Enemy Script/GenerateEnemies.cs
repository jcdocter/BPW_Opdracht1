using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemySpawn;
    private int xPos;
    private int zPos;
    public int enemyCount;
    public int SpawnTotal = 5;

    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while(enemyCount < SpawnTotal)
        {
            xPos = Random.Range(-47, 43);
            zPos = Random.Range(-45, 41);

            Instantiate(enemySpawn, new Vector3(xPos, 1, zPos), Quaternion.identity);
            yield return new WaitForSeconds(3f);
            enemyCount += 1;
        }
    }

}

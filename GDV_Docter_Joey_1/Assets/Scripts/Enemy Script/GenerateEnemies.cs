using System.Collections;
using UnityEngine;
using TMPro;

//made by Joey Docter
//spawn enemies
public class GenerateEnemies : MonoBehaviour
{
    public GameObject enemySpawn;
    private int xPos;
    private int zPos;
    public int enemyCount;

    public TextMeshProUGUI enemyCounter;
    public int SpawnTotal = 50;
    public static int enemyLeft = 50;
    
    //start Spawn
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    //text how much enemy's are left
    void Update()
    {
        enemyCounter.text = enemyLeft.ToString();
    }

    //spawn enemy in this range
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

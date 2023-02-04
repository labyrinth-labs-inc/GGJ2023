using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;
    
    [Space(5f)]
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<GameObject> enemies;

    GameObject currentEnemy;

    int indexEnemy = 0;

    private void Start() 
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
       // if(currentEnemy == null)
        //{
            yield return new WaitForSeconds(6f);
            currentEnemy = Instantiate(RandomEnemy(), RandomSpawnPoint().position, RandomSpawnPoint().rotation);
            Enemy enemyComp = currentEnemy.GetComponent<Enemy>();
            enemyComp.SetPlayer(player);
        //}
        yield return null;
        StartCoroutine(SpawnEnemy());
    }

    private GameObject RandomEnemy()
    {
        GameObject go = enemies[indexEnemy];
        indexEnemy += 1;
        if(indexEnemy >= enemies.Count)indexEnemy = 0;
        return go;
    } 

    private Transform RandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0,spawnPoints.Count)];
    }
}

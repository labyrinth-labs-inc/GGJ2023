using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;
    
    [Header("Enemies")]
    [SerializeField] List<GameObject> enemies;

    GameObject currentEnemy;

    int indexEnemy = 0;

    private void Start() 
    {
        if(enemies != null)
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        if(currentEnemy == null)
        {
            yield return new WaitForSeconds(3f);
            currentEnemy = Instantiate(RandomEnemy(), this.transform.position, this.transform.rotation);
        }
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
}

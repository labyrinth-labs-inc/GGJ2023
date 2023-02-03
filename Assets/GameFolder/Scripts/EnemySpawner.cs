using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("References")]
    [SerializeField] GameObject player;
    
    [Header("Enemies")]
    [SerializeField] GameObject radishEnemy;

    GameObject currentEnemy;

    private void Start() 
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        if(currentEnemy == null)
        {
            yield return new WaitForSeconds(3f);
            currentEnemy = Instantiate(radishEnemy, this.transform.position, this.transform.rotation);
        }
        yield return null;
        StartCoroutine(SpawnEnemy());
    }
}

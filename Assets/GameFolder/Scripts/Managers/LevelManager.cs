using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject enemiesSpawner; 

    public void StartLevel()
    {
        enemiesSpawner.SetActive(true);
    }
}

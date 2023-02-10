using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    public void StartGame()
    {
        levelManager.StartLevel(); 
    }
}

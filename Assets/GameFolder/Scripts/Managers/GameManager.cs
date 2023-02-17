using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] MenuManager menuManager;
    public void StartGame()
    {
        levelManager.StartLevel(); 
    }
}

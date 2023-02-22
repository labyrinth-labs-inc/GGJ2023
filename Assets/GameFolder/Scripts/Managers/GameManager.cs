using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] MenuManager menuManager;
    [SerializeField] AudioManager audioManager;
    void Start()
    {
        audioManager.PlayMenuMusic();
    }
    public void StartGame()
    {
        levelManager.StartLevel();
        audioManager.PlayGameplayMusic();
    }
}

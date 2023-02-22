using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartBttn : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshPro teste; 

    private void Update() {
        // teste.text = "foi reload";
    }
    
    void OnCollisionEnter(Collision other)
    {
        
    }
    void OnDestroy() 
    {
        StartGame(); 
    }

    void StartGame()
    {
        gameManager.StartGame();
    }
}

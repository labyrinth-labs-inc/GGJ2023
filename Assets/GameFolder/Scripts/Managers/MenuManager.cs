using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject creditsScreen;

    public void ShowCredits()
    {
        creditsScreen.SetActive(true);
    }
    public void HideCredits()
    {
        creditsScreen.SetActive(false);
    }
}

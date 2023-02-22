using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip menuMusic;
    [SerializeField] AudioClip gameplayMusic;
    [SerializeField]AudioSource audioSource;

    public void PlayMenuMusic()
    {
        audioSource.clip = menuMusic;
        audioSource.Play();
    }
    public void PlayGameplayMusic()
    {
        audioSource.clip = gameplayMusic;
        audioSource.Play();
    }
}

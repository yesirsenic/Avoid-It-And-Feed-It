using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource audioSource;

    public AudioClip buttonClick_Clip;
    public AudioClip gameover_Clip;
    public AudioClip feed_Clip;
    public AudioClip food_Crash_Stone_Clip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ButtonClickSFX()
    {
        audioSource.clip = buttonClick_Clip;
        audioSource.Play();
    }

    public void GameOverSFX()
    {
        audioSource.clip = gameover_Clip;
        audioSource.Play();
    }

    public void Feed_FoodSFX()
    {
        audioSource.clip = feed_Clip;
        audioSource.Play();
    }

    public void Food_Crash_StoneSFX()
    {
        audioSource.clip = food_Crash_Stone_Clip;
        audioSource.Play();
    }
    
}

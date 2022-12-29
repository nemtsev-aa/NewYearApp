using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip menuSound;

    public AudioClip gameSound1;
    public AudioClip gameSound2;

    public AudioClip viewSound;

    public AudioClip castEffect;

    private int appMode;

    
    public void SoundOn(int appMode)
    {
            switch (appMode)
            {
                case 0:
                    audioSource.clip = menuSound;
                    break;
                case 1:
                    audioSource.clip = gameSound1;
                    break;
                case 2:
                    audioSource.clip = viewSound;
                    break;
                case 3:
                    audioSource.clip = gameSound2;
                    break;
            }
            audioSource.Play();
    }
         
}


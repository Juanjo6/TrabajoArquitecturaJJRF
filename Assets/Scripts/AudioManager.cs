using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource[] soundEffects;

    private void Awake()
    {
        instance = this;
    }
    public void PlayMusic(int soundToPlay)
    {
        // Desactivamos el sonido si ya se estuviera reproduciendo
        soundEffects[soundToPlay].Stop();
        // Reproducimos el efecto de sonido que queremos
        soundEffects[soundToPlay].Play();
    }
    public void StopMusic(int soundToPlay)
    {
        // Desactivamos el sonido
        soundEffects[soundToPlay].Stop();
    }
}

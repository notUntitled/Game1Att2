using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoop : MonoBehaviour
{
    public AudioSource source;
    public AudioClip start;
    void Start()
    {
        source.PlayOneShot(start); //Plays the start
        source.PlayScheduled(AudioSettings.dspTime + start.length); // Plays the loop after the start
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip rainbow_1;
    public AudioClip rainbow_2;
    public AudioClip floating;
    public AudioClip happy_1;
    public AudioClip happy_2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        
    }
}

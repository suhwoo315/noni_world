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

    private AudioSource[] audioSource;
    private double nextEventTime;

    void Start()
    {
        audioSource = GetComponents<AudioSource>();
        ActivateSound1();
    }

    public void ActivateSound1()
    {
        Mute();
        nextEventTime = AudioSettings.dspTime + 30.857f;
        audioSource[0].clip = rainbow_1;
        audioSource[0].loop = false;
        audioSource[0].Play();
        StartCoroutine(ContinueSound1());
    }

    IEnumerator ContinueSound1()
    {
        yield return new WaitUntil(() => (AudioSettings.dspTime + 1.0f > nextEventTime));
        if (audioSource[0].clip == rainbow_1)
        {
            audioSource[1].clip = rainbow_2;
            audioSource[1].PlayScheduled(nextEventTime);
        }
    }

    public void ActivateSound2()
    {
        Mute();
        audioSource[0].clip = floating;
        audioSource[0].loop = true;
        audioSource[0].Play();
    }

    public void ActivateSound3()
    {
        Mute();
        nextEventTime = AudioSettings.dspTime + 16.218f;
        audioSource[0].clip = happy_1;
        audioSource[0].loop = false;
        audioSource[0].Play();
        StartCoroutine(ContinueSound3());
    }

    IEnumerator ContinueSound3()
    {
        yield return new WaitUntil(() => (AudioSettings.dspTime + 1.0f > nextEventTime));
        if (audioSource[0].clip == happy_1)
        {
            audioSource[1].clip = happy_2;
            audioSource[1].loop = true;
            audioSource[1].PlayScheduled(nextEventTime);
        }
    }

    public void Mute()
    {
        audioSource[0].Stop();
        audioSource[1].Stop();
    }
}

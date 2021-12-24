using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crunchip : ItemDialogue
{
    //private ParticleSystem particle;

    void Start()
    {
        //particle = GetComponent<ParticleSystem>();
    }

    public override string[] FirstDialogue()
    {
        //particle.Play();
        return firstDialogue;
    }

    public override string[] RandomDialogue()
    {
        //particle.Play();
        switch (Random.Range(1, 3))
        {
            case 1: return dialogue1;
            case 2: return dialogue2;
            case 3: return dialogue3;
            default: return dialogue3;
        }
    }

    public override void EndDialogue()
    {
        //particle.Stop();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cattodoggo : ItemDialogue
{
    public override string[] FirstDialogue()
    {
        animator.SetBool("isCollided", true);
        return firstDialogue;
    }

    public override string[] RandomDialogue()
    {
        switch (Random.Range(1, 3))
        {
            case 1: animator.SetBool("isCollided", true); return dialogue1;
            case 2: animator.SetBool("isCollided", true); return dialogue2;
            case 3: animator.SetBool("isBarking", true); return dialogue3;
            default: animator.SetBool("isBarking", true); return dialogue3;
        }
    }

    public override void EndDialogue()
    {
        animator.SetBool("isCollided", false);
        animator.SetBool("isBarking", false);
    }
}

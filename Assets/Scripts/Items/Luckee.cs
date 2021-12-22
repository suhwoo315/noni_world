using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luckee : ItemDialogue
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
            case 2: animator.SetBool("isThree", true); return dialogue2;
            case 3: animator.SetBool("isFour", true); return dialogue3;
            default: animator.SetBool("isCollided", true); return dialogue1;
        }
    }

    public override void EndDialogue()
    {
        animator.SetBool("isCollided", false);
        animator.SetBool("isThree", false);
        animator.SetBool("isFour", false);
    }
}

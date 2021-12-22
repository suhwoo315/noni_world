using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CDPlayer : ItemDialogue
{
    public override string[] FirstDialogue()
    {
        playerAnimator.SetBool("isDancing", true);
        animator.SetBool("isCollided", true);
        return firstDialogue;
    }

    public override string[] RandomDialogue()
    {
        playerAnimator.SetBool("isDancing", true);
        animator.SetBool("isCollided", true);
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
        playerAnimator.SetBool("isDancing", false);
        animator.SetBool("isCollided", false);
    }
}

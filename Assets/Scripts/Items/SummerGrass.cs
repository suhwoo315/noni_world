using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerGrass : ItemDialogue
{
    private Vector3 previousPosition;

    public override string[] FirstDialogue()
    {
        previousPosition = player.transform.position;
        player.transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
        player.transform.position = transform.position;
        playerAnimator.SetBool("isSittingHappy", true);
        animator.SetBool("isCollided", true);
        return firstDialogue;
    }

    public override string[] RandomDialogue()
    {
        player.transform.position = transform.position;
        playerAnimator.SetBool("isSittingHappy", true);
        switch (Random.Range(1, 3))
        {
            case 1: animator.SetBool("isCollided", true); return dialogue1;
            case 2: animator.SetBool("isBug", true); return dialogue2;
            case 3: animator.SetBool("isBug", true); return dialogue3;
            default: animator.SetBool("isCollided", true); return dialogue3;
        }
    }

    public override void EndDialogue()
    {
        player.transform.position = previousPosition;
        player.transform.localScale = Vector3.one;
        playerAnimator.SetBool("isSittingHappy", false);
        animator.SetBool("isCollided", false);
        animator.SetBool("isBug", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : ItemDialogue
{
    public override string[] FirstDialogue()
    {
        animator.SetBool("isCollided", true);
        StartCoroutine(StartWatching());
        return firstDialogue;
    }

    IEnumerator StartWatching()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().enabled = false;
        playerAnimator.SetBool("isSky", true);
    }

    public override string[] RandomDialogue()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                GetComponent<SpriteRenderer>().enabled = false;
                playerAnimator.SetBool("isSky", true);
                return dialogue1;
            case 2:
                GetComponent<SpriteRenderer>().enabled = false;
                playerAnimator.SetBool("isSky", true);
                return dialogue2;
            case 3: animator.SetBool("isCollided", true); return dialogue3;
            default: animator.SetBool("isCollided", true); return dialogue3;
        }
    }

    public override void EndDialogue()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        playerAnimator.SetBool("isSky", false);
        animator.SetBool("isCollided", false);
    }
}

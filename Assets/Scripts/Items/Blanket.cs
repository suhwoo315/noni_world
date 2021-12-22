using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blanket : ItemDialogue
{
    public override string[] FirstDialogue()
    {
        StartCoroutine(StartSleeping());
        return firstDialogue;
    }

    IEnumerator StartSleeping()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().enabled = false;
        playerAnimator.SetBool("isSleeping", true);
    }

    public override string[] RandomDialogue()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                GetComponent<SpriteRenderer>().enabled = false;
                playerAnimator.SetBool("isSleeping", true);
                return dialogue1;
            case 2:
                GetComponent<SpriteRenderer>().enabled = false;
                playerAnimator.SetBool("isSleeping", true);
                return dialogue2;
            case 3: return dialogue3;
            default: return dialogue3;
        }
    }

    public override void EndDialogue()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        playerAnimator.SetBool("isSleeping", false);
    }
}

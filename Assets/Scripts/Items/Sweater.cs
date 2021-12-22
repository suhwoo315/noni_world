using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sweater : ItemDialogue
{
    public override string[] FirstDialogue()
    {
        StartCoroutine(StartWearing());
        return firstDialogue;
    }

    IEnumerator StartWearing()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<SpriteRenderer>().enabled = false;
        playerAnimator.SetBool("isSweater", true);
    }

    public override string[] RandomDialogue()
    {
        switch (Random.Range(1, 3))
        {
            case 1:
                GetComponent<SpriteRenderer>().enabled = false;
                playerAnimator.SetBool("isSweater", true);
                return dialogue1;
            case 2:
                GetComponent<SpriteRenderer>().enabled = false;
                playerAnimator.SetBool("isSweater", true);
                return dialogue2;
            case 3: return dialogue3;
            default: return dialogue3;
        }
    }

    public override void EndDialogue()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        playerAnimator.SetBool("isSweater", false);
    }
}

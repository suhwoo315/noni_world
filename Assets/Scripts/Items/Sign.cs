using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : ItemDialogue
{
    public override void ItemNextDialogue()
    {
        if (line >= dialogue.Length)
        {
            canvas.SetActive(false);
            player.GetComponent<PlayerMovement>().Rise();
        }
        else dialogueText.text = dialogue[line++];
    }

    public override string[] FirstDialogue()
    {
        return firstDialogue;
    }

    public override string[] RandomDialogue()
    {
        return firstDialogue;
    }
}

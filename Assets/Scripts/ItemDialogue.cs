using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDialogue : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text dialogueText;
    [SerializeField] private DialogueInfo dialogueInfo;
    [SerializeField] private Animator playerAnimator;

    public bool newItem = true;

    private string[] dialogue;
    private int line;

    public void ShowDialogue()
    {
        line = 0;
        if (newItem) dialogue = dialogueInfo.dialogue0;
        else
        {
            switch (Random.Range(1, 7))
            {
                case 1: dialogue = dialogueInfo.dialogue1; break;
                case 2: dialogue = dialogueInfo.dialogue2; break;
                case 3: dialogue = dialogueInfo.dialogue3; break;
                case 4: dialogue = dialogueInfo.dialogue4; break;
                case 5: dialogue = dialogueInfo.dialogue5; break;
                case 6:
                default: dialogue = dialogueInfo.dialogue6; break;
            }
        }
        dialogueText.text = dialogue[line++];
        canvas.SetActive(true);
    }

    public void ItemNextDialogue()
    {
        if (line >= dialogue.Length)
        {
            //playerAnimator.SetBool();
            newItem = false;
            canvas.SetActive(false);
            gameManager.ActivateMove();
            if (!gameManager.CheckGameState()) StartCoroutine(WaitForActivateCollision());
        }
        else dialogueText.text = dialogue[line++];
    }

    IEnumerator WaitForActivateCollision()
    {
        yield return new WaitForSeconds(1.5f);
        gameManager.ActivateCollision();
    }

    public void SignNextDialogue()
    {
        if (line >= dialogue.Length)
        {
            canvas.SetActive(false);
            gameManager.ActivateRise();
        }
        else dialogueText.text = dialogue[line++];
    }
}

// write code for when level is higher than number of dialogues
// maybe use random dialogue..?
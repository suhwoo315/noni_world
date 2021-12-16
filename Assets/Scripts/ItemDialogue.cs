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

    private string[] dialogue;
    private int level = 0;
    private int line;

    public void ShowDialogue()
    {
        line = 0;
        switch (level)
        {
            case 0: dialogue = dialogueInfo.dialogue0; break;
            case 1: dialogue = dialogueInfo.dialogue1; break;
            case 2: dialogue = dialogueInfo.dialogue2; break;
            case 3: dialogue = dialogueInfo.dialogue3; break;
            case 4:
            default: dialogue = dialogueInfo.dialogue4; break;
        }
        dialogueText.text = dialogue[line++];
        canvas.SetActive(true);
    }

    public void ItemNextDialogue()
    {
        if (line >= dialogue.Length)
        {
            level++;
            canvas.SetActive(false);
            gameManager.ActivateMove();
            gameManager.CheckGameState();
        }
        else dialogueText.text = dialogue[line++];
    }
}

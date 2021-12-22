using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDialogue : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Text dialogueText;
    [SerializeField] private DialogueInfo dialogueInfo;

    private string[] dialogue;
    private int stage;
    private int line;
    private bool roundCleared;
    private Animator animator;

    void Start()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void ShowDialogue(bool roundCleared)
    {
        this.roundCleared = roundCleared;
        line = 0;
        stage = gameManager.stage;
        if (roundCleared)
        {
            animator.SetBool("isHappy", true);
            dialogue = dialogueInfo.dialogue6;
        }
        else
        {
            animator.SetBool("isTalking", true);
            switch (stage)
            {
                case 0: dialogue = dialogueInfo.dialogue0; break;
                case 1: dialogue = dialogueInfo.dialogue1; break;
                case 2: dialogue = dialogueInfo.dialogue2; break;
                case 3: dialogue = dialogueInfo.dialogue3; break;
                case 4: dialogue = dialogueInfo.dialogue4; break;
                case 5: dialogue = dialogueInfo.dialogue5; break;
                default: Debug.Log("invalid dialogue number"); break;
            }
        }
        dialogueText.text = dialogue[line++];
        canvas.SetActive(true);
    }

    public void PlayerNextDialogue()
    {
        if (line >= dialogue.Length)
        {
            canvas.SetActive(false);
            GetComponent<PlayerTouch>().touchNumber = 0;
            animator.SetBool("isTalking", false);
            animator.SetBool("isHappy", false);
            if (roundCleared)
            {
                gameManager.ActivateRise();
                gameManager.DeactivateCollider();
            }
            else if (stage == 0)
            {
                gameManager.IncreaseStage();
                gameManager.ActivateTouch();
            }
            else if ((0 < stage && stage < 4) || stage == 5)
            {
                gameManager.SetTargetHP();
                gameManager.ActivateFall();
            }
            else if (stage == 4)
            {
                gameManager.IncreaseStage();
                gameManager.ShowCredit();
            }
        }
        else dialogueText.text = dialogue[line++];
    }
}

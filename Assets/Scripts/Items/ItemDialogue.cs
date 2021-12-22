using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDialogue : MonoBehaviour
{
    [Header("Dialogue")]
    [SerializeField] protected string[] firstDialogue;
    [SerializeField] protected string[] dialogue1;
    [SerializeField] protected string[] dialogue2;
    [SerializeField] protected string[] dialogue3;

    [SerializeField] protected GameObject player;
    [SerializeField] protected GameManager gameManager;
    [SerializeField] protected GameObject canvas;
    [SerializeField] protected Text dialogueText;

    [SerializeField] private SoundManager soundManager;

    public bool newItem = true;
    protected Animator animator;
    protected Animator playerAnimator;
    protected string[] dialogue;
    protected int line;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimator = player.transform.GetChild(0).GetComponent<Animator>();
    }

    public void ShowDialogue()
    {
        line = 0;
        if (newItem) dialogue = FirstDialogue();
        else dialogue = RandomDialogue();
        dialogueText.text = dialogue[line++];
        canvas.SetActive(true);
    }

    public virtual void ItemNextDialogue()
    {
        if (line >= dialogue.Length)
        {
            soundManager.ActivateSound2();
            EndDialogue();
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

    public virtual string[] FirstDialogue()
    {
        return null;
    }

    public virtual string[] RandomDialogue()
    {
        return null;
    }

    public virtual void EndDialogue()
    {

    }
}
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

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameObject player;
    [SerializeField] private Text dialogueText;

    public bool newItem = true;
    protected Animator animator;
    protected Animator playerAnimator;
    private string[] dialogue;
    private int line;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerAnimator = player.GetComponent<Animator>();
    }

    public void ShowDialogue()
    {
        line = 0;
        if (newItem) dialogue = FirstDialogue();
        else dialogue = RandomDialogue();
        dialogueText.text = dialogue[line++];
        canvas.SetActive(true);
    }

    public void ItemNextDialogue()
    {
        if (line >= dialogue.Length)
        {
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

    public void SignNextDialogue()
    {
        if (line >= dialogue.Length)
        {
            canvas.SetActive(false);
            gameManager.ActivateRise();
        }
        else dialogueText.text = dialogue[line++];
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
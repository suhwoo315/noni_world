using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    [SerializeField] private string[] firstDialogue;
    [SerializeField] private string[] dialogue1;
    [SerializeField] private string[] dialogue2;
    [SerializeField] private string[] dialogue3;
    [SerializeField] private Animator playerAnimator;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public string[] FirstDialogue()
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

    public string[] RandomDialogue()
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

    public void EndDialogue()
    {
        GetComponent<SpriteRenderer>().enabled = true;
        playerAnimator.SetBool("isSky", false);
        animator.SetBool("isCollided", false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowRain : MonoBehaviour
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
        playerAnimator.SetBool("isSittingHappy", true);
        animator.SetBool("isCollided", true);
        return firstDialogue;
    }

    public string[] RandomDialogue()
    {
        playerAnimator.SetBool("isSittingHappy", true);
        animator.SetBool("isCollided", true);
        switch (Random.Range(1, 3))
        {
            case 1: return dialogue1;
            case 2: return dialogue2;
            case 3: return dialogue3;
            default: return dialogue3;
        }
    }

    public void EndDialogue()
    {
        playerAnimator.SetBool("isSittingHappy", false);
        animator.SetBool("isCollided", false);
    }
}

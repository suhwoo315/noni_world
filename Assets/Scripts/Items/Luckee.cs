using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luckee : MonoBehaviour
{
    [SerializeField] private string[] firstDialogue;
    [SerializeField] private string[] dialogue1;
    [SerializeField] private string[] dialogue2;
    [SerializeField] private string[] dialogue3;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public string[] FirstDialogue()
    {
        animator.SetBool("isCollided", true);
        return firstDialogue;
    }

    public string[] RandomDialogue()
    {
        switch (Random.Range(1, 3))
        {
            case 1: animator.SetBool("isCollided", true); return dialogue1;
            case 2: animator.SetBool("isThree", true); return dialogue2;
            case 3: animator.SetBool("isFour", true); return dialogue3;
            default: animator.SetBool("isCollided", true); return dialogue1;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isCollided", false);
        animator.SetBool("isThree", true);
        animator.SetBool("isFour", true);
    }
}

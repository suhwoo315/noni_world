using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummerGrass : MonoBehaviour
{
    [SerializeField] private string[] firstDialogue;
    [SerializeField] private string[] dialogue1;
    [SerializeField] private string[] dialogue2;
    [SerializeField] private string[] dialogue3;
    [SerializeField] private GameObject player;
    [SerializeField] private Animator playerAnimator;

    private Animator animator;
    private Vector3 previousPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public string[] FirstDialogue()
    {
        previousPosition = player.transform.position;
        player.transform.position = transform.position;
        playerAnimator.SetBool("isSittingHappy", true);
        animator.SetBool("isCollided", true);
        return firstDialogue;
    }

    public string[] RandomDialogue()
    {
        player.transform.position = transform.position;
        playerAnimator.SetBool("isSittingHappy", true);
        switch (Random.Range(1, 3))
        {
            case 1: animator.SetBool("isCollided", true); return dialogue1;
            case 2: animator.SetBool("isBug", true); return dialogue2;
            case 3: animator.SetBool("isBug", true); return dialogue3;
            default: animator.SetBool("isCollided", true); return dialogue3;
        }
    }

    public void EndDialogue()
    {
        player.transform.position = previousPosition;
        playerAnimator.SetBool("isSittingHappy", false);
        animator.SetBool("isCollided", false);
        animator.SetBool("isBug", false);
    }
}

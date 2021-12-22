using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameManager gameManager;

    public bool touchMode = true;
    public int touchNumber = 0;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (touchMode)
        {
            if (gameManager.stage == 4)
            {
                touchMode = false;
                StartCoroutine(ShowEnding());
            }
            if (touchNumber > 4)
            {
                touchMode = false;
                GetComponent<PlayerDialogue>().ShowDialogue(false);
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Stationary || touch.phase == TouchPhase.Moved) animator.SetBool("isBending", true);
                if (touch.phase == TouchPhase.Ended)
                {
                    animator.SetBool("isBending", false);
                    touchNumber++;
                }
            }
        }
    }

    IEnumerator ShowEnding()
    {
        yield return new WaitForSeconds(2.0f);
        GetComponent<PlayerDialogue>().ShowDialogue(false);
    }
}
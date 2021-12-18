using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private GameManager gameManager;

    public bool touchMode = true;
    public int touchNumber = 0;

    void Update()
    {
        if (touchMode)
        {
            if (gameManager.stage == 4)
            {
                touchMode = false;
                StartCoroutine(ShowEnding());
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                if(touch.phase == TouchPhase.Ended) touchNumber++;
                if (touchNumber > 4)
                {
                    touchMode = false;
                    GetComponent<PlayerDialogue>().ShowDialogue(false);
                }
                // else => play animation
            }
        }
    }

    IEnumerator ShowEnding()
    {
        yield return new WaitForSeconds(2.0f);
        GetComponent<PlayerDialogue>().ShowDialogue(false);
    }
}
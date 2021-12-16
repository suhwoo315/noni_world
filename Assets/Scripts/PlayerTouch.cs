using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTouch : MonoBehaviour
{
    [SerializeField] private GameObject canvas;

    public bool touchMode = true;
    public int touchNumber = 0;

    void Update()
    {
        if (touchMode)
        {
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
}
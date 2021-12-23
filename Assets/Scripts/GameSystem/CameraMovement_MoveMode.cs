using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement_MoveMode : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private float leftLimit;
    private float rightLimit;
    private float downLimit;
    private float upLimit;

    private Vector2 screenPlayerPosition;
    private Vector3 previousPlayerPosition;
    private Vector3 direction;

    void Start()
    {
        leftLimit = Screen.width * 0.5f * 0.6f;
        rightLimit = Screen.width - leftLimit;
        downLimit = Screen.height * 0.5f * 0.6f;
        upLimit = Screen.height - downLimit;

        previousPlayerPosition = player.transform.position;
    }

    void Update()
    {
        screenPlayerPosition = Camera.main.WorldToScreenPoint(player.transform.position);
        
        if (screenPlayerPosition.x < leftLimit || screenPlayerPosition.x > rightLimit ||
            screenPlayerPosition.y < downLimit || screenPlayerPosition.y > upLimit)
        {
            direction = player.transform.position - previousPlayerPosition;
            transform.position += direction;
        }

        previousPlayerPosition = player.transform.position;
    }
}

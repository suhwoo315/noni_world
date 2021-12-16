using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private Vector2 playerPosition;
    private float leftLimit;
    private float rightLimit;
    private float downLimit;
    private float upLimit;

    private Rigidbody2D cameraRigidbody;
    private float horizontal;
    private float vertical;
    private float speed = 3.0f;

    void Start()
    {
        leftLimit = Screen.width * 0.5f * 0.6f;
        rightLimit = Screen.width - leftLimit;
        downLimit = Screen.height * 0.5f * 0.6f;
        upLimit = Screen.height - downLimit;
        cameraRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);

        /*
        playerPosition = Camera.main.WorldToScreenPoint(player.transform.position);
        
        if (playerPosition.x < leftLimit || playerPosition.x > rightLimit ||
            playerPosition.y < downLimit || playerPosition.y > upLimit)
        {
            horizontal = Input.acceleration.x;
            vertical = Input.acceleration.y;
            cameraRigidbody.velocity = new Vector2(horizontal * speed, vertical * speed);

            Vector3 targetPos = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
            transform.position = targetPos;
        }
        else
        {
            //cameraRigidbody.velocity = new Vector2(0, 0);
        }*/
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject abyss;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SoundManager soundManager;

    public bool moveMode = false;
    public bool fallMode = false;
    public bool riseMode = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private float horizontal;
    private float vertical;
    private float speed = 3.0f;

    private float leftLimit;
    private float rightLimit;
    private float downLimit;
    private float upLimit;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        rightLimit = abyss.GetComponent<SpriteRenderer>().bounds.extents.x;
        leftLimit = -rightLimit;
        downLimit = abyss.transform.position.y - abyss.GetComponent<SpriteRenderer>().bounds.extents.y;
        upLimit = abyss.transform.position.y + abyss.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    void Update()
    {
        if (moveMode)
        {
            horizontal = Input.acceleration.x;
            vertical = Input.acceleration.y;
            playerRigidbody.velocity = new Vector2(horizontal * speed, vertical * speed);

            if (transform.position.x < leftLimit) transform.position = new Vector2(rightLimit, transform.position.y);
            else if (transform.position.x > rightLimit) transform.position = new Vector2(leftLimit, transform.position.y);
            if (transform.position.y < downLimit) transform.position = new Vector2(transform.position.x, upLimit);
            else if (transform.position.y > upLimit) transform.position = new Vector2(transform.position.x, downLimit);
        }

        if (fallMode)
        {
            StartCoroutine(StartRotation());
            playerRigidbody.gravityScale = 0.2f;
            if (transform.position.y < -5) playerRigidbody.gravityScale = 1.0f;
            if (transform.position.y < -20) playerRigidbody.gravityScale = 0.2f;
            if (transform.position.y <= -30)
            {
                animator.SetBool("isFalling", false);
                animator.SetBool("isGalaxy", true);
                playerRigidbody.gravityScale = 0f;
                playerRigidbody.velocity = new Vector2(0, 0);
                fallMode = false;
                moveMode = true;
                gameManager.ActivateCollider();
                gameManager.ActivateCollision();
                gameManager.ShowGalaxies();
                gameManager.RevealItems();
                if (gameManager.stage != 1 || gameManager.round != 1) soundManager.ActivateSound2();
            }
        }

        if (riseMode)
        {
            moveMode = false;
            StartCoroutine(StartRotation());
            playerRigidbody.gravityScale = -0.2f;
            if (transform.position.y > -20) playerRigidbody.gravityScale = -1.0f;
            if (transform.position.y > -5) playerRigidbody.gravityScale = -0.2f;
            if (transform.position.y >= 0)
            {
                animator.SetBool("isFalling", false);
                animator.SetBool("isGalaxy", false);
                playerRigidbody.gravityScale = 0f;
                playerRigidbody.velocity = new Vector2(0, 0);
                riseMode = false;
                gameManager.ActivateTouch();
                soundManager.ActivateSound1();
            }
        }
    }

    IEnumerator StartRotation()
    {
        soundManager.Mute();
        animator.SetBool("isFalling", true);
        yield return new WaitForSeconds(1.0f);
    }
}

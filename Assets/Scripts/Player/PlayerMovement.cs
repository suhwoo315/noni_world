using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject rainbow;
    [SerializeField] private GameObject abyss;
    [SerializeField] private GameObject boundary;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private Camera mainCamera;

    public bool moveMode = false;

    private Rigidbody2D playerRigidbody;
    private Animator animator;
    private Animator rainbowAnimator;
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
        rainbowAnimator = rainbow.GetComponent<Animator>();
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
    }

    public void Fall()
    {
        playerRigidbody.freezeRotation = false;
        soundManager.Mute();
        animator.SetBool("isFalling", true);
        rainbowAnimator.SetBool("isFadeout", true);
        playerRigidbody.gravityScale = 0.2f;
        StartCoroutine(ContinueFall());
    }

    IEnumerator ContinueFall()
    {
        yield return new WaitUntil(() => (transform.position.y < -5));
        playerRigidbody.gravityScale = 1.0f;

        yield return new WaitUntil(() => (transform.position.y < -40));
        playerRigidbody.gravityScale = 0.2f;

        yield return new WaitUntil(() => (transform.position.y <= -50));
        mainCamera.GetComponent<CameraMovement_TouchMode>().enabled = false;
        rainbowAnimator.SetBool("isFadeout", false);
        animator.SetBool("isFalling", false);
        animator.SetBool("isGalaxy", true);
        playerRigidbody.gravityScale = 0f;
        playerRigidbody.velocity = new Vector2(0, 0);
        gameManager.ActivateCollider();
        gameManager.ActivateCollision();
        gameManager.ShowGalaxies();
        gameManager.RevealItems();
        if (gameManager.stage != 1 || gameManager.round != 1)
        {
            mainCamera.GetComponent<CameraMovement_MoveMode>().enabled = true;
            moveMode = true;
            soundManager.ActivateSound2();
        }
        else
        {
            float targetX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, 0, 0)).x;
            float targetY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height * 0.5f, 0)).y;
            boundary.transform.position = new Vector3(targetX, targetY, 0);
            boundary.SetActive(true);
            moveMode = true;
        }
    }

    public void Rise()
    {
        StartCoroutine(ContinueRise());
    }

    IEnumerator ContinueRise()
    {
        yield return new WaitUntil(() => mainCamera.GetComponent<CameraMovement_TouchMode>().enabled);
        moveMode = false;
        soundManager.Mute();
        animator.SetBool("isFalling", true);
        playerRigidbody.gravityScale = -0.2f;

        yield return new WaitUntil(() => (transform.position.y > -40));
        playerRigidbody.gravityScale = -1.0f;

        yield return new WaitUntil(() => (transform.position.y > -20));
        rainbowAnimator.SetBool("isFadein", true);

        yield return new WaitUntil(() => (transform.position.y > -5));
        playerRigidbody.gravityScale = -0.2f;

        yield return new WaitUntil(() => (transform.position.y >= 0));
        rainbowAnimator.SetBool("isFadein", false);
        animator.SetBool("isFalling", false);
        animator.SetBool("isGalaxy", false);
        animator.SetBool("isOkay", false);
        playerRigidbody.gravityScale = 0f;
        playerRigidbody.velocity = new Vector2(0, 0);
        transform.rotation = Quaternion.identity;
        playerRigidbody.freezeRotation = true;
        gameManager.ActivateTouch();
        soundManager.ActivateSound1();
    }
}

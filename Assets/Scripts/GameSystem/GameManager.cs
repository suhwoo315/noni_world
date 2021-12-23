using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject boundary;
    [SerializeField] private GameObject[] items;
    [SerializeField] private GameObject[] galaxies;
    [SerializeField] private Camera mainCamera;

    public int stage = 0;
    public int round = 1;public string[] collectedItems;

    private int targetHP;
    private int currentHP = 0;
    private int itemsLeft = 17; // except finish sign
    private Animator playerAnimator;
    
    void Start()
    {
        playerAnimator = player.transform.GetChild(0).GetComponent<Animator>();
        collectedItems = new string[17];
    }

    public void ActivateTouch()
    {
        player.GetComponent<PlayerTouch>().touchMode = true;
    }

    public void ActivateMove()
    {
        player.GetComponent<PlayerMovement>().moveMode = true;
    }

    public void ActivateCollision()
    {
        player.GetComponent<PlayerCollision>().collideMode = true;
    }

    public void ActivateCollider()
    {
        player.GetComponent<CircleCollider2D>().enabled = true;
    }
    
    public void DeactivateMove()
    {
        player.GetComponent<PlayerMovement>().moveMode = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
    }

    public void DeactivateCollision()
    {
        player.GetComponent<PlayerCollision>().collideMode = false;
    }

    public void DeactivateCollider()
    {
        player.GetComponent<CircleCollider2D>().enabled = false;
    }

    public void IncreaseStage()
    {
        stage++;
    }

    public void IncreaseRound()
    {
        round++;
    }

    public void SetTargetHP()
    {
        if (stage == 1)
        {
            switch (round)
            {
                case 1: targetHP = 2; break;
                case 2: targetHP = 1; break;
                case 3: targetHP = 2; break;
            }
        }
        else if (stage == 2)
        {
            switch (round)
            {
                case 1: targetHP = 3; break;
                case 2: targetHP = 2; break;
            }
        }
        else if (stage == 3)
        {
            targetHP = Random.Range(2, 5);
            if (itemsLeft < targetHP) targetHP = itemsLeft;
        }
        else
        {
            targetHP = 1000;
        }
    }

    public void IncreaseCurrentHP(string name)
    {
        if (stage == 5) return;
        itemsLeft--;
        currentHP++;
        for(int i=0; i<collectedItems.Length; i++)
        {
            if (collectedItems[i] == null) collectedItems[i] = name;
        }
    }

    public bool CheckGameState()
    {
        bool roundCleared = false;
        if (currentHP >= targetHP / 2) playerAnimator.SetBool("isOkay", true);
        if (currentHP >= targetHP)
        {
            roundCleared = true;
            currentHP = 0;
            DeactivateCollision();
            if (stage == 1)
            {
                switch (round)
                {
                    case 1:
                    case 2: round++; break;
                    case 3: stage = 2; round = 1; break;
                }
            }
            else if (stage == 2)
            {
                switch (round)
                {
                    case 1: round++; break;
                    case 2: stage = 3; round = 1; break;
                }
            }
            else if (stage == 3)
            {
                if (itemsLeft == 0) stage = 4;
                else round++;
            }
            StartCoroutine(WaitAndShowDialogue());
        }
        return roundCleared;
    }

    IEnumerator WaitAndShowDialogue()
    {
        yield return new WaitForSeconds(3.0f);
        DeactivateMove();
        player.GetComponent<PlayerDialogue>().ShowDialogue(true);
    }

    public void RevealItems()
    {
        if (stage == 1)
        {
            switch (round)
            {
                case 1:
                    StartCoroutine(FirstRevealItems());
                    break;
                case 2:
                    StartCoroutine(RevealItem(3, 4));
                    break;
                case 3:
                    StartCoroutine(RevealItem(5, 5));
                    break;
            }
        }
        else if (stage == 2)
        {
            switch (round)
            {
                case 1:
                    StartCoroutine(RevealItem(6, 8));
                    break;
                case 2:
                    StartCoroutine(RevealItem(9, 11));
                    break;
            }
        }
        else if (stage == 3)
        {
            for(int i=12; i<items.Length-1; i++) items[i].SetActive(true);
        }
        else if (stage == 4)
        {
            StartCoroutine(RevealItem(items.Length-1, items.Length-1));
        }
    }

    IEnumerator FirstRevealItems()
    {
        yield return new WaitForSeconds(7.0f);
        items[0].SetActive(true);
        mainCamera.GetComponent<CameraMovement_MoveMode>().enabled = true;
        boundary.SetActive(false);
        yield return new WaitUntil(() => (itemsLeft == 16 && player.GetComponent<PlayerCollision>().collideMode == true));
        items[1].SetActive(true);
        yield return new WaitForSeconds(1.0f);
        items[2].SetActive(true);
    }

    IEnumerator RevealItem(int start, int end)
    {
        for(int i=start; i<=end; i++)
        {
            yield return new WaitForSeconds(1.0f);
            items[i].SetActive(true);
        }
    }

    public void ShowGalaxies()
    {
        if (itemsLeft == 13) StartCoroutine(ShowGalaxy(0));
        else if (itemsLeft == 10) StartCoroutine(ShowGalaxy(1));
        else if (stage == 3 && round == 1) StartCoroutine(ShowGalaxy(2));
    }

    IEnumerator ShowGalaxy(int index)
    {
        yield return new WaitForSeconds(1.0f);
        galaxies[index].SetActive(true);
    }

    public void CameraTouchMode()
    {
        mainCamera.GetComponent<CameraMovement_MoveMode>().enabled = false;
        StartCoroutine(MoveCameraSmooth());
    }

    IEnumerator MoveCameraSmooth()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, mainCamera.transform.position.z);
        float time = 0;
        while (time < 2f)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, time / 2f);
            time += Time.deltaTime;
            yield return null;
        }
        mainCamera.GetComponent<CameraMovement_TouchMode>().enabled = true;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ShowCredit()
    {
        SceneManager.LoadScene(2);
    }
}
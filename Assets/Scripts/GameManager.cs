using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject player;

    public int stage = 0;
    public int round = 1;

    private int targetHP;
    private int currentHP = 0;
    private int itemsLeft = 7;

    public void ActivateTouch()
    {
        player.GetComponent<PlayerTouch>().touchMode = true;
    }

    public void ActivateFall()
    {
        player.GetComponent<PlayerMovement>().fallMode = true;
    }

    public void ActivateRise()
    {
        player.GetComponent<PlayerMovement>().riseMode = true;
    }

    public void ActivateMove()
    {
        player.GetComponent<PlayerMovement>().moveMode = true;
    }

    public void DeactivateMove()
    {
        player.GetComponent<PlayerMovement>().moveMode = false;
        player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
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
        else
        {
            targetHP = Random.Range(2, 5);
            if (itemsLeft < targetHP) targetHP = itemsLeft;
            itemsLeft -= targetHP;
        }
    }

    public void IncreaseCurrentHP()
    {
        currentHP++;
    }

    public void CheckGameState()
    {
        if (currentHP >= targetHP)
        {
            currentHP = 0;
            DeactivateMove();
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
            else
            {
                round++;
            }
            StartCoroutine(WaitAndShowDialogue());
        }
    }

    IEnumerator WaitAndShowDialogue()
    {
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<PlayerDialogue>().ShowDialogue(true);
    }

    public void ShowCredit()
    {

    }
}

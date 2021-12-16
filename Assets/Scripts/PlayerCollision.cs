using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.DeactivateMove();
        gameManager.IncreaseCurrentHP();
        collision.gameObject.GetComponent<ItemDialogue>().ShowDialogue();
    }
}

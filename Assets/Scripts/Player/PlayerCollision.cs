using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;

    public bool collideMode = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collideMode)
        {
            collideMode = false;
            gameManager.DeactivateMove();
            if (collision.gameObject.GetComponent<ItemDialogue>().newItem) gameManager.IncreaseCurrentHP();
            gameManager.ShowGalaxies();
            collision.gameObject.GetComponent<ItemDialogue>().ShowDialogue();
        }
    }
}

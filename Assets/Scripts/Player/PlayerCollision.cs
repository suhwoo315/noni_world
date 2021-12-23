using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private SoundManager soundManager;

    public bool collideMode = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Boundary") return;
        if (collideMode)
        {
            soundManager.ActivateSound3();
            collideMode = false;
            gameManager.DeactivateMove();
            if (collision.gameObject.GetComponent<ItemDialogue>().newItem) gameManager.IncreaseCurrentHP(collision.gameObject.name);
            gameManager.ShowGalaxies();
            collision.gameObject.GetComponent<ItemDialogue>().ShowDialogue();
        }
    }
}

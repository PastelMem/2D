using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damageAmount = 1; // Amount of damage to deal to the player

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Check if it collides with the player
        {
            // Assuming the player has a Health component to manage health
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount); // Call the TakeDamage method
            }
            Destroy(gameObject); // Destroy the enemy after hitting the player
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 1;  // Health of the enemy

    // Call this method when the enemy takes damage
    public void TakeDamage(int damage)
    {
        health -= damage;  // Reduce health
        if (health <= 0)
        {
            Die();  // Call die method if health is zero or less
        }
    }

    private void Die()
    {
        // Add score for the player when the enemy dies
        ScoreManager.instance.AddScore(1);  // Add points for killing the enemy

        // Destroy the enemy GameObject
        Destroy(gameObject);
    }
}

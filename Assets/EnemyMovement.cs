using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f; // Speed at which the enemy moves
    private Transform player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform; // Get the player by tag
    }

    private void Update()
    {
        if (player != null)
        {
            // Move the enemy toward the player horizontally
            Vector2 direction = new Vector2(player.position.x - transform.position.x, 0).normalized;
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the enemy hits the player
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1); // Deal damage to the player
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Speed of the bullet
    public float lifetime = 2f; // Lifetime before bullet is destroyed
    private Vector2 direction; // Direction of the bullet

    private void Start()
    {
        Destroy(gameObject, lifetime); // Destroy bullet after lifetime
    }

    public void SetDirection(Vector2 dir)
    {
        direction = dir; // Set the bullet direction
    }

    private void Update()
    {
        // Move the bullet in the direction it's facing
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the bullet hits an enemy
        if (collision.CompareTag("Enemy"))
        {
            // Get the EnemyHealth component and damage the enemy
            EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(1); // Damage the enemy
            }
            Destroy(gameObject); // Destroy the bullet after hitting
        }
    }
}



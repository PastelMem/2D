using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public Transform firePoint; // Reference to the firepoint
    public AudioClip blasterSound; // Blaster sound effect
    private AudioSource audioSource; // Audio source for playing sound

    private void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Replace with your input for shooting
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate the bullet
        if (bulletPrefab != null && firePoint != null)
        {
            // Create the bullet at the fire point
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            // Get the player's facing direction
            Vector2 direction = Vector2.right;
            if (transform.localScale.x < 0) // Check if the player is facing left
            {
                direction = Vector2.left;
            }

            // Set the bullet's direction
            bullet.GetComponent<Bullet>().SetDirection(direction);

            // Play the blaster sound
            if (audioSource != null && blasterSound != null)
            {
                audioSource.PlayOneShot(blasterSound);
            }
        }
    }

}

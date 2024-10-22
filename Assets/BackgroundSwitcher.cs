using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // For UI-based backgrounds

public class BackgroundSwitcher : MonoBehaviour
{
    public Sprite background1;  // The first background image
    public Sprite background2;  // The second background image
    public float switchTime = 5f;  // Time interval for switching (5 seconds)

    private Image uiImage;  // Reference to the UI Image component (for UI-based backgrounds)
    private SpriteRenderer spriteRenderer;  // Reference to the SpriteRenderer (for sprite-based backgrounds)
    private bool isBackground1Active = true;  // Tracks which background is currently active
    private float timer = 0f;  // Tracks the time

    private void Start()
    {
        // Try to get the Image component for UI-based background
        uiImage = GetComponent<Image>();

        // Try to get the SpriteRenderer for sprite-based background
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set the initial background to background1
        SetBackground(background1);
    }

    private void Update()
    {
        // Increment the timer by the time passed since the last frame
        timer += Time.deltaTime;

        // Debug log to check if timer is increasing
        Debug.Log("Timer: " + timer);

        // If the switchTime has passed, switch the background
        if (timer >= switchTime)
        {
            Debug.Log("Switching Background");

            // Switch the background
            if (isBackground1Active)
            {
                SetBackground(background2);
                Debug.Log("Switched to Background 2");
            }
            else
            {
                SetBackground(background1);
                Debug.Log("Switched to Background 1");
            }

            // Reset the timer and toggle the active background flag
            timer = 0f;
            isBackground1Active = !isBackground1Active;
        }
    }

    // This method sets the background for both UI-based and Sprite-based backgrounds
    private void SetBackground(Sprite newBackground)
    {
        // For UI-based backgrounds (Image component)
        if (uiImage != null)
        {
            uiImage.sprite = newBackground;
        }

        // For sprite-based backgrounds (SpriteRenderer)
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = newBackground;
        }
    }
}


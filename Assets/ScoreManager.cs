using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; // Ensure you have this for TextMeshPro

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;  // Singleton instance
    public int score = 0;  // Player's score
    public TextMeshProUGUI scoreText;  // Reference to the TextMeshProUGUI element for displaying the score

    private void Awake()
    {
        // Implement the singleton pattern
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Optional: Keep the ScoreManager across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        UpdateScoreUI(); // Initialize the score display
    }

    // Method to add points to the score
    public void AddScore(int points)
    {
        score += points; // Increase the score
        UpdateScoreUI(); // Update the UI
    }

    // Method to update the score UI
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update the score text
        }
    }
}

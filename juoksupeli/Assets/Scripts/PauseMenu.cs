using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // Reference to the pause menu UI in the scene
    private bool isPaused = false; // Flag to track whether the game is currently paused

    void Start()
    {
        // Make sure the pause menu is initially hidden
        pauseMenuUI.SetActive(false);
    }

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Toggle the pause state
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        // Activate the pause menu UI
        pauseMenuUI.SetActive(true);

        // Pause the game
        Time.timeScale = 0f;

        // Set the paused flag to true
        isPaused = true;
    }

    void ResumeGame()
    {
        // Deactivate the pause menu UI
        pauseMenuUI.SetActive(false);

        // Resume the game
        Time.timeScale = 1f;

        // Set the paused flag to false
        isPaused = false;
    }
}

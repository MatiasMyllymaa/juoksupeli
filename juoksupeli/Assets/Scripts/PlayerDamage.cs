using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int health;
    public int maxHealth = 1;
    public GameObject gameOverScreen;
    private bool isPaused = false;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        gameOverScreen.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            
            gameOverScreen.SetActive(true);
            StopGame();
            
        }
    }
    void StopGame()
    {
        gameOverScreen.SetActive(true);

        Time.timeScale = 0f;

        isPaused = true;
    }
    void ResumeGame()
    {
        gameOverScreen.SetActive(false);

        Time.timeScale = 1f;

        isPaused = false;
    }
}

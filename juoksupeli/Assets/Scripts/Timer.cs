using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 0f;  // Initial time for the timer in seconds
    private float currentTime = 0f;  // Current time elapsed in the timer
    private bool isTimerRunning = false;  // Flag to check if the timer is currently running

    public TextMeshProUGUI timerText;  // Reference to a TextMeshProUGUI element to display the timer

    void Start()
    {
        // Set the initial time
        currentTime = totalTime;
        UpdateTimerText();

        // Start the timer when the scene is loaded
        StartTimer();
    }

    void Update()
    {
        // Check if the timer is running
        if (isTimerRunning)
        {
            // Increase the current time
            currentTime += Time.deltaTime;

            // Update the TextMeshProUGUI text
            UpdateTimerText();
        }
    }

    // Start the timer
    public void StartTimer()
    {
        isTimerRunning = true;
    }

    // Stop the timer
    public void StopTimer()
    {
        isTimerRunning = false;
    }

    // Reset the timer to its initial value
    public void ResetTimer()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    // Update the TextMeshProUGUI text to display the current time
    void UpdateTimerText()
    {
        // Assuming you have a TextMeshProUGUI component to display the timer
        if (timerText != null)
        {
            timerText.text = FormatTime(currentTime);
        }
    }

    // Format the time in minutes and seconds
    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // You can use this method to get the current time
    public float GetCurrentTime()
    {
        return currentTime;
    }
}

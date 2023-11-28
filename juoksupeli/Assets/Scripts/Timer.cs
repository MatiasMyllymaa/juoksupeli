using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 0f;
    private float currentTime = 0f;
    private bool isTimerRunning = false;

    public TextMeshProUGUI timerText;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();

        StartTimer();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;

            UpdateTimerText();
        }
    }

    public void StartTimer()
    {
        isTimerRunning = true;
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    public void ResetTimer()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = FormatTime(currentTime);
        }
    }

    string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}

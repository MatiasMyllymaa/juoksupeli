using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float totalTime = 0f;
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
            currentTime += Time.deltaTime * 10;

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
        int seconds = Mathf.FloorToInt(time);
        return string.Format("{0}", seconds);
    }

    public float GetCurrentTime()
    {
        return currentTime;
    }
}

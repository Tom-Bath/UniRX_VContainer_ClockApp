using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class TimerView : MonoBehaviour
    {
        public TextMeshProUGUI timerText;
        public Button StartPauseButton;
        public Button ResetButton;

        // Update the TextMeshPro UI component with the current timer value
        public void UpdateUI(float elapsedTime)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(elapsedTime);
            timerText.text = string.Format("{0:0}:{1:00}.{2:00}", ts.TotalMinutes, ts.Seconds, ts.Milliseconds / 10);
        }

        public void ToggleText(bool isPlaying)
        {
            StartPauseButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = isPlaying ? "Pause" : "Start";
        }
    }
}
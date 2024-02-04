using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Timer
{
    public class TimerView : MonoBehaviour
    {
        public AudioSource audioSource;
        public TextMeshProUGUI stopwatchText;
        public Button StartPauseButton;
        public Button ResetButton;
        public Button InputClearButton;

        [Header("Time Increment Buttons")]
        public Button PlusOneSecondButton;
        public Button PlusTenSecondButton;
        public Button PlusOneMinuteButton;
        public Button PlusTenMinuteButton;
        public Button PlusOneHourButton;

        // Update the TextMeshPro UI component with the current stopwatch value
        public void UpdateUIRemainingTime(TimeSpan ts)
        {
            stopwatchText.text = string.Format("{0:00}:{1:00}:{2:00}", ts.Hours, ts.Minutes, ts.Seconds);
        }
        public void ToggleText(bool isPlaying)
        {
            StartPauseButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = isPlaying ? "Pause" : "Start";
        }

        public void ToggleInputUI(bool isPlaying, TimeSpan timeSpan)
        {
            if (timeSpan != TimeSpan.Zero && !isPlaying)
            {
                return;
            }
            //We only want to show the timer input buttons when the timer isn't runnign
            PlusOneSecondButton.gameObject.SetActive(!isPlaying);
            PlusTenSecondButton.gameObject.SetActive(!isPlaying);
            PlusOneMinuteButton.gameObject.SetActive(!isPlaying);
            PlusTenMinuteButton.gameObject.SetActive(!isPlaying);
            PlusOneHourButton.gameObject.SetActive(!isPlaying);
            InputClearButton.gameObject.SetActive(!isPlaying);
        }

        public void PlaySound(bool isPlaying, TimeSpan timeSpan)
        {
            if (!isPlaying && timeSpan == TimeSpan.Zero)
            {
                audioSource.Play();
            }
            else if (isPlaying)
            {
                //So that the sound doesn't play on starting the app, we'll keep it muted until the clock begins
                audioSource.volume = 1f;
            }
        }
    }
}
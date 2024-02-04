using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Stopwatch
{
    public class StopwatchView : MonoBehaviour
    {
        // public TextMeshProUGUI stopwatchText;
        public Button StartPauseButton;
        public Button LapButton;
        public Button ResetButton;
        public GameObject LapContent;
        public GameObject CurrentLap;
        public GameObject LapUIPrefab;

        private List<GameObject> lapList; // Used to store the laps to be removed later

        public string TimeToString(float elapsedTime)
        {
            TimeSpan ts = TimeSpan.FromMilliseconds(elapsedTime);
            return string.Format("{0:0}:{1:00}.{2:00}", ts.TotalMinutes, ts.Seconds, ts.Milliseconds / 10);
        }

        public void UpdateUIElementText(GameObject gameObject, string newText)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = newText;
        }

        public void UpdateUIElementText(GameObject gameObject, float timeFloat)
        {
            UpdateUIElementText(gameObject, TimeToString(timeFloat));
        }

        public void InstantiateLapPrefabWithTime(string timestring)
        {
            if (lapList == null)  //Initialise for first new lap
            {
                lapList = new();
            }

            // Instantiate the text UI prefab
            GameObject newLapObject = Instantiate(LapUIPrefab);
            newLapObject.transform.SetParent(LapContent.transform, false);

            // Set the text content of the instantiated text UI
            UpdateUIElementText(newLapObject, string.Format("Lap {0} - {1}", lapList.Count + 1, timestring));
            lapList.Add(newLapObject);
        }

        public void ResetLaps()
        {
            for (int i = lapList.Count - 1; i >= 0; i--)
            {
                if (lapList[i] != null)
                {
                    Destroy(lapList[i]);
                }
                lapList.Remove(lapList[i]);
            }
        }

        public void ToggleText(bool isPlaying)
        {
            StartPauseButton.gameObject.GetComponentInChildren<TextMeshProUGUI>().text = isPlaying ? "Pause" : "Start";
        }
    }
}
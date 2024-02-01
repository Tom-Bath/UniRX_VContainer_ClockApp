using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clock
{
    // Responsible only for the functionality that can be called anytime, anywhere
    public class ClockService
    {
        public void PrintHelloWorld()
        {
            Debug.Log("Hello World");
        }

        public void UpdateClockUI(TextMeshProUGUI textComponent)
        {
            // Get the current time
            System.DateTime currentTime = System.DateTime.Now;

            // Format the time as a string
            string formattedTime = currentTime.ToString("HH:mm:ss");

            // Update the UI
            textComponent.text = formattedTime;
        }
    }
}
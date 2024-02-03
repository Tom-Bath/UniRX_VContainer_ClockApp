using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Time
{
    public class TimeView : MonoBehaviour
    {
        public TextMeshProUGUI timeText; // Reference to the TextMeshPro UI component
        public Button timeButton;

        // Update the TextMeshPro UI component with the current time
        public void UpdateUI(System.DateTime currentTime)
        {
            timeText.text = currentTime.ToString("HH:mm:ss");
        }
    }
}
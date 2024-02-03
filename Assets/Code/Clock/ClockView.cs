using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Clock
{
    public class ClockView : MonoBehaviour
    {
        public TextMeshProUGUI clockText;
        public Button clockButton;

        public void UpdateUI(System.DateTime currentTime)
        {
            clockText.text = currentTime.ToString("HH:mm:ss");
        }
    }
}
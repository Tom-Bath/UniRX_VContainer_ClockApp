using TMPro;
using UnityEngine;

namespace Clock
{
    public class ClockView : MonoBehaviour
    {
        public TextMeshProUGUI clockText;
        public void UpdateUI(System.DateTime currentTime)
        {
            clockText.text = currentTime.ToString("HH:mm:ss");
        }
    }
}
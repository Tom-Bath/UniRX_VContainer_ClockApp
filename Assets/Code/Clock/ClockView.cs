using System;
using TMPro;
using UnityEngine;

namespace Clock
{
    public class ClockView : MonoBehaviour
    {
        public TextMeshProUGUI clockText;
        public TextMeshProUGUI timezoneText;
        public void UpdateClockUI(DateTime currentTime)
        {
            clockText.text = currentTime.ToString("HH:mm:ss");
        }
        public void UpdateTimezoneUI(TimeZoneInfo currentTimezone)
        {
            timezoneText.text = currentTimezone.DisplayName;
        }
    }
}
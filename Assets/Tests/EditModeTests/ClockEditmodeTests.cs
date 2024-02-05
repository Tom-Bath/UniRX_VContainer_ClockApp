using NUnit.Framework;
using System;

using Clock;
using TMPro;
using UnityEngine;

public class ClockEditmodeTests
{
    [Test]
    public void ClockModel_UpdateClock_ShouldUpdateCurrentTime()
    {
        // Arrange
        ClockModel clockModel = new();
        DateTime now = DateTime.Now;

        // Act
        clockModel.UpdateClock();

        //Assert
        Assert.AreEqual(clockModel.CurrentTime.Value, now);
    }

    [Test]
    public void ClockView_UpdateClockUI_ShouldUpdateClockTextWithFormattedTime()
    {
        // Arrange
        var clockViewGameObject = new UnityEngine.GameObject();
        ClockView clockView = clockViewGameObject.AddComponent<ClockView>();
        var textMeshProUGUI = clockViewGameObject.AddComponent<TextMeshProUGUI>();
        clockView.clockText = textMeshProUGUI;

        var currentTime = new DateTime(2024, 2, 5, 12, 30, 45);

        // Act
        clockView.UpdateClockUI(currentTime);

        // Assert
        Assert.AreEqual("12:30:45", clockView.clockText.text);
    }

    [Test]
    public void ClockView_UpdateTimezoneUI_ShouldUpdateClockTextWithFormattedTimezone()
    {
        // Arrange
        GameObject clockViewGameObject = new GameObject();
        ClockView clockView = clockViewGameObject.AddComponent<ClockView>();
        TextMeshProUGUI textMeshProUGUI = clockViewGameObject.AddComponent<TextMeshProUGUI>();
        clockView.timezoneText = textMeshProUGUI;

        var currentTimezone = TimeZoneInfo.FindSystemTimeZoneById("GMT Standard Time");

        // Act
        clockView.UpdateTimezoneUI(currentTimezone);

        // Assert
        Assert.AreEqual("(UTC+00:00) Dublin, Edinburgh, Lisbon, London", clockView.timezoneText.text);
    }

}

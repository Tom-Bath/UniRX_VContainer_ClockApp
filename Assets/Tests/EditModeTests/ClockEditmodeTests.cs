using NUnit.Framework;
using System;

using Clock;
using TMPro;

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
    public void ClockView_UpdateUI_ShouldUpdateClockTextWithFormattedTime()
    {
        // Arrange
        var clockViewGameObject = new UnityEngine.GameObject();
        ClockView clockView = clockViewGameObject.AddComponent<ClockView>();
        var textMeshProUGUI = clockViewGameObject.AddComponent<TextMeshProUGUI>();
        clockView.clockText = textMeshProUGUI;

        var currentTime = new DateTime(2024, 2, 5, 12, 30, 45);

        // Act
        clockView.UpdateUI(currentTime);

        // Assert
        Assert.AreEqual("12:30:45", clockView.clockText.text);
    }
}

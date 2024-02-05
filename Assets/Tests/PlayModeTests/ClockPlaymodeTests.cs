using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Clock;
using System;
using TMPro;

public class ClockPlaymodeTests
{
    [UnityTest]
    public IEnumerator ClockModel_UpdateClock_ShouldUpdateCurrentTime()
    {
        // Arrange
        ClockModel clockModel = new();
        DateTime now = DateTime.Now;

        // Act
        clockModel.UpdateClock(now);

        // Assert
        yield return null; // Wait for end of frame to allow UniRx to update
        Assert.AreEqual(clockModel.CurrentTime.Value, now);
    }

    [UnityTest]
    public IEnumerator ClockViewModel_UpdateTimeInView_ShouldUpdateClockView()
    {
        // Arrange
        ClockModel clockModel = new();
        GameObject clockMockCanvasObject = new();
        ClockView clockView = clockMockCanvasObject.AddComponent<ClockView>();

        // Check if clockView is not null before attempting to access its properties
        Assert.IsNotNull(clockView, "ClockView is null");
        Assert.IsNotNull(clockView.gameObject, "ClockView's gameObject is null");
        clockView.clockText = clockView.gameObject.AddComponent<TextMeshProUGUI>();

        ClockViewModel clockViewModel = new ClockViewModel(clockModel, clockView);

        // Act
        clockModel.UpdateClock(DateTime.Now);
        clockViewModel.UpdateTimeInView();

        // Assert
        yield return null; // Wait for the end of the frame to allow UniRx to update
        Assert.AreEqual(clockModel.CurrentTime.Value.ToString("HH:mm:ss"), clockView.clockText.text);
    }

}
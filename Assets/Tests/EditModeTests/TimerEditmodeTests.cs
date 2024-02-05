using NUnit.Framework;
using System;
using Time;
using Timer;
using TMPro;
using UnityEngine;

public class TimerEditmodeTests
{
    [Test]
    public void TimerModel_ToggleTimer_ShouldInvertIsRunning()
    {
        // Arrange
        TimerModel timerModel = new();
        Assert.AreEqual(false, timerModel.IsRunning.Value);

        // Act
        timerModel.ToggleTimer();

        // Assert
        Assert.AreEqual(true, timerModel.IsRunning.Value);
    }

    [Test]
    public void TimerModel_ResetTimer_ShouldStopTimerAndClearRemainingTime()
    {
        // Arrange
        TimerModel timerModel = new();
        Assert.AreEqual(timerModel.RemainingTime.Value, TimeSpan.Zero);
        timerModel.IncrememntTimer(10);
        Assert.AreEqual(timerModel.RemainingTime.Value, TimeSpan.FromSeconds(10));

        // Act
        timerModel.ResetTimer();

        // Assert
        Assert.AreEqual(timerModel.IsRunning.Value, false);
        Assert.AreEqual(timerModel.RemainingTime.Value, TimeSpan.Zero);
    }

    [Test]
    public void TimerModel_ClearTimer_ShouldSetRemainingTimeToZero()
    {
        // Arrange
        var timerModel = new TimerModel();
        timerModel.IncrememntTimer(5);

        // Act
        timerModel.ClearTimer();

        // Assert
        Assert.AreEqual(TimeSpan.Zero, timerModel.RemainingTime.Value);
    }

    [Test]
    public void TimerModel_CheckTimerIsZero_ShouldStopTimerIfRemainingTimeIsZero()
    {
        // Arrange
        var timerModel = new TimerModel();
        timerModel.IncrememntTimer(1);

        // Act
        timerModel.CheckTimerIsZero();

        // Assert
        Assert.AreEqual(false, timerModel.IsRunning.Value);
    }

    [Test]
    public void TimerModel_IncrememntTimer_ShouldAddSecondsToRemainingTime()
    {
        // Arrange
        var timerModel = new TimerModel();

        // Act
        timerModel.IncrememntTimer(15);

        // Assert
        Assert.AreEqual(TimeSpan.FromSeconds(15), timerModel.RemainingTime.Value);
    }

    [Test]
    public void TimerView_UpdateUIRemainingTime_ShouldUpdateStopwatchTextWithFormattedTime()
    {
        // Arrange
        var timerViewGameObject = new GameObject();
        var timerView = timerViewGameObject.AddComponent<TimerView>();
        var textMeshProUGUI = timerViewGameObject.AddComponent<TextMeshProUGUI>();
        timerView.stopwatchText = textMeshProUGUI;

        var timeSpan = new TimeSpan(1, 23, 45);

        // Act
        timerView.UpdateUIRemainingTime(timeSpan);

        // Assert
        Assert.AreEqual("01:23:45", timerView.stopwatchText.text);
    }
}

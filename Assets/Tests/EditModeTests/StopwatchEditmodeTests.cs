using NUnit.Framework;
using Stopwatch;

public class StopwatchEditmodeTests
{
    [Test]
    public void StopwatchModel_MethodToggleStopwatch_ShouldToggleIsRunningValue()
    {
        // Arrange
        StopwatchModel stopwatchModel = new();  //stopwatchModel.IsRunning.Value should be false
        Assert.AreEqual(stopwatchModel.IsRunning.Value, false);

        // Acts & Asserts 1
        stopwatchModel.ToggleStopwatch();  // Now should be set to true
        Assert.AreEqual(stopwatchModel.IsRunning.Value, true);

        // Acts & Asserts 2
        stopwatchModel.ToggleStopwatch();  // Now should be set to false
        Assert.AreEqual(stopwatchModel.IsRunning.Value, false);
    }

    [Test]
    public void StopwatchModel_MethodResetStopwatch_ShouldSetValuesToDefault()
    {
        // Arrange
        StopwatchModel stopwatchModel = new();  //stopwatchModel.IsRunning.Value should be false, elapsedTime = 0f
        Assert.AreEqual(stopwatchModel.IsRunning.Value, false);
        Assert.AreEqual(stopwatchModel.ElapsedTime.Value, 1f);
        stopwatchModel.ToggleStopwatch();
        Assert.AreEqual(stopwatchModel.IsRunning.Value, true);

        // Acts
        stopwatchModel.ResetStopwatch();  // Now should be set to defaults

        // Asserts
        Assert.AreEqual(stopwatchModel.IsRunning.Value, false);
        Assert.AreEqual(stopwatchModel.ElapsedTime.Value, 0f);
    }

    [Test]
    public void StopwatchModel_MethodAddLapTime_ShouldAssignElapsedTimeToLapTime()
    {
        //Assign
        StopwatchModel stopwatchModel = new();  //stopwatchModel.IsRunning.Value should be false, elapsedTime = 0f
        stopwatchModel.ElapsedTime.Value = 10f;

        Assert.AreEqual(stopwatchModel.ElapsedTime.Value, 10f);
        Assert.AreEqual(stopwatchModel.PreviousLap.Value, 0f);

        //Act 
        stopwatchModel.AddLapTime();

        // Assert
        Assert.AreEqual(stopwatchModel.ElapsedTime.Value, 0f);
        Assert.AreEqual(stopwatchModel.PreviousLap.Value, 10f);
    }
}

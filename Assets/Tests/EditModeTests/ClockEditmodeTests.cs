using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Clock;
using System;

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
}

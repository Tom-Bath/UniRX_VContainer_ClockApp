using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Stopwatch;
using UnityEngine.UI;
using TMPro;

public class StopwatchPlaymodeTests
{
    [Test]
    public void StopwatchView_TimeToString_FormattingCorrect()
    {
        // Arrange
        var stopwatchViewObject = new GameObject();
        var stopwatchView = stopwatchViewObject.AddComponent<StopwatchView>();
        float elapsedTime = 1234f; 

        // Act
        string formattedTime = stopwatchView.TimeToString(elapsedTime);

        // Assert
        Assert.AreEqual("2057:36.79", formattedTime);
    }

    [Test]
    public void StopwatchView_UpdateUIElementText_TextUpdated()
    {
        // Arrange
        GameObject stopwatchViewObject = new GameObject();
        StopwatchView stopwatchView = stopwatchViewObject.AddComponent<StopwatchView>();
        GameObject textObject = new GameObject();
        textObject.AddComponent<TextMeshProUGUI>();
        string newText = "New Text";

        // Act
        stopwatchView.UpdateUIElementText(textObject, newText);

        // Assert
        Assert.AreEqual(newText, textObject.GetComponent<TextMeshProUGUI>().text);
    }

    [Test]
    public void StopwatchView_InstantiateLapPrefabWithTime_LapInstantiated()
    {
        // Arrange
        GameObject stopwatchViewObject = new GameObject();
        StopwatchView stopwatchView = stopwatchViewObject.AddComponent<StopwatchView>();
        stopwatchView.LapContent = new GameObject();
        stopwatchView.LapUIPrefab = new GameObject();
        stopwatchView.LapUIPrefab.AddComponent<TextMeshProUGUI>(); //the prefab needs a tmpro textbox

        // Act
        stopwatchView.InstantiateLapPrefabWithTime("01:23.45");

        // Assert
        Assert.AreEqual(1, stopwatchView.LapList.Count);
    }

    [Test]
    public void StopwatchView_ResetLaps_ShouldSetLapListTo0Elements()
    {
        // Arrange
        GameObject stopwatchViewObject = new GameObject();
        StopwatchView stopwatchView = stopwatchViewObject.AddComponent<StopwatchView>();
        stopwatchView.LapContent = new GameObject();
        stopwatchView.LapUIPrefab = new GameObject();
        stopwatchView.LapUIPrefab.AddComponent<TextMeshProUGUI>(); //the prefab needs a tmpro textbox

        stopwatchView.InstantiateLapPrefabWithTime("01:11.11");
        stopwatchView.InstantiateLapPrefabWithTime("02:22.22");
        stopwatchView.InstantiateLapPrefabWithTime("03:33.33");
        Assert.AreEqual(3, stopwatchView.LapList.Count);

        // Act
        stopwatchView.ResetLaps();

        // Assert
        Assert.AreEqual(0, stopwatchView.LapList.Count);
    }

    // Teardown method to be called after each test
    [TearDown]
    public void TearDown()
    {
        // Unload any loaded assets
        Resources.UnloadUnusedAssets();

        // Destroy all GameObjects created during the test
        foreach (var gameObject in UnityEngine.Object.FindObjectsOfType<GameObject>())
        {
            UnityEngine.Object.DestroyImmediate(gameObject);
        }
    }
}
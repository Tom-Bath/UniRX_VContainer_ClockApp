using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Display;

public class DisplayPlaymodeTests
{
    [UnityTest]
    public IEnumerator DisplayView_DisableAllCanvas_DisablesAllCanvases()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        DisplayView displayView = gameObject.AddComponent<DisplayView>();

        UIMapping[] newUIMapping = new UIMapping[3];
        for (int i = 0; i < newUIMapping.Length; i++)
        {
            GameObject canvasObject = new GameObject($"Canvas{i}");
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            UIMapping uiMapping = new UIMapping
            {
                uiName = $"UI{i}",
                UiCanvas = canvas
            };
            newUIMapping[i] = uiMapping;
        }
        displayView.uiMappings = newUIMapping;

        // Act
        displayView.DisableAllCanvas();
        yield return null;

        // Assert
        foreach (var item in displayView.UIMappings)
        {
            Assert.IsFalse(item.UiCanvas.enabled);
        }
    }

    [UnityTest]
    public IEnumerator DisplayView_SetActiveCanvas_EnablesSpecifiedCanvas()
    {
        // Arrange
        GameObject gameObject = new GameObject();
        DisplayView displayView = gameObject.AddComponent<DisplayView>();
        UIMapping[] newUIMapping = new UIMapping[3];
        for (int i = 0; i < newUIMapping.Length; i++)
        {
            GameObject canvasObject = new GameObject($"Canvas{i}");
            Canvas canvas = canvasObject.AddComponent<Canvas>();
            canvas.enabled = false; //For this test, we will set all UI to disabled
            UIMapping uiMapping = new UIMapping
            {
                uiName = $"UI{i}",
                UiCanvas = canvas
            };
            newUIMapping[i] = uiMapping;
        }
        displayView.uiMappings = newUIMapping;

        // Act
        string uiNameToActivate = "UI1";
        displayView.SetActiveCanvas(uiNameToActivate);
        yield return null;

        // Assert
        foreach (var item in displayView.UIMappings)
        {
            Assert.AreEqual(item.UiCanvas.enabled, item.uiName == uiNameToActivate);
        }
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
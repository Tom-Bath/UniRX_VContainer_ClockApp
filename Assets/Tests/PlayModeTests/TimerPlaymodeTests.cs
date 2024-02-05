using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

using Timer;
using System;
using TMPro;
using UnityEngine.UI;

public class TimerPlaymodeTests
{
    [UnityTest]
    public IEnumerator TimerView_PlaySound_ShouldPlayOrMuteAudioBasedOnIsPlayingAndTimeSpan()
    {
        // Arrange
        var timerViewGameObject = new GameObject();
        TimerView timerView = timerViewGameObject.AddComponent<TimerView>();
        AudioSource audioSource = timerViewGameObject.AddComponent<AudioSource>();
        timerView.audioSource = audioSource;

        // Load the audio clip from Resources folder
        AudioClip audioClip = Resources.Load<AudioClip>("Sounds/BeepSound");
        Assert.NotNull(audioClip, "Failed to load the audio clip");
        audioSource.clip = audioClip;

        // Create an audio listener to avoid missing listerenr warnings
        var audioListenerObject = new GameObject("TestAudioListener");
        audioListenerObject.AddComponent<AudioListener>();

        // Act
        timerView.PlaySound(false, TimeSpan.Zero);
        yield return null;

        // Assert
        Assert.IsTrue(audioSource.isPlaying);
        Assert.AreEqual(1f, audioSource.volume);
    }

    [UnityTest]
    public IEnumerator TimerView_ToggleInputUI_ShouldShowOrHideInputButtonsBasedOnIsPlayingAndTimeSpan()
    {
        // Arrange
        var timerViewGameObject = new GameObject();
        var timerView = timerViewGameObject.AddComponent<TimerView>();

        // Create all the buttons, and set their gameobjs to false (mimic start conditon)
        timerView.PlusOneSecondButton = new GameObject().AddComponent<Button>(); ;
        timerView.PlusTenSecondButton = new GameObject().AddComponent<Button>();
        timerView.PlusOneMinuteButton = new GameObject().AddComponent<Button>();
        timerView.PlusTenMinuteButton = new GameObject().AddComponent<Button>();
        timerView.PlusOneHourButton = new GameObject().AddComponent<Button>();
        timerView.InputClearButton = new GameObject().AddComponent<Button>();
        
        // Act
        timerView.ToggleInputUI(false, TimeSpan.Zero); //The UI is on when isPlaying = false
        yield return null;

        // Assert
        Assert.IsTrue(timerView.PlusOneSecondButton.gameObject.activeSelf);
        Assert.IsTrue(timerView.PlusTenSecondButton.gameObject.activeSelf);
        Assert.IsTrue(timerView.PlusOneMinuteButton.gameObject.activeSelf);
        Assert.IsTrue(timerView.PlusTenMinuteButton.gameObject.activeSelf);
        Assert.IsTrue(timerView.PlusOneHourButton.gameObject.activeSelf);
        Assert.IsTrue(timerView.InputClearButton.gameObject.activeSelf);

        // Act
        timerView.ToggleInputUI(true, TimeSpan.FromSeconds(5));
        yield return null;

        // Assert
        Assert.IsFalse(timerView.PlusOneSecondButton.gameObject.activeSelf);
        Assert.IsFalse(timerView.PlusTenSecondButton.gameObject.activeSelf);
        Assert.IsFalse(timerView.PlusOneMinuteButton.gameObject.activeSelf);
        Assert.IsFalse(timerView.PlusTenMinuteButton.gameObject.activeSelf);
        Assert.IsFalse(timerView.PlusOneHourButton.gameObject.activeSelf);
        Assert.IsFalse(timerView.InputClearButton.gameObject.activeSelf);
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
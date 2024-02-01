using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class BasicClock : MonoBehaviour
{
    public Button myButton;
    void Start()
    {
        // Use UniRx to subscribe to the OnClick event of the button
        // myButton.OnClickAsObservable()
        //     .Subscribe(_ => PrintHelloWorld())
        //     .AddTo(this); // AddTo is used to automatically dispose of the subscription when the GameObject is destroyed
    }
    
}
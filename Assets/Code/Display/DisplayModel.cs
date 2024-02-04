using System;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Display
{
    public class DisplayModel
    {
        //Using string rather than canvas as value because 
        public ReactiveProperty<string> activeCanvasString = new ReactiveProperty<string>("");

        public void SwapToScreen(string canvas)
        {
            activeCanvasString.Value = canvas;
        }
    }

    [Serializable]
    public class UIMapping
    {
        public string uiName;
        public Canvas UiCanvas;
        public Button UiButton;
    }

}
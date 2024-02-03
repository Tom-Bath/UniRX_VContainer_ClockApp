using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

namespace Display
{
    public class DisplayView : MonoBehaviour
    {
        [SerializeField]
        private UIMapping[] uiMappings;

        public UIMapping[] UIMappings => uiMappings;

        public void DisableAllCanvas()
        {
            foreach (var item in UIMappings)
            {
                item.UiCanvas.enabled = false;
            }
        }
        public void SetActiveCanvas(string uiName)
        {
            foreach (var item in UIMappings)
            {
                if (item.uiName == uiName)
                {
                    item.UiCanvas.enabled = true;
                    break;
                }
            }
        }
    }
}
using UnityEngine;

namespace Display
{
    public class DisplayView : MonoBehaviour
    {
        public UIMapping[] uiMappings;

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
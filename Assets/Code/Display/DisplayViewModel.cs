using System.Collections.Generic;
using UniRx;
using UnityEngine;
using VContainer.Unity;

namespace Display
{
    public class DisplayViewModel : IStartable
    {
        private DisplayModel displayModel;
        private DisplayView displayView;

        public CompositeDisposable disposables = new();

        public DisplayViewModel(DisplayModel model, DisplayView view)
        {
            displayModel = model;
            displayView = view;
        }

        void IStartable.Start()
        {
            foreach (var element in displayView.UIMappings)
            {
                element.UiButton.OnClickAsObservable()
                    .Subscribe(_ => displayModel.SwapToScreen(element.uiName))
                    .AddTo(disposables);
            }

            displayModel.activeCanvasString.Subscribe(value => {
                displayView.DisableAllCanvas();
                displayView.SetActiveCanvas(value);
            }).AddTo(disposables);
        }
    }
}
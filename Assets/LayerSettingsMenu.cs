using System;
using UnityEngine;
using UnityEngine.UI;

namespace ATH.UI
{
    public class LayerSettingsMenu : MonoBehaviour
    {
        [SerializeField] private Button closeButton;
        [SerializeField] private Button createNewLayer;

        private bool _inited = false;

        private PaintLayerManager paintLayerManager;
        private Action closeBtnExternalAction;

        private void Start()
        {
            closeButton.onClick.AddListener(CloseButtonAction);
            createNewLayer.onClick.AddListener(CreateLayerButtonAction);
        }

        private void CloseButtonAction()
        {
            gameObject.SetActive(false);
            closeBtnExternalAction?.Invoke();
        }

        private void CreateLayerButtonAction()
        {
            paintLayerManager.CreateLayer(1024, 1024);
        }

        //Used for dependency injection
        public void Init(PaintLayerManager paintLayerManager)
        {
            _inited = true;
            this.paintLayerManager = paintLayerManager;
        }

        public void SetCloseBtnAction(Action action)
        {
            closeBtnExternalAction = action;
        }


    }
}

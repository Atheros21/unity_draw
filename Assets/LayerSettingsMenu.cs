using UnityEngine;
using UnityEngine.UI;

namespace ATH
{
    public class LayerSettingsMenu : MonoBehaviour
    {
        [SerializeField] private Button closeButton;

        private bool _inited = false;

        private PaintLayerManager paintLayerManager;

        private void Start()
        {
            closeButton.onClick.AddListener(CloseButtonAction);
        }

        private void CloseButtonAction()
        {
            gameObject.SetActive(false);
        }

        //Used for dependency injection
        public void Init(PaintLayerManager paintLayerManager)
        {
            _inited = true;
            this.paintLayerManager = paintLayerManager;
        }

        
    }
}

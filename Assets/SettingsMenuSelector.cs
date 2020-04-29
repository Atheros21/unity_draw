using UnityEngine;
using UnityEngine.UI;

namespace ATH.UI
{
    public class SettingsMenuSelector : MonoBehaviour
    {
        [SerializeField] private Button toolSettingsBtn;
        [SerializeField] private Button layerSettingsBtn;

        private ToolSettingsMenu toolSettingsMenu;
        private LayerSettingsMenu layerSettingsMenu;

        private void Start()
        {
            toolSettingsBtn.onClick.AddListener(ToolSettingButtonAction);
        }

        private void LayerSettingsButtonAction()
        {
            layerSettingsMenu.gameObject.SetActive(true);
            toolSettingsMenu.gameObject.SetActive(false);
        }

        private void ToolSettingButtonAction()
        {
            toolSettingsMenu.gameObject.SetActive(true);
            layerSettingsMenu.gameObject.SetActive(false);
        }

        public void Init(ToolSettingsMenu toolSettingsMenu, LayerSettingsMenu layerSettingsMenu)
        {
            this.toolSettingsMenu = toolSettingsMenu;
            this.layerSettingsMenu = layerSettingsMenu;
            this.layerSettingsMenu.SetCloseBtnAction(delegate { gameObject.SetActive(true); });
            this.toolSettingsMenu.SetCloseBtnAction(delegate { gameObject.SetActive(true); });
        }
    }
}

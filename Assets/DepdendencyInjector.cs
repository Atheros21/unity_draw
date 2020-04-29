using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ATH
{
    public class DepdendencyInjector : MonoBehaviour
    {
        [SerializeField] private PaintLayerManager paintLayerManager;
        [Space(10)]
        [SerializeField] private UI.LayerSettingsMenu layerSettingsMenu;
        [SerializeField] private UI.ToolSettingsMenu toolSettingsMenu;
        [SerializeField] private UI.SettingsMenuSelector settingsMenuSelector;

        private void Start()
        {
            layerSettingsMenu.Init(paintLayerManager);
            settingsMenuSelector.Init(toolSettingsMenu, layerSettingsMenu);
        }
    }
}

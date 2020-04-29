using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ATH.UI
{
    public class ToolSettingsMenu : MonoBehaviour
    {
        [SerializeField] private ColorPainter colorPainter;

        [SerializeField] private Button closeBtn;

        [SerializeField] private Image colorIndicator;

        [SerializeField] private Slider redSlider;
        [SerializeField] private Slider greenSlider;
        [SerializeField] private Slider blueSlider;

        [SerializeField] private TextMeshProUGUI brushSizeLabel;
        [SerializeField] private Slider brushSizeSlider;

        private ToolSettings toolSettings;

        private Action closeBtnExternalAction;

        private void Awake()
        {
            toolSettings = new ToolSettings(Color.gray, 5);
            colorPainter.SetToolSettingRef(toolSettings);    
        }

        private void Start()
        {
            closeBtn.onClick.AddListener(CloseButtonAction);
            redSlider.onValueChanged.AddListener(ctx => { SliderAction(ctx, toolSettings.SetToolRedValue); });
            brushSizeSlider.onValueChanged.AddListener(BrushSizeSliderAction);
            greenSlider.onValueChanged.AddListener(ctx => { SliderAction(ctx, toolSettings.SetToolGreenValue); });
            blueSlider.onValueChanged.AddListener(ctx => { SliderAction(ctx, toolSettings.SetToolBlueValue); });
            gameObject.SetActive(false);
        }

        private void CloseButtonAction()
        {
            gameObject.SetActive(false);
            closeBtnExternalAction?.Invoke();
        }

        private void SliderAction(float sliderValue, Action<float> action)
        {
            action.Invoke(sliderValue);
            colorIndicator.color = toolSettings.Color;
        }

        private void BrushSizeSliderAction(float value)
        {
            brushSizeLabel.text = "Brush size:" + value;
            toolSettings.SetRadius((int)value);
        }

        public void SetCloseBtnAction(Action action)
        {
            closeBtnExternalAction = action;
        }
    }
}

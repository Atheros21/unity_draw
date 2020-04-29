using UnityEngine;

namespace ATH
{
    [System.Serializable]
    public class ToolSettings
    {
        public Color Color { get; private set; }
        public int Radius { get; private set; }

        private const int brushMaxRadius = 501;

        public ToolSettings(Color defaultColor, int defaultRadius)
        {
            Color = defaultColor;
            Radius = defaultRadius;
        }

        public void SetToolColor(Color targetColor)
        {
            Color = targetColor;
        }
        public void SetToolRedValue(float value)
        {
            Color = new Color(value,Color.g,Color.b);
        }
        public void SetToolGreenValue(float value)
        {
            Color = new Color(Color.r, value, Color.b);
        }
        public void SetToolBlueValue(float value)
        {
            Color = new Color(Color.r, Color.g, value);
        }


        public void SetRadius(int newSize)
        {
            if (newSize < 0 || newSize > brushMaxRadius)
            {
                return;
            }
            Radius = newSize;
        }
    }
}
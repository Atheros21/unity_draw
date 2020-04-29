using System.Collections.Generic;
using UnityEngine;

namespace ATH
{
    [CreateAssetMenu()]
    public class ColorTheme : ScriptableObject
    {
        [SerializeField] private Color color1;
        [SerializeField] private Color color2;
        [SerializeField] private Color color3;
        [SerializeField] private Color color4;
        [SerializeField] private Color color5;

        public Color GetColor(int index)
        {
            int indexLimit = index % 5;
            switch(indexLimit)
            {
                case 0:
                    return color1;
                case 1:
                    return color2;
                case 2:
                    return color3;
                case 3:
                    return color4;
                case 4:
                    return color5;
            }
            return Color.white;
        }
    }
}
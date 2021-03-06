﻿using UnityEngine;
using UnityEngine.UI;

namespace ATH
{
    public class PaintLayer
    {
        private Texture2D texture;
        private RawImage rawImage;

        public PaintLayer(Texture2D texture, RawImage rawImage)
        {
            this.texture = texture;
            this.rawImage = rawImage;
            this.rawImage.texture = this.texture;
        }

        public void SetColor(Color targetColor)
        {
            for (int i = 0; i < texture.width; i++)
            {
                for (int j = 0; j < texture.height; j++)
                {
                    texture.SetPixel(i, j, targetColor);
                }
            }
            texture.Apply();
        }

        public void PaintPixel(int i, int j, Color targetColor)
        {
            i = Mathf.Clamp(i,0, texture.height);
            j = Mathf.Clamp(j,0, texture.width);
            texture.SetPixel(i, j, targetColor);
        }

        public void ApplyChanges()
        {
            texture.Apply();
        }

        public void IncreasePriority()
        {
            int currentOrder = rawImage.transform.GetSiblingIndex();
            rawImage.transform.SetSiblingIndex(++currentOrder);
        }
        public void DecreasePriority()
        {
            int currentOrder = rawImage.transform.GetSiblingIndex();
            rawImage.transform.SetSiblingIndex(currentOrder>1?currentOrder-1:0);
        }

        public Texture2D GetTexture()
        {
            return texture;
        }
    }
}

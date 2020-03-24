using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ATH
{
    public class PaintLayerManager : MonoBehaviour
    {
        [SerializeField] private Vector2 layerCreartionSize;
        private List<PaintLayer> paintLayers = new List<PaintLayer>();
        private Canvas parentCanvas;

        void Start()
        {
            parentCanvas = GetComponentInParent<Canvas>();
            CreateLayer(1024, 1024);
        }

        void Update()
        {

        }

        private void CreateLayer(int width, int height)
        {
            Texture2D texture2D = new Texture2D(height, width);
            GameObject go = new GameObject("Layer " + paintLayers.Count, typeof(RectTransform), typeof(RawImage));
            RectTransform rectTransform = go.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(parentCanvas.pixelRect.width / 2, parentCanvas.pixelRect.height / 2);
            rectTransform.sizeDelta = new Vector2(layerCreartionSize.x, layerCreartionSize.y);
            go.transform.SetParent(transform);
            PaintLayer paintLayer = new PaintLayer(texture2D, go.GetComponent<RawImage>());
            paintLayer.SetColor(new Color(0, 0, 0, 1));
            paintLayers.Add(paintLayer);
        }
    }
}

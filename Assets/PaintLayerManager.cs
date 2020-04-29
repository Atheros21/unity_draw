using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace ATH
{
    public class PaintLayerManager : MonoBehaviour
    {
        [SerializeField] private Vector2Int layerCreartionSize;
        private List<PaintLayer> paintLayers = new List<PaintLayer>();
        private int selectedLayer = 0;
        private Canvas parentCanvas;
        [SerializeField] private Button saveTexture;
        void Start()
        {
            parentCanvas = GetComponentInParent<Canvas>();
            CreateLayer(layerCreartionSize.x, layerCreartionSize.y);
            saveTexture.onClick.AddListener(SaveTexture);
        }

        void Update()
        {

        }
        public PaintLayer GetActivePaintLayer()
        {
            return paintLayers[selectedLayer];
        }
        public void CreateLayer(int width, int height)
        {
            Texture2D texture2D = new Texture2D(height, width);
            GameObject go = new GameObject("Layer " + paintLayers.Count, typeof(RectTransform), typeof(RawImage));
            RectTransform rectTransform = go.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(parentCanvas.pixelRect.width / 2, parentCanvas.pixelRect.height / 2);
            rectTransform.sizeDelta = new Vector2(layerCreartionSize.x, layerCreartionSize.y);
            go.transform.SetParent(transform);
            go.transform.localScale = Vector3.one;
            PaintLayer paintLayer = new PaintLayer(texture2D, go.GetComponent<RawImage>());
            paintLayer.SetColor(new Color(0, 0, 0, 1));
            paintLayers.Add(paintLayer);
        }

        public void SaveTexture()
        {
            byte[] bytes = GetActivePaintLayer().GetTexture().EncodeToPNG();
            File.WriteAllBytes(Application.dataPath+"PaintedImage.png",bytes);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace ATH
{
    public class ColorPainter : MonoBehaviour
    {
        [SerializeField] private GameObject brushCursor;
        [SerializeField] private PaintLayerManager paintLayerManager;
        [SerializeField] private Vector2 brushCenter;
        [SerializeField] private InputAction mousePos;
        [SerializeField] private RectTransform paintRect;
        private ToolSettings toolSettings;

        private EventTrigger eventTrigger;
        private bool isCursorOverCanvas;
        private float strokeTimer = 0.05f;
        private float currentStrokeTimer = 0.1f;
        private void Start()
        {
            eventTrigger = GetComponent<EventTrigger>();

            EventTrigger.Entry mouseEnterCanvas = new EventTrigger.Entry();
            mouseEnterCanvas.eventID = EventTriggerType.PointerEnter;
            mouseEnterCanvas.callback.AddListener(delegate { MouseEnterCanvasAction(); });


            EventTrigger.Entry mouseExitCanvas = new EventTrigger.Entry();
            mouseExitCanvas.eventID = EventTriggerType.PointerExit;
            mouseExitCanvas.callback.AddListener(delegate { MouseExitCanvasAction(); });

            eventTrigger.triggers.Add(mouseEnterCanvas);
            eventTrigger.triggers.Add(mouseExitCanvas);

            mousePos.Enable();
        }

        private void Update()
        {
            if (isCursorOverCanvas)
            {
                brushCenter = mousePos.ReadValue<Vector2>();
                brushCursor.transform.position = new Vector3(brushCenter.x, brushCenter.y, 0);
                Vector2 paintPoint;
                RectTransformUtility.ScreenPointToLocalPointInRectangle(paintRect, brushCenter,null, out paintPoint);
                Vector2 normalizedPoint = Rect.PointToNormalized(paintRect.rect, paintPoint);
                if (Input.GetMouseButton(0))
                {
                    for (int i = (int)-toolSettings.Radius; i < toolSettings.Radius; i++)
                    {
                        for (int j = (int)-toolSettings.Radius; j < toolSettings.Radius; j++)
                        {
                            if (i * i + j * j < toolSettings.Radius * toolSettings.Radius)
                                paintLayerManager.GetActivePaintLayer().PaintPixel((int)(normalizedPoint.x*900) + i, (int)(normalizedPoint.y*900) + j, toolSettings.Color);
                        }
                    }

                    currentStrokeTimer = strokeTimer;
                    paintLayerManager.GetActivePaintLayer().ApplyChanges();
                }
            }
        }

        private void MouseEnterCanvasAction()
        {
            isCursorOverCanvas = true;
            Cursor.visible = false;
        }

        private void MouseExitCanvasAction()
        {
            isCursorOverCanvas = false;
            Cursor.visible = true;
        }

        public void SetToolSettingRef(ToolSettings toolSettings)
        {
            this.toolSettings = toolSettings;
        }
    }
}

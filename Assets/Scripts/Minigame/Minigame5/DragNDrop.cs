using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IDropHandler
{
    public event Action OnImageSnap;
    [SerializeField] private RectTransform endPoint;
    [SerializeField] private float snappingThreshold = 0.5f;
    private Vector2 distance;
    private RectTransform rectTransform;
    private bool isDragging = false;
    private bool isSnapped = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (!isSnapped)
        {
            Vector2 pointerPosition = Camera.main.ScreenToWorldPoint(eventData.position);
            Vector2 newObjectPosition = pointerPosition - distance;


            rectTransform.position = newObjectPosition;
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        distance = Camera.main.ScreenToWorldPoint(eventData.position) - transform.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        float distanceToEndPoint = Vector2.Distance(rectTransform.position, endPoint.position);
        Debug.Log(distanceToEndPoint);
        if (distanceToEndPoint < snappingThreshold)
        {
            rectTransform.position = endPoint.position;
            Debug.Log("snapped");
            isSnapped = true;
            OnImageSnap?.Invoke();
        }
    }
}

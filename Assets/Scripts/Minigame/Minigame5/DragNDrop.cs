using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IDropHandler
{
    [SerializeField] private RectTransform endPoint;
    private Vector2 distance;
    private RectTransform rectTransform;
    private bool isDragging = false;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    public void OnDrag(PointerEventData eventData)
    {

        Vector2 pointerPosition = Camera.main.ScreenToWorldPoint(eventData.position);
        Vector2 newObjectPosition = pointerPosition - distance;


        rectTransform.position = newObjectPosition;
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
        throw new System.NotImplementedException();
    }
}

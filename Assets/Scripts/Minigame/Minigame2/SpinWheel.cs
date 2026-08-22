using UnityEngine;
using UnityEngine.EventSystems;

public class SpinWheel : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    [SerializeField] private RectTransform wheel;
    [SerializeField] private BugClimb bugClimb;

    private bool isDragging;
    private float previousAngle;

    private void Start()
    {
        Debug.Log(wheel.position);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        previousAngle = GetMouseAngle(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;
        float currentAngle = GetMouseAngle(eventData);
        float angleDifference = Mathf.DeltaAngle(previousAngle, currentAngle);
        wheel.Rotate(0, 0, angleDifference);
        if (angleDifference < 0)
        {
            
            float spinAmount = Mathf.Abs(angleDifference);
            bugClimb.AddProgress(spinAmount);
        }

        previousAngle = currentAngle;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    private float GetMouseAngle(PointerEventData eventData)
    {
        Vector2 wheelCenter = RectTransformUtility.WorldToScreenPoint(eventData.pressEventCamera, wheel.position);

        Vector2 direction = eventData.position - wheelCenter;

        return Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
}
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class Horse : MonoBehaviour, IPointerClickHandler
{
    public event Action OnHorseSpanked;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Spanked");
        OnHorseSpanked?.Invoke();
    }
}

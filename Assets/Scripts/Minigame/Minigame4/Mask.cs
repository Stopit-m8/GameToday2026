using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mask : MonoBehaviour, IPointerClickHandler
{
    public event Action OnMaskClick;
    private bool maskActive = false;
    public void ActivateMask()
    {
        maskActive = true;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (maskActive)
        {
            OnMaskClick?.Invoke();
            Debug.Log("la piz");
        }
        
    }
}

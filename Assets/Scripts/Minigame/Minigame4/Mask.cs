using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Mask : MonoBehaviour, IPointerClickHandler
{
    public event Action OnMaskClick;
    private bool maskActive = false;
    [SerializeField] private TMP_Text clickMeText;
    [SerializeField] private float clickMeTimeShow;
    private float currTime;
    public void ActivateMask()
    {
        maskActive = true;
        StartCoroutine(ClickMeTextShow());
    }

    IEnumerator ClickMeTextShow()
    {
        while (maskActive)
        {
            Debug.Log("Ja lenis");
            currTime += Time.deltaTime;
            if (currTime >= clickMeTimeShow)
            {
                clickMeText.DOFade(1f, 1f);
                yield return new WaitForSeconds(1f);
                currTime = 0;
            }
            yield return null;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (maskActive)
        {
            OnMaskClick?.Invoke();
            clickMeText.DOFade(0f, 1f);
            Debug.Log("la piz");
        }
        
    }
}

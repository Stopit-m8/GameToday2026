using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mask : MonoBehaviour, IPointerClickHandler
{
    public event Action OnMaskClick;
    private bool maskActive = false;
    [SerializeField] private TMP_Text clickMeText;
    [SerializeField] private float clickMeTimeShow;
    [SerializeField] private Image mask;
    private Image people;
    private float currTime;

    private void Awake()
    {
        people = GetComponent<Image>();
    }

    public void ActivateMask()
    {
        maskActive = true;
        people.DOColor(Color.white, 1f);
        mask.DOColor(Color.white, 1f);
        StartCoroutine(ClickMeTextShow());
    }

    IEnumerator ActivateMaskCoroutine()
    {
        
        yield return new WaitForSeconds(1f);
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
            currTime = 0;
            transform.DOShakePosition(1f, 10, 10, 90, false, true, ShakeRandomnessMode.Full);
            clickMeText.DOFade(0f, 1f);
            Debug.Log("la piz");
        }
        
    }
}

using DG.Tweening;
using System;
using System.Collections;
using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mask : MonoBehaviour, IPointerClickHandler
{
    public event Action OnMaskClick;
    private bool maskActive = false;
    [SerializeField] private Transform[] hands;
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
            ShakeStuff();
            
            clickMeText.DOFade(0f, 1f);
            Debug.Log("la piz");
        }
        
    }

    private void ShakeStuff()
    {
        transform.DOShakePosition(1f, 10, 10, 90, false, true, ShakeRandomnessMode.Full);
        foreach (Transform t in hands)
        {
            t.DOShakePosition(1f, 10, 10, 90, false, true, ShakeRandomnessMode.Full);
        }
    }
}

using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Circle : MonoBehaviour, IPointerClickHandler
{
    public event Action<Circle> OnCircleClicked;
    private Image circle;
    [SerializeField] private float showTime;
    [SerializeField] private float stayTime;
    [SerializeField] private float hideTime;

    private void Awake()
    {
        circle = GetComponent<Image>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        OnCircleClicked?.Invoke(this);
        StopAllCoroutines();
        gameObject.SetActive(false);

    }

    private void OnEnable()
    {
        ShowCircle();
    }

    private void ShowCircle()
    {
        StartCoroutine(ShowCircleCoroutine());

    }

    IEnumerator ShowCircleCoroutine()
    {
        circle.DOFade(1f, showTime);
        yield return new WaitForSeconds(showTime + stayTime);
        circle.DOFade(0f, hideTime);
        yield return new WaitForSeconds(hideTime);
        gameObject.SetActive(false);
    }

}

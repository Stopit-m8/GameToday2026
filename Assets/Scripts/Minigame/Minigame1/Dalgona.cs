using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dalgona : MonoBehaviour
{
    public event Action<bool> OnDalgonaChecked;

    private Image image;
    [SerializeField] private MoldSO[] molds;

    [Header("Check Only")]
    [SerializeField] private MoldSO currmold;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnDisable()
    {
        DOTween.Kill(gameObject);

        GetComponent<Image>()?.DOKill();
        transform.DOKill();
    }

    private void ShowSprite()
    {
        image.sprite = currmold.sprite;
        image.DOFade(1f, 2f);
    }

    private void HideSprite()
    {
        image.DOFade(0f, 10f);
        Debug.Log("penis");
        gameObject.SetActive(false);
    }

    public void CheckDalgona(MoldSO mold)
    {
        bool success = currmold.moldType == mold.moldType;
        if (success)
        {
            Debug.Log("Dalgona and mold is the same");
        }
        else
        {
            Debug.Log("Dalgona breaks");
        }
        OnDalgonaChecked?.Invoke(success);
        HideSprite();
    }

    public void Initialize()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        currmold = molds[UnityEngine.Random.Range(0, molds.Length)];
        ShowSprite();
    }
}

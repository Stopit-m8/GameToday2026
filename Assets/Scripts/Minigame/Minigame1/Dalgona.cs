using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dalgona : MonoBehaviour
{
    public event Action<bool> OnDalgonaChecked;

    private Image image;
    [SerializeField] private GameObject moldObject;
    [SerializeField] private MoldSO[] molds;
    [SerializeField] private float fadeTime;

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
        image.DOFade(1f, fadeTime);
    }

    private void HideSprite()
    {
        image.DOFade(0f, fadeTime);
    }

    public void CheckDalgona(MoldSO mold)
    {
        StartCoroutine(CheckDalgonaCoroutine(mold));
    }

    IEnumerator CheckDalgonaCoroutine(MoldSO mold)
    {
        bool success = currmold.moldType == mold.moldType;
        moldObject.transform.position = new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z);

        moldObject.GetComponent<Image>().sprite = mold.sprite;
        moldObject.GetComponent<Image>().DOFade(1f, 0.3f);
        
        moldObject.transform.DOMove(transform.position, fadeTime/4);
        yield return new WaitForSeconds(fadeTime/4);
        if (success)
        {
            Debug.Log("Dalgona and mold is the same");
        }
        else
        {
            moldObject.transform.DOShakePosition(1f, 10f);
            Debug.Log("Dalgona breaks");
        }
        yield return new WaitForSeconds(fadeTime);
        HideSprite();
        moldObject.transform.DOMove(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), fadeTime / 4);
        moldObject.GetComponent<Image>().DOFade(0f, fadeTime);
        yield return new WaitForSeconds(fadeTime);
        gameObject.SetActive(false);
        OnDalgonaChecked?.Invoke(success);
    }

    public void Initialize()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        currmold = molds[UnityEngine.Random.Range(0, molds.Length)];
        ShowSprite();
    }

}

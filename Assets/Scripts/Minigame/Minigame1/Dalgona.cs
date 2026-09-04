using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Dalgona : MonoBehaviour
{
    public event Action<bool, bool> OnDalgonaChecked;
    public event Action OnDalgonaMCDone;

    private Image image;
    private bool mcDalgonaActive = false;
    private int currMCDalgona = 0;
    [SerializeField] private GameObject moldObject;
    [SerializeField] private MoldSO[] molds;
    [SerializeField] private MoldSO[] mcMolds;
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
        if (!mcDalgonaActive)
        {
            if (success)
            {
                ChangeAppearenceCut();
                Debug.Log("Dalgona and mold is the same");
            }
            else
            {

                moldObject.transform.DOShakePosition(1f, 10f);
                ChangeAppearenceCracked();
                Debug.Log("Dalgona breaks");
            }
            yield return new WaitForSeconds(fadeTime);
            HideSprite();
            moldObject.transform.DOMove(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), fadeTime / 4);
            moldObject.GetComponent<Image>().DOFade(0f, fadeTime);
            yield return new WaitForSeconds(fadeTime);
            gameObject.SetActive(false);
            OnDalgonaChecked?.Invoke(success, mcDalgonaActive);
        }
        else
        {
            if (!success)
            {
                moldObject.transform.DOShakePosition(1f, 10f);
                Debug.Log("Dalgona breaks");
                currMCDalgona++;
                image.sprite = mcMolds[currMCDalgona].sprite;
                if (currMCDalgona >= mcMolds.Length - 1)
                {
                    OnDalgonaMCDone?.Invoke();
                }
            }
            yield return new WaitForSeconds(fadeTime);
            moldObject.transform.DOMove(new Vector3(transform.position.x, transform.position.y + 3f, transform.position.z), fadeTime / 4);
            moldObject.GetComponent<Image>().DOFade(0f, fadeTime);
            yield return new WaitForSeconds(fadeTime);
            OnDalgonaChecked?.Invoke(success, mcDalgonaActive);
        }
    }

    public void ChangeAppearenceCut()
    {
        image.sprite = currmold.cuttedSprite;
    }

    public void ChangeAppearenceCracked()
    {
        image.sprite = currmold.crackedSprite;
    }

    public void Initialize()
    {
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        currmold = molds[UnityEngine.Random.Range(0, molds.Length)];
        ShowSprite();
    }

    public void InitializeMC()
    {
        mcDalgonaActive = true;
        image.color = new Color(image.color.r, image.color.g, image.color.b, 0f);
        currmold = mcMolds[0];
        ShowSprite();
    }

}

using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class Whip : MonoBehaviour
{
    [SerializeField] private float spankTime = 1f;
    [SerializeField] private Sprite spank;
    [SerializeField] private Sprite normal;
    private RectTransform rectTransform;
    [SerializeField] private Canvas canvas;
    private bool activeMinigame;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void SetCustomImage(Sprite image)
    {
        gameObject.GetComponent<Image>().sprite = image;
    }

    public void SetActiveMinigame(bool state)
    {
        activeMinigame = state;
    }

    private void Update()
    {
        if (activeMinigame)
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Mouse.current.position.ReadValue(), canvas.worldCamera, out Vector2 pos);

            rectTransform.anchoredPosition = pos;
        }
        
    }

    public void SpankHorse()
    {
        Debug.Log("Whip");
        StartCoroutine(SpankHorseCoroutine());
    }

    IEnumerator SpankHorseCoroutine()
    {
        SetCustomImage(spank);
        yield return new WaitForSeconds(spankTime);
        SetCustomImage(normal);
    }
}

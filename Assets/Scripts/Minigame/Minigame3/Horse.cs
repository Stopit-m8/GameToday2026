using UnityEngine.EventSystems;
using UnityEngine;
using System;
using UnityEngine.UI;

public class Horse : MonoBehaviour, IPointerClickHandler
{
    public event Action OnHorseSpanked;
    [SerializeField] private Sprite glitchSprite;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Spanked");
        OnHorseSpanked?.Invoke();
    }

    public void ChangeSprite()
    {
        gameObject.GetComponent<Image>().sprite = glitchSprite;
    }
}

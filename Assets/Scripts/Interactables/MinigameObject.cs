using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MinigameObject : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject notificationPlace;

    public void Interact()
    {
        Debug.Log("Object interacted");
        MinigameManager.instance.OpenMinigame();
    }

    public void OffFocus()
    {
        notificationPlace.SetActive(false);
    }

    public void OnFocus()
    {
        notificationPlace.SetActive(true);
    }
}

using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MinigameObject : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject notificationPlace;
    private bool hasInteracted = false;

    public void Interact()
    {
        if (hasInteracted)
        {
            return;
        }
        Debug.Log("Object interacted");
        MinigameManager.instance.OpenMinigame();
        OffFocus();
        hasInteracted = true;
    }

    public void OffFocus()
    {
        notificationPlace.SetActive(false);
    }

    public void OnFocus()
    {
        if (hasInteracted)
        {
            return;
        }
        notificationPlace.SetActive(true);
    }
}

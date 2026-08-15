using UnityEngine;

public class MinigameObject : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject notificationPlace;
    [SerializeField] private GameObject minigamePanel;

    public void Interact()
    {
        Debug.Log("Object interacted");
        minigamePanel.SetActive(true);
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

using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject notificationPlace;
    private PlayerInventory inventory;

    private void Awake()
    {
        inventory = FindFirstObjectByType<PlayerInventory>();
    }

    public void Interact()
    {
        inventory.GetKey();
        Destroy(gameObject);
        Debug.Log("Kontol");
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

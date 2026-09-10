using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class MinigameObjectV2 : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject notificationPlace;
    private bool hasInteracted = false;
    private PlayerInventory inventory;
    private MonologueTrigger monologueTrigger;

    private void Awake()
    {
        inventory = FindFirstObjectByType<PlayerInventory>();
        monologueTrigger = GetComponent<MonologueTrigger>();
    }

    public void Interact()
    {
        if (hasInteracted)
        {
            return;
        }
        if (inventory.GiveKey() > 0)
        {
            Debug.Log("Object interacted");
            MinigameManager.instance.OpenMinigame();
            OffFocus();
            hasInteracted = true;
        }
        else
        {
            monologueTrigger.TriggerMonologue();
        }
        
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

using UnityEngine;

public class InteractPlayer : MonoBehaviour
{
    private IInteractable interactableInRange;
    private Collider2D col;
    private PlayerInventory playerInventory;

    private void Awake()
    {
        playerInventory = GetComponent<PlayerInventory>();
        col = GetComponent<Collider2D>();
    }

    public void Interact()
    {
        interactableInRange?.Interact();
    }

    public void CantInteract(MonologueTrigger trigger)
    {
        trigger.TriggerMonologue();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable))
        {
            interactableInRange = interactable;
            interactableInRange.OnFocus();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out IInteractable interactable) && interactable == interactableInRange)
        {
            interactableInRange.OffFocus();
            interactableInRange = null;
        }
    }
}

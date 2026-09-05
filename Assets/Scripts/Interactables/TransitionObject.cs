using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionObject : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject notificationPlace;
    private PlayerInventory inventory;
    private InteractPlayer interactPlayer;
    private MonologueTrigger trigger;

    private void Awake()
    {
        trigger = GetComponent<MonologueTrigger>();
        inventory = FindFirstObjectByType<PlayerInventory>();
        interactPlayer = FindFirstObjectByType<InteractPlayer>();
    }

    public void Interact()
    {
        if (inventory.GiveKey() > 0)
        {
            inventory.DestroyKey();
            TransitionManager.instance.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            interactPlayer.CantInteract(trigger);
        }
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

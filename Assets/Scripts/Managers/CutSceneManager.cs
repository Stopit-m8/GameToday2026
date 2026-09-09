using System;
using UnityEngine;

public class CutSceneManager : MonoBehaviour
{
    [SerializeField] private DialogueSO[] dialogueSOs;
    private PlayerInventory inventory;
    [SerializeField] int keyCountToStart = 4;
    public event Action OnAllKeysCollected;

    private void Awake()
    {
        inventory = FindFirstObjectByType<PlayerInventory>();
        inventory.OnKeyCountChanged += CheckKeyCount;
    }

    private void CheckKeyCount(int key)
    {
        if (key == keyCountToStart)
        {
            DialogueManager.instance.OnDialogueEnd += Invoke;
        }
            PlayDialogue(key-1);
    }

    private void Invoke()
    {
        Debug.Log("toni gay");
        OnAllKeysCollected?.Invoke();
    }

    private void PlayDialogue(int dialogueIndex)
    {
        Debug.Log($"this is dialogue {dialogueIndex}");
        DialogueManager.instance.StartDialogue(dialogueSOs[dialogueIndex].dialogue);
    }
}

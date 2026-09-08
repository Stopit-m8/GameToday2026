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
            OnAllKeysCollected?.Invoke();
        }
        else
        {
            PlayDialogue(key-1);
        }
    }

    private void PlayDialogue(int dialogueIndex)
    {
        DialogueManager.instance.StartDialogue(dialogueSOs[dialogueIndex].dialogue);
    }
}

using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueSO dialogue;

    public void TriggerDialogue()
    {
        DialogueManager.instance.StartDialogue(dialogue.dialogue);
    }
}

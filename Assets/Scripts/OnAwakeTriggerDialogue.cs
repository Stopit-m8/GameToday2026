using System.Collections;
using UnityEngine;

public class OnAwakeTriggerDialogue : MonoBehaviour
{
    private DialogueTrigger dialogueTrigger;

    private void Awake()
    {
        dialogueTrigger = GetComponent<DialogueTrigger>();
    }

    private void Start()
    {

        StartCoroutine(StartCor());
    }

    IEnumerator StartCor()
    {
        yield return null;

        dialogueTrigger.TriggerDialogue();
    }
    
}

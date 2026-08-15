using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private Queue<DialogueLines> sentences;
    [SerializeField] private float typeSpeed;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    

    private void Start()
    {
        sentences = new Queue<DialogueLines>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        sentences.Clear();
        foreach (DialogueLines dialogueLines in dialogue.dialogueLines)
        {
            sentences.Enqueue(dialogueLines);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        Debug.Log(sentences.Count);
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        DialogueLines sentence = sentences.Dequeue();
        //StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence);
    }

    //IEnumerator TypeSentence(DialogueLines dialogueLine)
    //{
    //    textBoxDialogueArea.text = dialogueLine.line;
    //    textBoxDialogueArea.maxVisibleCharacters = 0;
    //    for (int i = 0; i <= dialogueLine.line.Length; i++)
    //    {
    //        textBoxDialogueArea.maxVisibleCharacters = i;
    //        yield return new WaitForSeconds(typeSpeed);
    //    }
    //}

    private void EndDialogue()
    {
        Debug.Log("End of conv");
    }
}

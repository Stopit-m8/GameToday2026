using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    private Queue<DialogueLines> sentences;
    [SerializeField] private TMP_Text textArea;
    [SerializeField] private Image leftSprite;
    [SerializeField] private Image rightSprite;
    private Sprite prevLeftSprite;
    private Sprite prevRightSprite;
    [SerializeField] private float typeSpeed;
    [SerializeField] private PlayerInput playerInput;

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
        foreach (var map in playerInput.actions.actionMaps)
        {
            map.Disable();
        }
        playerInput.actions.FindActionMap("Dialogue").Enable();
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
        DisplayImage(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence.sentence);
    }

    IEnumerator TypeSentence(DialogueLines dialogueLine)
    {
        textArea.text = dialogueLine.sentence;
        textArea.maxVisibleCharacters = 0;
        for (int i = 0; i <= dialogueLine.sentence.Length; i++)
        {
            textArea.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    private void DisplayImage(DialogueLines dialogueLine)
    {
        Sprite leftImage = dialogueLine.leftSprite;
        Sprite rightImage = dialogueLine.rightSprite;
        if (leftImage == null)
        {
            leftImage = prevLeftSprite;
        }
        else
        {
            prevLeftSprite = leftImage;
        }

        if (rightImage == null)
        {
            rightImage = prevRightSprite;
        }
        else
        {
            prevRightSprite = rightImage;
        }
        leftSprite.sprite = leftImage;
        rightSprite.sprite = rightImage;

        if (dialogueLine.onLeft)
        {
            //update opacity
        }
        else
        {
            //update opacity
        }
    }

    private void EndDialogue()
    {
        foreach (var map in playerInput.actions.actionMaps)
        {
            map.Disable();
        }
        playerInput.actions.FindActionMap("Player").Enable();
        Debug.Log("End of conv");
    }
}

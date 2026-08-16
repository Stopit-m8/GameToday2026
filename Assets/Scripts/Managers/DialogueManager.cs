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
    private Sprite prevLeftSprite;
    private Sprite prevRightSprite;

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text textArea;
    [SerializeField] private Image leftImage;
    [SerializeField] private Image rightImage;

    public bool isTyping { get; private set; }
    private float typeSpeed;
    [SerializeField] private float normalTypeSpeed;
    [SerializeField] private float fastTypeSpeed;
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
        typeSpeed = normalTypeSpeed;
    }

    public void SpeedType()
    {
        typeSpeed = fastTypeSpeed;
    }

    public void SlowType()
    {
        typeSpeed = normalTypeSpeed;
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
        nameText.text = sentence.name;
        DisplayImage(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log(sentence.sentence);
    }

    IEnumerator TypeSentence(DialogueLines dialogueLine)
    {
        isTyping = true;
        textArea.text = dialogueLine.sentence;
        textArea.maxVisibleCharacters = 0;
        for (int i = 0; i <= dialogueLine.sentence.Length; i++)
        {
            textArea.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeSpeed);
        }
        isTyping = false;
        SlowType();
    }

    private void DisplayImage(DialogueLines dialogueLine)
    {
        Sprite leftSprite = dialogueLine.leftSprite;
        Sprite rightSprite = dialogueLine.rightSprite;
        Image activeImage = dialogueLine.onLeft ? leftImage : rightImage;
        Image inactiveImage = dialogueLine.onLeft ? rightImage : leftImage;

        if (leftSprite == null)
        {
            leftSprite = prevLeftSprite;
        }
        else
        {
            prevLeftSprite = leftSprite;
        }

        if (rightSprite == null)
        {
            rightSprite = prevRightSprite;
        }
        else
        {
            prevRightSprite = rightSprite;
        }

        leftImage.sprite = leftSprite;
        rightImage.sprite = rightSprite;

        ChangeOpacity(activeImage, 1f);
        ChangeOpacity(inactiveImage, 0.5f);
    }

    private void ChangeOpacity(Image image, float opacity)
    {
        Color color = image.color;
        color.a = opacity;
        image.color = color;
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

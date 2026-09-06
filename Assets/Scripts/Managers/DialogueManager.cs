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
    private Image backGroundImage;
    private CanvasGroup backGroundCanvasGroup;
    private bool changeScene;
    private string sceneName;

    [SerializeField] private GameObject backGround;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text textArea;

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
        backGroundImage = backGround.GetComponent<Image>();
        backGroundCanvasGroup = backGround.GetComponent<CanvasGroup>();
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
        changeScene = dialogue.changeScene;
        sceneName = dialogue.sceneName;
        foreach (var map in playerInput.actions.actionMaps)
        {
            map.Disable();
        }
        playerInput.actions.FindActionMap("Dialogue").Enable();
        EnableGroup();

        sentences.Clear();
        foreach (DialogueLines dialogueLines in dialogue.dialogueLines)
        {
            sentences.Enqueue(dialogueLines);
        }
        DisplayNextSentence();
    }

    private void EnableGroup()
    {
        backGroundCanvasGroup.alpha = 1;
        backGroundCanvasGroup.interactable = true;
        backGroundCanvasGroup.blocksRaycasts = true;
    }

    private void DisableGroup()
    {
        backGroundCanvasGroup.alpha = 0;
        backGroundCanvasGroup.interactable = false;
        backGroundCanvasGroup.blocksRaycasts = false;
    }

    private void ChangeOpacity(Image image, float opacity)
    {
        Color color = image.color;
        color.a = opacity;
        image.color = color;
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
        Sprite bgImage = dialogueLine.background;

        if (bgImage == null)
        {
            ChangeOpacity(backGroundImage, 0f);
        }
        else
        {
            ChangeOpacity(backGroundImage, 1f);
        }

        backGroundImage.sprite = bgImage;
    }

    private void EndDialogue()
    {
        DisableGroup();
        foreach (var map in playerInput.actions.actionMaps)
        {
            map.Disable();
        }
        playerInput.actions.FindActionMap("Player").Enable();
        if (changeScene)
        {
            TransitionManager.instance.LoadScene(sceneName);
        }
        Debug.Log("End of conv");
    }
}

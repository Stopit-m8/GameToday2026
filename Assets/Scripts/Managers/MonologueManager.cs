using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MonologueManager : MonoBehaviour
{
    public static MonologueManager Instance;
    private Queue<MonologueLine> sentences;
    [SerializeField] private float typeSpeed;
    [SerializeField] private float showTime;
    [SerializeField] private TMP_Text text;
    [SerializeField] private CanvasGroup monologuePanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        sentences = new Queue<MonologueLine>();
    }

    private void ShowPanel()
    {
        monologuePanel.alpha = 1f;
        monologuePanel.blocksRaycasts = true;
        monologuePanel.interactable = true;
    }

    private void HidePanel()
    {
        monologuePanel.alpha = 0f;
        monologuePanel.blocksRaycasts = false;
        monologuePanel.interactable = false;
    }

    public void StartMonologue(Monologue monologue)
    {
        sentences.Clear();
        foreach (MonologueLine monologueLines in monologue.monologueLines)
        {
            sentences.Enqueue(monologueLines);   
        }
        ShowPanel();
        DisplayNextSentence();
    }

    private void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndMonologue();
            return;
        }
        StartCoroutine(DisplayNextSentenceCoroutine());
    }

    IEnumerator DisplayNextSentenceCoroutine()
    {
        MonologueLine sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
        Debug.Log("The other penis");
        yield return new WaitForSeconds(showTime);
        DisplayNextSentence();
        Debug.Log("penis");
    }

    IEnumerator TypeSentence(MonologueLine monologueLine)
    {
        text.text = monologueLine.sentence;
        text.maxVisibleCharacters = 0;
        for (int i = 0; i <= monologueLine.sentence.Length; i++)
        {
            text.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    private void EndMonologue()
    {
        HidePanel();
        Debug.Log("End of monologue");
    }
}

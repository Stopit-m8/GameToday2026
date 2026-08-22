using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;
    private IMinigame minigame;
    private CanvasGroup minigamePanel;
    [SerializeField] private GameObject minigameObject;
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
        minigamePanel = minigameObject.GetComponent<CanvasGroup>();
        minigame = minigameObject.GetComponent<IMinigame>();
    }

    public void OpenMinigame()
    {
        StartCoroutine(OpenMinigameCoroutine());
    }

    IEnumerator OpenMinigameCoroutine()
    {
        OpenPanel(minigamePanel);
        minigame.StartMinigame();
        yield return null;
        playerInput.actions.FindActionMap("Player").Disable();
    }

    public void FinishMinigame()
    {
        playerInput.actions.FindActionMap("Player").Enable();
        ClosePanel(minigamePanel);
    }

    private void ClosePanel(CanvasGroup panel)
    {
        panel.alpha = 0f;
        panel.interactable = false;
        panel.blocksRaycasts = false;
    }

    private void OpenPanel(CanvasGroup panel)
    {
        panel.alpha = 1f;
        panel.interactable = true;
        panel.blocksRaycasts = true;
    }
}

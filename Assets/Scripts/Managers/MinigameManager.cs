using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;
    private IMinigame minigame;
    private CanvasGroup minigamePanel;
    [SerializeField] private GameObject minigameObject;

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
        OpenPanel(minigamePanel);
        minigame.StartMinigame();
    }

    public void FinishMinigame()
    {
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

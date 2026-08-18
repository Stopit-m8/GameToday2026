using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;
    [SerializeField] private CanvasGroup minigamePanel;

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

    public void OpenMinigame()
    {
        OpenPanel(minigamePanel);
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

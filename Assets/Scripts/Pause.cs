using System.Xml.Serialization;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private CanvasGroup pausePanel;
    [SerializeField] private CanvasGroup settingPanel;
    private bool isPaused = false;

    private void RevealPanel(CanvasGroup panel)
    {
        panel.alpha = 1.0f;
        panel.interactable = true;
        panel.blocksRaycasts = true;
    }

    private void UnRevealPanel(CanvasGroup panel)
    {
        panel.alpha = 0f;
        panel.interactable = false;
        panel.blocksRaycasts = false;
    }

    public void OpenClosePause()
    {
        if (!isPaused)
        {
            RevealPanel(pausePanel);
            UnRevealPanel(settingPanel);
            isPaused = true;
        }
        else
        {
            UnRevealPanel(pausePanel);
            UnRevealPanel(settingPanel);
            isPaused = false;
        }
    }

    public void OpenCloseSetting()
    {
        if (settingPanel.alpha != 1f)
        {
            RevealPanel(settingPanel);
            UnRevealPanel(pausePanel);
        }
        else
        {
            UnRevealPanel(settingPanel);
            RevealPanel(pausePanel);
        }
    }

    public void BackToMainMenu()
    {
        TransitionManager.instance.LoadScene(0);
    }
}

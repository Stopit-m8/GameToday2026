using System.Xml.Serialization;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private CanvasGroup pausePanel;
    [SerializeField] private CanvasGroup settingPanel;
    private bool isPaused = false;

    private void PlayButtonSFX()
    {
        AudioManager.instance.PlaySFX(AudioManager.instance.Button);
    }

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
        PlayButtonSFX();
        
        if (!isPaused)
        {
            Time.timeScale = 0f;
            RevealPanel(pausePanel);
            UnRevealPanel(settingPanel);
            isPaused = true;
        }
        else
        {
            Time.timeScale = 1f;
            UnRevealPanel(pausePanel);
            UnRevealPanel(settingPanel);
            isPaused = false;
        }
    }

    public void OpenCloseSetting()
    {
        PlayButtonSFX();
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

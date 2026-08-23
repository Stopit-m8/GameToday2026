using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup mainMenuPanel;
    [SerializeField] private CanvasGroup settingPanel;
    [SerializeField] private CanvasGroup creditPanel;
    public void PlayGame()
    {
        Debug.Log("Play game");
        TransitionManager.instance.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenCloseSettings()
    {
        if (settingPanel.alpha == 1f)
        {
            ClosePanel(settingPanel);
            OpenPanel(mainMenuPanel);
        }
        else
        {
            ClosePanel(mainMenuPanel);
            OpenPanel(settingPanel);
        }
    }

    public void OpenCloseCredit()
    {
        if (creditPanel.alpha == 1f)
        {
            ClosePanel(creditPanel);
            OpenPanel(mainMenuPanel);
        }
        else
        {
            ClosePanel(mainMenuPanel);
            OpenPanel(creditPanel);
        }
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

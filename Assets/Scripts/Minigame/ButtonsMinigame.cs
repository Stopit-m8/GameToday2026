using UnityEngine;

public class ButtonsMinigame : MonoBehaviour
{
    [SerializeField] private GameObject MinigamePanel;

    public void CloseMinigame()
    {
        MinigamePanel.SetActive(false);
    }
}

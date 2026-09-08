using UnityEngine;

public class Minigame5 : MonoBehaviour, IMinigame
{
    private CutSceneManager cutSceneManager;

    private void Awake()
    {
        cutSceneManager = FindFirstObjectByType<CutSceneManager>();
        cutSceneManager.OnAllKeysCollected += StartMinigame;
    }

    public void StartMinigame()
    {
       MinigameManager.instance.OpenMinigame();
    }

    public void StopMinigame()
    {
        cutSceneManager.OnAllKeysCollected -= StartMinigame;
    }

    

    


}

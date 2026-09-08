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
        throw new System.NotImplementedException();
    }

    public void StopMinigame()
    {
        cutSceneManager.OnAllKeysCollected -= StartMinigame;
    }

    

    


}

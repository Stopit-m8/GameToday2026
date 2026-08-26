using UnityEngine;

public class Minigame4 : MonoBehaviour, IMinigame
{
    [SerializeField] private GameObject spawnArea;
    [SerializeField] private GameObject circlePrefab;
    public void StartMinigame()
    {
        throw new System.NotImplementedException();
    }

    public void StopMinigame()
    {
        MinigameManager.instance.FinishMinigame();
    }

    private void Initialize()
    {

    }

    public void SpawnCircle()
    {

    }
}

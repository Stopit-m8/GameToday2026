using UnityEngine;

public class Minigame5 : MonoBehaviour, IMinigame
{
    private PlayerInventory inventory;
    [SerializeField] int keyCountToStart = 4;

    public void StartMinigame()
    {
        throw new System.NotImplementedException();
    }

    public void StopMinigame()
    {
        throw new System.NotImplementedException();
    }

    private void Awake()
    {
        inventory = FindFirstObjectByType<PlayerInventory>();
        inventory.OnKeyCountChanged += CheckKeyCount;
    }

    private void CheckKeyCount(int key)
    {
        if (key == keyCountToStart)
        {
            StartMinigame();
        }
    }


}

using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public event Action<int> OnKeyCountChanged;
    private int hasKey = 0;

    private void Update()
    {
        Debug.Log($"hasKey =  {hasKey}");
    }

    public void GetKey()
    {
        hasKey++;
        OnKeyCountChanged?.Invoke(hasKey);
    }

    public int GiveKey()
    {
        return hasKey;
    }

    public void DestroyKey()
    {
        hasKey = 0;
    }
}

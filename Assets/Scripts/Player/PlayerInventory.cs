using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private bool hasKey = false;

    private void Update()
    {
        Debug.Log($"hasKey =  {hasKey}");
    }

    public void GetKey()
    {
        hasKey = true;
    }

    public bool GiveKey()
    {
        return hasKey;
    }

    public void DestroyKey()
    {
        hasKey = false;
    }
}

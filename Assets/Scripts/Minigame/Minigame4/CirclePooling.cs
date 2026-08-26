using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CirclePooling : MonoBehaviour
{
    private List<GameObject> pooledObjects = new();
    private int amountToPool = 10;
    [SerializeField] private GameObject circlePrefab;

    public void Initialize(RectTransform parent)
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(circlePrefab, parent.transform.position, Quaternion.identity, parent.transform);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeInHierarchy)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}

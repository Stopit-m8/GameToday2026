using UnityEngine;

public class Hands : MonoBehaviour
{
    private RectTransform[] handTransforms;
    private void Awake()
    {
        handTransforms = new RectTransform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            handTransforms[i] = transform.GetChild(i).GetComponent<RectTransform>();
        }
    }
}

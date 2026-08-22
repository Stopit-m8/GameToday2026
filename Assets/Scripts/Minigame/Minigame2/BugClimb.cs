using UnityEngine;

public class BugClimb : MonoBehaviour
{
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    [SerializeField] private float progressMultiplier = 0.001f;

    [Header("Read Only")]
    [SerializeField] private float progress;
    

    public void AddProgress(float spinAmount)
    {
        progress += spinAmount * progressMultiplier;
        progress = Mathf.Clamp01(progress);
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, progress);
    }
}
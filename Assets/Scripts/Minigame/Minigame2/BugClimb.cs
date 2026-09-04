using System;
using UnityEngine;
using UnityEngine.UI;

public class BugClimb : MonoBehaviour
{
    public event Action<bool> OnArriveStart;
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;
    [SerializeField] private Image ballImage;

    [SerializeField] private float progressMultiplier = 0.001f;

    [Header("Read Only")]
    [SerializeField] private float progress;

    private void TurnBall(float spinAmount)
    {
        ballImage.rectTransform.Rotate(0f, 0f, -spinAmount);
    }

    public void AddProgress(float spinAmount)
    {
        TurnBall(spinAmount);
        progress += spinAmount * progressMultiplier;
        progress = Mathf.Clamp01(progress);
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, progress);
        CheckProgress();
    }

    private void CheckProgress()
    {
        if (transform.position == endPoint.position)
        {
            OnArriveStart?.Invoke(true);
            return;
        }
        else
        {
            return;
        }
    }

    public void ResetProgress()
    {
        progress = 0f;
    }
}
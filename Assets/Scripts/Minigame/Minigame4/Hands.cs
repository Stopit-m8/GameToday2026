using DG.Tweening;
using UnityEngine;

public class Hands : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private RectTransform[] handTransforms;
    private Vector2[] points;
    private bool[] handMoved;

    private void Awake()
    {
        int childCount = transform.childCount;

        handTransforms = new RectTransform[childCount];
        points = new Vector2[childCount];
        handMoved = new bool[childCount];

        for (int i = 0; i < childCount; i++)
        {
            // The hand itself
            handTransforms[i] = transform
                .GetChild(i)
                .GetChild(0)
                .GetComponent<RectTransform>();

            // The target position
            RectTransform point = transform
                .GetChild(i)
                .GetChild(1)
                .GetComponent<RectTransform>();

            points[i] = point.anchoredPosition;
        }
    }

    public void MoveHand(int maskClicked, int maskLimit)
    {
        if (maskClicked >= maskLimit * 0.8f)
        {
            MoveHandToPoint(0);
        }
        else if (maskClicked >= maskLimit * 0.6f)
        {
            MoveHandToPoint(1);
        }
        else if (maskClicked >= maskLimit * 0.4f)
        {
            MoveHandToPoint(2);
        }
        else if (maskClicked >= maskLimit * 0.2f)
        {
            MoveHandToPoint(3);
        }
    }

    private void MoveHandToPoint(int index)
    {
        if (handMoved[index])
            return;

        handMoved[index] = true;

        handTransforms[index]
            .DOAnchorPos(points[index], 0.5f)
            .SetEase(Ease.OutQuad);
    }
}
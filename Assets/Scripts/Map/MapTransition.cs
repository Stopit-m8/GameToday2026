using Unity.Cinemachine;
using UnityEngine;

public class MapTransition : MonoBehaviour
{
    [SerializeField] private PolygonCollider2D mapBound;
    private CinemachineConfiner2D confiner;
    [SerializeField] private Direction dir;
    [SerializeField] private float addPos;

    enum Direction
    {
        Left,
        Right
    }

    private void Awake()
    {
        confiner = FindFirstObjectByType<CinemachineConfiner2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UpdatePlayerPosition(collision.gameObject);
            confiner.BoundingShape2D = mapBound;
        }
    }

    private void UpdatePlayerPosition(GameObject player)
    {
        Vector3 newPos = player.transform.position;
        switch (dir)
        {
            case Direction.Left:
                newPos.x -= addPos;
                break;
            case Direction.Right:
                newPos.x += addPos;
                break;
        }
        player.transform.position = newPos;
    }
}

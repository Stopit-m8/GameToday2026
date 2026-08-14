using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 Dir)
    {
        rb.linearVelocity = new Vector2(speed * Dir.normalized.x, rb.linearVelocityY);
    }
}

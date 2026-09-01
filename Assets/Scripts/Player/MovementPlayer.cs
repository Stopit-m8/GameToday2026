using UnityEngine;

public class MovementPlayer : MonoBehaviour, IMovement
{
    [SerializeField] private float speed;
    private Vector2 dir = new();
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 Dir)
    {
        dir = Dir;
        Debug.Log(rb.linearVelocityX);
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dir.x * speed, rb.linearVelocityY);
    }
}

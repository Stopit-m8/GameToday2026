using System.Collections;
using UnityEngine;

public class UnderwaterMovementPlayer : MonoBehaviour, IMovement
{
    private Vector2 direction;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float maxSpeed = 5f;
    private bool isStunned = false;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 dir)
    {
        direction = dir;
    }

    public void GetStunned(float stunnedTime)
    {
        StartCoroutine(GetStunnedCoroutine(stunnedTime));
    }

    IEnumerator GetStunnedCoroutine(float stunnedTime)
    {
        isStunned = true;
        yield return new WaitForSeconds(stunnedTime);
        isStunned = false;
    }

    private void FixedUpdate()
    {
        if (!isStunned)
        {
            if (direction != Vector2.zero)
            {
                rb.AddForce(direction.normalized * acceleration);
                rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, maxSpeed);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            Debug.Log("Player is stunned");
        }
    }
}

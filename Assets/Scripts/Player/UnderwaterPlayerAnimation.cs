using UnityEngine;

public class UnderwaterPlayerAnimation : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Rigidbody2D rb;
    private bool isLookingRight = true;

    private void Awake()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        animator.SetFloat("Velocity", Mathf.Abs(rb.linearVelocityX));
        SpriteFlip();
    }

    private void SpriteFlip()
    {
        if (rb.linearVelocityX < -0.0001f && isLookingRight)
        {
            spriteRenderer.flipY = true;
            isLookingRight = !isLookingRight;
        }
        else if (rb.linearVelocityX > 0.0001f && !isLookingRight)
        {
            spriteRenderer.flipY = false;
            isLookingRight = !isLookingRight;
        }
    }
}

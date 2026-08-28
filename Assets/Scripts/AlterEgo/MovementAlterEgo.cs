using System;
using System.Collections;
using UnityEngine;

public class MovementAlterEgo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 1;
    private bool isStunned = false;

    private Rigidbody2D rb;
    private Vector2 dir;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Stun(float stunTime)
    {
        StartCoroutine(StunCoroutine(stunTime));
    }

    IEnumerator StunCoroutine(float stunTime)
    {
        isStunned = true;
        yield return new WaitForSeconds(stunTime);
        isStunned = false;
    }

    private void Update()
    {
        dir = player.transform.position - transform.position;
    }

    private void FixedUpdate()
    {
        if (!isStunned)
        {
            rb.linearVelocity = new Vector2(dir.normalized.x * speed, dir.normalized.y * speed);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            Debug.Log("Is Stunned");
        }
        
        
    }
}

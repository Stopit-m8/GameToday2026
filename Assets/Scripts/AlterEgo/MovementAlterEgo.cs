using System;
using System.Collections;
using UnityEngine;

public class MovementAlterEgo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 1;
    private float currSpeed;
    private bool isStunned = false;

    private Rigidbody2D rb;
    private Vector2 dir;
    private MonologueAlterEgo monologueAlterEgo;

    private void Awake()
    {
        currSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        monologueAlterEgo = GetComponent<MonologueAlterEgo>();
        DialogueManager.instance.Ondialogue += Stop;
        DialogueManager.instance.OnDialogueEnd += StartAgain;
    }

    private void OnDisable()
    {
        DialogueManager.instance.Ondialogue -= Stop;
        DialogueManager.instance.OnDialogueEnd -= StartAgain;
    }

    private void Stop()
    {
        currSpeed = 0;
    }

    private void StartAgain()
    {
        currSpeed = speed;
    }

    public void Stun(float stunTime)
    {
        StartCoroutine(StunCoroutine(stunTime));
    }

    IEnumerator StunCoroutine(float stunTime)
    {
        isStunned = true;
        monologueAlterEgo.StartMonologue();
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
            rb.linearVelocity = new Vector2(dir.normalized.x * currSpeed, dir.normalized.y * currSpeed);
        }
        else
        {
            rb.linearVelocity = Vector2.zero;
            Debug.Log("Is Stunned");
        }
        
        
    }
}

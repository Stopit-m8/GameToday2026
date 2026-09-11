using System;
using System.Collections;
using UnityEngine;

public class MovementAlterEgo : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 1;
    private float currSpeed;
    private bool canMove = true;
    private bool isStunned = false;

    private Rigidbody2D rb;
    private Vector2 dir;
    private MonologueAlterEgo monologueAlterEgo;

    private void Awake()
    {
        currSpeed = speed;
        rb = GetComponent<Rigidbody2D>();
        monologueAlterEgo = GetComponent<MonologueAlterEgo>();
        
    }

    private void OnEnable()
    {
        DialogueManager.instance.Ondialogue += Stop;
        DialogueManager.instance.OnDialogueEnd += StartAgain;
        MinigameManager.instance.OnMinigameOpen += Stop;
    }

    private void OnDisable()
    {
        DialogueManager.instance.Ondialogue -= Stop;
        DialogueManager.instance.OnDialogueEnd -= StartAgain;
        MinigameManager.instance.OnMinigameOpen -= Stop;
    }

    private void Stop()
    {
        Debug.Log("stop");
        canMove = false;
        rb.linearVelocity = Vector2.zero;
    }

    private void StartAgain()
    {
        canMove = true;
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
        if (!canMove || isStunned)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        rb.linearVelocity = new Vector2(
            dir.normalized.x * currSpeed,
            dir.normalized.y * currSpeed
        );
    }
}

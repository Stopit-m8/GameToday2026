using System.Collections;
using UnityEngine;

public class StunAlterEgo : MonoBehaviour
{
    [SerializeField] private float stunTime = 0.5f;
    [SerializeField] private float stayInPlaceTime = 2f;
    [SerializeField] private float jumpScareTime = 0.5f;
    [SerializeField] private Transform[] TeleportPoint;
    [SerializeField] private CanvasGroup jumpscarePanel;
    private MovementAlterEgo movement;

    private void Awake()
    {
        movement = GetComponent<MovementAlterEgo>();
    }

    private void Stun(UnderwaterMovementPlayer player)
    {
        StartCoroutine(StunCoroutine(player));
    }

    IEnumerator StunCoroutine(UnderwaterMovementPlayer player)
    {
        jumpscarePanel.alpha = 1f;
        player.GetStunned(stunTime);
        yield return new WaitForSeconds(jumpScareTime);
        movement.Stun(stayInPlaceTime);
        //transform.position = TeleportPoint[Random.Range(0, TeleportPoint.Length)].position;
        jumpscarePanel.alpha = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.Scream);
            Stun(collision.GetComponent<UnderwaterMovementPlayer>());
        }
    }
}

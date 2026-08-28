using UnityEngine;

public class StunAlterEgo : MonoBehaviour
{
    [SerializeField] private float stunTime = 0.5f;
    [SerializeField] private float stayInPlaceTime = 2f;
    private MovementAlterEgo movement;

    private void Awake()
    {
        movement = GetComponent<MovementAlterEgo>();
    }

    private void Stun(UnderwaterMovementPlayer player)
    {
        player.GetStunned(stunTime);
        movement.Stun(stayInPlaceTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Stun(collision.GetComponent<UnderwaterMovementPlayer>());
        }
    }
}

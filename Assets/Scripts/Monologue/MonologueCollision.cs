using UnityEngine;

public class MonologueCollision : MonoBehaviour
{
    private MonologueTrigger trigger;

    private void Awake()
    {
        trigger = GetComponent<MonologueTrigger>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            trigger.TriggerMonologue();
            gameObject.SetActive(false);
        }
    }
}

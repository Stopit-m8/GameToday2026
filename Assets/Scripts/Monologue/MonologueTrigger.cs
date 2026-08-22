using UnityEngine;

public class MonologueTrigger : MonoBehaviour
{
    public MonologueSO monologue;

    private void TriggerMonologue()
    {
        MonologueManager.Instance.StartMonologue(monologue.monologue);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TriggerMonologue();
            gameObject.SetActive(false);
        }
    }
}

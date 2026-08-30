using UnityEngine;

public class MonologueTrigger : MonoBehaviour
{
    public MonologueSO monologue;

    public void TriggerMonologue()
    {
        MonologueManager.Instance.StartMonologue(monologue.monologue);
    }
}

using UnityEngine;
using UnityEngine.Playables;

public class Minigame2 : MonoBehaviour, IMinigame
{
    [SerializeField] private BugClimb bugClimb;
    private bool isFinished = false;
    [SerializeField] private PlayableDirector timeline;
    private MonologueTrigger monologueTrigger;
    public void StartMinigame()
    {
        bugClimb.ResetProgress();
        bugClimb.OnArriveStart += MinigameFinish;
    }

    private void Start()
    {
        monologueTrigger = GetComponent<MonologueTrigger>();
    }

    private void MinigameFinish(bool finishStatus)
    {
        if (finishStatus && !isFinished)
        {
            //StopMinigame();
            timeline.Play();
            isFinished = true;
        }
    }

    public void StopMinigame()
    {

        MinigameManager.instance.FinishMinigame();
        monologueTrigger.TriggerMonologue();
    }
}

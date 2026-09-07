using UnityEngine;
using UnityEngine.Playables;

public class Minigame2 : MonoBehaviour, IMinigame
{
    [SerializeField] private BugClimb bugClimb;
    private bool isFinished = false;
    [SerializeField] private PlayableDirector timeline;
    public void StartMinigame()
    {
        bugClimb.ResetProgress();
        bugClimb.OnArriveStart += MinigameFinish;
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
    }
}

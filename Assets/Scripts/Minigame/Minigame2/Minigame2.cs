using UnityEngine;

public class Minigame2 : MonoBehaviour, IMinigame
{
    [SerializeField] private BugClimb bugClimb;
    private bool isFinished = false;
    public void StartMinigame()
    {
        bugClimb.ResetProgress();
        bugClimb.OnArriveStart += MinigameFinish;
    }

    private void MinigameFinish(bool finishStatus)
    {
        if (finishStatus && !isFinished)
        {
            StopMinigame();
            isFinished = true;
        }
    }

    public void StopMinigame()
    {
        MinigameManager.instance.FinishMinigame();
    }
}

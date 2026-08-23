using UnityEngine;

public class Minigame2 : MonoBehaviour, IMinigame
{
    [SerializeField] private BugClimb bugClimb;
    public void StartMinigame()
    {
        bugClimb.ResetProgress();
        bugClimb.OnArriveStart += MinigameFinish;
    }

    private void MinigameFinish(bool finishStatus)
    {
        if (finishStatus)
        {
            StopMinigame();
        }
    }

    public void StopMinigame()
    {
        MinigameManager.instance.FinishMinigame();
        //spawn prefab
    }
}

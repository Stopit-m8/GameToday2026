using UnityEngine;

public class Minigame5 : MonoBehaviour, IMinigame
{
    [SerializeField] private DragNDrop dragNDrop;
    private int currSnap;
    private int currSnapMax = 4;
    public void StartMinigame()
    {
        dragNDrop.OnImageSnap += CountSnap;
    }

    public void StopMinigame()
    {
        dragNDrop.OnImageSnap -= CountSnap;
        TransitionManager.instance.LoadScene("EndingIlustrasiScene");
    }

    private void CountSnap()
    {
        currSnap++;
        if (currSnap+1 >= currSnapMax)
        {
            StopMinigame();
        }
    }
    

    


}

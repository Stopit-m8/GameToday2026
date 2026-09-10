using UnityEngine;

public class Minigame5 : MonoBehaviour, IMinigame
{
    [SerializeField] private DragNDrop[] dragNDrop;
    private int currSnap;
    private int currSnapMax = 4;
    public void StartMinigame()
    {
        for (int i = 0; i < dragNDrop.Length; i++)
        {
            dragNDrop[i].OnImageSnap += CountSnap;
        }
        
    }

    public void StopMinigame()
    {
        TransitionManager.instance.LoadScene("EndingIlustrasiScene");
    }

    private void CountSnap(DragNDrop obj)
    {
        obj.OnImageSnap -= CountSnap;
        currSnap++;
        Debug.Log($"currsnap = {currSnap}");
        if (currSnap >= currSnapMax)
        {
            StopMinigame();
        }
    }
    

    


}

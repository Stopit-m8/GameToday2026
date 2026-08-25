using UnityEngine;
using UnityEngine.UI;

public class Minigame3 : MonoBehaviour, IMinigame
{
    [SerializeField] private Slider progressSlider;
    [SerializeField] private float addedProgress;
    [SerializeField] private Horse horse;
    [SerializeField] private Whip whip;
    public void StartMinigame()
    {
        horse.OnHorseSpanked += HorseSpanked;
        whip.SetActiveMinigame(true);
        Cursor.visible = false;
    }

    public void HorseSpanked()
    {
        whip.SpankHorse();
        AddProgress();
    }

    private void AddProgress()
    {
        if (progressSlider.value >= progressSlider.maxValue)
        {
            StopMinigame();
            return;
        }
        progressSlider.value += addedProgress;
    }

    public void StopMinigame()
    {
        StopAllCoroutines();
        whip.SetActiveMinigame(false);
        Cursor.visible = true;
        horse.OnHorseSpanked -= HorseSpanked;
        MinigameManager.instance.FinishMinigame();
    }
}

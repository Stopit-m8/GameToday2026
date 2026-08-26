using UnityEngine;
using UnityEngine.UI;

public class Minigame3 : MonoBehaviour, IMinigame
{
    [SerializeField] private Slider progressSlider;
    [SerializeField] private float addedProgress;
    [SerializeField] private Horse horse;
    [SerializeField] private Whip whip;
    private bool hasGlitch = false;
    public void StartMinigame()
    {
        hasGlitch = false;
        horse.OnHorseSpanked += HorseSpanked;
        whip.SetActiveMinigame(true);
        Cursor.visible = false;
    }

    public void HorseSpanked()
    {
        whip.SpankHorse();
        AddProgress();
    }

    private void DoGlitch()
    {
        progressSlider.value = 75f;
        
        horse.ChangeSprite();

        hasGlitch = true;
    }

    private void AddProgress()
    {
        if (progressSlider.value >= progressSlider.maxValue)
        {
            if (!hasGlitch)
            {
                DoGlitch();
            }
            else
            {
                StopMinigame();
                return;
            }
                
        }
        else
        {
            progressSlider.value += addedProgress;
        }
            
    }

    public void StopMinigame()
    {
        StopAllCoroutines();
        whip.SetActiveMinigame(false);
        Cursor.visible = true;
        horse.OnHorseSpanked -= HorseSpanked;
        MinigameManager.instance.FinishMinigame();
        hasGlitch = true;
    }
}

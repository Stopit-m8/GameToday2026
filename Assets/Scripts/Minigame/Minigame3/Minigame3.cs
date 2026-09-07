using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class Minigame3 : MonoBehaviour, IMinigame
{
    [SerializeField] private Slider progressSlider;
    [SerializeField] private float addedProgress;
    [SerializeField] private Horse horse;
    [SerializeField] private Whip whip;
    [SerializeField] private CanvasGroup notification;
    [SerializeField] private float minSpawnTime;
    [SerializeField] private float maxSpawnTime;
    [SerializeField] private PlayableDirector timeline;
    private bool timeStart = false;
    private float spawnTimer = 0;
    private bool spankNow = false;
    //private bool hasGlitch = false;

    private void Update()
    {
        if (timeStart)
        {
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= Random.Range(minSpawnTime, maxSpawnTime))
            {
                ShowNotification(true);
            }
        }
    }

    private void ShowNotification(bool notificationActive)
    {
        if (notificationActive)
        {
            spankNow = true;
            notification.alpha = 1.0f;

        }
        else
        {
            spankNow = false;
            notification.alpha = 0f;
        }
    }

    public void StartMinigame()
    {
        //hasGlitch = false;
        timeStart = true;
        horse.OnHorseSpanked += HorseSpanked;
        whip.SetActiveMinigame(true);
        Cursor.visible = false;
    }

    public void HorseSpanked()
    {
        whip.SpankHorse();
        AddProgress();
    }

    //private void DoGlitch()
    //{
    //    progressSlider.value = 75f;
        
    //    horse.ChangeSprite();

    //    hasGlitch = true;
    //}

    private void AddProgress()
    {
        if (progressSlider.value >= progressSlider.maxValue)
        {
            //if (!hasGlitch)
            //{
            //    DoGlitch();
            //}
            timeline.Play();
                //StopMinigame();
                return;
                
        }
        if(spankNow)
        {
            progressSlider.value += addedProgress;
            ShowNotification(false);
            spawnTimer = 0;
        }
        else
        {
            progressSlider.value -= addedProgress;
        }
            
    }

    public void StopMinigame()
    {
        StopAllCoroutines();
        whip.SetActiveMinigame(false);
        Cursor.visible = true;
        horse.OnHorseSpanked -= HorseSpanked;
        MinigameManager.instance.FinishMinigame();
        //hasGlitch = true;
        timeStart = false;
    }
}

using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class Minigame4 : MonoBehaviour, IMinigame
{
    [SerializeField] private RectTransform spawnArea;
    [SerializeField] private int spawnTime;
    [SerializeField] private Mask mask;
    [SerializeField] private int circlesLimit;
    [SerializeField] private int maskLimit;
    [SerializeField] private Hands hands;
    [SerializeField] private PlayableDirector timeline;
    private CirclePooling pool;
    private int circleClicked = 0;
    private int maskClicked = 0;
    private bool minigameIsActive = false;

    private void Awake()
    {
        pool = GetComponent<CirclePooling>();
    }

    private void Start()
    {
        Initialize();
    }

    public void StartMinigame()
    {
        minigameIsActive = true;
        mask.OnMaskClick += MaskClicked;
        StartCoroutine(SpawnCircleCoroutine());
    }

    public void PlayTimeline()
    {
        timeline.Play();
    }

    public void StopMinigame()
    {
        StopAllCoroutines();
        minigameIsActive = false;
        MinigameManager.instance.FinishMinigame();
        TransitionManager.instance.LoadScene("Underwater");
    }

    private void Initialize()
    {
        pool.Initialize(spawnArea);
    }

    public void SpawnCircle()
    {
        GameObject obj = pool.GetPooledObject();
        if (obj != null)
        {
            obj.GetComponent<Circle>().OnCircleClicked += CircleClicked;
            obj.GetComponent<Circle>().OnCircleDisabled += UnsubFromCircle;
            float x = Random.Range(spawnArea.rect.xMin, spawnArea.rect.xMax);
            float y = Random.Range(spawnArea.rect.yMin, spawnArea.rect.yMax);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            obj.SetActive(true);
        }
    }

    private void UnsubFromCircle(Circle circle)
    {
        circle.OnCircleClicked -= CircleClicked;
        circle.OnCircleDisabled -= UnsubFromCircle;
    }

    IEnumerator SpawnCircleCoroutine()
    {
        while (minigameIsActive)
        {
            SpawnCircle();
            yield return new WaitForSeconds(spawnTime);
        }
        
        
    }

    private void CircleClicked(Circle circle)
    {
        circleClicked++;
        Debug.Log($"circle clicked = {circleClicked}");
        circle.OnCircleClicked -= CircleClicked;
        Debug.Log("Clicked: " + circle.gameObject.name);
        if (circleClicked >= circlesLimit)
        {
            StopAllCoroutines();
            StartMaskClick();
            return;
        }
        
    }

    private void MaskClicked()
    {
        maskClicked++;
        hands.MoveHand(maskClicked, maskLimit);
        Debug.Log($"mask clicked = {maskClicked}");
        if (maskClicked == maskLimit/2)
        {
            AudioManager.instance.PlaySFX(AudioManager.instance.Mask);
        }
        if (maskClicked >= maskLimit)
        {
            StopAllCoroutines();
            //StopMinigame();
            PlayTimeline();
            return;
        }
        
        
    }

    private void StartMaskClick()
    {
        pool.DisableAll();
        mask.ActivateMask();
    }
}

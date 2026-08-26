using System.Collections;
using UnityEngine;

public class Minigame4 : MonoBehaviour, IMinigame
{
    [SerializeField] private RectTransform spawnArea;
    [SerializeField] private int spawnTime;
    private CirclePooling pool;
    private int circleClicked = 0;
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
        StartCoroutine(SpawnCircleCoroutine());
    }

    public void StopMinigame()
    {
        StopAllCoroutines();
        minigameIsActive = false;
        MinigameManager.instance.FinishMinigame();
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
            float x = Random.Range(spawnArea.rect.xMin, spawnArea.rect.xMax);
            float y = Random.Range(spawnArea.rect.yMin, spawnArea.rect.yMax);
            obj.GetComponent<RectTransform>().anchoredPosition = new Vector2(x, y);
            obj.SetActive(true);
        }
        ;
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
        circle.OnCircleClicked -= CircleClicked;
        Debug.Log("Clicked: " + circle.gameObject.name);
        if (circleClicked >= 10)
        {
            StopAllCoroutines();
            //this will be replaced
            StopMinigame();
            return;
            //this will be replaced
        }
        circleClicked++;
        Debug.Log($"circle clicked = {circleClicked}");
    }
}

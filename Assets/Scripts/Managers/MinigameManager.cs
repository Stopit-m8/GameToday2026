using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;
    private IMinigame minigame;
    private CanvasGroup minigamePanel;
    private CutSceneManager cutSceneManager;

    [SerializeField] private GameObject minigameObject;
    [SerializeField] private PlayerInput playerInput;
    
    [SerializeField] private Transform spawnPoint;

    [SerializeField] private GameObject maskPrefab;
    [SerializeField] private Sprite maskSprite;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log("Scene loaded: " + scene.name);

        if (scene.buildIndex == 6)
        {
            cutSceneManager = FindFirstObjectByType<CutSceneManager>();

            if (cutSceneManager != null)
            {
                cutSceneManager.OnAllKeysCollected += OpenMinigame;
                Debug.Log($"cutsceneManager{cutSceneManager}");
            }
        }
    }

    private void Start()
    {
        minigamePanel = minigameObject.GetComponent<CanvasGroup>();
        minigame = minigameObject.GetComponent<IMinigame>();
    }

    public void OpenMinigame()
    {
        StartCoroutine(OpenMinigameCoroutine());
    }

    IEnumerator OpenMinigameCoroutine()
    {
        OpenPanel(minigamePanel);
        minigame.StartMinigame();
        yield return null;
        playerInput.actions.FindActionMap("Player").Disable();
    }

    public void FinishMinigame()
    {
        if (cutSceneManager != null)
        {
            cutSceneManager.OnAllKeysCollected -= OpenMinigame;
        }
        playerInput.actions.FindActionMap("Player").Enable();
        GameObject obj = Instantiate(maskPrefab, spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform);
        obj.GetComponent<SpriteRenderer>().sprite = maskSprite;
        ClosePanel(minigamePanel);
    }

    private void ClosePanel(CanvasGroup panel)
    {
        panel.alpha = 0f;
        panel.interactable = false;
        panel.blocksRaycasts = false;
    }

    private void OpenPanel(CanvasGroup panel)
    {
        panel.alpha = 1f;
        panel.interactable = true;
        panel.blocksRaycasts = true;
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Header("Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("Audio Clip BGM")]
    public AudioClip CutsceneEnding;
    public AudioClip CutsceneAwal;
    public AudioClip GameplayAkhir;
    public AudioClip Gameplay13;
    public AudioClip Gameplay4;
    public AudioClip MainMenu;

    [Header("Audio Clip SFX")]
    public AudioClip BeetleWalk;
    public AudioClip Button;
    public AudioClip CookiePan;
    public AudioClip DialogueBeep;
    public AudioClip Mask;
    public AudioClip Panel;
    public AudioClip PlacePuzzle;
    public AudioClip Scream;
    public AudioClip Swim;
    public AudioClip Walk;
    public AudioClip Crunch;
    public AudioClip Horse;
    public AudioClip Pop;
    public AudioClip Whip;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        musicSource.clip = MainMenu;
        musicSource.Play();
    }

    public void StopSFX()
    {
        sfxSource.Stop();
    }

    public void PlaySFX(AudioClip sfx)
    {
        sfxSource.PlayOneShot(sfx);
    }

    public void PauseSFX()
    {
        sfxSource.Pause();
    }

    public void UnPauseSFX()
    {
        sfxSource.UnPause();
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

        if (scene.buildIndex == 0)
        {
            musicSource.Stop();
            musicSource.clip = MainMenu;
            musicSource.Play();
        }
        if (scene.buildIndex == 1)
        {
            musicSource.Stop();
            musicSource.clip = CutsceneAwal;
            musicSource.Play();
        }
        if (scene.buildIndex == 2)
        {
            musicSource.Stop();
            musicSource.clip = Gameplay13;
            musicSource.Play();
        }
        if (scene.buildIndex == 5)
        {
            musicSource.Stop();
            musicSource.clip = Gameplay4;
            musicSource.Play();
        }
        if (scene.buildIndex == 6)
        {
            musicSource.Stop();
            musicSource.clip = GameplayAkhir;
            musicSource.Play();
        }
        if (scene.buildIndex == 7)
        {
            musicSource.Stop();
            musicSource.clip = CutsceneEnding;
            musicSource.Play();
        }
    }
}

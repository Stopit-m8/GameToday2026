using UnityEngine;

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
    public AudioClip GameplayAwal;
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

}

using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    [SerializeField] private Animator animator;
    private bool isTransitioning = false;

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

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(StartLoadScene(sceneIndex));
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(StartLoadScene(sceneName));
    }

    IEnumerator StartLoadScene(int sceneIndex)
    {
        Time.timeScale = 1f;
        if (!isTransitioning)
        {
            isTransitioning = true;
            animator.SetTrigger("FadeIn");

            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(sceneIndex);
            animator.SetTrigger("FadeOut");
            isTransitioning = false;
        }
        
    }

    IEnumerator StartLoadScene(string sceneName)
    {
        if (!isTransitioning)
        {
            isTransitioning = true;

            animator.SetTrigger("FadeIn");

            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(sceneName);
            animator.SetTrigger("FadeOut");
            isTransitioning = false;
        }
        
    }
}

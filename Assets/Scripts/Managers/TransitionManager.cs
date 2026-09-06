using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionManager : MonoBehaviour
{
    public static TransitionManager instance;
    [SerializeField] private Animator animator;

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
        animator.SetTrigger("FadeIn");
        
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneIndex);
        animator.SetTrigger("FadeOut");
    }

    IEnumerator StartLoadScene(string sceneName)
    {
        animator.SetTrigger("FadeIn");

        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
        animator.SetTrigger("FadeOut");
    }
}

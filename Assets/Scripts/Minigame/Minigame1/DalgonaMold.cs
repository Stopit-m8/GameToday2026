using UnityEngine;
using UnityEngine.UI;

public class DalgonaMold : MonoBehaviour
{
    private Image image;
    [SerializeField] private Minigame1 minigame;
    [SerializeField] private MoldSO moldSO;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Start()
    {
        image.sprite = moldSO.sprite;
    }
    public void DeployMold()
    {
        Debug.Log($"Send {moldSO.moldType}");
        minigame.CheckDalgonaWithMold(moldSO);
    }
}

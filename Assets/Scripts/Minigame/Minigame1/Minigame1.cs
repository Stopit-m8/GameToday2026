using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1 : MonoBehaviour, IMinigame
{
    [SerializeField] private GameObject dalgonaPrefab;
    [SerializeField] private Transform dalgonaSpawnPoint;
    private GameObject currDalgona;
    private int currSuccess = 0;

    public void StartMinigame()
    {
        SpawnDalgona();
        currSuccess = 0;
        currDalgona.GetComponent<Dalgona>().OnDalgonaChecked += DalgonaChecked;
    }

    public void StopMinigame()
    {
        foreach (Transform child in dalgonaSpawnPoint)
        {
            child.gameObject.SetActive(false);
        }
        currDalgona = null;
        currDalgona.GetComponent<Dalgona>().OnDalgonaChecked -= DalgonaChecked;
        MinigameManager.instance.FinishMinigame();
    }

    private void SpawnDalgona()
    {
        if (dalgonaSpawnPoint.childCount <= 0)
        {
            GameObject dalgona = Instantiate(dalgonaPrefab, dalgonaSpawnPoint.position, Quaternion.identity, dalgonaSpawnPoint);
            dalgona.GetComponent<Dalgona>().Initialize();
            currDalgona = dalgona;
        }
        else if(!dalgonaSpawnPoint.GetChild(0).gameObject.activeInHierarchy)
        {
            GameObject dalgona = dalgonaSpawnPoint.GetChild(0).gameObject;
            dalgona.SetActive(true);
            dalgona.GetComponent<Dalgona>().Initialize();
            currDalgona = dalgona;
        }
        
    }

    private void DalgonaChecked(bool success)
    {
        if (success)
        {
            currSuccess++;
            Debug.Log($"Manager received success = {currSuccess}");
        }
        else
        {
            Debug.Log("Manager received failure");
        }

        SpawnDalgona();
    }

    public void CheckDalgonaWithMold(MoldSO mold)
    {
        currDalgona.GetComponent<Dalgona>().CheckDalgona(mold);
        SpawnDalgona();
    }
}

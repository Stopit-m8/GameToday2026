using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Minigame1 : MonoBehaviour, IMinigame
{
    [SerializeField] private TMP_Text successText;
    [SerializeField] private GameObject dalgonaPrefab;
    [SerializeField] private Transform dalgonaSpawnPoint;
    [SerializeField] private int maxSuccess;
    private GameObject currDalgona;
    private GameObject currMold;
    private int currSuccess = 0;

    public void StartMinigame()
    {
        SpawnDalgona();
        currSuccess = 0;
        UpdateUI();
        currDalgona.GetComponent<Dalgona>().OnDalgonaChecked += DalgonaChecked;
    }

    public void StopMinigame()
    {
        foreach (Transform child in dalgonaSpawnPoint)
        {
            child.gameObject.SetActive(false);
        }
        currDalgona.GetComponent<Dalgona>().OnDalgonaChecked -= DalgonaChecked;
        currDalgona = null;
        currMold = null;
        
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
        currMold = currDalgona.transform.GetChild(0).gameObject;
        
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
        UpdateUI();
        if (CheckSuccess() == false)
        {
            SpawnDalgona();
        }
        else
        {
            StopMinigame();

        }
        
    }

    private bool CheckSuccess()
    {
        if (currSuccess >= maxSuccess)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void UpdateUI()
    {
        successText.text = $"Success {currSuccess}/{maxSuccess}";
    }

    public void CheckDalgonaWithMold(MoldSO mold)
    {
        currDalgona.GetComponent<Dalgona>().CheckDalgona(mold);
        
    }
}

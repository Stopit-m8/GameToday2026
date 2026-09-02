using DG.Tweening;
using System.Collections;
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
    private bool canPress = true;

    public void StartMinigame()
    {
        SpawnDalgona();
        currSuccess = 0;
        UpdateUI();
        currDalgona.GetComponent<Dalgona>().OnDalgonaChecked += DalgonaChecked;
        currDalgona.GetComponent<Dalgona>().OnDalgonaMCDone += StopMinigame;
    }

    IEnumerator StopMinigameCoroutine()
    {
        yield return new WaitForSeconds(4.5f);
        foreach (Transform child in dalgonaSpawnPoint)
        {
            child.gameObject.SetActive(false);
        }
        currDalgona.GetComponent<Dalgona>().OnDalgonaChecked -= DalgonaChecked;
        currDalgona.GetComponent<Dalgona>().OnDalgonaMCDone -= StopMinigame;
        currDalgona = null;
        currMold = null;

        MinigameManager.instance.FinishMinigame();
    }

    public void StopMinigame()
    {
        Debug.Log("ts works");
        StartCoroutine(StopMinigameCoroutine());
        
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

    private void DalgonaChecked(bool success, bool mcDalgonaActive)
    {
        if (!mcDalgonaActive)
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
                SpawnMCDalgona();

            }
        }
        canPress = true;
    }

    private void SpawnMCDalgona()
    {
        if (dalgonaSpawnPoint.childCount <= 0)
        {
            GameObject dalgona = Instantiate(dalgonaPrefab, dalgonaSpawnPoint.position, Quaternion.identity, dalgonaSpawnPoint);
            dalgona.GetComponent<Dalgona>().InitializeMC();
            currDalgona = dalgona;
        }
        else if (!dalgonaSpawnPoint.GetChild(0).gameObject.activeInHierarchy)
        {
            GameObject dalgona = dalgonaSpawnPoint.GetChild(0).gameObject;
            dalgona.SetActive(true);
            dalgona.GetComponent<Dalgona>().InitializeMC();
            currDalgona = dalgona;
        }
        currMold = currDalgona.transform.GetChild(0).gameObject;
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
        if (canPress)
        {
            currDalgona.GetComponent<Dalgona>().CheckDalgona(mold);
            canPress = false;
        }
        
        
    }
}

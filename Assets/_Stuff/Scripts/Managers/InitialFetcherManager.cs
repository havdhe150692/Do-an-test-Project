using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects.ToadStatus;
using _Stuff.Scripts.UI.ToadTabList;
using UnityEngine;

public class InitialFetcherManager : MonoBehaviour
{
    private bool[] initialLoaderDoneList;
    private bool isAllDone = true;

    [SerializeField] private GameObject loadingScene;
    private int numberOfBool = 3;

    [SerializeField] public PlayerDataFetcher PlayerDataFetcher;
    [SerializeField] public ToadListFetcher toadListFetcher;
    [SerializeField] public ToadStatusFetcher toadStatusFetcher;
  //  [SerializeField] private Chain_MoneyFetcher
    //[SerializeField] private InventoryFetcher inventoryFetcher;
    
    //Boolean list of inital data fetcher
    // 0 =  User Basic Data
    // 1 =  User Total Toad List
    // 2 = Toad Status List


    public void Awake()
    {
        initialLoaderDoneList = new bool[numberOfBool];
    }

    public void DoneSetUpAtIndex(int index)
    {
        initialLoaderDoneList[index] = true;
        if(index == 0)
        {
            if (!CheckIfIsNewPlayer())
            {
                toadListFetcher.gameObject.SetActive(true);
               // toadStatusFetcher.gameObject.SetActive(true);
            }
            else
            {
                DisableLoadingSceneAndPlayGame();
            }
        }
        CheckAllDone();
    }

    public bool CheckIfIsNewPlayer()
    {
        var c = TotalManager.Instance.dataManager.isNewPlayer;
        if(c)
        {
            TotalManager.Instance.newPlayerManager.gameObject.SetActive(true);
        }
        else
        {
            TotalManager.Instance.newPlayerManager.gameObject.SetActive(false);
        }

        return c;
    }
    
    
    private void CheckAllDone()
    {
        foreach (var a in initialLoaderDoneList)
        {
            isAllDone = isAllDone && a;
        }

        if (isAllDone)
        {
            DisableLoadingSceneAndPlayGame();
            //TEST UiToadPlacement
           //TotalManager.Instance.uiManager.uiToadPlacement.InitialSetup();
           // TotalManager.Instance.uiManager.toadDisplayTab.SetUpToadList();
       
        }
        else
        {
            isAllDone = true;
        }
    }

    public void DisableLoadingSceneAndPlayGame()
    {
        //TotalManager.Instance.newPlayerManager.gameObject.SetActive(true);
        loadingScene.SetActive(false);
        
    }
}

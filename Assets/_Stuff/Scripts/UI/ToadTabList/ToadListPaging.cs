using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using _Stuff.Scripts.UI.ToadTabList;
using UnityEngine;
using UnityEngine.UI;

public class ToadListPaging : MonoBehaviour
{
    private List<ToadInfoData> allToadData => TotalManager.Instance.dataManager.listData;
    private int numberOfPage => (allToadData.Count + 6 - 1) / 6;
    private int currentPage;

    [SerializeField] public ToadListDisplayPage displaypage;
    //[SerializeField] private ToadListFetcher fetcher;


    [SerializeField] private Button nextButton;
    [SerializeField] private Button lastButton;

    private void Awake()
    {
        nextButton.onClick.AddListener(NextPage);
        lastButton.onClick.AddListener(LastPage);
    }

    private void Start()
    {
        StartPage();
        foreach (var VARIABLE in allToadData)
        {
            Debug.Log(VARIABLE.ToString());
        }
    }

    public void SetUpData()
    {
        StartPage();
    }

    private void StartPage()
    {
        currentPage = 1;
        displaypage.FetchData(currentPage);
        lastButton.interactable = false;
        if (currentPage == numberOfPage)
        {
            nextButton.interactable = false;
        }
        //fetcher.GetAllToadOfThisPage(currentPage);
    }

    private void NextPage()
    {
        currentPage++;
        if (currentPage > numberOfPage)
        {
            currentPage = numberOfPage;
        }

        if (currentPage == numberOfPage)
        {
            nextButton.interactable = false;
        }
        displaypage.FetchData(currentPage);
        
        if (currentPage > 1)
        {
            lastButton.interactable = true;
        }
     
        //fetcher.GetAllToadOfThisPage(currentPage);
    }

    private void LastPage()
    {
        currentPage--;
        if (currentPage < 1)
        {
            currentPage = 1; 
        }

        if (currentPage == 1)
        {
            lastButton.interactable = false;
        }
        if (currentPage < numberOfPage)
        {
            nextButton.interactable = true;
        }
        displaypage.FetchData(currentPage);
        
        //fetcher.GetAllToadOfThisPage(currentPage);
    }


}

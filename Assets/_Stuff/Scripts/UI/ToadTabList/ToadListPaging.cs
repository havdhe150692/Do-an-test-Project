using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using _Stuff.Scripts.UI.ToadTabList;
using UnityEngine;
using UnityEngine.UI;

public class ToadListPaging : MonoBehaviour
{
 
    private int numberOfPage;
    private int currentPage;


    private List<ToadListJson> allToadJson;
    [SerializeField] public ToadListDisplayPage displaypage;
    //[SerializeField] private ToadListFetcher fetcher;


    [SerializeField] private Button nextButton;
    [SerializeField] private Button lastButton;

    private void Awake()
    {
        nextButton.onClick.AddListener(NextPage);
        lastButton.onClick.AddListener(LastPage);
    }


    public void ReceiveFromJson(List<ToadListJson> toadjsonList)
    {
        allToadJson = toadjsonList;
        numberOfPage = (allToadJson.Count + 6 - 1) / 6;
    }

    private void Start()
    {
        StartPage();
        foreach (var VARIABLE in allToadJson)
        {
            Debug.Log(VARIABLE.ToString());
        }
    }

    private void StartPage()
    {
        currentPage = 1;
        displaypage.FetchData(allToadJson, currentPage);
        lastButton.interactable = false;
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
        displaypage.FetchData(allToadJson, currentPage);
        
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
        displaypage.FetchData(allToadJson, currentPage);
        
        //fetcher.GetAllToadOfThisPage(currentPage);
    }


}

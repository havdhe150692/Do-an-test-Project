using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using _Stuff.Scripts.UI.ToadTabList;
using UnityEngine;
using UnityEngine.UI;

public class UiToadBreedingList : MonoBehaviour
{
    public int currentSelectionPointing;
    private List<ToadStatusCheck> allToadData;
    private int numberOfPage => (TotalManager.Instance.dataManager.listData.Count + 6 - 1) / 6;
    private int currentPage;

    [SerializeField] public ToadListDisplayPage displaypage;
    //[SerializeField] private ToadListFetcher fetcher;


    [SerializeField] private Button nextButton;
    [SerializeField] private Button lastButton;
    [SerializeField] private Button exitBtn;
    [SerializeField] private GameObject totalBoard;
    private void Awake()
    {
        nextButton.onClick.AddListener(NextPage);
        lastButton.onClick.AddListener(LastPage);
        exitBtn.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        totalBoard.gameObject.SetActive(false);
    }

    private void Start()
    {
        StartPage();
    }

    private void OnEnable()
    {
        StartPage();
    }

    public void SetUpData(int currentSelectionPointing)
    {
        this.currentSelectionPointing = currentSelectionPointing;
        //TotalManager.Instance.dataManager.CheckIfBreedable();
        //allToadData = TotalManager.Instance.dataManager.breedList;
        StartPage();
    }

    private void StartPage()
    {
        currentPage = 1;
        displaypage.FetchData(currentPage);
        lastButton.interactable = false;
        Debug.Log("UiToadBreedingList ====");
        if (currentPage == numberOfPage)
        {
            nextButton.interactable = false;
        }
        else
        {
            nextButton.interactable = true;
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

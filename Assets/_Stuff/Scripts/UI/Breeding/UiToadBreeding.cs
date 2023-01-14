using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiToadBreeding : MonoBehaviour
{
    [SerializeField] private Button btnExit;
    [SerializeField] private Text rarityDisplay;
    [SerializeField] private Button btnBreed;
    [SerializeField] private Button btnCheckRarity;
    [SerializeField] private Text fullToad;
    
    [SerializeField] public UiToadBreedingList UiToadBreedingList;
    [SerializeField] public GameObject uiToadBreedingListGameObj;
    [SerializeField] public UiToadBreedingSelection selection1;
    [SerializeField] public UiToadBreedingSelection selection2;

    private bool isOpening = false;
    private void Awake()
    {
        btnExit.onClick.AddListener(OnClickBtnExit);
        btnCheckRarity.onClick.AddListener(OnClickBtnCheckRarity);
        btnBreed.onClick.AddListener(OnClickBtnBreed);
    }

    private void OnClickBtnExit()
    {
        this.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isOpening)
        {
            if (TotalManager.Instance.dataManager.listData.Count >= 10)
            {
                fullToad.text = "You reached the number of toad limit";
                fullToad.gameObject.SetActive(true);
                btnBreed.interactable = false;
                btnCheckRarity.interactable = false;
            }
            else
            {
               if((selection1.globalId == -1)||(selection2.globalId == -1))
               {
                   btnBreed.interactable = false; 
                   btnCheckRarity.interactable = false;
               }
               else 
               {
                   if ((TotalManager.Instance.dataManager.toadInfos[selection1.globalId].isBreedable == false) ||
                       (TotalManager.Instance.dataManager.toadInfos[selection2.globalId].isBreedable == false)) 
                   { 
                       fullToad.text = "Some toads can't be breeding now"; 
                       fullToad.gameObject.SetActive(true); 
                       btnBreed.interactable = false;
                       
                       Debug.Log("selection1 = " + selection1.name + " " + "selection2 = " +selection2.name);
                   }
                   else 
                   { 
                       btnCheckRarity.interactable = true; 
                       fullToad.gameObject.SetActive(false); 
                       btnBreed.interactable = true;
                       
                   }
               }
            }
           

         
        }

    }

    private void OnEnable()
    {
        isOpening = true;
        //TotalManager.Instance.dataManager.isToadBreedingSelectionBoard = true;

    }

    private void OnDisable()
    {
     
        selection1.globalId = -1;
        selection2.globalId = -1;
    }

    public void OnClickBtnCheckRarity()
    {
        string rarity1 = selection1.GetRarity();
        string rarity2 = selection2.GetRarity();

        string result = TotalManager.Instance.dynamicFetcherManager.toadGenerationFetcher.RequestCheckRarity(rarity1, rarity2);


    }

    public void SetRarityText(string txt)
    {
        rarityDisplay.gameObject.SetActive(true);
        rarityDisplay.text = txt;
    }


    public void OnClickBtnBreed()
    {
        string rarity1 = selection1.GetRarity();
        string rarity2 = selection2.GetRarity();

        int id1 = selection1.GetId();
        int id2 = selection2.GetId();
        
        TotalManager.Instance.dynamicFetcherManager.toadGenerationFetcher.RequestBreedToad(id1, id2);

       // DO SMTHING
    }
}

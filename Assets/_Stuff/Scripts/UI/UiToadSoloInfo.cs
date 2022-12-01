using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using UnityEngine;
using UnityEngine.UI;

public class UiToadSoloInfo : MonoBehaviour
{
    [SerializeField] public Button btnExit;
    [SerializeField] public GameObject totalBoard;
    [SerializeField] public Button btnGoTo;
    [SerializeField] public Button btnBreed;
    [SerializeField] public Button btnMarket;

    [SerializeField] public Text name;
    [SerializeField] public Text rarity;
    [SerializeField] public Text info;
    [SerializeField] public Text dOb;
    [SerializeField] public Text toadClass;
    [SerializeField] public Image image;


    private void Start()
    {
        btnExit.onClick.AddListener(TurnOffBoard);
    }
    
    private void TurnOffBoard()
    {
        totalBoard.SetActive(false);
    }

    public void ShowBoardAndDetail(int toadGlobalId)
    {
        TotalManager.Instance.dynamicFetcherManager.toadSoloDetailFetcher.GetDetailOfToad(toadGlobalId);
        totalBoard.SetActive(true);
    }

    public void ReceiveFromJson(ToadDetailJson toadDetailJson)
    {
        name.text = toadDetailJson.name;
        rarity.text = toadDetailJson.rarity.ToString();
        info.text = toadDetailJson.info;
        dOb.text = toadDetailJson.dateOfBirth;
        toadClass.text = toadDetailJson.toadClass;
        
    }
}

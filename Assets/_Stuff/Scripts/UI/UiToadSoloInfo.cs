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

    [SerializeField] public Text typeCounter;
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

    public void ShowBoardAndDetail(int indexId)
    {
        //TotalManager.Instance.dataManager.listData.
        var obj = TotalManager.Instance.dataManager.listData[indexId];
        ReceiveFromJson(obj);
        totalBoard.SetActive(true);
        image.sprite = TotalManager.Instance.dataManager.imagesSource.spriteList[obj.dataId -1];
    }

    public void ReceiveFromJson(ToadInfoData toadInfoData)
    {
        name.text = toadInfoData.name + " " + "#" + toadInfoData.typeCounter.ToString();

        DisplayRarityText(rarity, toadInfoData.rarity);
        info.text = toadInfoData.info;
        dOb.text = toadInfoData.dob.ToString();
        toadClass.text = toadInfoData.toadClass;
   //     typeCounter.text = "#" + toadInfoData.typeCounter.ToString();
    }
    
    void DisplayRarityText(Text rarityText, ToadInfo.Rarity value)
    {
        switch (value)
        {
            case ToadInfo.Rarity.Common: 
                rarityText.color = new Color32(9, 87, 22, 255);
                
                break;
            case ToadInfo.Rarity.Rare:
                rarityText.color = new Color32(3, 177, 252, 255);
                break;
            case ToadInfo.Rarity.Epic:
                rarityText.color = new Color32(230, 223, 3, 255);
                break;
            case ToadInfo.Rarity.Mythical:
                rarityText.color = new Color32(148, 3, 252, 255);
                break;
            case ToadInfo.Rarity.Legendary:
                rarityText.color = new Color32(252, 3, 45,255);
                break;
        }
        rarityText.text = value.ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using _Stuff.Scripts.UI.ToadTabList;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiToadBreedingSelection : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private int number;
    [SerializeField] private Text name;
    [SerializeField] private Text rarity;
    [SerializeField] private Image image;
    [SerializeField] private Text typeCounter;
    [SerializeField] public int globalId = -1;
    private int indexId;


    public void ChangeDataFromJson(ToadInfoData toadInfoData, int indexId)
    {
        name.text = toadInfoData.name + " " + "#" + toadInfoData.typeCounter.ToString();
        DisplayRarityText(rarity, toadInfoData.rarity);
       
        globalId = toadInfoData.globalId;
//        typeCounter.text = toadInfoData.typeCounter.ToString();
        this.indexId = indexId;
        this.image.sprite = TotalManager.Instance.dataManager.imagesSource.spriteList[toadInfoData.dataId - 1];
      //  this.typeCounter.text = "#" + toadInfoData.typeCounter.ToString();
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
    
    
    public int GetId()
    {
        return globalId;
    }

    public string GetRarity()
    {
        return rarity.text;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TotalManager.Instance.uiManager.uiToadBreeding.UiToadBreedingList.SetUpData(number);
        TotalManager.Instance.uiManager.uiToadBreeding.uiToadBreedingListGameObj.SetActive(true);
       
    }
}

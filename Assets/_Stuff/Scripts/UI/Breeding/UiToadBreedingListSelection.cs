using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UiToadBreedingListSelection : MonoBehaviour,IPointerClickHandler
{
    [SerializeField] private Text name;
    [SerializeField] private Text rarity;
    [SerializeField] private Image image;
    [SerializeField] private Text typeCounter;
    [SerializeField] private int globalId;
    private int indexId;
    private ToadInfoData _toadInfoData;


    public void ChangeDataFromJson(ToadInfoData toadInfoData, int indexId)
    {
        name.text = toadInfoData.name + "" + "#" + toadInfoData.typeCounter.ToString();;
        rarity.text = toadInfoData.rarity.ToString();
        DisplayRarityText(  rarity, toadInfoData.rarity);
        globalId = toadInfoData.globalId;
      //  typeCounter.text = toadInfoData.typeCounter.ToString();
        this.indexId = indexId;
        this._toadInfoData = toadInfoData;
        this.image.sprite = TotalManager.Instance.dataManager.imagesSource.spriteList[toadInfoData.dataId - 1];
     //   this.typeCounter.text = "#" + toadInfoData.typeCounter.ToString();

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (TotalManager.Instance.uiManager.uiToadBreeding.UiToadBreedingList.currentSelectionPointing)
        {
            case 1:
                TotalManager.Instance.uiManager.uiToadBreeding.selection1.ChangeDataFromJson(_toadInfoData, indexId);
                break;
            case 2:
                TotalManager.Instance.uiManager.uiToadBreeding.selection2.ChangeDataFromJson(_toadInfoData, indexId);
                break;
        }
        TotalManager.Instance.uiManager.uiToadBreeding.uiToadBreedingListGameObj.SetActive(false);

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

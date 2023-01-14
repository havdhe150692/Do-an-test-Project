using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIToadReward : MonoBehaviour
{
   [SerializeField] private Image toadImg;
   [SerializeField] private Text toadName;
   [SerializeField] private Text toadRarity;
   [SerializeField] private Button thankAndReceiveButton;

   private void Start()
   {
      thankAndReceiveButton.onClick.AddListener(TurnOffTheBoard);
   }

   public void TurnOffTheBoard()
   {
      this.gameObject.SetActive(false);
   }

   public void SetUp(JObject jsonObject)
   {
      Debug.Log(jsonObject.GetValue("toadData"));
      Debug.Log(jsonObject.GetValue("toadData")["name"]);

      var dataid = (int) jsonObject.GetValue("toadData")["id"];
      var typecounter = (int) jsonObject.GetValue("typeCounter");
      
      toadImg.sprite = TotalManager.Instance.dataManager.imagesSource.spriteList[dataid -1];
      toadName.text = (string) jsonObject.GetValue("toadData")["name"] + " " + "#" + typecounter;
  
         var rarity = ToadInfo.Rarity
         .Parse(typeof(ToadInfo.Rarity), (string) jsonObject.GetValue("toadData")["rarity"]);
         var t = (ToadInfo.Rarity) rarity;
         DisplayRarityText(toadRarity, t);
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

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
  
      
      toadName.text = (string) jsonObject.GetValue("toadData")["name"];
      toadRarity.text = ToadInfo.Rarity
         .Parse(typeof(ToadInfo.Rarity), (string) jsonObject.GetValue("toadData")["rarity"]).ToString();

   }
}

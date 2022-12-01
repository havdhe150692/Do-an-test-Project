using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.UI.Inventory;
using UnityEngine;

public class InventoryList : MonoBehaviour
{
    [SerializeField] private List<InventoryTab> buttonList;
    //0. mosquito
    //1. bugg
    //2. butterfly
    //3. egg1
    //4. eeg2
    //5. map2


    public void ReceiveFromJson(List<ItemInventory> itemInventories)
    {
        for (int i = 0; i < buttonList.Count; i++)
        {
            var btn = buttonList[i];
            btn.id = i;
            btn.amount.text = itemInventories[i].quantity.ToString();
            
        }
    }
    
    
    
}

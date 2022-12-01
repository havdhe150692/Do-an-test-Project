using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using _Stuff.Scripts.UI.Inventory;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class InventoryFetcher : MonoBehaviour
{
    private string headUrl = "http://localhost:8080/inventoryApi/";
    [SerializeField] private int userId;
    private string getAllItemUrl;
    private List<ItemInventory> itemInventoryList;
    
    
    private void Awake()
    {
        getAllItemUrl = headUrl + userId;
    }
    
    private void Start()
    {   
        GetAllItem();
    }

    private void GetAllItem()
    {
        StartCoroutine(GetAllItemFromFetch());
    }
    
    
    IEnumerator  GetAllItemFromFetch() {
        UnityWebRequest www = UnityWebRequest.Get(getAllItemUrl);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            string txt = www.downloadHandler.text;
            itemInventoryList = JsonConvert.DeserializeObject<List<ItemInventory>>(txt);
            TotalManager.Instance.uiManager.uiInventory.inventoryList.ReceiveFromJson(itemInventoryList);
            if (www.isDone)
            {
                TotalManager.Instance.initialFetcherManager.DoneSetUpAtIndex(3);
            }
        }
    }

 

    
    
    
    
}

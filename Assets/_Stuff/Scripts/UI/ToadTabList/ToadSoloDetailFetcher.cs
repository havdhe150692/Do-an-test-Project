using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.Networking;

public class ToadSoloDetailFetcher : MonoBehaviour
{
    private string headUrl = "http://localhost:8080/toadApi/detail/";
    [SerializeField] private int toadId;
  
    
    public void GetDetailOfToad(int id)
    {
        StartCoroutine(RequestDetailOfToad(id));
    }
    
    IEnumerator  RequestDetailOfToad(int id) {
        UnityWebRequest www = UnityWebRequest.Get(headUrl + id);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            Debug.Log(www.downloadHandler.text);
            
            if (www.isDone)
            {
                string txt = www.downloadHandler.text;
                ToadDetailJson toadDetailJson = JsonConvert.DeserializeObject<ToadDetailJson>(txt);
                TotalManager.Instance.uiManager.toadSoloInfo.ReceiveFromJson(toadDetailJson);
            }
        }
    }
}

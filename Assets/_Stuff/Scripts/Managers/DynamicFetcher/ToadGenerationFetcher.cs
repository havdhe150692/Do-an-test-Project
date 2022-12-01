using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using Newtonsoft.Json.Linq;

public class ToadGenerationFetcher : MonoBehaviour
{
    private String postUrl = "http://localhost:8080/toadGeneration/";
    private String toadBreed = "toadBreeding";
    private string generateCommonToad = "commonToad";
    private string finalString;
    
    public JObject jsonObject; 


    public JObject RequestACommonToad()
    { 
        TotalManager.Instance.uiManager.uiWaitingForData.SetActive(true);
        StartCoroutine(Upload());
        return jsonObject;
    }

    IEnumerator Upload()
    {
        int userId = TotalManager.Instance.dataManager.userId;

        finalString = postUrl + generateCommonToad;
        WWWForm form = new WWWForm();
        form.AddField("userId", userId);

        using (UnityWebRequest www = UnityWebRequest.Post(finalString, form))
        {
            yield return www.SendWebRequest();
           
            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                string txt = www.downloadHandler.text;
                Debug.Log(txt);
                JObject json = JObject.Parse(txt);
                jsonObject = json;
                Debug.Log(json.GetValue("id"));
                
                TotalManager.Instance.uiManager.uiWaitingForData.SetActive(false);
                TotalManager.Instance.uiManager.uiEggUnboxing.gameObject.SetActive(true);
                TotalManager.Instance.uiManager.uiToadReward.SetUp(json);
                TotalManager.Instance.initialFetcherManager.toadListFetcher.GetAllToad();
                //TotalManager.Instance.uiManager
            }
        }
    }


    IEnumerator CreateToadNFT()
     {
         int userId = TotalManager.Instance.dataManager.userId;

         finalString = postUrl + toadBreed;
         WWWForm form = new WWWForm();
         form.AddField("userId", userId);
         string rarityA = "Mythical";
         string rarityB = "Epic";
         form.AddField("rarityA", rarityA);
         form.AddField("rarityB", rarityB);
         using (UnityWebRequest www = UnityWebRequest.Post(finalString, form))
         {
             yield return www.SendWebRequest();
           
             if (www.result != UnityWebRequest.Result.Success)
             {
                 Debug.Log(www.error);
             }
             else
             {
                 string txt = www.downloadHandler.text;
                 Debug.Log(txt);
                 JObject json = JObject.Parse(txt);
                 jsonObject = json;
                 Debug.Log(json.GetValue("id"));
                 
                
             }
         }
     }
}
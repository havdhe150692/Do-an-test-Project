using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
    private string checkRarity = "checkRarity";
    private string finalString;
    
    public JObject jsonObject;
    public string rarityCheckString;

    public void SetupDataBreed(int toadId, string timestamp)
    {
        var list = TotalManager.Instance.dataManager.statusData;
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i].id == toadId)
            {
                list[i].expectedBreed = DateTime.Parse(timestamp);
            }
                
        }
        TotalManager.Instance.uiManager.uiToadPlacement.InitialSetup();
    }
    public String RequestCheckRarity(string rarityA, string rarityB)
    {
        StartCoroutine(CheckRarity(rarityA, rarityB));
        return rarityCheckString;
    }

    public JObject RequestBreedToad(int  id1, int id2 )
    {
        TotalManager.Instance.uiManager.uiWaitingForData.SetActive(true);
        StartCoroutine(CreateToadNFT(id1, id2));
        return jsonObject;
    }

    public JObject RequestACommonToad()
    { 
        TotalManager.Instance.uiManager.uiWaitingForData.SetActive(true);
        StartCoroutine(CreateCommonToad());
        return jsonObject;
    }

    IEnumerator CreateCommonToad()
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


    IEnumerator CreateToadNFT(int  id1, int id2)
     {
         int userId = TotalManager.Instance.dataManager.userId;

         finalString = postUrl + toadBreed;
         WWWForm form = new WWWForm();
         form.AddField("userId", userId);
  
         form.AddField("parentAId", id1);
         form.AddField("parentBId", id2);
         using (UnityWebRequest www = UnityWebRequest.Post(finalString, form))
         {
             yield return www.SendWebRequest();
           
             if ((www.result != UnityWebRequest.Result.Success) && (www.downloadHandler.text != ""))
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
                
             }
         }
     }
    
    IEnumerator CheckRarity(string rarityA, string rarityB)
    {
        int userId = TotalManager.Instance.dataManager.userId;

        finalString = postUrl + checkRarity;
        WWWForm form = new WWWForm();
        form.AddField("userId", userId);
        string rarityAs = rarityA.ToString();
        string rarityBs = rarityB.ToString();
        form.AddField("rarityA", rarityAs);
        form.AddField("rarityB", rarityBs);
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
                rarityCheckString = txt;
                TotalManager.Instance.uiManager.uiToadBreeding.SetRarityText(txt);
           
            }
        }
    }
}
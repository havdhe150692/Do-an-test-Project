using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace _Stuff.Scripts.Managers.DynamicFetcher
{
    public class StatusActionFetcher : MonoBehaviour
    {
        private string postUrlBase = "http://localhost:8080/checkStatus/";
        
        private string collect = "collect";
        private string breed = "breed";
        private string feed = "feed";
        private string mature = "mature";
        
        private string finalString;

        public void SetupDataHungry(int toadId, string json)
        {
            JObject jObject = JObject.Parse(json);
            var expectedHungry = jObject.GetValue("expectedHungry").ToString();
            var expectedCollect = jObject.GetValue("expectedCollect").ToString();
            var expectedBreed = jObject.GetValue("expectedBreed").ToString();
            
            var list = TotalManager.Instance.dataManager.statusData;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].id == toadId)
                {
                    list[i].expectedHungry = DateTime.Parse(expectedHungry);
                    list[i].expectedCollect = DateTime.Parse(expectedCollect);
                    list[i].expectedBreed = DateTime.Parse(expectedBreed);
                }
                
            }
            TotalManager.Instance.uiManager.uiToadPlacement.InitialSetup();
        }

        public void RequestFeed(int toadId)
        {
            StartCoroutine(PostFeed(toadId));
        }
        
        IEnumerator PostFeed(int toadId)
        {
            int userId = TotalManager.Instance.dataManager.userId;
            string finalString = postUrlBase + feed;
            WWWForm form = new WWWForm();
            form.AddField("userId", userId);
            form.AddField("toadId", toadId);

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
                    if (www.isDone && txt != "[]")
                    {
                        SetupDataHungry(toadId, txt);
                    }
                    // Show results as text
                    //Debug.Log(www.downloadHandler.text);
                  
                    //pageToadJson = JsonConvert.DeserializeObject<List<ToadListJson>>(txt);

                }
            }
            
            
        }
        
        IEnumerator GetCollect(int toadId)
        {
            string finalString = postUrlBase + collect + toadId;
            UnityWebRequest www = UnityWebRequest.Get(finalString);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                //Debug.Log(www.downloadHandler.text);
                string txt = www.downloadHandler.text;

                //pageToadJson = JsonConvert.DeserializeObject<List<ToadListJson>>(txt);

            }
        }
    }
}
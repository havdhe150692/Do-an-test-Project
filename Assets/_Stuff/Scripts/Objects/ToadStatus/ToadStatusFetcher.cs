using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace _Stuff.Scripts.Objects.ToadStatus
{
    public class ToadStatusFetcher : MonoBehaviour
    {
        private int userId => TotalManager.Instance.dataManager.userId;
        private string headUrl = "http://localhost:8080/toadApi/";
        private string statusUrl = "status/";
        private string getAllToadStatusUrl;


        public List<ToadStatusJson> allToadStatusList;


        private void Start()
        {
            getAllToadStatusUrl = headUrl + statusUrl + userId;
            GetAllToadStatus();

        }

        public void GetAllToadStatus()
        {
            StartCoroutine(GetAllToadStatusFromFetch());
        }

        IEnumerator GetAllToadStatusFromFetch()
        {
            UnityWebRequest www = UnityWebRequest.Get(getAllToadStatusUrl);
            yield return www.SendWebRequest();


            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log("TOAD STATUS FETCHER " + www.downloadHandler.text);
                string txt = www.downloadHandler.text;
                if (www.isDone && txt != "[]")
                {
                    JArray totalArray = JArray.Parse(txt);
                    List<ToadStatusCheck> statusChecks = new List<ToadStatusCheck>();
                    for (int i = 0; i < totalArray.Count; i++)
                    {
                        var jToken = totalArray[i];
                        var id = int.Parse(jToken["id"].ToString());
                        var isMature = bool.Parse(jToken["isMature"].ToString());
                        var isToBreed = bool.Parse(jToken["isToBreed"].ToString());
                        var isToFeed = bool.Parse(jToken["isToFeed"].ToString());
                        var isToCollect = bool.Parse(jToken["isToCollect"].ToString());

                        ToadStatusCheck toadStatusCheck = new ToadStatusCheck();
                        toadStatusCheck.id = id;
                        toadStatusCheck.isMature = isMature;
                        toadStatusCheck.isToBreed = isToBreed;
                        toadStatusCheck.isToFeed = isToFeed;
                        toadStatusCheck.isToCollect = isToCollect;
                        
                        statusChecks.Add(toadStatusCheck);

                    }

                    TotalManager.Instance.dataManager.statusChecks = statusChecks;
                    //SET UP ICON AND DATA
                   
                    TotalManager.Instance.initialFetcherManager.DoneSetUpAtIndex(2);
                }
            }
        }

    }

}
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
        [SerializeField] private int userId;
        private string headUrl = "http://localhost:8080/toadApi/user/";
        private string statusUrl = "/status";
        private string getAllToadStatusUrl;


        public List<ToadStatusJson> allToadStatusList;

        private void Awake()
        {
            getAllToadStatusUrl = headUrl + userId + statusUrl;
        }


        private void Start()
        {
            GetAllToadStatus();

        }

        public void GetAllToadStatus()
        {
            StartCoroutine(InitialGetAllToadStatusFromFetch());
        }

        IEnumerator InitialGetAllToadStatusFromFetch()
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
                Debug.Log(www.downloadHandler.text);
                string txt = www.downloadHandler.text;
                JObject jsonObject = JObject.Parse(txt);
                int numberOfToadInList = jsonObject.Count;
                



                    allToadStatusList = JsonConvert.DeserializeObject<List<ToadStatusJson>>(txt);
                Debug.Log(allToadStatusList);
                TotalManager.Instance.dataManager.toadStatusJson = allToadStatusList;
                if (www.isDone)
                {
                    TotalManager.Instance.initialFetcherManager.DoneSetUpAtIndex(2);
                }
            }
        }

    }

}
using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using Jint.Native.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;
using UnityEngine;
using UnityEngine.Networking;

namespace _Stuff.Scripts.UI.ToadTabList
{
    public class ToadListFetcher : MonoBehaviour
    {
        private int userId;
        private string headUrl = "http://localhost:8080/toadApi/";
        private string pageUrl = "/page/";
        private string getAllToadUrl;
        private string getToadAtThisPageUrl;

        public List<ToadListJson> allToadJson;
        public List<ToadListJson> pageToadJson;

        //NOTE: USER ID SHOULD BE FETCHED BY PROPER UNITY WEBGL WAY/ COOKIE/ TOKEN?.... 

        private void Awake()
        {
            
        }

        private void Start()
        {
            userId = TotalManager.Instance.dataManager.userId;
            getAllToadUrl = headUrl + userId;
            getToadAtThisPageUrl = headUrl + userId + pageUrl;
            
            GetAllToad();
        }

        public void GetAllToad()
        {
            StartCoroutine(GetAllToadFromFetch());
        }


        public void GetAllToadOfThisPage(int pageId)
        {
            StartCoroutine(GetAllToadAtThisPageFromFetch(pageId));
        }

        IEnumerator GetAllToadFromFetch()
        {
            UnityWebRequest www = UnityWebRequest.Get(getAllToadUrl);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                // Show results as text
                Debug.Log("TOAD LIST FETCHER " + www.downloadHandler.text);
                string txt = www.downloadHandler.text;
                if (www.isDone && txt != "[]")
                {
                    JArray totalArray = JArray.Parse(txt);
                    int numberOfToadInList = totalArray.Count;
                    List<ToadInfoData> listData = new List<ToadInfoData>();
                    List<ToadInfoStatus> statusData = new List<ToadInfoStatus>();
                    for (int i = 0; i < totalArray.Count; i++)
                    {
                        var totalString = totalArray;
                        var jToken = totalString[i];
                        var id = int.Parse(jToken["id"].ToString());
                        var toadData = jToken["toadData"];
                        var typeCounter = jToken["typeCounter"];
                        var dob = jToken["dateOfBirth"];
                        var toadStatus = jToken["toadStatus"];

                        var globalId = id;
                        var dataId = int.Parse(toadData["id"].ToString());
                        var name = toadData["name"].ToString();
                        var rarity = toadData["rarity"].ToString();
                        var info = toadData["info"].ToString();
                        var toadClass = toadData["toadClass"]["name"].ToString();
                        var toadTypeCounter = typeCounter.ToString();
                        // var dateOfBirth =
                        //     DateTime.ParseExact(dob.ToString(), "dd/MM/yyyy HH:mm:ss tt",
                        //         System.Globalization.CultureInfo.InvariantCulture);
                        var dateOfBirth =
                            DateTime.Parse(dob.ToString());

                        ToadInfoData t = new ToadInfoData();
                        t.dataId = dataId;
                        t.globalId = globalId;
                        t.name = name;
                        t.rarity = (ToadInfo.Rarity) Enum.Parse(typeof(ToadInfo.Rarity), rarity);
                        t.info = info;
                        t.toadClass = toadClass;
                        t.typeCounter = Int32.Parse(toadTypeCounter);
                        t.dob = dateOfBirth;
     
                        ToadInfoStatus s = new ToadInfoStatus();
                        s.id = Int32.Parse(toadStatus["id"].ToString());
                        s.expectedMature =  DateTime.Parse(toadStatus["expectedMature"].ToString());
                        s.expectedBreed =  DateTime.Parse(toadStatus["expectedBreed"].ToString());
                        s.expectedHungry = DateTime.Parse(toadStatus["expectedHungry"].ToString());
                        s.expectedCollect = DateTime.Parse(toadStatus["expectedCollect"].ToString());

                        // s.expectedMature = DateTime.ParseExact(toadStatus["expectedMature"].ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz",
                        //     System.Globalization.CultureInfo.InvariantCulture);
                        // s.expectedBreed = DateTime.ParseExact(toadStatus["expectedBreed"].ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz",
                        //     System.Globalization.CultureInfo.InvariantCulture);
                        // s.expectedHungry = DateTime.ParseExact(toadStatus["expectedHungry"].ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz",
                        //     System.Globalization.CultureInfo.InvariantCulture);
                        // s.expectedCollect = DateTime.ParseExact(toadStatus["expectedCollect"].ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz",
                        //     System.Globalization.CultureInfo.InvariantCulture);
                        
                        listData.Add(t);
                        statusData.Add(s);

                        //
                        // {
                        //     "id": 45,
                        //     "toadData": {
                        //         "id": 2,
                        //         "name": "Cóc Cam ",
                        //         "rarity": "Common",
                        //         "info": "Chú cóc này mới nhập học Đại học FPT nên trông tươi tỉnh hơn hẳn.",
                        //         "pictureId": 2,
                        //         "toadClass": {
                        //             "id": 2,
                        //             "name": "Economic Toad"
                        //         }
                        //     },
                        //     "typeCounter": 0,
                        //     "dateOfBirth": "2022-11-30T09:39:12.592+00:00",
                        //     "toadStatus": {
                        //         "id": 45,
                        //         "expectedMature": null,
                        //         "expectedBreed": null,
                        //         "expectedHungry": null,
                        //         "expectedCollect": null
                        //     }
                        // }
                    }

                    var dataManagerListData = TotalManager.Instance.dataManager.listData;
                    var dataManagerStatusData = TotalManager.Instance.dataManager.statusData;
                    Debug.Log("listData count = " + listData.Count);
                    Debug.Log("statusData count = " + statusData.Count);
                    
                    TotalManager.Instance.dataManager.listData = listData;
                    TotalManager.Instance.dataManager.statusData = statusData;
                   
                    TotalManager.Instance.uiManager.uiWaitingForData.SetActive(false);
                    TotalManager.Instance.uiManager.uiToadPlacement.InitialSetup();
                    TotalManager.Instance.uiManager.toadDisplayTab.SetUpToadList();
                    //SET UP TOAD POSITION
                    TotalManager.Instance.initialFetcherManager.DoneSetUpAtIndex(1);
                    TotalManager.Instance.uiManager.transactionProcessing.gameObject.SetActive(false);

                }
            }
        }

        IEnumerator GetAllToadAtThisPageFromFetch(int pageId)
        {
            string pageUrl = getToadAtThisPageUrl + pageId;
            UnityWebRequest www = UnityWebRequest.Get(pageUrl);
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

                pageToadJson = JsonConvert.DeserializeObject<List<ToadListJson>>(txt);

                Debug.Log(txt);
                Debug.Log(TotalManager.Instance.uiManager);
                Debug.Log(TotalManager.Instance.uiManager.toadDisplayTab);
                Debug.Log(TotalManager.Instance.uiManager.toadDisplayTab.pagingController);
                Debug.Log(TotalManager.Instance.uiManager.toadDisplayTab.pagingController.displaypage);
                //TotalManager.Instance.uiManager.toadDisplayTab.pagingController.displaypage.FetchData(pageToadJson);
            }
        }
    }
}
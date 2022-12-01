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
        [SerializeField] private int userId;
        private string headUrl = "http://localhost:8080/toadApi/";
        private string pageUrl = "/page/";
        private string getAllToadUrl;
        private string getToadAtThisPageUrl;

        public List<ToadListJson> allToadJson;
        public List<ToadListJson> pageToadJson;
        
        //NOTE: USER ID SHOULD BE FETCHED BY PROPER UNITY WEBGL WAY/ COOKIE/ TOKEN?.... 
        
        private void Awake()
        {
            getAllToadUrl = headUrl + userId;
            getToadAtThisPageUrl = headUrl + userId + pageUrl;
        }
        
        private void Start()
        {   
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
        
        IEnumerator  GetAllToadFromFetch() {
            UnityWebRequest www = UnityWebRequest.Get(getAllToadUrl);
            yield return www.SendWebRequest();
 
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else {
                // Show results as text
                Debug.Log(www.downloadHandler.text);
                string txt = www.downloadHandler.text;
                allToadJson = JsonConvert.DeserializeObject<List<ToadListJson>>(txt);
                TotalManager.Instance.dataManager.toadListJson = allToadJson;
                if (www.isDone)
                {
                    TotalManager.Instance.initialFetcherManager.DoneSetUpAtIndex(1);
                }
            }
        }
        
        IEnumerator  GetAllToadAtThisPageFromFetch(int pageId)
        {
            string pageUrl = getToadAtThisPageUrl + pageId;
            UnityWebRequest www = UnityWebRequest.Get(pageUrl);
            yield return www.SendWebRequest();
 
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else {
                // Show results as text
                //Debug.Log(www.downloadHandler.text);
                string txt = www.downloadHandler.text;
                JObject totalString = JObject.Parse(txt);
                int numberOfToadInList = totalString.Count;
                List<ToadInfoData> listData = new List<ToadInfoData>();
                List<ToadInfoStatus> statusData = new List<ToadInfoStatus>();
                for (int i = 0; i < totalString.Count; i++)
                {
                    var jToken = totalString[i];
                    var id = int.Parse(jToken[0].ToString());
                    var toadData = jToken[1];
                    var typeCounter = jToken[2];
                    var dob = jToken[3];
                    var toadStatus = jToken[4];

                    var globalId = id;
                    var name = toadData[1].ToString();
                    var rarity = toadData[2].ToString();
                    var info = toadData[3].ToString();
                    var toadClass = toadData[5].ToString();
                    var toadTypeCounter = typeCounter.ToString();
                    var dateOfBirth =
                    DateTime.ParseExact(dob.ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);

                    ToadInfoData t = new ToadInfoData();
                    t.globalId = globalId;
                    t.name = name;
                    t.rarity = (ToadInfo.Rarity) Enum.Parse(typeof(ToadInfo.Rarity), rarity);
                    t.info = info;
                    t.toadClass = toadClass;
                    t.typeCounter = Int32.Parse(toadTypeCounter);
                    t.dob = dateOfBirth;

                    ToadInfoStatus s = new ToadInfoStatus();
                    s.id = Int32.Parse(toadStatus[0].ToString());
                    s.expectedMature = DateTime.ParseExact(toadStatus[1].ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);
                    s.expectedBreed = DateTime.ParseExact(toadStatus[2].ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);
                    s.expectedHungry = DateTime.ParseExact(toadStatus[3].ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);
                    s.expectedCollect = DateTime.ParseExact(toadStatus[4].ToString(), "yyyy-MM-ddTHH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);


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
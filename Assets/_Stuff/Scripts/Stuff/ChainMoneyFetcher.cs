using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using Newtonsoft.Json;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Utilities;
using UnityEngine;
using UnityEngine.Networking;

namespace _Stuff.Scripts.Stuff
{
    public class ChainMoneyFetcher : MonoBehaviour
    {
        [SerializeField] private int userId;
        private string headUrl = "http://localhost:8080/tokenApi/balance/";
        private string getMoneyUrl;
        
        private void Awake()
        {
            getMoneyUrl = headUrl + userId;
          
        }
        
        
        public void GetYourBalance()
        {
            StartCoroutine(Initial_GetYourBalanceFromFetch());
        }


        IEnumerator Initial_GetYourBalanceFromFetch()
        {
            UnityWebRequest www = UnityWebRequest.Get(getMoneyUrl);
            yield return www.SendWebRequest();
 
            if (www.result != UnityWebRequest.Result.Success) {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                string txt = www.downloadHandler.text;
                int yourBalance = Int32.Parse(txt);
                TotalManager.Instance.dataManager.tokenBalance = yourBalance;
                if (www.isDone)
                {
                    TotalManager.Instance.initialFetcherManager.DoneSetUpAtIndex(1);
                }
            }
        }
    }
}
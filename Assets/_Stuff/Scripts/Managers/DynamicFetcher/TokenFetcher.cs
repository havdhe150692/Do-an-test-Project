using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;

namespace _Stuff.Scripts.Managers.DynamicFetcher
{
    public class TokenFetcher: MonoBehaviour
    {
        private String postUrl = "http://localhost:8080/tokenApi/requestMoney";
      
        private string finalString;
    
        public JObject jsonObject; 


        public JObject RequestNewPlayerMoney()
        { 
            TotalManager.Instance.uiManager.transactionProcessing.gameObject.SetActive(true);
            StartCoroutine(Upload());
            return jsonObject;
        }

        IEnumerator Upload()
        {
            int userId = TotalManager.Instance.dataManager.userId;

            finalString = postUrl;
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
                    //balance
                    TotalManager.Instance.uiManager.uiMoneyText.text = txt;
                    TotalManager.Instance.uiManager.transactionProcessing.gameObject.SetActive(false);
                
                }
            }
        }
    }
}
using System;
using System.Numerics;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;
using UnityEngine.UI;
using BigInteger = System.Numerics.BigInteger;

public class PlayerDataFetcher : MonoBehaviour
{
    private String userName;
    private String getURL = "http://localhost:8080/userData/";
    [SerializeField] public int id;
    [FormerlySerializedAs("text")] [SerializeField] private Text nameText;

    private void Awake()
    {
    }

    private void Start()
    {
        id = TotalManager.Instance.dataManager.userId;
        getURL += id;
        StartCoroutine(GetText());
    }
    
    IEnumerator GetText() {
        UnityWebRequest www = UnityWebRequest.Get(getURL);
        yield return www.SendWebRequest();
 
        if (www.result != UnityWebRequest.Result.Success) {
            Debug.Log(www.error);
        }
        else {
            // Show results as text
            string value = www.downloadHandler.text;
            JObject json = JObject.Parse(value);
            if (www.isDone && value != "")
            {
                nameText.text = json.GetValue("name").ToString();
                TotalManager.Instance.uiManager.uiMoneyText.text = json.GetValue("balance").ToString();
                
                TotalManager.Instance.dataManager.userId =  (int) json.GetValue("id");
                TotalManager.Instance.dataManager.tokenBalance = BigInteger.Parse((string) json.GetValue("balance"));
                TotalManager.Instance.dataManager.isNewPlayer = (bool) json.GetValue("isNewPlayer");
                
                Debug.Log("TEST JSON " + json.GetValue("name"));
                Debug.Log("TEST JSON " + json.GetValue("balance"));
                Debug.Log("TEST JSON " + json.GetValue("isNewPlayer"));
                
                
                
                TotalManager.Instance.initialFetcherManager.DoneSetUpAtIndex(0);
            }

        }
    }
}

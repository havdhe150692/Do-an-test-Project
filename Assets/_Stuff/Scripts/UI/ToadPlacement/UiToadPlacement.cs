using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using UnityEngine;

public class UiToadPlacement : MonoBehaviour
{
    [SerializeField] private List<ToadInfo> toadObjList;

    public void InitialSetup()
    {
        var listData = TotalManager.Instance.dataManager.listData;
        var statusData = TotalManager.Instance.dataManager.statusData;
        Debug.Log("listData = " + listData.Count); 
        Debug.Log("statusDate = " + statusData.Count);
        
        for (int i = 0; i < listData.Count; i++)
        {
            var toadListJson = listData[i];
            toadObjList[i].gameObject.SetActive(true);
            toadObjList[i].FetchFromToadListJson(listData[i]); 
            toadObjList[i].FetchFromToadStatusJson(statusData[i]); 
            toadObjList[i].gameObject.GetComponent<ToadUIObject>().InitialSetup();
            Debug.Log("UiToadPlacement = " + i);

        }
    }
}

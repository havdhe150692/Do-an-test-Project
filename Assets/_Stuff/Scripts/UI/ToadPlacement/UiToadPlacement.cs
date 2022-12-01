using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using UnityEngine;

public class UiToadPlacement : MonoBehaviour
{
    [SerializeField] private List<ToadInfo> toadObjList;

    public void InitialSetup(List<ToadListJson> toad, List<ToadStatusJson> toadStatusList)
    {
        for (int i = 0; i < toad.Count; i++)
            {
            var toadListJson = toad[i];
            toadObjList[i].gameObject.SetActive(true);
            
            if(!(toadStatusList.Count < i))
            {
                toadObjList[i].FetchFromToadStatusJson(toadStatusList[i]); 
                toadObjList[i].gameObject.GetComponent<ToadUIObject>().InitialSetup();
            }

        }
    }
}

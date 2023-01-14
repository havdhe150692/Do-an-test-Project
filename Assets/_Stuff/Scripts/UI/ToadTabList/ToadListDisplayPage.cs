using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using UnityEngine;

public class ToadListDisplayPage : MonoBehaviour
{
    [SerializeField] private List<GameObject> tabList;

    public void FetchData(int pageNumber)
    {
        var list = TotalManager.Instance.dataManager.listData;
        Debug.Log("listData.Count = " + list.Count);
        for (int i = 0; i < tabList.Count; i++)
        {
            tabList[i].SetActive(false);
            
            //var toadJson = list[i + pageNumber * 6 - 5];
            if (inBounds(i + pageNumber * 6 - 6, list))
            {
                Debug.Log("index = "+ (i + pageNumber * 6 - 6));
                var toadJson = list[i + pageNumber * 6 - 6];
                Debug.Log(i + pageNumber * 6 - 6);
                tabList[i].SetActive(true);
                tabList[i].GetComponent<ToadListSquareTab>()?.ChangeDataFromJson(toadJson,i + pageNumber * 6 - 6 );
                tabList[i].GetComponent<UiToadBreedingListSelection>()?.ChangeDataFromJson(toadJson,i + pageNumber * 6 - 6 );
            }


        }

        // for (int i = list.Count; i < 6; i++)
        // {
        //     tabList[i].SetActive(false);
        // }
    }
    
    private bool inBounds<T>(int index, List<T> array) 
    {
        return (index >= 0) && (index < array.Count);
    }
}

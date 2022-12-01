using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToadUIObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler, IPointerClickHandler
{
    [SerializeField] private ToadInfo toadInfo;
    [SerializeField] private GameObject coinToCollect;

    private void Start()
    {
        if (toadInfo == null)
        {
               Debug.Log("toadinfo is null");
        }

        toadInfo = GetComponent<ToadInfo>();

    }


    public void InitialSetup()
    {
        if (toadInfo.isCollectable)
        {
            coinToCollect.SetActive(true);
        }
        else
        {
            coinToCollect.SetActive(false);
        }


    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TotalManager.Instance.uiManager.ShowToadInfoBox(this.gameObject);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TotalManager.Instance.uiManager.HideToadInfoBox();
    }

    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped");
        GameObject droppedObj = eventData.pointerDrag;

        // if (droppedObj.CompareTag("food"))
        // {
        //     Debug.Log("dsdssssdsdskjkni");
        //     toadInfo.stats[ToadInfo.Stats.Hunger] += 15;
        // }
        // else
        // {
        //     Debug.Log("bruh");
        // }
    }
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        // toadInfo.stats[ToadInfo.Stats.Happiness] += 
        if (toadInfo.isCollectable)
        {
            toadInfo.isCollectable = false;
            coinToCollect.SetActive(false);
            
            TotalManager.Instance.uiManager.uiInventory.IncreaseGold(2000);
            
        }
    }
}

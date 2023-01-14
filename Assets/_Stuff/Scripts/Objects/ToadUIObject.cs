using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToadUIObject : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDropHandler, IPointerClickHandler
{
    [SerializeField] private ToadInfo toadInfo;
    [SerializeField] private GameObject coinToCollect;

    private bool isChangedSize = false;

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

    private void ChangeSize()
    {
        if (!isChangedSize)
        {
            isChangedSize = true;
            this.gameObject.transform.localScale = new Vector3(1.4f, 1.4f, 1.4f);
        }
    }

    private void Update()
    {
        if (toadInfo.isCollectable)
        {
            coinToCollect.SetActive(true);
        }

        if (toadInfo.isMature)
        {
            ChangeSize();

        }

        if (toadInfo.isBreedable)
        {
            //show smth
        }

        if (toadInfo.isFeedable)
        {
            //show smth
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

        if (droppedObj.CompareTag("food"))
        {
             Debug.Log("dropped food"); 
             TotalManager.Instance.dynamicFetcherManager.statusActionFetcher.RequestFeed(toadInfo.globalId);
             //execute logic
             if (toadInfo.isFeedable)
             {
              
                 toadInfo.isFeedable = false;
             }
             else
             {
                 //show you cannot do
             }
        }
     
    }
    
    
    public void OnPointerClick(PointerEventData eventData)
    {
        // toadInfo.stats[ToadInfo.Stats.Happiness] += 
        if (toadInfo.isCollectable)
        {
            toadInfo.isCollectable = false;
            coinToCollect.SetActive(false);
            
            TotalManager.Instance.dynamicFetcherManager.tokenFetcher.RequestCollect(toadInfo.globalId);
            

        }
    }
}

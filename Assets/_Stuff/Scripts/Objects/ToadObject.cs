using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ToadObject : MonoBehaviour
{
    [SerializeField] private ToadInfo toadInfo;


    private void OnMouseEnter()
    {
        TotalManager.Instance.uiManager.ShowToadInfoBox(this.gameObject);
    }

    private void OnMouseExit()
    {
        TotalManager.Instance.uiManager.HideToadInfoBox();
    }


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("dropped");
        GameObject droppedObj = eventData.pointerDrag;

        // if (droppedObj.CompareTag("food"))
        // {
        //     toadInfo.stats[ToadInfo.Stats.Hunger] += 20;
        // }
        // else
        // {
        //     Debug.Log("bruh");
        // }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //toadInfo.stats[ToadInfo.Stats.Happiness] += 20;
    }
}

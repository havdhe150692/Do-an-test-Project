using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiActionBarObject : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler //IPointerDownHandler
{

    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    private Transform initialposition;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        initialposition = rectTransform;
        // = GameObject.Find("UICanvas").GetComponent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
       
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Instantiate(this.gameObject, canvas.transform, initialposition);
        Destroy(this.gameObject);
    }

    public void OnDrag(PointerEventData eventData)
    {
        //rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        transform.position = Input.mousePosition;
        //throw new System.NotImplementedException();
    }
}

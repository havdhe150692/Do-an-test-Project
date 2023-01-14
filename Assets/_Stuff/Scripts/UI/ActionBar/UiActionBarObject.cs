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
        canvas = GameObject.Find("UICanvas").GetComponent<Canvas>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //throw new System.NotImplementedException();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

       GameObject g = Instantiate(this.gameObject, this.gameObject.transform.parent);
       g.transform.localScale = this.gameObject.transform.localScale;
       g.transform.position = this.gameObject.transform.position;
       g.transform.parent = this.gameObject.transform.parent;
       
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

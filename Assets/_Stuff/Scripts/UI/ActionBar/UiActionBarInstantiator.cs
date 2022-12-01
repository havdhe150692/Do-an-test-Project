using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiActionBarInstantiator : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private UiActionBarObject objectToSummon;
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Instantiate(objectToSummon);
        
    }
}

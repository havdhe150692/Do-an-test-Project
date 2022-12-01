using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToadListSquareTab : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Text name;
    [SerializeField] private Text rarity;
    [SerializeField] private Image image;
    [SerializeField] private int globalId;


    public void ChangeDataFromJson(ToadListJson toadListJson)
    {
        name.text = toadListJson.name;
        rarity.text = toadListJson.rarity.ToString();
        globalId = toadListJson.globalId;

    }

    public void OnPointerClick(PointerEventData eventData)
    {
        TotalManager.Instance.uiManager.toadSoloInfo.ShowBoardAndDetail(globalId);
    }
}

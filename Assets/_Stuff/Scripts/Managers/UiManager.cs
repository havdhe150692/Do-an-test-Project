using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using _Stuff.Scripts.Managers;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    //[SerializeField] private UiToadInfoScriptOld toadInfoBox;
    [SerializeField] private UiToadMouseOverInfo toadInfoBox;

    [SerializeField] public UiToadDisplayTab toadDisplayTab;

    [SerializeField] public UiToadSoloInfo toadSoloInfo;

    [SerializeField] public UiToadPlacement uiToadPlacement;

    [SerializeField] public UiInventory uiInventory;

    [SerializeField] public UIEggUnboxing uiEggUnboxing;

    [SerializeField] public UIToadReward uiToadReward;

    [SerializeField] public GameObject transactionProcessing;

    [SerializeField] public UiToadBreeding uiToadBreeding;

    [SerializeField] public UiGuide uiGuide;

    [SerializeField] public UiSetting uiSetting;

    [SerializeField] public GameObject uiWaitingForData;
    
    [SerializeField] public Text uiMoneyText;
    
    [SerializeField] private Button guideBtn;
    [SerializeField] private Button toadListBtn;

    [SerializeField] private Button settingBtn;
    [SerializeField] private Button shopBtn;
    [SerializeField] private Button eggBtn;


    [SerializeField] private GameObject gObjBoardToadList;
    [SerializeField] private GameObject gObjToadBreeding;
    [SerializeField] private GameObject gObjSetting;
    [SerializeField] private GameObject gObjGuide;
    
    [DllImport("__Internal")]
    private static extern void openWindow(string url);

    private void Awake()
    {
        toadListBtn.onClick.AddListener(ShowToadList);
        eggBtn.onClick.AddListener(ShowToadBreeding);
        settingBtn.onClick.AddListener(ShowSetting);
        guideBtn.onClick.AddListener(ShowGuide);
      //  shopBtn.onClick.AddListener(OpenLinkBackToShop);
    }

    public void ShowGuide()
    {
        uiGuide.gameObject.SetActive(true);
    }

    public void ShowSetting()
    {
        uiSetting.gameObject.SetActive(true);
    }

    public void ShowToadList()
    {
        gObjBoardToadList.SetActive(true);
    }

    public void ShowToadBreeding()
    {
        gObjToadBreeding.SetActive(true);
    }
    
    public void ShowToadInfoBox(GameObject toad)
    {
       // toadInfoBox.SetUpInfoOfToad();
        toadInfoBox.objectToFollow = toad.transform;
        toadInfoBox.gameObject.SetActive(true);
    }

    public void HideToadInfoBox()
    {
        toadInfoBox.gameObject.SetActive(false);
    }
    
    public void OpenLinkBackToShop() {
        #if !UNITY_EDITOR
		    openWindow("http://unity3d.com");
        #endif
    }

    
}

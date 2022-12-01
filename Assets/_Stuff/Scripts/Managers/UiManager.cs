using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Managers;
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

    [SerializeField] public UiTransactionProcessing transactionProcessing;

    [SerializeField] public GameObject uiWaitingForData;
    
    [SerializeField] public Text uiMoneyText;
    
    [SerializeField] private Button handBtn;
    [SerializeField] private Button foodBtn;
    [SerializeField] private Button toadListBtn;
    [SerializeField] private Button medicineBtn;
    [SerializeField] private Button settingBtn;
    [SerializeField] private Button shopBtn;
    [SerializeField] private Button marketBtn;
    [SerializeField] private Button eggBtn;


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
    
}

using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.UI.ToadTabList;
using UnityEngine;
using UnityEngine.UI;

public class UiToadDisplayTab : MonoBehaviour
{
    [SerializeField] public ToadListPaging pagingController;
    [SerializeField] public Button btnExit;
    [SerializeField] public GameObject totalBoard;
    //[SerializeField] public GameObject blackBG;


    private void Start()
    {
        btnExit.onClick.AddListener(TurnOffBoard);
    }

    private void TurnOffBoard()
    {
        totalBoard.SetActive(false);
        //blackBG.SetActive(false);
    }
}

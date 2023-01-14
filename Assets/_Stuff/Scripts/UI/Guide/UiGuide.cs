using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiGuide : MonoBehaviour
{
    [SerializeField] private Button exitBtn;

    private void Awake()
    {
        exitBtn.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        this.gameObject.SetActive(false);
    }
}

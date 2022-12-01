using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEggUnboxing : MonoBehaviour
{
    [SerializeField] private Image eggImg;
    [SerializeField] private Image brokenEggImg;
    
    void Start()
    {
        StartCoroutine(UnboxingEgg());
    }


    IEnumerator UnboxingEgg()
    {
        yield return new WaitForSeconds(3);
        eggImg.gameObject.SetActive(false);
        brokenEggImg.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
        TotalManager.Instance.uiManager.uiToadReward.gameObject.SetActive(true);
    }   

}

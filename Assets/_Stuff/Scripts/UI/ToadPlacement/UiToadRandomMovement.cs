using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;


public class UiToadRandomMovement : MonoBehaviour
{
    private bool isWaiting = false;
    public int randomNum = 0;

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {
            StartCoroutine(WaitAndThen());
        }
    }

    IEnumerator WaitAndThen()
    {
         isWaiting = true;
         
         int num = Random.Range(1, 30);
            randomNum = num;
            yield return new WaitForSeconds(randomNum);

            Vector3 newScale = this.gameObject.transform.localScale;
            newScale.x *= -1;
            this.gameObject.transform.localScale = newScale;

            isWaiting = false;

        
       
        
    }
    
}

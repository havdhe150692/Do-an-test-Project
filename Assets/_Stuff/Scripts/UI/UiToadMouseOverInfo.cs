using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class UiToadMouseOverInfo : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI ageText;
    [SerializeField] private TextMeshProUGUI rarityText;

    [SerializeField] private Text hungerNumber;
    [SerializeField] private Text breedStatus;
    [SerializeField] private Text growStatus;
    [SerializeField] private Text collectStatus;
    
    [SerializeField] private Text nextFeedTimer;
    [SerializeField] private Text nextBreedTimer;
    [SerializeField] private Text nextCollectTimer;
    [SerializeField] private Text estimatedGrowTimer;
    
    public RectTransform canvasRectT;
    public RectTransform thisRectT;
    public Transform objectToFollow;

    private void Start()
    {
        thisRectT = GetComponent<RectTransform>();
        canvasRectT = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }
    

    private void Update()
    {
       
        if (objectToFollow != null)
        {

            ToadInfo objectToFollowInfo = objectToFollow.GetComponent<ToadInfo>();
            nameText.text = objectToFollowInfo.toadName;
            ageText.text = "1 days 60 minute";
            rarityText.text = objectToFollowInfo.rarity.ToString();

            
            
           
            DisplayTimeForText(estimatedGrowTimer, objectToFollowInfo.remainMature);
            
            if (objectToFollowInfo.isCollectable)
            {
                collectStatus.text = "YES";
                nextCollectTimer.text = "00:00:00";
            }
            else
            {
                collectStatus.text = "NO";
                DisplayTimeForText(nextCollectTimer, objectToFollowInfo.remainCollect);
            }

            if (objectToFollowInfo.isFeedable)
            {
                nextFeedTimer.text = "00:00:00";
            }
            else
            {
                DisplayTimeForText(nextFeedTimer, objectToFollowInfo.remainHungry);
            }

            if (objectToFollowInfo.isBreedable)
            {
                nextBreedTimer.text = "00:00:00";
                breedStatus.text = "YES";
            }
            else
            {
                breedStatus.text = "NO";
                DisplayTimeForText(nextBreedTimer, objectToFollowInfo.remainBreed);
            }
            
            // Final position of marker above GO in world space
            RectTransform anotherRect = objectToFollow.GetComponent<RectTransform>();
            Vector2 offsetPos = new Vector2(anotherRect.anchoredPosition.x, anotherRect.anchoredPosition.y + 100);

            // Set
            thisRectT.anchoredPosition = offsetPos;

        }
    }


    

    void DisplayTimeForText(Text timeText, float value)
    {
        
        float seconds = Mathf.FloorToInt(value % 60);
        float minutes = Mathf.FloorToInt((value / 60) % 60);
        float hours = Mathf.FloorToInt((value / 3606) % 24);
        timeText.text = string.Format("{0:00}:{1:00}:{2:00}",hours, minutes, seconds);
    }
    
    
    
}

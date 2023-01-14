using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;

public class UiToadMouseOverInfo : MonoBehaviour
{
    [SerializeField] private Text nameText;
    [SerializeField] private Text ageText;
    [SerializeField] private Text rarityText;

    [SerializeField] private Text hungerNumber;
    [SerializeField] private Text breedStatus;
    [SerializeField] private Text growStatus;
    [SerializeField] private Text collectStatus;

    [SerializeField] private GameObject growGameObj;
    [SerializeField] private GameObject breedGameObj;
    
    
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
         
            DisplayAgeText(objectToFollowInfo.age);
            DisplayRarityText(rarityText, objectToFollowInfo.rarity);

            if (objectToFollowInfo.isMature)
            {
                growGameObj.SetActive(false);
                breedGameObj.SetActive(true);
            }
            else
            {
                growGameObj.SetActive(true);
                breedGameObj.SetActive(false);
                
                growStatus.text = "NO";  
                DisplayTimeForText(estimatedGrowTimer, objectToFollowInfo.remainMature);
            }

            if (objectToFollowInfo.isCollectable)
            {
                collectStatus.text = "YES";
                nextCollectTimer.text = "READY";
                nextCollectTimer.color = new Color32(9, 87, 22, 255);
            }
            else
            {
                collectStatus.text = "NO";
                DisplayTimeForText(nextCollectTimer, objectToFollowInfo.remainCollect);
            }

            if (objectToFollowInfo.isFeedable)
            {
                nextFeedTimer.text = "READY";
                nextFeedTimer.color = new Color32(9, 87, 22, 255);
            }
            else
            {
                DisplayTimeForText(nextFeedTimer, objectToFollowInfo.remainHungry);
            }

            if (objectToFollowInfo.isBreedable)
            {
                nextBreedTimer.text = "READY";
                nextBreedTimer.color = new Color32(9, 87, 22, 255);
                breedStatus.text = "YES";
            }
            else
            {
                breedStatus.text = "NO";
                DisplayTimeForText(nextBreedTimer, objectToFollowInfo.remainBreed);
            }
            
            // Final position of marker above GO in world space
            RectTransform anotherRect = objectToFollow.GetComponent<RectTransform>();
            Vector2 offsetPos = new Vector2(anotherRect.anchoredPosition.x, anotherRect.anchoredPosition.y + 150);

            // Set
            thisRectT.anchoredPosition = offsetPos;

        }
    }

    void DisplayAgeText(TimeSpan value)
    {
        int hours = value.Hours - value.Days * 24;
        int days = value.Days;
        ageText.text = string.Format("{0:00} days {1:00} hours old",days, hours);
    }
    

    void DisplayTimeForText(Text timeText, float value)
    {
        timeText.color = new Color32(180, 89, 26, 255);
        float seconds = Mathf.FloorToInt(value % 60);
        float minutes = Mathf.FloorToInt((value / 60) % 60);
        float hours = Mathf.FloorToInt((value / 3606) % 24);
        timeText.text = string.Format("{0:00} hours {1:00} mins {2:00}s",hours, minutes, seconds);
    }

    void DisplayRarityText(Text rarityText, ToadInfo.Rarity value)
    {
        switch (value)
        {
            case ToadInfo.Rarity.Common: 
                rarityText.color = new Color32(9, 87, 22, 255);
                
                break;
            case ToadInfo.Rarity.Rare:
                rarityText.color = new Color32(3, 177, 252, 255);
                break;
            case ToadInfo.Rarity.Epic:
                rarityText.color = new Color32(230, 223, 3, 255);
                break;
            case ToadInfo.Rarity.Mythical:
                rarityText.color = new Color32(148, 3, 252, 255);
                break;
            case ToadInfo.Rarity.Legendary:
                rarityText.color = new Color32(252, 3, 45,255);
                break;
        }
        rarityText.text = value.ToString();
    }
    
    
    
}

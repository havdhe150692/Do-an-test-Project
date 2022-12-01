using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiToadInfoScriptOld : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI ageText;
    [SerializeField] private TextMeshProUGUI rarityText;

    [SerializeField] private Text hungerPercent;
    [SerializeField] private Text happinessPercent;
    [SerializeField] private Text healthPercent;

    [SerializeField] private Slider hungerSlider;
    [SerializeField] private Slider happinessSlider;
    [SerializeField] private Slider healthSlider;
    
    public RectTransform canvasRectT;
    public RectTransform thisRectT;
    public Transform objectToFollow;

    private void Start()
    {
        thisRectT = GetComponent<RectTransform>();
        canvasRectT = GetComponentInParent<Canvas>().GetComponent<RectTransform>();
    }

    public void SetUpInfoOfToad()
    {
        nameText.text = "Coc Vuong";
        ageText.text = "1 days 60 minute";
        rarityText.text = "Common";

        hungerPercent.text = "50/100";
        happinessPercent.text = "30/100";
        healthPercent.text = "70/100";

        hungerSlider.value = 0.5f;
        happinessSlider.value = 0.3f;
        healthSlider.value = 0.7f;
    }


    public void SetUpInfoOfToad(ToadInfo toadInfo)
    {
        
    }

    private void Update()
    {
        // if (objectToFollow != null)
        // {
        //
        //     float offsetPosY = objectToFollow.transform.position.y + 2.5f;
        //
        //     // Final position of marker above GO in world space
        //     Vector3 offsetPos = new Vector3(objectToFollow.transform.position.x, offsetPosY, objectToFollow.transform.position.z);
        //
        //     // Calculate *screen* position (note, not a canvas/recttransform position)
        //     Vector2 canvasPos;
        //     Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);
        //
        //     // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
        //     RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRectT, screenPoint, null, out canvasPos);
        //
        //     // Set
        //     thisRectT.localPosition = canvasPos;
        //
        // }

        if (objectToFollow != null)
        {

            ToadInfo objectToFollowInfo = objectToFollow.GetComponent<ToadInfo>();
            nameText.text = objectToFollowInfo.toadName;
            ageText.text = "1 days 60 minute";
            rarityText.text = objectToFollowInfo.rarity.ToString();

            // hungerPercent.text = objectToFollowInfo.stats[ToadInfo.Stats.Hunger].ToString();
            // happinessPercent.text =  objectToFollowInfo.stats[ToadInfo.Stats.Happiness].ToString();
            // healthPercent.text =  objectToFollowInfo.stats[ToadInfo.Stats.Health].ToString();
            //
            // hungerSlider.value = objectToFollowInfo.stats[ToadInfo.Stats.Hunger]/100f;
            // happinessSlider.value = objectToFollowInfo.stats[ToadInfo.Stats.Happiness]/100f;
            // healthSlider.value = objectToFollowInfo.stats[ToadInfo.Stats.Happiness] / 100f;

            
            
            
            // Final position of marker above GO in world space
            RectTransform anotherRect = objectToFollow.GetComponent<RectTransform>();
            Vector2 offsetPos = new Vector2(anotherRect.anchoredPosition.x, anotherRect.anchoredPosition.y + 100);
            
            // Set
            thisRectT.anchoredPosition = offsetPos;

        }

    }
}

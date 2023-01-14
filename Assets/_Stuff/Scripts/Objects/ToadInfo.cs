using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

//[CreateAssetMenu(fileName = "ToadData", menuName = "ScriptableObjects/ToadDataSO", order = 1)]
public class ToadInfo : MonoBehaviour
{
    // public enum Stats
    // {
    //     Hunger,
    //     Happiness,
    //     Health,
    //     Growing
    // }
    //
    
    
    public enum  Rarity
    {
        Common,
        Rare,
        Epic,
        Mythical,
        Legendary
    }

    [SerializeField] public int globalId;
    [SerializeField]  public String toadName;
    [SerializeField]  public TimeSpan age;
    [SerializeField]  public Rarity rarity;
    [SerializeField] public Image imageShow;

    public bool isMature;
    public bool isCollectable;
    public bool isFeedable;
    public bool isBreedable;

    public float remainMature;
    public float remainHungry;
    public float remainCollect;
    public float remainBreed;

    public void SetupImageWithDataId(int id)
    {
        Debug.Log("dataid is " + id);
        imageShow.sprite = TotalManager.Instance.dataManager.imagesSource.spriteList[id - 1];
        
    }

    public void FetchFromToadListJson(ToadInfoData toadInfoData)
    {
        this.globalId = toadInfoData.globalId;
        this.toadName = toadInfoData.name;
        this.rarity = toadInfoData.rarity;
        SetupImageWithDataId(toadInfoData.dataId);
        
        DateTime now = DateTime.Now;
        age = ( now - toadInfoData.dob);
        TotalManager.Instance.dataManager.toadInfos.TryGetValue(toadInfoData.globalId, out ToadInfo t);
        if (t == null)
        {
            TotalManager.Instance.dataManager.toadInfos.Add(toadInfoData.globalId, this);
        }
        else
        {
            TotalManager.Instance.dataManager.toadInfos[toadInfoData.globalId] = this;
        }

        // this.age = toadInfoData.dob;
    }
    
    public void FetchFromToadStatusJson(ToadInfoStatus toadInfoStatus)
    {
        DateTime now = DateTime.Now;
        DateTime expectedMatureDate = toadInfoStatus.expectedMature;
        DateTime expectedHungryDate = toadInfoStatus.expectedHungry;
        DateTime expectedCollectDate = toadInfoStatus.expectedCollect;
        DateTime expectedBreedDate = toadInfoStatus.expectedBreed;

        remainMature = (float) (expectedMatureDate - now).TotalSeconds; 
        remainHungry = (float) (expectedHungryDate - now).TotalSeconds; 
        remainCollect = (float) (expectedCollectDate - now).TotalSeconds;
        remainBreed = (float) (expectedBreedDate - now).TotalSeconds;
        
       Debug.Log(toadName + " expected breed: " + expectedBreedDate);
  
        
        if (remainMature < 0)
        {
            isMature = true;
        }
        else
        {
            isMature = false;
        }

        if (remainHungry < 0)
        {
            isFeedable = true;
        }
        else
        {
            isFeedable = false;
        }
        
        if (remainCollect < 0)
        {
            isCollectable = true;
        }
        else
        {
            isCollectable = false;
        }
        
        if (remainBreed < 0)
        {
            isBreedable = true;
        }
        else
        {
            isBreedable = false;
        }
    }
    
    private void Update()
    {
        
        if (remainMature > 0)
        {
            remainMature -= Time.deltaTime;
            isMature = false;
        }
        else
        {
            isMature = true;
        }

        if (remainHungry > 0)
        {
            remainHungry -= Time.deltaTime;
            isFeedable = false;
        }
        else
        {
            isFeedable = true;
        }
        
        if (remainCollect > 0)
        {
            remainCollect -= Time.deltaTime;
            isCollectable = false;
        }
        else
        {
            isCollectable = true;
        }
        
        if (remainBreed > 0)
        {
            remainBreed -= Time.deltaTime;
            isBreedable = false;
        }
        else
        {
            isBreedable = true;
        }
        
        
        
    }
    // public Dictionary<Stats, int> stats = new Dictionary<Stats, int>
    // {
    //     {Stats.Health, 100},
    //     {Stats.Happiness, 100},
    //     {Stats.Hunger, 100}
    // };  
    
    // public void ChangeStats(Stats stat, int value)
    // {
    //     stats[stat] += value;
    //     stats[stat] = Mathf.Clamp(stats[stat], 0, 100);
    // }

   
    //
    // private void StartStatsDecrease() {
    //      StartCoroutine(DecreaseStat(Stats.Health, 10f));
    //      StartCoroutine(DecreaseStat(Stats.Happiness, 5f));
    //      StartCoroutine(DecreaseStat(Stats.Hunger, 5f));
    //      //StartCoroutine(DecreaseStat(Stats.Growing, 0.25f));
    // }

    // private IEnumerator DecreaseStat(Stats stat, float time)
    // {
    //     {
    //         isDecreasingStat = true;
    //         yield return new WaitForSeconds(time);
    //         isDecreasingStat = false;
    //         if (stats[stat] > 0)
    //         {
    //             stats[stat] -= 1;
    //         }
    //         
    //     }
    // }
    //
 
    
    

}

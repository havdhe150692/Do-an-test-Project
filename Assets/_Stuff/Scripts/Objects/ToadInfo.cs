using System;
using System.Collections;
using System.Collections.Generic;
using _Stuff.Scripts.Objects;
using UnityEngine;
using UnityEngine.PlayerLoop;

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
    
    [SerializeField]  public String toadName;
    [SerializeField]  public DateTime dOb;
    [SerializeField]  public bool isGrown;
    [SerializeField]  public Rarity rarity;

    public bool isMature;
    public bool isCollectable;
    public bool isFeedable;
    public bool isBreedable;

    public float remainMature;
    public float remainHungry;
    public float remainCollect;
    public float remainBreed;

    public void FetchFromToadListJson(ToadListJson toadListJson)
    {
        this.name = toadListJson.name;
        this.rarity = toadListJson.rarity;
    
    }
    
    public void FetchFromToadStatusJson(ToadStatusJson toadStatusJson)
    {
        DateTime now = DateTime.Now;
        DateTime expectedMatureDate = DateTime.ParseExact(toadStatusJson.expectedMature, "yyyy-MM-ddTHH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);
        DateTime expectedHungryDate = DateTime.ParseExact(toadStatusJson.expectedHungry, "yyyy-MM-ddTHH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);
        DateTime expectedCollectDate = DateTime.ParseExact(toadStatusJson.expectedCollect, "yyyy-MM-ddTHH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);
        DateTime expectedBreedDate = DateTime.ParseExact(toadStatusJson.expectedBreed, "yyyy-MM-ddTHH:mm:ss.fffzzz", System.Globalization.CultureInfo.InvariantCulture);

        remainMature = (float) (expectedMatureDate - now).TotalSeconds; 
        remainHungry = (float) (expectedHungryDate - now).TotalSeconds; 
        remainCollect = (float) (expectedCollectDate - now).TotalSeconds;
        remainBreed = (float) (expectedBreedDate - now).TotalSeconds;
        
      
        Debug.Log(toadName + " " +remainCollect);
  
        
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
        }

        if (remainHungry > 0)
        {
            remainHungry -= Time.deltaTime;
        }
        
        if (remainCollect > 0)
        {
            remainCollect -= Time.deltaTime;
        }
        
        if (remainBreed > 0)
        {
            remainBreed -= Time.deltaTime;
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

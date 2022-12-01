using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ToadStatusJson
{
    public int id;
    
    public string expectedMature;
    public string expectedBreed;
    public string expectedHungry;
    public string expectedCollect;
    

    public override string ToString()
    {
        return id + " " + expectedMature + " " + expectedBreed + " " + expectedHungry + " " + expectedCollect;
    }
}

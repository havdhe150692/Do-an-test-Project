using System.Collections;
using System.Collections.Generic;
using Org.BouncyCastle.Math;
using UnityEngine;
using UnityEngine.UI;

public class UiTransactionProcessing : MonoBehaviour
{
    [SerializeField] private Text transferDetail;
    public static string SYSTEM = "TOADKING";

    public void ChangeText(string from, string to, BigInteger amount)
    {
        transferDetail.text = "Transfer " + amount.ToString() + " from " + from + " to" + to;
    }
    
    
}

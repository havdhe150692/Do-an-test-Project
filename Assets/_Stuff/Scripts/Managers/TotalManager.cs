using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using _Stuff.Scripts.Managers;
using UnityEngine;

public class TotalManager : MonoBehaviour
{
   public static TotalManager Instance;
   
   [SerializeField] public UiManager uiManager;
   [SerializeField] public CursorManager cursorManager;
   [SerializeField] public InitialFetcherManager initialFetcherManager;
   [SerializeField] public DynamicFetcherManager dynamicFetcherManager;
   [SerializeField] public DataManager dataManager;
   [SerializeField] public NewPlayerManager newPlayerManager;
   
   [DllImport("__Internal")]
   private static extern string GetUserID();
   private void Awake()
   {
      Instance = this;
    
   }
   
   public void SetUserId(int userId)
   {
      dataManager.userId = userId;
   }
 
}

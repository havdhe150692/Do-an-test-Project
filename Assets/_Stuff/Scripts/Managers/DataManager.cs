using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Numerics;
using System.Runtime.InteropServices;
using _Stuff.Scripts.Objects;
using UnityEngine;

namespace _Stuff.Scripts.Managers
{
    public class DataManager : MonoBehaviour
    {
        public int userId = 0;
        public BigInteger tokenBalance = BigInteger.Zero;
        public bool isNewPlayer = true;
        public List<ToadInfoData> listData =
            new List<ToadInfoData>();
        
        public List<ToadInfoStatus> statusData =  
            new List<ToadInfoStatus>();

        public List<ToadStatusCheck> statusChecks =
            new List<ToadStatusCheck>();
        
        public List<ToadStatusCheck> breedList =
            new List<ToadStatusCheck>();

        public List<ToadStatusCheck> collectList =
            new List<ToadStatusCheck>();

        public List<ToadStatusCheck> matureList =
            new List<ToadStatusCheck>();

        public List<ToadStatusCheck> feedList =
            new List<ToadStatusCheck>();

        public ToadImages imagesSource;


        public Dictionary<int, ToadInfo> toadInfos = new Dictionary<int, ToadInfo>();

        public bool isToadBreedingSelectionBoard = false;
        
        [DllImport("__Internal")]
        private static extern string GetUserID();

        private void Awake()
        {
           SetUserId(Int32.Parse(GetUserID()));
           Debug.Log(userId);
           


        }

        public void CheckIfBreedable()
        {
            List<ToadStatusCheck> listStatusCheck = new List<ToadStatusCheck>();
            for (int i = 0; i < statusChecks.Count; i++)
            {
                var sc = statusChecks[i];
                if (sc.isToBreed)
                {
                    listStatusCheck.Add(sc);
                }
            }

            breedList = listStatusCheck;
        }

        public void SetUserId(int userId)
        {
            this.userId = userId;
        }
        
    }
}
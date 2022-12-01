using System.Collections.Generic;
using System.Numerics;
using _Stuff.Scripts.Objects;
using UnityEngine;

namespace _Stuff.Scripts.Managers
{
    public class DataManager : MonoBehaviour
    {
        public int userId = 0;
        public BigInteger tokenBalance = BigInteger.Zero;
        public bool isNewPlayer = true;
        public List<ToadListJson> toadListJson;
        public List<ToadStatusJson> toadStatusJson;
    }
}
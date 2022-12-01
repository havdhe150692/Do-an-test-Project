using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Stuff.Scripts.Objects
{
    [Serializable]
    public class ToadListJson
    {
        public int ListId;
        public int globalId;
        public String name;
        public ToadInfo.Rarity rarity;
        public int ownerId;

        public override string ToString()
        {
            return ListId + " " + globalId + " " + name + " " + rarity + " " + ownerId;
        }
    }


}
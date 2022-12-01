using System;

namespace _Stuff.Scripts.Objects
{
    
    [Serializable]
    public class ToadDetailJson
    {
        public int globalId;
        public String name;
        public ToadInfo.Rarity rarity;
        public String dateOfBirth;
        public String info;
        public String toadClass;
    }
}
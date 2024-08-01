using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameEngine
{
    public class Monster : LivingCreatures
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int MaxDMG { get; set; }
        public int XPReward { get; set;}
        public int GoldReward { get; set;}
        public List<LootItem> LootTable { get; set; }
        public Monster(int id, string name, int maxDMG, int xpRevard, int goldReward, int currentHP, int maxHP, int currentMana, int maxMana) 
            : base(currentHP, maxHP, currentMana, maxMana)
        {
            ID = id;
            Name = name;
            MaxDMG = maxDMG;
            XPReward = xpRevard;
            GoldReward = goldReward;
            LootTable = new List<LootItem>();
        }
    }
}

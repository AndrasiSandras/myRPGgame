using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameEngine
{
    public class Potion : Item
    {
        public int HealAmount { get; set;}
        public int ManaAmount { get; set; }
        public int XPAmount { get; set; }
        public Potion(int id, string name, string namePlural, int healAmount, int manaAmount, int xpAmount) 
            : base(id, name, namePlural)
        {
            HealAmount = healAmount;
            ManaAmount = manaAmount;
            XPAmount = xpAmount;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameEngine
{
    public class Spell : Item
    {
        public int MinDMG { get; set; }
        public int MaxDMG { get; set; }
        public int ManaCost { get; set; }
        public Spell(int id, string name, string namePlural, int minimumDMG, int maximumDMG, int manaCost) 
            : base(id, name, namePlural)
        {
            MinDMG = minimumDMG;
            MaxDMG = maximumDMG;
            ManaCost = manaCost;
        }
    }
}

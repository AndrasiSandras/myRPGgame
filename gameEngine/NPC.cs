using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameEngine
{
    public class NPC : LivingCreatures
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public NPC(int id, string name, int currentHP, int maxHP, int currentMana, int maxMana)
            : base(currentHP, maxHP, currentMana, maxMana)
        {
            ID = id;
            Name = name;
        }
    }
}

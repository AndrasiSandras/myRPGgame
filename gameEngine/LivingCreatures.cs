using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameEngine
{
    public class LivingCreatures
    {
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int CurrentMana { get; set; }
        public int MaxMana { get; set; }
        public LivingCreatures(int currentHP, int maxHP, int currentMana, int maxMana)
        {
            CurrentHP = currentHP;
            MaxHP = maxHP;
            CurrentMana = currentMana;
            MaxMana = maxMana;
        }
    }
}

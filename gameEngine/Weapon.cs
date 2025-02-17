﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameEngine
{
    public class Weapon : Item
    {
        public int MinDMG { get; set; }
        public int MaxDMG { get; set;}
        public Weapon(int id, string name, string namePlural, int minimumDMG, int maximumDMG) 
            : base(id, name, namePlural)
        {
            MinDMG = minimumDMG;
            MaxDMG = maximumDMG;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gameEngine
{
    public class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int XPReward { get; set; }
        public int GoldReward { get; set; }
        public List<QuestCompletionItem> QuestCompletionItems { get; set; }
        public Item ItemReward { get; set; }

        public Quest(int id, string name, string description, int xpRevard, int goldRevard) 
        {
            ID = id;
            Name = name;
            Description = description;
            XPReward = xpRevard;
            GoldReward = goldRevard;
            QuestCompletionItems = new List<QuestCompletionItem>();
        }
    }
}

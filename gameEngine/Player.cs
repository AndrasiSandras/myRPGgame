using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gameEngine
{
    public class Player : LivingCreatures
    {
        public int Gold {  get; set; }
        public int XP { get; set; }
        public int Level
        {
            get { return ((XP / 100) + 1); }
        }
        public List<Inventory> Inventory { get; set; }
        public List<PlayerQuest> Quests { get; set; }
        public Location CurrentLocation { get; set; }

        public Player(int currentHP, int maxHP, int currentMana, int maxMana, int gold, int xp) 
            : base(currentHP, maxHP, currentMana, maxMana)
        {
            Gold = gold;
            XP = xp;

            Inventory = new List<Inventory>();
            Quests = new List<PlayerQuest>();
        }
        public bool HasRequiredItemToEnterThisLocation(Location location)
        {
            if (location.ItemRequiredToEnter == null)
            {
                // There is no required item for this location, so return "true"
                return true;
            }
            // See if the player has the required item in their inventory
            return Inventory.Exists(ii => ii.Details.ID == location.ItemRequiredToEnter.ID);
        }
        public bool HasThisQuest(Quest quest)
        {
            return Quests.Exists(pq => pq.Details.ID == quest.ID);
        }
        public bool CompletedThisQuest(Quest quest)
        {
            foreach (PlayerQuest playerQuest in Quests)
            {
                if (playerQuest.Details.ID == quest.ID)
                {
                    return playerQuest.IsCompleted;
                }
            }

            return false;
        }
        public bool HasAllQuestCompletionItems(Quest quest)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                // Check each item in the player's inventory, to see if they have it, and enough of it
                if (!Inventory.Exists(ii => ii.Details.ID == qci.Details.ID && ii.Quantity >= qci.Quantity))
                {
                    return false;
                }
            }
            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }
        public void RemoveQuestCompletionItems(Quest quest)
        {
            foreach (QuestCompletionItem qci in quest.QuestCompletionItems)
            {
                Inventory item = Inventory.SingleOrDefault(ii => ii.Details.ID == qci.Details.ID);
                if (item != null)
                {
                    // Subtract the quantity from the player's inventory that was needed to complete the quest
                    item.Quantity -= qci.Quantity;
                }
            }
        }
        public void AddItemToInventory(Item itemToAdd)
        {
            Inventory item = Inventory.SingleOrDefault(ii => ii.Details.ID == itemToAdd.ID);
            if (item == null)
            {
                // They didn't have the item, so add it to their inventory, with a quantity of 1
                Inventory.Add(new Inventory(itemToAdd, 1));
            }
            else
            {
                // They have the item in their inventory, so increase the quantity by one
                item.Quantity++;
            }
        }
        public void MarkQuestCompleted(Quest quest)
        {
            // Find the quest in the player's quest list
            PlayerQuest playerQuest = Quests.SingleOrDefault(pq => pq.Details.ID == quest.ID);
            if (playerQuest != null)
            {
                playerQuest.IsCompleted = true;
            }
        }
        public string ToXmlString()
        {
            XmlDocument playerData = new XmlDocument();
            // Create the top-level XML node
            XmlNode player = playerData.CreateElement("Player");
            playerData.AppendChild(player);
            // Create the "Stats" child node to hold the other player statistics nodes
            XmlNode stats = playerData.CreateElement("Stats");
            player.AppendChild(stats);
            // Create the child nodes for the "Stats" node
            XmlNode currentHP = playerData.CreateElement("CurrentHP");
            currentHP.AppendChild(playerData.CreateTextNode(this.CurrentHP.ToString()));
            stats.AppendChild(currentHP);
            XmlNode maxHP = playerData.CreateElement("MaxHP");
            maxHP.AppendChild(playerData.CreateTextNode(this.MaxHP.ToString()));
            stats.AppendChild(maxHP);
            XmlNode currentMana = playerData.CreateElement("CurrentMana");
            currentMana.AppendChild(playerData.CreateTextNode(this.CurrentMana.ToString()));
            stats.AppendChild(currentMana);
            XmlNode maxMana = playerData.CreateElement("MaxMana");
            maxMana.AppendChild(playerData.CreateTextNode(this.MaxMana.ToString()));
            stats.AppendChild(maxMana);
            XmlNode gold = playerData.CreateElement("Gold");
            gold.AppendChild(playerData.CreateTextNode(this.Gold.ToString()));
            stats.AppendChild(gold);
            XmlNode xp = playerData.CreateElement("XP");
            xp.AppendChild(playerData.CreateTextNode(this.XP.ToString()));
            stats.AppendChild(xp);
            XmlNode currentLocation = playerData.CreateElement("CurrentLocation");
            currentLocation.AppendChild(playerData.CreateTextNode(this.CurrentLocation.ID.ToString()));
            stats.AppendChild(currentLocation);
            // Create the "InventoryItems" child node to hold each InventoryItem node
            XmlNode inventoryItems = playerData.CreateElement("InventoryItems");
            player.AppendChild(inventoryItems);
            // Create an "InventoryItem" node for each item in the player's inventory
            foreach (Inventory item in this.Inventory)
            {
                XmlNode inventory = playerData.CreateElement("InventoryItem");
                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = item.Details.ID.ToString();
                inventory.Attributes.Append(idAttribute);
                XmlAttribute quantityAttribute = playerData.CreateAttribute("Quantity");
                quantityAttribute.Value = item.Quantity.ToString();
                inventory.Attributes.Append(quantityAttribute);
                inventoryItems.AppendChild(inventory);
            }
            // Create the "PlayerQuests" child node to hold each PlayerQuest node
            XmlNode playerQuests = playerData.CreateElement("PlayerQuests");
            player.AppendChild(playerQuests);
            // Create a "PlayerQuest" node for each quest the player has acquired
            foreach (PlayerQuest quest in this.Quests)
            {
                XmlNode playerQuest = playerData.CreateElement("PlayerQuest");
                XmlAttribute idAttribute = playerData.CreateAttribute("ID");
                idAttribute.Value = quest.Details.ID.ToString();
                playerQuest.Attributes.Append(idAttribute);
                XmlAttribute isCompletedAttribute = playerData.CreateAttribute("IsCompleted");
                isCompletedAttribute.Value = quest.IsCompleted.ToString();
                playerQuest.Attributes.Append(isCompletedAttribute);
                playerQuests.AppendChild(playerQuest);
            }
            return playerData.InnerXml; // The XML document, as a string, so we can save the data to disk
        }
    }
}
using gameEngine;
using System.Security.Cryptography;

namespace myRPGgame
{
    public partial class myRPGgame : Form
    {
        private Player player;
        private Monster currentMonster;

        public myRPGgame()
        {
            InitializeComponent();

            player = new Player(100, 100, 100, 100, 50, 0);
            MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            player.Inventory.Add(new Inventory(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1));

            UpdatePlayerStats();
        }

        private void myRPGgame_Load(object sender, EventArgs e)
        {

        }

        private void ButtonNorth_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToNorth);
        }

        private void ButtonWest_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToWest);
        }

        private void ButtonEast_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToEast);
        }

        private void ButtonSouth_Click(object sender, EventArgs e)
        {
            MoveTo(player.CurrentLocation.LocationToSouth);
        }

        private void MoveTo(Location newLocation)
        {
            //Does the location have any required items
            if (!player.HasRequiredItemToEnterThisLocation(newLocation))
            {
                richTextBoxMessages.Text += "You must have a " + newLocation.ItemRequiredToEnter.Name + " to enter this location." + Environment.NewLine;
                ScrollToBottomOfMessages();
                return;
            }

            // Update the player's current location
            player.CurrentLocation = newLocation;

            // Show/hide available movement buttons
            ButtonNorth.Visible = (newLocation.LocationToNorth != null);
            ButtonEast.Visible = (newLocation.LocationToEast != null);
            ButtonSouth.Visible = (newLocation.LocationToSouth != null);
            ButtonWest.Visible = (newLocation.LocationToWest != null);

            // Display current location name and description
            richTextBoxLocation.Text = newLocation.Name + Environment.NewLine;
            richTextBoxLocation.Text += newLocation.Description + Environment.NewLine;

            if (newLocation == World.LocationByID(World.LOCATION_ID_HOME))
            {
                // Completely heal the player!!!
                player.CurrentHP = player.MaxHP;
                player.CurrentMana = player.MaxMana;
            }

            // Update Hit Points in UI
            hpCounter.Text = player.CurrentHP.ToString();
            manaCounter.Text = player.CurrentMana.ToString();

            // Does the location have a quest?
            if (newLocation.QuestAvailableHere != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = player.HasThisQuest(newLocation.QuestAvailableHere);
                bool playerAlreadyCompletedQuest = player.CompletedThisQuest(newLocation.QuestAvailableHere);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = player.HasAllQuestCompletionItems(newLocation.QuestAvailableHere);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            richTextBoxMessages.Text += Environment.NewLine;
                            richTextBoxMessages.Text += "You complete the '" + newLocation.QuestAvailableHere.Name + "' quest." + Environment.NewLine;

                            // Remove quest items from inventory
                            player.RemoveQuestCompletionItems(newLocation.QuestAvailableHere);


                            // Give quest rewards
                            richTextBoxMessages.Text += "You receive: " + Environment.NewLine;
                            richTextBoxMessages.Text += newLocation.QuestAvailableHere.XPReward.ToString() + " experience points" + Environment.NewLine;
                            richTextBoxMessages.Text += newLocation.QuestAvailableHere.GoldReward.ToString() + " gold" + Environment.NewLine;
                            richTextBoxMessages.Text += newLocation.QuestAvailableHere.ItemReward.Name + Environment.NewLine;
                            richTextBoxMessages.Text += Environment.NewLine;

                            player.XP += newLocation.QuestAvailableHere.XPReward;
                            player.Gold += newLocation.QuestAvailableHere.GoldReward;

                            // Add the reward item to the player's inventory
                            player.AddItemToInventory(newLocation.QuestAvailableHere.ItemReward);

                            // Mark the quest as completed
                            player.MarkQuestCompleted(newLocation.QuestAvailableHere);

                            ScrollToBottomOfMessages();
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
                    richTextBoxMessages.Text += "You receive the " + newLocation.QuestAvailableHere.Name + " quest." + Environment.NewLine;
                    richTextBoxMessages.Text += newLocation.QuestAvailableHere.Description + Environment.NewLine;
                    richTextBoxMessages.Text += "To complete it, return with:" + Environment.NewLine;
                    foreach (QuestCompletionItem qci in newLocation.QuestAvailableHere.QuestCompletionItems)
                    {
                        if (qci.Quantity == 1)
                        {
                            richTextBoxMessages.Text += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                            ScrollToBottomOfMessages();
                        }
                        else
                        {
                            richTextBoxMessages.Text += qci.Quantity.ToString() + " " + qci.Details.NamePlural + Environment.NewLine;
                            ScrollToBottomOfMessages();
                        }
                    }
                    richTextBoxMessages.Text += Environment.NewLine;

                    // Add the quest to the player's quest list
                    player.Quests.Add(new PlayerQuest(newLocation.QuestAvailableHere));
                    ScrollToBottomOfMessages();
                }
            }

            // Does the location have a monster?
            if (newLocation.MonsterLivingHere != null)
            {
                richTextBoxMessages.Text += "You see a " + newLocation.MonsterLivingHere.Name + Environment.NewLine;

                // Make a new monster, using the values from the standard monster in the World.Monster list
                Monster standardMonster = World.MonsterByID(newLocation.MonsterLivingHere.ID);

                currentMonster = new Monster(standardMonster.ID, standardMonster.Name, standardMonster.MaxDMG,
                    standardMonster.XPReward, standardMonster.GoldReward, standardMonster.CurrentHP, standardMonster.MaxHP, standardMonster.CurrentMana, standardMonster.MaxMana);

                foreach (LootItem lootItem in standardMonster.LootTable)
                {
                    currentMonster.LootTable.Add(lootItem);
                }

                comboBoxWeapons.Visible = true;
                comboBoxSpells.Visible = true;
                comboBoxPotions.Visible = true;
                UseWeapon.Visible = true;
                UseSpell.Visible = true;
                UsePotion.Visible = true;

                ScrollToBottomOfMessages();
            }
            else
            {
                currentMonster = null;

                comboBoxWeapons.Visible = false;
                comboBoxSpells.Visible = false;
                comboBoxPotions.Visible = false;
                UseWeapon.Visible = false;
                UseSpell.Visible = false;
                UsePotion.Visible = false;
            }

            // Refresh player's stats
            UpdatePlayerStats();

            // Refresh player's inventory list
            UpdateInventoryListInUI();

            // Refresh player's quest list
            UpdateQuestListInUI();

            // Refresh player's weapons combobox
            UpdateWeaponListInUI();

            // Refresh player's spells combobox
            UpdateSpellListInUI();

            // Refresh player's potions combobox
            UpdatePotionListInUI();
        }
        private void UpdatePlayerStats()
        {
            // Refresh player information and inventory controls
            hpCounter.Text = player.CurrentHP.ToString();
            manaCounter.Text = player.CurrentMana.ToString();
            goldCounter.Text = player.Gold.ToString();
            xpCounter.Text = player.XP.ToString();
            levelCounter.Text = player.Level.ToString();
        }

        private void UpdateInventoryListInUI()
        {
            dataGridViewInventory.RowHeadersVisible = false;

            dataGridViewInventory.ColumnCount = 2;
            dataGridViewInventory.Columns[0].Name = "Name";
            dataGridViewInventory.Columns[0].Width = 197;
            dataGridViewInventory.Columns[1].Name = "Quantity";

            dataGridViewInventory.Rows.Clear();

            foreach (Inventory inventoryItem in player.Inventory)
            {
                if (inventoryItem.Quantity > 0)
                {
                    dataGridViewInventory.Rows.Add(new[] { inventoryItem.Details.Name, inventoryItem.Quantity.ToString() });
                }
            }
        }

        private void UpdateQuestListInUI()
        {
            dataGridViewQuests.RowHeadersVisible = false;

            dataGridViewQuests.ColumnCount = 2;
            dataGridViewQuests.Columns[0].Name = "Name";
            dataGridViewQuests.Columns[0].Width = 197;
            dataGridViewQuests.Columns[1].Name = "Done?";

            dataGridViewQuests.Rows.Clear();

            foreach (PlayerQuest playerQuest in player.Quests)
            {
                dataGridViewQuests.Rows.Add(new[] { playerQuest.Details.Name, playerQuest.IsCompleted.ToString() });
            }
        }

        private void UpdateWeaponListInUI()
        {
            List<Weapon> weapons = new List<Weapon>();

            foreach (Inventory inventoryItem in player.Inventory)
            {
                if (inventoryItem.Details is Weapon)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        weapons.Add((Weapon)inventoryItem.Details);
                    }
                }
            }

            if (weapons.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                comboBoxWeapons.Visible = false;
                UseWeapon.Visible = false;
            }
            else
            {
                comboBoxWeapons.DataSource = weapons;
                comboBoxWeapons.DisplayMember = "Name";
                comboBoxWeapons.ValueMember = "ID";

                comboBoxWeapons.SelectedIndex = 0;
            }
        }
        private void UpdateSpellListInUI()
        {
            List<Spell> spells = new List<Spell>();

            foreach (Inventory inventoryItem in player.Inventory)
            {
                if (inventoryItem.Details is Spell)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        spells.Add((Spell)inventoryItem.Details);
                    }
                }
            }

            if (spells.Count == 0)
            {
                // The player doesn't have any weapons, so hide the weapon combobox and "Use" button
                comboBoxSpells.Visible = false;
                UseSpell.Visible = false;
            }
            else
            {
                comboBoxSpells.DataSource = spells;
                comboBoxSpells.DisplayMember = "Name";
                comboBoxSpells.ValueMember = "ID";

                comboBoxSpells.SelectedIndex = 0;
            }
        }

        private void UpdatePotionListInUI()
        {
            List<Potion> Potions = new List<Potion>();

            foreach (Inventory inventoryItem in player.Inventory)
            {
                if (inventoryItem.Details is Potion)
                {
                    if (inventoryItem.Quantity > 0)
                    {
                        Potions.Add((Potion)inventoryItem.Details);
                    }
                }
            }

            if (Potions.Count == 0)
            {
                // The player doesn't have any potions, so hide the potion combobox and "Use" button
                comboBoxPotions.Visible = false;
                UsePotion.Visible = false;
            }
            else
            {
                comboBoxPotions.DataSource = Potions;
                comboBoxPotions.DisplayMember = "Name";
                comboBoxPotions.ValueMember = "ID";

                comboBoxPotions.SelectedIndex = 0;
            }
        }

        private void UseWeapon_Click(object sender, EventArgs e)
        {
            // Get the currently selected weapon from the cboWeapons ComboBox
            Weapon currentWeapon = (Weapon)comboBoxWeapons.SelectedItem;
            // Determine the amount of damage to do to the monster
            int damageToMonster = RNG.NumberBetween(currentWeapon.MinDMG, currentWeapon.MaxDMG);
            // Apply the damage to the monster's CurrentHitPoints
            currentMonster.CurrentHP -= damageToMonster;
            // Display message
            Attack(damageToMonster);

        }
        private void UseSpell_Click(object sender, EventArgs e)
        {
            // Get the currently selected weapon from the cboWeapons ComboBox
            Spell currentSpell = (Spell)comboBoxSpells.SelectedItem;
            if (player.CurrentMana < currentSpell.ManaCost)
            {
                richTextBoxMessages.Text += "You cant use " + currentSpell.Name + ", not enough mana" + Environment.NewLine;
                ScrollToBottomOfMessages();
            }
            else
            {
                // Determine the amount of damage to do to the monster
                int damageToMonster = RNG.NumberBetween(currentSpell.MinDMG, currentSpell.MaxDMG);
                // Apply the damage to the monster's CurrentHitPoints
                currentMonster.CurrentHP -= damageToMonster;
                // Mana cost
                player.CurrentMana -= currentSpell.ManaCost;
                // Display message
                Attack(damageToMonster);
            }
        }

        private void UsePotion_Click(object sender, EventArgs e)
        {
            // Get the currently selected potion from the combobox
            Potion potion = (Potion)comboBoxPotions.SelectedItem;
            // Add healing amount to the player's current hit points
            player.CurrentHP = (player.CurrentHP + potion.HealAmount);
            player.CurrentMana = (player.CurrentMana + potion.ManaAmount);
            player.XP = (player.XP + potion.XPAmount);
            // CurrentHitPoints cannot exceed player's MaximumHitPoints
            if (player.CurrentHP > player.MaxHP)
            {
                player.CurrentHP = player.MaxHP;
            }
            if (player.CurrentMana > player.MaxMana)
            {
                player.CurrentMana = player.MaxMana;
            }
            // Remove the potion from the player's inventory
            foreach (Inventory ii in player.Inventory)
            {
                if (ii.Details.ID == potion.ID)
                {
                    ii.Quantity--;
                    break;
                }
            }
            // Display message
            richTextBoxMessages.Text += "You drink a " + potion.Name + Environment.NewLine;
            // Monster gets their turn to attack
            // Determine the amount of damage the monster does to the player
            int damageToPlayer = RNG.NumberBetween(0, currentMonster.MaxDMG);
            // Display message
            richTextBoxMessages.Text += "The " + currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;
            // Subtract damage from player
            player.CurrentHP -= damageToPlayer;
            if (player.CurrentHP <= 0)
            {
                // Display message
                richTextBoxMessages.Text += "The " + currentMonster.Name + " killed you." + Environment.NewLine;
                // Move player to "Home"
                MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            }
            // Refresh player data in UI
            hpCounter.Text = player.CurrentHP.ToString();
            manaCounter.Text = player.CurrentMana.ToString();
            UpdateInventoryListInUI();
            UpdatePotionListInUI();
            ScrollToBottomOfMessages();
        }
        private void ScrollToBottomOfMessages()
        {
            richTextBoxMessages.SelectionStart = richTextBoxMessages.Text.Length;
            richTextBoxMessages.ScrollToCaret();
        }

        private void Attack(int DMG)
        {
            int damageToMonster = DMG;
            // Display message
            richTextBoxMessages.Text += "You hit the " + currentMonster.Name + " for " + damageToMonster.ToString() + " points." + Environment.NewLine;
            // Check if the monster is dead
            if (currentMonster.CurrentHP <= 0)
            {
                // Monster is dead
                richTextBoxMessages.Text += Environment.NewLine;
                richTextBoxMessages.Text += "You defeated the " + currentMonster.Name + Environment.NewLine;
                // Give player experience points for killing the monster
                player.XP += currentMonster.XPReward;
                richTextBoxMessages.Text += "You receive " + currentMonster.XPReward.ToString() + " experience points" + Environment.NewLine;
                // Give player gold for killing the monster 
                player.Gold += currentMonster.GoldReward;
                richTextBoxMessages.Text += "You receive " + currentMonster.GoldReward.ToString() + " gold" + Environment.NewLine;
                // Get random loot items from the monster
                List<Inventory> lootedItems = new List<Inventory>();
                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (LootItem lootItem in currentMonster.LootTable)
                {
                    if (RNG.NumberBetween(1, 100) <= lootItem.DropPercentage)
                    {
                        lootedItems.Add(new Inventory(lootItem.Details, 1));
                    }
                }
                // If no items were randomly selected, then add the default loot item(s).
                if (lootedItems.Count == 0)
                {
                    foreach (LootItem lootItem in currentMonster.LootTable)
                    {
                        if (lootItem.IsDefaultItem)
                        {
                            lootedItems.Add(new Inventory(lootItem.Details, 1));
                        }
                    }
                }
                // Add the looted items to the player's inventory
                foreach (Inventory inventoryItem in lootedItems)
                {
                    player.AddItemToInventory(inventoryItem.Details);
                    if (inventoryItem.Quantity == 1)
                    {
                        richTextBoxMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                    }
                    else
                    {
                        richTextBoxMessages.Text += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.NamePlural + Environment.NewLine;
                    }
                }
                // Refresh player information and inventory controls
                UpdatePlayerStats();
                UpdateInventoryListInUI();
                UpdateWeaponListInUI();
                UpdatePotionListInUI();
                // Add a blank line to the messages box, just for appearance.
                richTextBoxMessages.Text += Environment.NewLine;
                // Move player to current location (to heal player and create a new monster to fight)
                MoveTo(player.CurrentLocation);
                ScrollToBottomOfMessages();
            }
            else
            {
                // Monster is still alive
                // Determine the amount of damage the monster does to the player
                int damageToPlayer = RNG.NumberBetween(0, currentMonster.MaxDMG);
                // Display message
                richTextBoxMessages.Text += "The " + currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;
                // Subtract damage from player
                player.CurrentHP -= damageToPlayer;
                // Refresh player data in UI
                hpCounter.Text = player.CurrentHP.ToString();
                manaCounter.Text = player.CurrentMana.ToString();
                if (player.CurrentHP <= 0)
                {
                    // Display message
                    richTextBoxMessages.Text += "The " + currentMonster.Name + " killed you." + Environment.NewLine;
                    // Move player to "Home"
                    MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                }
                ScrollToBottomOfMessages();
            }
        }
    }
}
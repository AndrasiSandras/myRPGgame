namespace myRPGgame
{
    partial class myRPGgame
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            hpBar = new Label();
            goldBar = new Label();
            xpBar = new Label();
            levelBar = new Label();
            hpCounter = new Label();
            goldCounter = new Label();
            xpCounter = new Label();
            levelCounter = new Label();
            manaBar = new Label();
            manaCounter = new Label();
            label = new Label();
            comboBoxWeapons = new ComboBox();
            comboBoxPotions = new ComboBox();
            comboBoxSpells = new ComboBox();
            UseWeapon = new Button();
            UseSpell = new Button();
            UsePotion = new Button();
            ButtonNorth = new Button();
            ButtonWest = new Button();
            ButtonEast = new Button();
            ButtonSouth = new Button();
            richTextBoxLocation = new RichTextBox();
            richTextBoxMessages = new RichTextBox();
            dataGridViewInventory = new DataGridView();
            dataGridViewQuests = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuests).BeginInit();
            SuspendLayout();
            // 
            // hpBar
            // 
            hpBar.AutoSize = true;
            hpBar.BackColor = Color.Red;
            hpBar.Location = new Point(20, 20);
            hpBar.Name = "hpBar";
            hpBar.Size = new Size(39, 25);
            hpBar.TabIndex = 0;
            hpBar.Text = "HP:";
            // 
            // goldBar
            // 
            goldBar.AutoSize = true;
            goldBar.BackColor = Color.Gold;
            goldBar.Location = new Point(20, 100);
            goldBar.Name = "goldBar";
            goldBar.Size = new Size(54, 25);
            goldBar.TabIndex = 1;
            goldBar.Text = "Gold:";
            // 
            // xpBar
            // 
            xpBar.AutoSize = true;
            xpBar.BackColor = Color.Lime;
            xpBar.Location = new Point(20, 140);
            xpBar.Name = "xpBar";
            xpBar.Size = new Size(37, 25);
            xpBar.TabIndex = 2;
            xpBar.Text = "XP:";
            // 
            // levelBar
            // 
            levelBar.AutoSize = true;
            levelBar.BackColor = Color.FromArgb(192, 255, 192);
            levelBar.Location = new Point(20, 180);
            levelBar.Name = "levelBar";
            levelBar.Size = new Size(55, 25);
            levelBar.TabIndex = 3;
            levelBar.Text = "Level:";
            // 
            // hpCounter
            // 
            hpCounter.AutoSize = true;
            hpCounter.BackColor = Color.Red;
            hpCounter.Location = new Point(120, 20);
            hpCounter.Name = "hpCounter";
            hpCounter.Size = new Size(0, 25);
            hpCounter.TabIndex = 4;
            // 
            // goldCounter
            // 
            goldCounter.AutoSize = true;
            goldCounter.BackColor = Color.Gold;
            goldCounter.Location = new Point(120, 100);
            goldCounter.Name = "goldCounter";
            goldCounter.Size = new Size(0, 25);
            goldCounter.TabIndex = 5;
            // 
            // xpCounter
            // 
            xpCounter.AutoSize = true;
            xpCounter.BackColor = Color.Lime;
            xpCounter.Location = new Point(120, 140);
            xpCounter.Name = "xpCounter";
            xpCounter.Size = new Size(0, 25);
            xpCounter.TabIndex = 6;
            // 
            // levelCounter
            // 
            levelCounter.AutoSize = true;
            levelCounter.BackColor = Color.FromArgb(192, 255, 192);
            levelCounter.Location = new Point(120, 180);
            levelCounter.Name = "levelCounter";
            levelCounter.Size = new Size(0, 25);
            levelCounter.TabIndex = 7;
            // 
            // manaBar
            // 
            manaBar.AutoSize = true;
            manaBar.BackColor = Color.SkyBlue;
            manaBar.Location = new Point(20, 60);
            manaBar.Name = "manaBar";
            manaBar.Size = new Size(56, 25);
            manaBar.TabIndex = 8;
            manaBar.Text = "Mana";
            // 
            // manaCounter
            // 
            manaCounter.AutoSize = true;
            manaCounter.BackColor = Color.SkyBlue;
            manaCounter.Location = new Point(120, 60);
            manaCounter.Name = "manaCounter";
            manaCounter.Size = new Size(0, 25);
            manaCounter.TabIndex = 9;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(610, 460);
            label.Name = "label";
            label.Size = new Size(111, 25);
            label.TabIndex = 12;
            label.Text = "Select action";
            // 
            // comboBoxWeapons
            // 
            comboBoxWeapons.FormattingEnabled = true;
            comboBoxWeapons.Location = new Point(370, 510);
            comboBoxWeapons.Name = "comboBoxWeapons";
            comboBoxWeapons.Size = new Size(182, 33);
            comboBoxWeapons.TabIndex = 13;
            // 
            // comboBoxPotions
            // 
            comboBoxPotions.FormattingEnabled = true;
            comboBoxPotions.Location = new Point(370, 590);
            comboBoxPotions.Name = "comboBoxPotions";
            comboBoxPotions.Size = new Size(182, 33);
            comboBoxPotions.TabIndex = 14;
            // 
            // comboBoxSpells
            // 
            comboBoxSpells.FormattingEnabled = true;
            comboBoxSpells.Location = new Point(370, 550);
            comboBoxSpells.Name = "comboBoxSpells";
            comboBoxSpells.Size = new Size(182, 33);
            comboBoxSpells.TabIndex = 15;
            // 
            // UseWeapon
            // 
            UseWeapon.Location = new Point(610, 510);
            UseWeapon.Name = "UseWeapon";
            UseWeapon.Size = new Size(112, 34);
            UseWeapon.TabIndex = 16;
            UseWeapon.Text = "Use";
            UseWeapon.UseVisualStyleBackColor = true;
            UseWeapon.Click += UseWeapon_Click;
            // 
            // UseSpell
            // 
            UseSpell.Location = new Point(610, 550);
            UseSpell.Name = "UseSpell";
            UseSpell.Size = new Size(112, 34);
            UseSpell.TabIndex = 17;
            UseSpell.Text = "Use";
            UseSpell.UseVisualStyleBackColor = true;
            UseSpell.Click += UseSpell_Click;
            // 
            // UsePotion
            // 
            UsePotion.Location = new Point(610, 590);
            UsePotion.Name = "UsePotion";
            UsePotion.Size = new Size(112, 34);
            UsePotion.TabIndex = 18;
            UsePotion.Text = "Use";
            UsePotion.UseVisualStyleBackColor = true;
            UsePotion.Click += UsePotion_Click;
            // 
            // ButtonNorth
            // 
            ButtonNorth.Location = new Point(510, 300);
            ButtonNorth.Name = "ButtonNorth";
            ButtonNorth.Size = new Size(112, 34);
            ButtonNorth.TabIndex = 19;
            ButtonNorth.Text = "North";
            ButtonNorth.UseVisualStyleBackColor = true;
            ButtonNorth.Click += ButtonNorth_Click;
            // 
            // ButtonWest
            // 
            ButtonWest.Location = new Point(410, 360);
            ButtonWest.Name = "ButtonWest";
            ButtonWest.Size = new Size(112, 34);
            ButtonWest.TabIndex = 20;
            ButtonWest.Text = "West";
            ButtonWest.UseVisualStyleBackColor = true;
            ButtonWest.Click += ButtonWest_Click;
            // 
            // ButtonEast
            // 
            ButtonEast.Location = new Point(610, 360);
            ButtonEast.Name = "ButtonEast";
            ButtonEast.Size = new Size(112, 34);
            ButtonEast.TabIndex = 21;
            ButtonEast.Text = "East";
            ButtonEast.UseVisualStyleBackColor = true;
            ButtonEast.Click += ButtonEast_Click;
            // 
            // ButtonSouth
            // 
            ButtonSouth.Location = new Point(510, 420);
            ButtonSouth.Name = "ButtonSouth";
            ButtonSouth.Size = new Size(112, 34);
            ButtonSouth.TabIndex = 22;
            ButtonSouth.Text = "South";
            ButtonSouth.UseVisualStyleBackColor = true;
            ButtonSouth.Click += ButtonSouth_Click;
            // 
            // richTextBoxLocation
            // 
            richTextBoxLocation.Location = new Point(350, 20);
            richTextBoxLocation.Name = "richTextBoxLocation";
            richTextBoxLocation.ReadOnly = true;
            richTextBoxLocation.Size = new Size(360, 100);
            richTextBoxLocation.TabIndex = 23;
            richTextBoxLocation.Text = "";
            // 
            // richTextBoxMessages
            // 
            richTextBoxMessages.Location = new Point(350, 130);
            richTextBoxMessages.Name = "richTextBoxMessages";
            richTextBoxMessages.Size = new Size(360, 144);
            richTextBoxMessages.TabIndex = 24;
            richTextBoxMessages.Text = "";
            // 
            // dataGridViewInventory
            // 
            dataGridViewInventory.AllowUserToAddRows = false;
            dataGridViewInventory.AllowUserToDeleteRows = false;
            dataGridViewInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewInventory.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewInventory.Location = new Point(20, 230);
            dataGridViewInventory.MultiSelect = false;
            dataGridViewInventory.Name = "dataGridViewInventory";
            dataGridViewInventory.ReadOnly = true;
            dataGridViewInventory.RowHeadersWidth = 62;
            dataGridViewInventory.Size = new Size(300, 260);
            dataGridViewInventory.TabIndex = 25;
            // 
            // dataGridViewQuests
            // 
            dataGridViewQuests.AllowUserToAddRows = false;
            dataGridViewQuests.AllowUserToDeleteRows = false;
            dataGridViewQuests.AllowUserToResizeRows = false;
            dataGridViewQuests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewQuests.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridViewQuests.Location = new Point(20, 500);
            dataGridViewQuests.MultiSelect = false;
            dataGridViewQuests.Name = "dataGridViewQuests";
            dataGridViewQuests.ReadOnly = true;
            dataGridViewQuests.RowHeadersWidth = 62;
            dataGridViewQuests.Size = new Size(300, 120);
            dataGridViewQuests.TabIndex = 26;
            // 
            // myRPGgame
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 634);
            Controls.Add(dataGridViewQuests);
            Controls.Add(dataGridViewInventory);
            Controls.Add(richTextBoxMessages);
            Controls.Add(richTextBoxLocation);
            Controls.Add(ButtonSouth);
            Controls.Add(ButtonEast);
            Controls.Add(ButtonWest);
            Controls.Add(ButtonNorth);
            Controls.Add(UsePotion);
            Controls.Add(UseSpell);
            Controls.Add(UseWeapon);
            Controls.Add(comboBoxSpells);
            Controls.Add(comboBoxPotions);
            Controls.Add(comboBoxWeapons);
            Controls.Add(label);
            Controls.Add(manaCounter);
            Controls.Add(manaBar);
            Controls.Add(levelCounter);
            Controls.Add(xpCounter);
            Controls.Add(goldCounter);
            Controls.Add(hpCounter);
            Controls.Add(levelBar);
            Controls.Add(xpBar);
            Controls.Add(goldBar);
            Controls.Add(hpBar);
            Name = "myRPGgame";
            Text = "My RPG";
            Load += myRPGgame_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridViewInventory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewQuests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label hpBar;
        private Label goldBar;
        private Label xpBar;
        private Label levelBar;
        private Label hpCounter;
        private Label goldCounter;
        private Label xpCounter;
        private Label levelCounter;
        private Label manaBar;
        private Label manaCounter;
        private Label label;
        private ComboBox comboBoxWeapons;
        private ComboBox comboBoxPotions;
        private ComboBox comboBoxSpells;
        private Button UseWeapon;
        private Button UseSpell;
        private Button UsePotion;
        private Button ButtonNorth;
        private Button ButtonWest;
        private Button ButtonEast;
        private Button ButtonSouth;
        private RichTextBox richTextBoxLocation;
        private RichTextBox richTextBoxMessages;
        private DataGridView dataGridViewInventory;
        private DataGridView dataGridViewQuests;
    }
}

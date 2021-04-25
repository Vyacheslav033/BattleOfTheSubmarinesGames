
namespace BattleOfTheSubmarinesGames
{
    partial class CustomizationSubmarines
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SubmarineType = new System.Windows.Forms.Label();
            this.Customization_panel = new System.Windows.Forms.Panel();
            this.AtomicRocketSum = new System.Windows.Forms.NumericUpDown();
            this.IceRocketSum = new System.Windows.Forms.NumericUpDown();
            this.FieryRocketSum = new System.Windows.Forms.NumericUpDown();
            this.EquipSubmarinePanel = new System.Windows.Forms.Button();
            this.SubmarineAmunitionPanel = new System.Windows.Forms.Label();
            this.atomicRocketPanel = new System.Windows.Forms.Panel();
            this.iceRocketPanel = new System.Windows.Forms.Panel();
            this.fieryRocketPanel = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StartGame_Button = new System.Windows.Forms.Button();
            this.NameGame = new System.Windows.Forms.Label();
            this.Customization_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AtomicRocketSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IceRocketSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieryRocketSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SubmarineType
            // 
            this.SubmarineType.AutoSize = true;
            this.SubmarineType.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubmarineType.ForeColor = System.Drawing.Color.MidnightBlue;
            this.SubmarineType.Location = new System.Drawing.Point(288, 19);
            this.SubmarineType.Name = "SubmarineType";
            this.SubmarineType.Size = new System.Drawing.Size(566, 52);
            this.SubmarineType.TabIndex = 0;
            this.SubmarineType.Text = "Снарядите первого игрока";
            // 
            // Customization_panel
            // 
            this.Customization_panel.BackColor = System.Drawing.Color.Transparent;
            this.Customization_panel.Controls.Add(this.AtomicRocketSum);
            this.Customization_panel.Controls.Add(this.IceRocketSum);
            this.Customization_panel.Controls.Add(this.FieryRocketSum);
            this.Customization_panel.Controls.Add(this.EquipSubmarinePanel);
            this.Customization_panel.Controls.Add(this.SubmarineAmunitionPanel);
            this.Customization_panel.Controls.Add(this.atomicRocketPanel);
            this.Customization_panel.Controls.Add(this.iceRocketPanel);
            this.Customization_panel.Controls.Add(this.fieryRocketPanel);
            this.Customization_panel.Controls.Add(this.pictureBox3);
            this.Customization_panel.Controls.Add(this.pictureBox2);
            this.Customization_panel.Controls.Add(this.pictureBox1);
            this.Customization_panel.Controls.Add(this.SubmarineType);
            this.Customization_panel.Location = new System.Drawing.Point(112, 12);
            this.Customization_panel.Name = "Customization_panel";
            this.Customization_panel.Size = new System.Drawing.Size(1125, 615);
            this.Customization_panel.TabIndex = 1;
            this.Customization_panel.Visible = false;
            // 
            // AtomicRocketSum
            // 
            this.AtomicRocketSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AtomicRocketSum.Location = new System.Drawing.Point(860, 399);
            this.AtomicRocketSum.Name = "AtomicRocketSum";
            this.AtomicRocketSum.Size = new System.Drawing.Size(120, 45);
            this.AtomicRocketSum.TabIndex = 14;
            // 
            // IceRocketSum
            // 
            this.IceRocketSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IceRocketSum.Location = new System.Drawing.Point(501, 399);
            this.IceRocketSum.Name = "IceRocketSum";
            this.IceRocketSum.Size = new System.Drawing.Size(120, 45);
            this.IceRocketSum.TabIndex = 13;
            // 
            // FieryRocketSum
            // 
            this.FieryRocketSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FieryRocketSum.Location = new System.Drawing.Point(89, 399);
            this.FieryRocketSum.Name = "FieryRocketSum";
            this.FieryRocketSum.Size = new System.Drawing.Size(120, 45);
            this.FieryRocketSum.TabIndex = 12;
            // 
            // EquipSubmarinePanel
            // 
            this.EquipSubmarinePanel.BackColor = System.Drawing.Color.Indigo;
            this.EquipSubmarinePanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.EquipSubmarinePanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EquipSubmarinePanel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EquipSubmarinePanel.Location = new System.Drawing.Point(390, 515);
            this.EquipSubmarinePanel.Name = "EquipSubmarinePanel";
            this.EquipSubmarinePanel.Size = new System.Drawing.Size(382, 55);
            this.EquipSubmarinePanel.TabIndex = 11;
            this.EquipSubmarinePanel.Text = "Снарядить";
            this.EquipSubmarinePanel.UseVisualStyleBackColor = false;
            this.EquipSubmarinePanel.Click += new System.EventHandler(this.EquipSubmarinePanel_Click);
            // 
            // SubmarineAmunitionPanel
            // 
            this.SubmarineAmunitionPanel.AutoSize = true;
            this.SubmarineAmunitionPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SubmarineAmunitionPanel.Location = new System.Drawing.Point(383, 340);
            this.SubmarineAmunitionPanel.Name = "SubmarineAmunitionPanel";
            this.SubmarineAmunitionPanel.Size = new System.Drawing.Size(102, 38);
            this.SubmarineAmunitionPanel.TabIndex = 7;
            this.SubmarineAmunitionPanel.Text = "xxxxx";
            // 
            // atomicRocketPanel
            // 
            this.atomicRocketPanel.Location = new System.Drawing.Point(759, 170);
            this.atomicRocketPanel.Name = "atomicRocketPanel";
            this.atomicRocketPanel.Size = new System.Drawing.Size(350, 167);
            this.atomicRocketPanel.TabIndex = 6;
            // 
            // iceRocketPanel
            // 
            this.iceRocketPanel.Location = new System.Drawing.Point(390, 170);
            this.iceRocketPanel.Name = "iceRocketPanel";
            this.iceRocketPanel.Size = new System.Drawing.Size(350, 167);
            this.iceRocketPanel.TabIndex = 5;
            // 
            // fieryRocketPanel
            // 
            this.fieryRocketPanel.Location = new System.Drawing.Point(21, 170);
            this.fieryRocketPanel.Name = "fieryRocketPanel";
            this.fieryRocketPanel.Size = new System.Drawing.Size(350, 167);
            this.fieryRocketPanel.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::BattleOfTheSubmarinesGames.Properties.Resources.atomicRocket;
            this.pictureBox3.Location = new System.Drawing.Point(759, 88);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(250, 50);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::BattleOfTheSubmarinesGames.Properties.Resources.iceRocket;
            this.pictureBox2.Location = new System.Drawing.Point(390, 88);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 50);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::BattleOfTheSubmarinesGames.Properties.Resources.fieryRocket;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(21, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(250, 50);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // StartGame_Button
            // 
            this.StartGame_Button.BackColor = System.Drawing.Color.Indigo;
            this.StartGame_Button.FlatAppearance.BorderColor = System.Drawing.Color.Navy;
            this.StartGame_Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.StartGame_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StartGame_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartGame_Button.Location = new System.Drawing.Point(1086, 661);
            this.StartGame_Button.Name = "StartGame_Button";
            this.StartGame_Button.Size = new System.Drawing.Size(434, 91);
            this.StartGame_Button.TabIndex = 2;
            this.StartGame_Button.Text = "Начать игру";
            this.StartGame_Button.UseVisualStyleBackColor = false;
            this.StartGame_Button.Click += new System.EventHandler(this.StartGame_Button_Click);
            // 
            // NameGame
            // 
            this.NameGame.AutoSize = true;
            this.NameGame.BackColor = System.Drawing.Color.Transparent;
            this.NameGame.Font = new System.Drawing.Font("Wide Latin", 25.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameGame.Location = new System.Drawing.Point(66, 722);
            this.NameGame.Name = "NameGame";
            this.NameGame.Size = new System.Drawing.Size(937, 52);
            this.NameGame.TabIndex = 4;
            this.NameGame.Text = "Battle of the Submarines";
            // 
            // CustomizationSubmarines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::BattleOfTheSubmarinesGames.Properties.Resources.gameScreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1555, 837);
            this.Controls.Add(this.NameGame);
            this.Controls.Add(this.StartGame_Button);
            this.Controls.Add(this.Customization_panel);
            this.Name = "CustomizationSubmarines";
            this.Text = "Battle of the Submarines";
            this.Customization_panel.ResumeLayout(false);
            this.Customization_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AtomicRocketSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IceRocketSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FieryRocketSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label SubmarineType;
        private System.Windows.Forms.Panel Customization_panel;
        private System.Windows.Forms.Button StartGame_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel fieryRocketPanel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel atomicRocketPanel;
        private System.Windows.Forms.Panel iceRocketPanel;
        private System.Windows.Forms.Label SubmarineAmunitionPanel;
        private System.Windows.Forms.Button EquipSubmarinePanel;
        private System.Windows.Forms.NumericUpDown FieryRocketSum;
        private System.Windows.Forms.NumericUpDown AtomicRocketSum;
        private System.Windows.Forms.NumericUpDown IceRocketSum;
        private System.Windows.Forms.Label NameGame;
    }
}
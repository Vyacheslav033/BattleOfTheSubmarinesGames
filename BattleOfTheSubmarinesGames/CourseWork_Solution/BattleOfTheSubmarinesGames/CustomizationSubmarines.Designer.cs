
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomizationSubmarines));
            this.label1 = new System.Windows.Forms.Label();
            this.Customization_panel = new System.Windows.Forms.Panel();
            this.atomicRocketPanel = new System.Windows.Forms.Panel();
            this.iceRocketPanel = new System.Windows.Forms.Panel();
            this.fieryRocketPanel = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.StartGame_Button = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Customization_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(427, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 38);
            this.label1.TabIndex = 0;
            this.label1.Text = "Снарядите лодку";
            // 
            // Customization_panel
            // 
            this.Customization_panel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Customization_panel.Controls.Add(this.label2);
            this.Customization_panel.Controls.Add(this.atomicRocketPanel);
            this.Customization_panel.Controls.Add(this.iceRocketPanel);
            this.Customization_panel.Controls.Add(this.fieryRocketPanel);
            this.Customization_panel.Controls.Add(this.pictureBox3);
            this.Customization_panel.Controls.Add(this.pictureBox2);
            this.Customization_panel.Controls.Add(this.pictureBox1);
            this.Customization_panel.Controls.Add(this.label1);
            this.Customization_panel.Location = new System.Drawing.Point(80, 12);
            this.Customization_panel.Name = "Customization_panel";
            this.Customization_panel.Size = new System.Drawing.Size(1125, 598);
            this.Customization_panel.TabIndex = 1;
            this.Customization_panel.Visible = false;
            // 
            // atomicRocketPanel
            // 
            this.atomicRocketPanel.Location = new System.Drawing.Point(759, 191);
            this.atomicRocketPanel.Name = "atomicRocketPanel";
            this.atomicRocketPanel.Size = new System.Drawing.Size(350, 167);
            this.atomicRocketPanel.TabIndex = 6;
            // 
            // iceRocketPanel
            // 
            this.iceRocketPanel.Location = new System.Drawing.Point(390, 191);
            this.iceRocketPanel.Name = "iceRocketPanel";
            this.iceRocketPanel.Size = new System.Drawing.Size(350, 167);
            this.iceRocketPanel.TabIndex = 5;
            // 
            // fieryRocketPanel
            // 
            this.fieryRocketPanel.Location = new System.Drawing.Point(21, 191);
            this.fieryRocketPanel.Name = "fieryRocketPanel";
            this.fieryRocketPanel.Size = new System.Drawing.Size(350, 167);
            this.fieryRocketPanel.TabIndex = 4;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::BattleOfTheSubmarinesGames.Properties.Resources.atomicRocket;
            this.pictureBox3.Location = new System.Drawing.Point(759, 99);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(250, 50);
            this.pictureBox3.TabIndex = 3;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.BackgroundImage")));
            this.pictureBox2.Location = new System.Drawing.Point(390, 99);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 50);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(21, 99);
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
            this.StartGame_Button.Location = new System.Drawing.Point(423, 616);
            this.StartGame_Button.Name = "StartGame_Button";
            this.StartGame_Button.Size = new System.Drawing.Size(434, 91);
            this.StartGame_Button.TabIndex = 2;
            this.StartGame_Button.Text = "Начать игру";
            this.StartGame_Button.UseVisualStyleBackColor = false;
            this.StartGame_Button.Click += new System.EventHandler(this.StartGame_Button_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(544, 403);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            // 
            // CustomizationSubmarines
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1289, 736);
            this.Controls.Add(this.StartGame_Button);
            this.Controls.Add(this.Customization_panel);
            this.Name = "CustomizationSubmarines";
            this.Text = "Form1";
            this.Customization_panel.ResumeLayout(false);
            this.Customization_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Customization_panel;
        private System.Windows.Forms.Button StartGame_Button;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel fieryRocketPanel;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel atomicRocketPanel;
        private System.Windows.Forms.Panel iceRocketPanel;
        private System.Windows.Forms.Label label2;
    }
}

namespace Winforms1942GameClone
{
    partial class MenuForm
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
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.startGameButton = new System.Windows.Forms.Button();
            this.scoreButton = new System.Windows.Forms.Button();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.usernameLabel = new System.Windows.Forms.Label();
            this.enterUsernamePanel = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.enterUsernamePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoPictureBox.Image = global::Winforms1942GameClone.Properties.Resources._1942Logo;
            this.logoPictureBox.Location = new System.Drawing.Point(254, 84);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(574, 146);
            this.logoPictureBox.TabIndex = 1;
            this.logoPictureBox.TabStop = false;
            // 
            // startGameButton
            // 
            this.startGameButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.startGameButton.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGameButton.Location = new System.Drawing.Point(254, 454);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(265, 65);
            this.startGameButton.TabIndex = 2;
            this.startGameButton.Text = "Start New Game";
            this.startGameButton.UseVisualStyleBackColor = false;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // scoreButton
            // 
            this.scoreButton.BackColor = System.Drawing.SystemColors.ControlLight;
            this.scoreButton.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreButton.Location = new System.Drawing.Point(563, 454);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(265, 65);
            this.scoreButton.TabIndex = 4;
            this.scoreButton.Text = "Check Best Scores";
            this.scoreButton.UseVisualStyleBackColor = false;
            this.scoreButton.Click += new System.EventHandler(this.scoreButton_Click);
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameTextBox.Location = new System.Drawing.Point(31, 67);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(505, 31);
            this.usernameTextBox.TabIndex = 5;
            // 
            // usernameLabel
            // 
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usernameLabel.Location = new System.Drawing.Point(62, 23);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(452, 23);
            this.usernameLabel.TabIndex = 6;
            this.usernameLabel.Text = "Enter Usermane(default anonymous):";
            // 
            // enterUsernamePanel
            // 
            this.enterUsernamePanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.enterUsernamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.enterUsernamePanel.Controls.Add(this.usernameLabel);
            this.enterUsernamePanel.Controls.Add(this.usernameTextBox);
            this.enterUsernamePanel.Location = new System.Drawing.Point(254, 303);
            this.enterUsernamePanel.Name = "enterUsernamePanel";
            this.enterUsernamePanel.Size = new System.Drawing.Size(574, 119);
            this.enterUsernamePanel.TabIndex = 7;
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1084, 644);
            this.Controls.Add(this.enterUsernamePanel);
            this.Controls.Add(this.scoreButton);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.logoPictureBox);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arcade1942";
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.enterUsernamePanel.ResumeLayout(false);
            this.enterUsernamePanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Button scoreButton;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Panel enterUsernamePanel;
    }
}
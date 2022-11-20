
namespace Winforms1942GameClone
{
    partial class GameForm
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
            this.components = new System.ComponentModel.Container();
            this.globalClockTimer = new System.Windows.Forms.Timer(this.components);
            this.bulletsTimer = new System.Windows.Forms.Timer(this.components);
            this.cleanUpTimer = new System.Windows.Forms.Timer(this.components);
            this.eventTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyFighterTimer = new System.Windows.Forms.Timer(this.components);
            this.checkGameOverTimer = new System.Windows.Forms.Timer(this.components);
            this.playerPictureBox = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.highscoreLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // globalClockTimer
            // 
            this.globalClockTimer.Interval = 1000;
            this.globalClockTimer.Tick += new System.EventHandler(this.globalClockTimer_Tick);
            // 
            // bulletsTimer
            // 
            this.bulletsTimer.Tick += new System.EventHandler(this.bulletsTimer_Tick);
            // 
            // cleanUpTimer
            // 
            this.cleanUpTimer.Interval = 1;
            this.cleanUpTimer.Tick += new System.EventHandler(this.cleanUpTimer_Tick);
            // 
            // eventTimer
            // 
            this.eventTimer.Tick += new System.EventHandler(this.eventTimer_Tick);
            // 
            // enemyFighterTimer
            // 
            this.enemyFighterTimer.Tick += new System.EventHandler(this.enemyFighterTimer_Tick);
            // 
            // checkGameOverTimer
            // 
            this.checkGameOverTimer.Tick += new System.EventHandler(this.checkGameOverTimer_Tick);
            // 
            // playerPictureBox
            // 
            this.playerPictureBox.BackgroundImage = global::Winforms1942GameClone.Properties.Resources.american_plane;
            this.playerPictureBox.Location = new System.Drawing.Point(501, 577);
            this.playerPictureBox.Name = "playerPictureBox";
            this.playerPictureBox.Size = new System.Drawing.Size(85, 55);
            this.playerPictureBox.TabIndex = 4;
            this.playerPictureBox.TabStop = false;
            this.playerPictureBox.Visible = false;
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.Location = new System.Drawing.Point(10, 11);
            this.scoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(101, 24);
            this.scoreLabel.TabIndex = 5;
            this.scoreLabel.Text = "Score:0";
            // 
            // highscoreLabel
            // 
            this.highscoreLabel.AutoSize = true;
            this.highscoreLabel.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highscoreLabel.Location = new System.Drawing.Point(459, 9);
            this.highscoreLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.highscoreLabel.Name = "highscoreLabel";
            this.highscoreLabel.Size = new System.Drawing.Size(153, 24);
            this.highscoreLabel.TabIndex = 6;
            this.highscoreLabel.Text = "HighScore:0";
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1084, 644);
            this.Controls.Add(this.highscoreLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.playerPictureBox);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arcade1942";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox playerPictureBox;
        private System.Windows.Forms.Timer globalClockTimer;
        private System.Windows.Forms.Timer bulletsTimer;
        private System.Windows.Forms.Timer cleanUpTimer;
        private System.Windows.Forms.Timer eventTimer;
        private System.Windows.Forms.Timer enemyFighterTimer;
        private System.Windows.Forms.Timer checkGameOverTimer;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label highscoreLabel;
    }
}


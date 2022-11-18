
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
            this.startGameButton = new System.Windows.Forms.Button();
            this.scoreButton = new System.Windows.Forms.Button();
            this.globalClockTimer = new System.Windows.Forms.Timer(this.components);
            this.bulletsTimer = new System.Windows.Forms.Timer(this.components);
            this.cleanUpTimer = new System.Windows.Forms.Timer(this.components);
            this.eventTimer = new System.Windows.Forms.Timer(this.components);
            this.enemyFighterTimer = new System.Windows.Forms.Timer(this.components);
            this.checkGameOverTimer = new System.Windows.Forms.Timer(this.components);
            this.playerPictureBox = new System.Windows.Forms.PictureBox();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // startGameButton
            // 
            this.startGameButton.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGameButton.Location = new System.Drawing.Point(254, 300);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(265, 65);
            this.startGameButton.TabIndex = 1;
            this.startGameButton.Text = "Start New Game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // scoreButton
            // 
            this.scoreButton.Font = new System.Drawing.Font("Courier New", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreButton.Location = new System.Drawing.Point(563, 300);
            this.scoreButton.Name = "scoreButton";
            this.scoreButton.Size = new System.Drawing.Size(265, 65);
            this.scoreButton.TabIndex = 3;
            this.scoreButton.Text = "Check Best Scores";
            this.scoreButton.UseVisualStyleBackColor = true;
            // 
            // globalClockTimer
            // 
            this.globalClockTimer.Interval = 1000;
            this.globalClockTimer.Tick += new System.EventHandler(this.globalClockTimer_Tick);
            // 
            // cleanUpTimer
            // 
            this.cleanUpTimer.Interval = 10;
            // 
            // eventTimer
            // 
            this.eventTimer.Tick += new System.EventHandler(this.eventTimer_Tick);
            // 
            // playerPictureBox
            // 
            this.playerPictureBox.BackgroundImage = global::Winforms1942GameClone.Properties.Resources.american_plane;
            this.playerPictureBox.Location = new System.Drawing.Point(500, 544);
            this.playerPictureBox.Name = "playerPictureBox";
            this.playerPictureBox.Size = new System.Drawing.Size(85, 55);
            this.playerPictureBox.TabIndex = 4;
            this.playerPictureBox.TabStop = false;
            this.playerPictureBox.Visible = false;
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.logoPictureBox.Image = global::Winforms1942GameClone.Properties.Resources._1942Logo;
            this.logoPictureBox.Location = new System.Drawing.Point(254, 111);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(574, 146);
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1084, 611);
            this.Controls.Add(this.playerPictureBox);
            this.Controls.Add(this.scoreButton);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.logoPictureBox);
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Arcade1942";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.playerPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Button scoreButton;
        private System.Windows.Forms.PictureBox playerPictureBox;
        private System.Windows.Forms.Timer globalClockTimer;
        private System.Windows.Forms.Timer bulletsTimer;
        private System.Windows.Forms.Timer cleanUpTimer;
        private System.Windows.Forms.Timer eventTimer;
        private System.Windows.Forms.Timer enemyFighterTimer;
        private System.Windows.Forms.Timer checkGameOverTimer;
    }
}


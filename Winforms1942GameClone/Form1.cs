using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winforms1942GameClone
{
    public partial class GameForm : Form
    {
        public GameForm()
        {
            InitializeComponent();
        }

        private bool gameHasStarted = false;
        private List<PictureBox> playerBullets = new List<PictureBox>();
        private List<EnemyFighter> enemyFighters = new List<EnemyFighter>();
        private int clock;

        private class EnemyFighter
        {
            public PictureBox Picture { get; set; }
            public int XChange { get; set; }
            public int YChange { get; set; }
            public int BulletDirectionX { get; set; }
            public int BulletDirectionY { get; set; }
            public int Life { get; set; }
            //the greater the number the worse it is
            public int FireRate { get; set; }

            public EnemyFighter(PictureBox picture, int xChange, int yChange, int life, int fireRate, int bulletDirectionX, int bulletDirectionY)
            {
                this.Picture = picture;
                this.XChange = xChange;
                this.YChange = yChange;
                this.Life = life;
                this.FireRate = fireRate;
                this.BulletDirectionX = bulletDirectionX;
                this.BulletDirectionY = bulletDirectionY;
            }
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            playerPictureBox.Visible = true;
            logoPictureBox.Visible = false;
            startGameButton.Visible = false;
            scoreButton.Visible = false;
            gameHasStarted = true;
            MessageBox.Show("The game is about to begin!");
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (!gameHasStarted) return;

            if ((e.KeyCode.ToString() == "A" || e.KeyCode.ToString() == "Left") && (e.KeyCode.ToString() == "W" || e.KeyCode.ToString() == "Up"))
            {
                playerPictureBox.Location = new Point(playerPictureBox.Location.X - 15, playerPictureBox.Location.Y - 15);
            }
            else if (e.KeyCode.ToString() == "A" || e.KeyCode.ToString() == "Left")
            {
                playerPictureBox.Location = new Point(playerPictureBox.Location.X - 15, playerPictureBox.Location.Y);
            }
            else if (e.KeyCode.ToString() == "W" || e.KeyCode.ToString() == "Up")
            {
                playerPictureBox.Location = new Point(playerPictureBox.Location.X, playerPictureBox.Location.Y - 15);
            }
            else if (e.KeyCode.ToString() == "S" || e.KeyCode.ToString() == "Down")
            {
                playerPictureBox.Location = new Point(playerPictureBox.Location.X, playerPictureBox.Location.Y + 15);
            }
            else if (e.KeyCode.ToString() == "D" || e.KeyCode.ToString() == "Right")
            {
                playerPictureBox.Location = new Point(playerPictureBox.Location.X + 15, playerPictureBox.Location.Y);
            }
            else if (e.KeyCode.ToString() == "Space")
            {
                int temp = 0;

                for (int i = 0; i < 2; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.bullet1;
                    pictureBox.Location = new Point(playerPictureBox.Location.X + 25 + temp, playerPictureBox.Location.Y - playerPictureBox.Height + 20);
                    pictureBox.Size = new System.Drawing.Size(13, 25);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    playerBullets.Add(pictureBox);

                    temp += 20;
                }

            }
        }

        private void globalClockTimer_Tick(object sender, EventArgs e)
        {
            clock += 1;
        }

        private void eventTimer_Tick(object sender, EventArgs e)
        {
            if (clock % 20 == 0 && clock != 0)
            {
                int temp = 0;
                int temp2 = 0;

                for (int i = 0; i < 3; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_light_fighter;
                    pictureBox.Location = new Point(0 + temp, 0 + temp2);
                    pictureBox.Size = new System.Drawing.Size(51, 49);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    temp += 60;
                    temp2 += 5;

                    EnemyFighter enemyFighter = new EnemyFighter(pictureBox, 20, 15, 1, 100, 20, 20);
                    enemyFighters.Add(enemyFighter);
                }
            }

            if ((clock + 10) % 20 == 0 && clock != 0)
            {
                int temp = 0;
                int temp2 = 0;

                for (int i = 0; i < 3; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_light_fighter;
                    pictureBox.Location = new Point(this.Width - temp, 0 + temp2);
                    pictureBox.Size = new System.Drawing.Size(51, 49);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    temp += 60;
                    temp2 += 5;

                    EnemyFighter enemyFighter = new EnemyFighter(pictureBox, -20, 15, 1, 100, -20, 20);
                    enemyFighters.Add(enemyFighter);
                }
            }
        }
    }
}

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
            random = new Random();
            InitializeComponent();
        }

        private Random random;
        private bool gameHasStarted = false;
        private List<PictureBox> playerBullets = new List<PictureBox>();
        private List<EnemyFighter> enemyFighters = new List<EnemyFighter>();
        private List<EnemyBullet> enemyBullets = new List<EnemyBullet>();
        private List<EnemyDestruction> enemyDestructions = new List<EnemyDestruction>();
        private int clock;

        private class EnemyDestruction
        {
            public PictureBox Picture { get; set; }
            public int TimeRemaining { get; set; }

            public EnemyDestruction(PictureBox picture, int timeRemaining)
            {
                this.Picture = picture;
                this.TimeRemaining = timeRemaining;
            }
        }
        private class EnemyBullet
        {
            public PictureBox Picture { get; set; }
            public int XChange { get; set; }
            public int YChange { get; set; }

            public EnemyBullet(PictureBox picture, int xChange, int yChange)
            {
                this.Picture = picture;
                this.XChange = xChange;
                this.YChange = yChange;
            }
        }
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
            public string FighterType { get; set; }
            public int HitTimer { get; set; } = 0;

            public EnemyFighter(PictureBox picture, int xChange, int yChange, int life, int fireRate, int bulletDirectionX, 
                int bulletDirectionY,string fighterType)
            {
                this.Picture = picture;
                this.XChange = xChange;
                this.YChange = yChange;
                this.Life = life;
                this.FireRate = fireRate;
                this.BulletDirectionX = bulletDirectionX;
                this.BulletDirectionY = bulletDirectionY;
                this.FighterType = fighterType;
            }
        }

        private class EnemyMiniBossFighter : EnemyFighter
        {
            public int ChangeCounterX {get;set;}
            public int RangeX { get; set; }
            public EnemyMiniBossFighter(PictureBox picture, int xChange, int yChange, int life, int fireRate, int bulletDirectionX,
                int bulletDirectionY, string fighterType, int changeCounterX, int rangeX) 
                :base(picture, xChange, yChange, life, fireRate, bulletDirectionX, bulletDirectionY, fighterType)
            {
                this.ChangeCounterX = changeCounterX;
                this.RangeX = rangeX;
            }
        }

        private class EnemyBossFighter : EnemyMiniBossFighter
        {
            public int ChangeCounterY { get; set; }
            public int RangeY { get; set; }
            public EnemyBossFighter(PictureBox picture, int xChange, int yChange, int life, int fireRate, int bulletDirectionX,
                int bulletDirectionY, string fighterType, int changeCounterX, int rangeX,int changeCounterY,int rangeY) 
                : base(picture, xChange, yChange, life, fireRate, bulletDirectionX, bulletDirectionY, fighterType, changeCounterX, rangeX)
            {
                this.ChangeCounterY = changeCounterY;
                this.RangeY = rangeY;
            }
        }
        private void startGameButton_Click(object sender, EventArgs e)
        {
            playerPictureBox.Visible = true;
            logoPictureBox.Visible = false;
            startGameButton.Visible = false;
            scoreButton.Visible = false;
            gameHasStarted = true;

            globalClockTimer.Enabled = true;
            bulletsTimer.Enabled = true;
            cleanUpTimer.Enabled = true;
            eventTimer.Enabled = true;
            enemyFighterTimer.Enabled = true;
            checkGameOverTimer.Enabled = true;
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
            eventTimer.Enabled = true;
        }

        private void eventTimer_Tick(object sender, EventArgs e)
        {
            //starting attack
            if(clock == 5 || clock == 15 || clock == 22 || clock == 26) {
                int temp = 0;
                int temp2 = 0;

                for (int i = 0; i < 5; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_medium_fighter;
                    pictureBox.Location = new Point(this.Width/2 + temp - 130, -20 + temp2);
                    pictureBox.Size = new System.Drawing.Size(51, 49);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    temp += 60;
                    temp2 += 10;

                    EnemyFighter enemyFighter = new EnemyFighter(pictureBox, 0, 20, 2, 50, 0, 25,"medium");
                    enemyFighters.Add(enemyFighter);
                }

                eventTimer.Enabled = false;
            }

            

            //left flank attack
            if (clock % 20 == 0 && clock != 0 && clock < 80)
            {
                int temp = 0;
                int temp2 = 0;

                for (int i = 0; i < 4; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_light_fighter;
                    pictureBox.Location = new Point(0 + temp, temp2);
                    pictureBox.Size = new System.Drawing.Size(51, 49);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    temp += 60;
                    temp2 += 5;

                    EnemyFighter enemyFighter = new EnemyFighter(pictureBox, 20, 15, 1, 100, 20, 20,"light");
                    enemyFighters.Add(enemyFighter);
                }

                temp = 0;
                temp2 = 200;
                for (int i = 0; i < 4; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_light_fighter;
                    pictureBox.Location = new Point(temp, temp2);
                    pictureBox.Size = new System.Drawing.Size(51, 49);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    temp += 60;
                    temp2 += 5;

                    EnemyFighter enemyFighter = new EnemyFighter(pictureBox, 20, 15, 1, 100, 20, 20, "light");
                    enemyFighters.Add(enemyFighter);
                }

                eventTimer.Enabled = false;
            }

            //right flank attack
            if ((clock + 10) % 20 == 0 && clock != 0 && clock < 80)
            {
                int temp = 0;
                int temp2 = 0;

                for (int i = 0; i < 4; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_light_fighter;
                    pictureBox.Location = new Point(this.Width - temp, temp2);
                    pictureBox.Size = new System.Drawing.Size(51, 49);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    temp += 60;
                    temp2 += 5;

                    EnemyFighter enemyFighter = new EnemyFighter(pictureBox, -20, 15, 1, 100, -20, 20,"light");
                    enemyFighters.Add(enemyFighter);
                }

                temp = 0;
                temp2 = 200;
                for (int i = 0; i < 4; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_light_fighter;
                    pictureBox.Location = new Point(this.Width - temp, temp2);
                    pictureBox.Size = new System.Drawing.Size(51, 49);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    temp += 60;
                    temp2 += 5;

                    EnemyFighter enemyFighter = new EnemyFighter(pictureBox, -20, 15, 1, 100, -20, 20, "light");
                    enemyFighters.Add(enemyFighter);
                }

                eventTimer.Enabled = false;
            }

            //mini boss event
            if (clock == 30)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_bomber_mini_boss;
                pictureBox.Location = new Point(this.Width / 2 - 100, 10);
                pictureBox.Size = new System.Drawing.Size(202, 155);
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                Controls.Add(pictureBox);


                EnemyMiniBossFighter enemyFighter = new EnemyMiniBossFighter(pictureBox, 5, 0, 50, 10, 0, 25, "mini_boss", 100, 200);
                enemyFighters.Add(enemyFighter);

                eventTimer.Enabled = false;
            }

            //second mini boss event
            if (clock == 50)
            {
                int temp = this.Width / 2 - 100;
                for (int i = 0; i < 2; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_bomber_mini_boss;
                    pictureBox.Location = new Point(temp, 10);
                    pictureBox.Size = new System.Drawing.Size(202, 155);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    temp = 20;

                    EnemyMiniBossFighter enemyFighter = new EnemyMiniBossFighter(pictureBox, 5, 0, 50, 10, 0, 25, "mini_boss", 0, 100);
                    enemyFighters.Add(enemyFighter);
                }

                eventTimer.Enabled = false;
            }

            //final boss event
            if (clock == 1)
            {
                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_heavy_bomber_boss;
                pictureBox.Location = new Point(this.Width / 3 - 100, 0);
                pictureBox.Size = new System.Drawing.Size(540, 293);
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                Controls.Add(pictureBox);


                EnemyBossFighter enemyFighter = new EnemyBossFighter(pictureBox, 5, 5, 200, 15, 0, 10, "boss",40,80,0,20);
                enemyFighters.Add(enemyFighter);

                eventTimer.Enabled = false;
            }

            //wave that combines with boss on its flank
            if(clock >= 100 && clock % 10 == 0)
            {
                int temp = 10;
                int temp2 = 0;

                for (int i = 0; i < 4; i++)
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.japanese_medium_fighter;
                    pictureBox.Location = new Point(temp, temp2);
                    pictureBox.Size = new System.Drawing.Size(51, 49);
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    temp += 60;
                    if(i == 1)
                    {
                        temp = this.Width - 140;
                    }
                    
                    temp2 += 10;

                    EnemyFighter enemyFighter = new EnemyFighter(pictureBox, 0, 20, 2, 50, 0, 25, "medium");
                    enemyFighters.Add(enemyFighter);
                }

                eventTimer.Enabled = false;
            }
        }

        private void enemyFighterTimer_Tick(object sender, EventArgs e)
        {

            foreach (EnemyFighter fighter in enemyFighters)
            {
                //show that the fighter is hit
                if(fighter.HitTimer != 0)
                {
                    fighter.HitTimer -= 1;

                }
                else fighter.Picture.BackColor = Color.Transparent;

                if (fighter.FighterType == "medium")
                {
                    int randomEvent = random.Next(0, 35);
                    if (randomEvent == 0) fighter.XChange = -fighter.XChange;
                    else if (randomEvent == 10) fighter.YChange = -fighter.YChange;
                    
                }
                else if(fighter.FighterType == "mini_boss"){
                    if (fighter is EnemyMiniBossFighter)
                    {
                        EnemyMiniBossFighter temp = (EnemyMiniBossFighter)fighter;
                        if (temp.ChangeCounterX >= temp.RangeX)
                        {
                            fighter.XChange = -fighter.XChange;
                            temp.ChangeCounterX = 0;
                        }
                        temp.ChangeCounterX += 1;
                    }    
                }
                else if(fighter.FighterType == "boss"){
                        EnemyBossFighter temp = (EnemyBossFighter)fighter;
                        if (temp.ChangeCounterX >= temp.RangeX)
                        {
                            fighter.XChange = -fighter.XChange;
                            temp.ChangeCounterX = 0;
                        }
                        temp.ChangeCounterX += 1;
                        if (temp.ChangeCounterY >= temp.RangeY)
                        {
                            fighter.YChange = -fighter.YChange;
                            temp.ChangeCounterY = 0;
                        }
                        temp.ChangeCounterY += 1;
                }

                fighter.Picture.Location = new Point(fighter.Picture.Location.X + fighter.XChange, fighter.Picture.Location.Y + fighter.YChange);
                int number = random.Next(0, fighter.FireRate);
                if (number == 0)
                {
                    if(fighter.FighterType == "mini_boss")
                    {
                        int temp = -20;
                        for (int i = 0; i < 3; i++)
                        {
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.bullet2;
                            pictureBox.Location = new Point(fighter.Picture.Location.X + 90, fighter.Picture.Location.Y + 45);
                            pictureBox.Size = new System.Drawing.Size(17, 17);
                            pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                            Controls.Add(pictureBox);
                            EnemyBullet enemyBullet = new EnemyBullet(pictureBox, fighter.BulletDirectionX + temp, fighter.BulletDirectionY);
                            enemyBullets.Add(enemyBullet);

                            temp += 20;
                        }
                    }
                    else if(fighter.FighterType == "boss")
                    {
                        int temp = 0;
                        for(int i = 0; i < 4; i++)
                        {
                            PictureBox pictureBox = new PictureBox();
                            pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.bullet2;
                            pictureBox.Location = new Point(fighter.Picture.Location.X + temp, fighter.Picture.Location.Y + fighter.Picture.Height -20);
                            pictureBox.Size = new System.Drawing.Size(17, 17);
                            pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                            Controls.Add(pictureBox);
                            EnemyBullet enemyBullet = new EnemyBullet(pictureBox, fighter.BulletDirectionX, fighter.BulletDirectionY);
                            enemyBullets.Add(enemyBullet);

                            temp += 170;
                        }

                    }
                    else
                    {
                        PictureBox pictureBox = new PictureBox();
                        pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.bullet2;
                        pictureBox.Location = new Point(fighter.Picture.Location.X + 5, fighter.Picture.Location.Y + 25);
                        pictureBox.Size = new System.Drawing.Size(17, 17);
                        pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                        Controls.Add(pictureBox);

                        EnemyBullet enemyBullet = new EnemyBullet(pictureBox, fighter.BulletDirectionX, fighter.BulletDirectionY);
                        enemyBullets.Add(enemyBullet);
                    }
                    
                    
                }

            }
        }

        private void bulletsTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < playerBullets.Count; i++)
            {
                playerBullets[i].Location = new Point(playerBullets[i].Location.X, playerBullets[i].Location.Y - 20);
            }

            foreach (EnemyBullet enemybullet in enemyBullets)
            {
                enemybullet.Picture.Location = new Point(enemybullet.Picture.Location.X + enemybullet.XChange, enemybullet.Picture.Location.Y + enemybullet.YChange);
            }

            //check if enemy plane is hit by our bullets
            int j = 0;
            while (j < playerBullets.Count)
            {
                int i = 0;
                while (i < enemyFighters.Count)
                {
                    //TODO sometimes it crashes because of the cleanup.
                    try
                    {
                        if (enemyHit(i, j)) break;
                    }
                    catch{
                        
                    }
                    
                    i++;
                }
                j++;
            }

            //clear destructions
            for (int i = 0; i < enemyDestructions.Count; i++)
            {
                enemyDestructions[i].TimeRemaining -= 1;
                if (enemyDestructions[i].TimeRemaining <= 0)
                {
                    Controls.Remove(enemyDestructions[i].Picture);
                    enemyDestructions.Remove(enemyDestructions[i]);
                    i -= 1;
                }
            }
        }

        private void cleanUpTimer_Tick(object sender, EventArgs e)
        {
            //removal of planes when outside the board
            for (int i = 0; i < enemyFighters.Count; i++)
            {
                if (enemyFighters[i].Picture.Location.Y > this.Height + 20 || enemyFighters[i].Picture.Location.Y < -40)
                {
                    Controls.Remove(enemyFighters[i].Picture);
                    enemyFighters.Remove(enemyFighters[i]);
                    i -= 1;
                }
            }

            //remove players bullets when out of the board
            for (int i = 0; i < playerBullets.Count; i++)
            {
                if (playerBullets[i].Location.Y < -20)
                {
                    Controls.Remove(playerBullets[i]);
                    playerBullets.Remove(playerBullets[i]);
                    i -= 1;
                }
            }

            //remove players bullets when out of the board
            for (int i = 0; i < enemyBullets.Count; i++)
            {
                if (enemyBullets[i].Picture.Location.Y > this.Height + 20)
                {
                    Controls.Remove(enemyBullets[i].Picture);
                    enemyBullets.Remove(enemyBullets[i]);
                    i -= 1;
                }
            }
        }

        private void checkGameOverTimer_Tick(object sender, EventArgs e)
        {
            //if an enemy bullet hit our plane
            foreach (EnemyBullet enemybullet in enemyBullets)
            {
                if ((enemybullet.Picture.Location.X >= playerPictureBox.Location.X && enemybullet.Picture.Location.X <= playerPictureBox.Location.X + 85)
                            && (enemybullet.Picture.Location.Y >= playerPictureBox.Location.Y && enemybullet.Picture.Location.Y <= playerPictureBox.Location.Y + 55))
                {

                    playerPictureBox.Image = global::Winforms1942GameClone.Properties.Resources.fighter_death_animation;

                    globalClockTimer.Stop();
                    bulletsTimer.Stop();
                    cleanUpTimer.Stop();
                    eventTimer.Stop();
                    enemyFighterTimer.Stop();
                    checkGameOverTimer.Stop();

                    MessageBox.Show("You Lost!");

                    return;
                }
            }

            //if an enemy plane crashed on our plane
            foreach (EnemyFighter fighter in enemyFighters)
            {
                if ((fighter.Picture.Location.X >= playerPictureBox.Location.X && fighter.Picture.Location.X <= playerPictureBox.Location.X + 85)
                            && (fighter.Picture.Location.Y >= playerPictureBox.Location.Y && fighter.Picture.Location.Y <= playerPictureBox.Location.Y + 55))
                {
                    playerPictureBox.Image = global::Winforms1942GameClone.Properties.Resources.fighter_death_animation;
                    fighter.Picture.Image = global::Winforms1942GameClone.Properties.Resources.fighter_death_animation;

                    globalClockTimer.Stop();
                    bulletsTimer.Stop();
                    cleanUpTimer.Stop();
                    eventTimer.Stop();
                    enemyFighterTimer.Stop();
                    checkGameOverTimer.Stop();

                    MessageBox.Show("You Lost!");

                    return;
                }
            }
        }


        private bool enemyHit(int i,int j)
        {
            if ((playerBullets[j].Location.X >= enemyFighters[i].Picture.Location.X && playerBullets[j].Location.X <= enemyFighters[i].Picture.Location.X + enemyFighters[i].Picture.Size.Width)
                            && (playerBullets[j].Location.Y >= enemyFighters[i].Picture.Location.Y - enemyFighters[i].Picture.Size.Height && playerBullets[j].Location.Y <= enemyFighters[i].Picture.Location.Y))
            {
                //check if the enemy fighter does not have any life left
                enemyFighters[i].Life -= 1;
                Controls.Remove(playerBullets[j]);
                playerBullets.Remove(playerBullets[j]);
                enemyFighters[i].HitTimer = 3;
                enemyFighters[i].Picture.BackColor = Color.FromArgb(80,255,0,0);
                if (enemyFighters[i].Life <= 0)
                {
                    PictureBox pictureBox = new PictureBox();
                    EnemyDestruction enemyDestruction = new EnemyDestruction(pictureBox, 10); 
                    pictureBox.Location = new Point(enemyFighters[i].Picture.Location.X, enemyFighters[i].Picture.Location.Y);
                    if (enemyFighters[i].FighterType == "mini_boss")
                    {
                        
                        pictureBox.Image = global::Winforms1942GameClone.Properties.Resources._3;
                        enemyDestruction.TimeRemaining = 20;
                        pictureBox.Size = new System.Drawing.Size(208, 163);
                    
                    }
                    else if(enemyFighters[i].FighterType == "boss")
                    {
                        pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.boss_destroyed;
                        enemyDestruction.TimeRemaining = 20;
                        pictureBox.Size = new System.Drawing.Size(540, 293);
                    }
                    else
                    {
                        pictureBox.Image = global::Winforms1942GameClone.Properties.Resources.fighter_death_animation;
                        pictureBox.Size = new System.Drawing.Size(53, 46);
                    }
                    
                    
                    pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                    Controls.Add(pictureBox);

                    enemyDestructions.Add(enemyDestruction);

                    Controls.Remove(enemyFighters[i].Picture);
                    enemyFighters.Remove(enemyFighters[i]);
                    return true;
                }

            }

            return false;
        }
    }
}

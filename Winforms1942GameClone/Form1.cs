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

        private void startGameButton_Click(object sender, EventArgs e)
        {
            playerPictureBox.Visible = true;
            logoPictureBox.Visible = false;
            startGameButton.Visible = false;
            scoreButton.Visible = false;
            gameHasStarted = true;
            MessageBox.Show("The game is about to begin!");
        }
    }
}

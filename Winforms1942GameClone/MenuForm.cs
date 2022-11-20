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
    public partial class MenuForm : Form
    {
        private string username = "";
        public MenuForm()
        {
            InitializeComponent();
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            if(usernameTextBox.Text == "")
            {
                username = "anonymous";
            }
            else
            {
                username = usernameTextBox.Text;
            }
             
            GameForm gameForm = new GameForm(username);
            gameForm.Show();
            usernameTextBox.Text = "";
        }

        private void scoreButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            ScoresForm scoresForm = new ScoresForm();
            scoresForm.Show();
        }
    }
}

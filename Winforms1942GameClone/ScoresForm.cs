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
    public partial class ScoresForm : Form
    {
        private List<ScoreModel> scores = new List<ScoreModel>();
        private List<Label> usernamesLabels = new List<Label>();
        private List<Label> scoresLabels = new List<Label>();
        public ScoresForm()
        {
            InitializeComponent();
            scores = SqliteDataAccess.LoadScores();
            usernamesLabels.Add(topUsernameLabel); usernamesLabels.Add(secondUsernameLabel); usernamesLabels.Add(thirdUsernameLabel);
            usernamesLabels.Add(fourthUsernameLabel); usernamesLabels.Add(fifthUsernameLabel); usernamesLabels.Add(sixthUsernameLabel); 
            usernamesLabels.Add(seventhUsernameLabel); usernamesLabels.Add(eighthUsernameLabel);  usernamesLabels.Add(ninthUsernameLabel);
            usernamesLabels.Add(tenthUsernameLabel);

            scoresLabels.Add(topScoreLabel); scoresLabels.Add(secondScoreLabel); scoresLabels.Add(thirdScoreLabel); 
            scoresLabels.Add(fourthScoreLabel); scoresLabels.Add(fifthScoreLabel); scoresLabels.Add(sixthScoreLabel); 
            scoresLabels.Add(seventhScoreLabel); scoresLabels.Add(eighthScoreLabel);  scoresLabels.Add(ninthScoreLabel); 
            scoresLabels.Add(tenthScoreLabel);

            for(int i = 0; i < scores.Count; i++)
            {
                usernamesLabels[i].Text = scores[i].Username;
                scoresLabels[i].Text = scores[i].Score.ToString();
            }

        }

        private void returnToHomePageButton_Click(object sender, EventArgs e)
        {
            Application.OpenForms[0].Show();
            this.Close();
        }

        //TODO find another way
        private void ScoresForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Application.OpenForms[0].Close();
        }
    }
}

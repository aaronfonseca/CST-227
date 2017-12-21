using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cst227_milestone6
{
    public partial class highScore_Form : Form
    {
        // creat difficulty attr 
        public string difficulty;
        // create score TimeSpan attr 
        public TimeSpan score;
        // creat win attr
        public bool win;

        // Create generic for each difficulty highscore
        public List<PlayerStats> easy = new List<PlayerStats>();
        public List<PlayerStats> medium = new List<PlayerStats>();
        public List<PlayerStats> hard = new List<PlayerStats>();


        public highScore_Form()
        {
            InitializeComponent();
        }

        public highScore_Form(int difficulty, TimeSpan score, bool win)
        {

            // Get values from highScore External File
            foreach (string line in File.ReadLines("highscore.csv"))
            {

                // split line by comma
                var values = line.Split(',');

                // add new list object depnding on difficulty
                if (values[1] == "easy")
                {
                    easy.Add(new PlayerStats(values[0], values[1], TimeSpan.Parse(values[2])));
                }
                else if (values[1] == "medium")
                {
                    medium.Add(new PlayerStats(values[0], values[1], TimeSpan.Parse(values[2])));
                }
                else if (values[1] == "hard")
                {
                    hard.Add(new PlayerStats(values[0], values[1], TimeSpan.Parse(values[2])));
                }

            }

            if (difficulty == 1)
            {
                this.difficulty = "easy";
            }
             else if (difficulty == 2)
            {
                this.difficulty = "medium";
            }
            else if (difficulty == 3)
            {
                this.difficulty = "hard";
                
            }
            this.score = score;
            this.win = win;
            InitializeComponent();
        }

        // Set Grid class for each cell
        public MINESWEEPER Menu;

        // Have Current Grid class
        public void createMenu(MINESWEEPER Menu)
        {
            Menu = Menu;
        }

        // Initialize Form
        private void highScore_Form_Load(object sender, EventArgs e)
        {

            // Hide these objects on lose
            if (!win)
            {
            initials_textbox.Visible = false;
            highscore_btn.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            yourScore_label.Visible = false;
            } else // show these objects on win
            {
                initials_textbox.Visible = true;
                highscore_btn.Visible = true;
                label4.Visible = true;
                label5.Visible = true;
                yourScore_label.Visible = true;
                yourScore_label.Text = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", score.Hours, score.Minutes, score.Seconds, score.Milliseconds / 10);
            }

            // On win or lose show the top five scores for that difficulty
            string output = "Difficulty: " + difficulty + Environment.NewLine + Environment.NewLine;

            if (difficulty == "easy")
            {
                foreach (var stat in easy)
                {
                    output += stat.Initials + ": " + stat.time + Environment.NewLine + Environment.NewLine;
                }
            }
            else if (difficulty == "medium")
            {
                foreach (var stat in medium)
                {
                    output += stat.Initials + ": " + stat.time + Environment.NewLine + Environment.NewLine;
                }
            }
            else if (difficulty == "hard")
            {
                foreach (var stat in hard)
                {
                    output += stat.Initials + ": " + stat.time + Environment.NewLine + Environment.NewLine;
                }

            }

            highscore_label.Text = output.ToUpper();
            this.CenterToScreen();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        // On submit button
        private void highscore_btn_Click(object sender, EventArgs e)
        {
            
            if (difficulty == "easy")
            {
                // add submitted score to highscore list
                easy[4] = new PlayerStats(initials_textbox.Text, difficulty, score);
                // sort by score
                var newList = easy.OrderByDescending(PlayerStats => PlayerStats.time).ToList(); // ToList optional
                // only replace top 5 scores
                for(var i = 0; i >= 4; i++) {
                    easy[i] = newList[i];
                }
            }
            else if (difficulty == "medium")
            {
                medium[4] = new PlayerStats(initials_textbox.Text, difficulty, score);
                // sort by score
                var newList = medium.OrderByDescending(PlayerStats => PlayerStats.time).ToList(); // ToList optional
                // only replace top 5 scores
                for (var i = 0; i >= 4; i++)
                {
                    medium[i] = newList[i];
                }
            }
            else if (difficulty == "hard")
            {
                hard[4] = new PlayerStats(initials_textbox.Text, difficulty, score);
                // sort by score
                var newList = hard.OrderByDescending(PlayerStats => PlayerStats.time).ToList(); // ToList optional
                 // only replace top 5 scores
                for (var i = 0; i >= 4; i++)
                {
                    hard[i] = newList[i];
                }
            }

            if (!File.Exists("highscore.csv"))
            {
                File.Create("highscore.csv").Close();
            }
            string delimter = ",";
            List<string[]> output = new List<string[]>();

            //flexible part ... add as many object as you want based on your app logic
            for (var i = 0; i < 5; i++)
            {
                output.Add(new string[] { easy[i].Initials, easy[i].level, Convert.ToString(easy[i].time)});
            }
            for (var i = 0; i < 5; i++)
            {
                output.Add(new string[] { medium[i].Initials, medium[i].level, Convert.ToString(medium[i].time)});
            }
            for (var i = 0; i < 5; i++)
            {
                output.Add(new string[] { hard[i].Initials, hard[i].level, Convert.ToString(hard[i].time)});
            }

            int length = output.Count;

            using (System.IO.TextWriter writer = File.CreateText("highscore.csv"))
            {
                for (int index = 0; index < length; index++)
                {

                        writer.WriteLine(string.Join(delimter, output[index]));
                    
                }
            }

            // On win or lose show the top five scores for that difficulty
            string newScore = "Difficulty: " + difficulty + Environment.NewLine + Environment.NewLine;

            if (difficulty == "easy")
            {
                foreach (var stat in easy)
                {
                    newScore += stat.Initials + ": " + stat.time + Environment.NewLine + Environment.NewLine;
                }
            }
            else if (difficulty == "medium")
            {
                foreach (var stat in medium)
                {
                    newScore += stat.Initials + ": " + stat.time + Environment.NewLine + Environment.NewLine;
                }
            }
            else if (difficulty == "hard")
            {
                foreach (var stat in hard)
                {
                    newScore += stat.Initials + ": " + stat.time + Environment.NewLine + Environment.NewLine;
                }

            }

            highscore_label.Text = newScore.ToUpper();
                        initials_textbox.Visible = false;
            highscore_btn.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            yourScore_label.Visible = false;

        }

        private void yourScore_label_Click(object sender, EventArgs e)
        {

        }

        private void initials_textbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

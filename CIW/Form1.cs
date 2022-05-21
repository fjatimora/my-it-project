using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CIW
{
    public partial class CIW : Form
    {
        public static int score;
        public static char answer;
        private char rand1;
        private char rand2;
        public static char userans;

        private int lives;
        private int timeleft;
        private bool functionhasbeencalled;

        public static string username;

        public CIW(string user)
        {
            InitializeComponent();
            SetVar();
            generate();
            assign();
            

            username = user;
            lblUser.Text = "Player: " + user;
            setBtn();
        }

        private void SetVar()
        {
            score = 0;
            timeleft = 5;
            functionhasbeencalled = false;
            timer1.Enabled = true;
            lives = 3;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void generate()
        {
            char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            Random rnd = new Random();
            int randnum = rnd.Next(0, 26);
            answer = letters[randnum];

            int randomizer = rnd.Next(1, 3);
            if (randomizer == 1)
            {
                rand1 = answer;

                int randoption = rnd.Next(0, 26);
                rand2 = letters[randoption];
            }
            else if (randomizer == 2)
            {
                rand2 = answer;

                int randoption = rnd.Next(0, 26);
                rand1 = letters[randoption];
            }

            functionhasbeencalled = false;
        }

        private void checkans()
        {
            if (score < 20)
            {
                if (userans == answer)
                {
                    score += 2;
                    lblScore.Text = "Score: " + score;
                }
                else if (userans != answer)
                {
                    score -= 1;
                    lives -= 1;
                    lblScore.Text = "Score: " + score;
                    lblLives.Text = "Lives: " + lives;
                }

                functionhasbeencalled = true;

                timeleft = 5;
                progressBar1.Value = timeleft;
            }
            else if (score >= 20)
            {
                if (userans == answer)
                {
                    score += 2;
                    lblScore.Text = "Score: " + score;
                }
                else if (userans != answer)
                {
                    score -= 1;
                    lives -= 1;
                    lblScore.Text = "Score: " + score;
                    lblLives.Text = "Lives: " + lives;
                }

                functionhasbeencalled = true;

                timeleft = 3;
                progressBar1.Maximum = 3;
                progressBar1.Value = timeleft;
            }
            
        }

        private void assign()
        {
            RandLetter.Text = Char.ToString(answer);
            button1.Text = Char.ToString(rand1);
            button2.Text = Char.ToString(rand2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            userans = rand1;
            checkans();
            generate();
            assign();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userans = rand2;
            checkans();
            generate();
            assign();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timeleft--;
            if (timeleft >=0)
            {
                progressBar1.Value = timeleft;
            }
            

            if (score < 20)
            {
                if ((timeleft < 0) && (functionhasbeencalled == false))
                {
                    score--;
                    lives -= 1;
                    lblScore.Text = "Score: " + score;
                    lblLives.Text = "Lives: " + lives;
                    timeleft = 5;
                    progressBar1.Maximum = 5;
                    progressBar1.Value = timeleft;
                }
            }
            else if (score >= 20)
            {
                if ((timeleft < 0) && (functionhasbeencalled == false))
                {
                    score--;
                    lives -= 1;
                    lblScore.Text = "Score: " + score;
                    lblLives.Text = "Lives: " + lives;
                    timeleft = 3;
                    progressBar1.Maximum = 3;
                    progressBar1.Value = timeleft;
                }
            }


            if (lives <= 0)
            {
                exitpage();
            }
            else if (score >= 50)
            {
                timer1.Interval = 2147483647;

                exitpage();
            }
        }

        public void createfile(int filescore)
        {
            string now = DateTime.Now.ToString("yyyy-MM-dd");

            string filename = @"D:\" + now + " " + username + ".txt";

            string writeText = now + " : " + username + " - " + filescore;

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            using (FileStream fs = File.Create(filename))
            {
                Byte[] title = new UTF8Encoding(true).GetBytes(writeText);
                fs.Write(title, 0, writeText.Length);
            }
        }

        public void exit(int exitscore)
        {
            timer1.Enabled = false;
            createfile(exitscore);
            FrmScore formscore = new FrmScore();
            formscore.InsertData(exitscore);

            this.Close();
            Environment.Exit(1);
        }

        private void exitpage()
        {
            Form4 frm4 = new Form4(score);
            frm4.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            exitpage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmScore frmscore = new FrmScore();
            frmscore.Show();
            timer1.Enabled = false;
            this.Visible = false;
        }

        private void setBtn()
        {
            this.RandLetter.BackColor = System.Drawing.Color.Transparent;
            this.lblScore.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblLives.BackColor = System.Drawing.Color.Transparent;
            this.Time.BackColor = System.Drawing.Color.Transparent;

            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;

            this.progressBar1.Value = 5;
        }
    }
}

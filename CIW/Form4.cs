using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CIW
{
    public partial class Form4 : Form
    {
        public string username;
        public bool formhasbeenopened = false;
        public static int score4;

        public Form4(int score2)
        {
            InitializeComponent();
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.btnRestart.BackColor = System.Drawing.Color.Transparent;
            this.btnRestart.FlatAppearance.BorderSize = 0;
            this.btnExit.BackColor = System.Drawing.Color.Transparent;
            this.btnExit.FlatAppearance.BorderSize = 0;

            username = CIW.username;
            score4 = score2;

            if (score4 >= 50)
            {
                label1.Text = username + " is the winner!";
            }
            else if (score4 < 50)
            {
                label1.Text = "Game Over";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CIW ciw = new CIW(username);
            ciw.createfile(score4);
            ciw.Show();
            FrmScore formscore = new FrmScore();
            formscore.InsertData(score4);
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CIW ciw = new CIW(username);
            ciw.exit(score4);
        }
    }
}

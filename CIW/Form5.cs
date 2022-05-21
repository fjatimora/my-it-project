using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CIW
{
    public partial class Form5 : Form
    {
        private int time = 3;
        private string username2;
        public Form5(string username)
        {
            InitializeComponent();
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.lblTime.BackColor = System.Drawing.Color.Transparent;

            username2 = username;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            lblTime.Text = time.ToString();

            if (time == 0)
            {
                CIW ciw = new CIW(username2);
                ciw.Show();
                this.Close();
            }
        }
    }
}

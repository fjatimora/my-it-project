using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CIW
{
    public partial class Login : Form
    {
        public string username;
        public bool formhasbeenopened = false;

        public Login()
        {
            InitializeComponent();
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label2.BackColor = System.Drawing.Color.Transparent;

            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            formhasbeenopened = true;
            username = textBox1.Text;
            Form5 form5 = new Form5(username);
            form5.Show();
            this.Visible = false;
        }
    }
}

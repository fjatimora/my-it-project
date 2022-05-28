using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace CIW
{
    public partial class FrmScore : Form
    {

        public string username;

        private static ArrayList ListID = new ArrayList();
        private static ArrayList ListDateTime = new ArrayList();
        private static ArrayList ListName = new ArrayList();
        private static ArrayList ListScore = new ArrayList();

        public FrmScore()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void GetData(string newquery)
        {
            try
            {
                string conString;
                conString = @"Data Source=localhost; Initial Catalog=CIW;User ID=sa;Password=QAZwsx123";

                SqlConnection cnn = new SqlConnection(conString);
                cnn.Open();

                SqlCommand sqlCommand;
                SqlDataReader sqlDataReader;
                string query = newquery;


                sqlCommand = new SqlCommand(query, cnn);
                sqlDataReader = sqlCommand.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    ListID.Add(sqlDataReader.GetValue(0).ToString());
                    ListDateTime.Add(sqlDataReader.GetValue(1).ToString());
                    ListName.Add(sqlDataReader.GetValue(2).ToString());
                    ListScore.Add(sqlDataReader.GetValue(3).ToString());
                }

                cnn.Close();

            }
            catch (Exception ex)
            {

            }
        }

        private void updateDatagrid(int j)
        {
            if (j == 1)
            {
                dataGridView1.Rows.Clear();
                for (int i = 0; i < ListID.Count; i++)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView1);
                    newRow.Cells[0].Value = ListID[i];
                    newRow.Cells[1].Value = ListDateTime[i];
                    newRow.Cells[2].Value = ListName[i];
                    newRow.Cells[3].Value = ListScore[i];
                    dataGridView1.Rows.Add(newRow);
                }
                ListID.Clear();
                ListDateTime.Clear();
                ListName.Clear();
                ListScore.Clear();
            }
            else if (j == 2)
            {
                dataGridView2.Rows.Clear();
                for (int i = 0; i < ListID.Count; i++)
                {
                    DataGridViewRow newRow = new DataGridViewRow();

                    newRow.CreateCells(dataGridView2);
                    newRow.Cells[0].Value = ListID[i];
                    newRow.Cells[1].Value = ListDateTime[i];
                    newRow.Cells[2].Value = ListName[i];
                    newRow.Cells[3].Value = ListScore[i];
                    dataGridView2.Rows.Add(newRow);
                }
                ListID.Clear();
                ListDateTime.Clear();
                ListName.Clear();
                ListScore.Clear();
            }
        }

        public void InsertData(int savescore)
        {
            try
            {
                username = CIW.username;
                string score = savescore.ToString();
                string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                string conString;
                conString = @"Data Source=localhost; Initial Catalog=CIW;User ID=sa;Password=QAZwsx123";

                SqlConnection cnn = new SqlConnection(conString);
                cnn.Open();

                SqlCommand sqlcommand;
                SqlDataAdapter adapter = new SqlDataAdapter();
                string query = String.Empty;
                query = "Insert into Game (Date, PlayerName, Score) values ('" + date + "', '" + username + "', '" + score + "')";

                sqlcommand = new SqlCommand(query, cnn);

                adapter.InsertCommand = new SqlCommand(query, cnn);
                adapter.InsertCommand.ExecuteNonQuery();

                cnn.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetData("SELECT GameID, Date, PlayerName, Score FROM Game");
            updateDatagrid(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CIW ciw = new CIW(username);
            ciw.Visible = true;
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnTop_Click(object sender, EventArgs e)
        {
            GetData("SELECT TOP 10 * FROM Game ORDER BY (Score) DESC");
            updateDatagrid(2);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

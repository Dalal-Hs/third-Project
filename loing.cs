using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project2
{
    public partial class loging : Form
    {
        public loging()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            account acc = new account();
            acc.Show();
            this.Hide();
        }
        public static string AccNumber;
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=\\Mac\Home\Documents\ATMDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void button1_Click(object sender, EventArgs e)
        {
            Con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(" select count (*) from AccountTbl where Accnum ='" + AccNumTb.Text + "' and PIN = " + PinTb.Text + " ", Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1") 
            {
                AccNumber = AccNumTb.Text;
                HOME home = new HOME();
                home.Show();
                this.Hide();
                Con.Close();

            }
            else
            {
                MessageBox.Show(" Wrong Account Number Or PIN Code ");
            }
            Con.Close();
        }

        private void loging_Load(object sender, EventArgs e)
        {

        }
    }
}

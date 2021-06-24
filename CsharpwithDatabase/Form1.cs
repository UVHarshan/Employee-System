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

namespace CsharpwithDatabase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source = (LocalDb)\\Demo; Initial Catalog = CsharpTut; Integrated Security = True");
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * From Account Where Username = '" + txtUsername.Text + "' and Password = '" + txtPassword.Text + "'  ", con);
            SqlDataReader sdr; 
            sdr = cmd.ExecuteReader();

            if(sdr.Read())
            {
                Dashboard ds = new Dashboard();
                ds.Show();
                this.Hide();
            }

            else
            {
                MessageBox.Show("Incorrect Deatls", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            con.Close();               
        }
    }
}

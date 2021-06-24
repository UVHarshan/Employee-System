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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //1. SqlConnection - Connection String
            //2. SqlCommand - consists the query

            SqlConnection con = new SqlConnection("Data Source=(LocalDb)\\Demo; Database=CsharpTut; Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Employee ([ID],[FirstName],[LastName],[Email],[Gender],[Salary],[HireDate])  VALUES('"+txtID.Text+"', '"+txtFN.Text+"', '"+txtLN.Text+"', '"+txtEmail.Text+"', '"+comboGender.Text+"', '"+txtSalary.Text+"', '"+dtHireDate.Value+"')", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record Saved Successfully", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadEmployeeRecords();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //1. SqlConnection
            //2. SqlCommand - query

            SqlConnection con = new SqlConnection("Data Source=(LocalDb)\\Demo; Database=CsharpTut; Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("UPDATE [Employee]  SET [FirstName]= '"+txtFN.Text+ "', [LastName]='"+txtLN.Text+ "', [Email]='"+txtEmail.Text+ "', [Gender]='"+comboGender.Text+ "', [Salary]='"+txtSalary.Text+ "', [HireDate]='"+dtHireDate.Value+"' Where ID ='"+txtID.Text+"'  ", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record Updated Successfully", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadEmployeeRecords();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //1. SqlConnection
            //2. SqlCommand - query to perform the transaction

            SqlConnection con = new SqlConnection("Data Source=(LocalDb)\\Demo; Database=CsharpTut; Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("  DELETE FROM [Employee]  WHERE ID ='"+txtID.Text+"'  ", con);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Record Deleted Successfully", "Message Title", MessageBoxButtons.OK, MessageBoxIcon.Information);

            loadEmployeeRecords();
        }

        public void loadEmployeeRecords()
        {
            //1. SqlConnection 
            //2. SqlCommand 
            //3. DataTable
            //4. SqlDataAdapter
            //5. Binding Source

            SqlConnection con = new SqlConnection("Data Source=(LocalDb)\\Demo; Database=CsharpTut; Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * From Employee", con);
            SqlDataAdapter sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();

            sda.Fill(dt);

            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            dgvEmployee.DataSource = bs;
            sda.Update(dt);

        }




        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadEmployeeRecords();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtID.Text = string.Empty;
            txtFN.Text = string.Empty;
            txtLN.Text = string.Empty;
            txtEmail.Text = string.Empty;
            comboGender.Text = string.Empty;
            txtSalary.Text = string.Empty;
        }
    }
}

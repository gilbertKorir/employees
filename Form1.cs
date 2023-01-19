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

namespace employees
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-PGF82N7\\SQLEXPRESS;Initial Catalog=storedProcDB;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("AddEmp", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = IDtxt.Text;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = Nametxt.Text;
            cmd.Parameters.Add("@adress", SqlDbType.VarChar).Value = Adresstxt.Text;
            cmd.ExecuteNonQuery();

            MessageBox.Show("Employee Added");
            conn.Close();
            clearForm();
        }

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("DisplayEmp", conn);
            cmd.CommandType= CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            dataGridView1.DataSource= dt;
            conn.Close();
            clearForm();
        }
        private void clearForm()
        {
            IDtxt.Text = "";
            Nametxt.Text = "";
            Adresstxt.Text = "";
        }
    }
}

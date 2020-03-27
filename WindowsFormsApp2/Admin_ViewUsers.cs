using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class Admin_ViewUsers : Form
    {
        SqlConnection sqlCon;
        SqlDataAdapter sda;
        DataTable dt;
        SqlCommand cmd;
        

        public Admin_ViewUsers()
        {
            try
            {

                DBconnection obj = new DBconnection();
                sqlCon = obj.GetConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting" + ex, "Login", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            InitializeComponent();
        }

        private void btnVAS_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MISHAL\MISHSQL;Initial Catalog=BigError;Integrated Security=True");
            sda = new SqlDataAdapter("select Username,Password,UserType from StaffInfo where UserType='" + cmbUserType.Text + "'", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVAC_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=MISHAL\MISHSQL;Initial Catalog=BigError;Integrated Security=True");
            sda = new SqlDataAdapter("select PhoneNo,Name,UserType from UserInfo2 where UserType='" + cmbUserType2.Text + "'", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure to delete this Staff/Record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog == DialogResult.Yes)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(rowIndex);
            }
            else if (dialog == DialogResult.No)
            {

            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Are you sure to delete this Customer/Record?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialog ==DialogResult.Yes)
            {


                //Deletes User Records but Record still in Database
                int rowIndex = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.Rows.RemoveAt(rowIndex);


                //This Function Basically just Deletes Every User Records Might Come In Handy
                //SqlConnection con = new SqlConnection(@"Data Source=MISHAL\MISHSQL;Initial Catalog=BigError;Integrated Security=True");
                //con.Open();
                //cmd = new SqlCommand("Delete From UserInfo2 where UserType = '" + cmbUserType2.Text + "'",con);
                //cmd.ExecuteNonQuery();
                //con.Close();
                //MessageBox.Show("Customer Account Successfully Removed");


            }
            else if (dialog == DialogResult.No)
            {
                //Meh
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Admin_Dashboard obj = new Admin_Dashboard();
            obj.Show();
            this.Hide();
        }
    }
}

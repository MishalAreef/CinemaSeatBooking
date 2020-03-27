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
    public partial class Cashier_AddProducts : Form
    {
        SqlConnection sqlCon;
        SqlDataAdapter sda;
        DataTable dt;
        public Cashier_AddProducts()
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
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parms = base.CreateParams;
                parms.ClassStyle |= 0x200;
                return parms;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Cashier_Dashboard obj = new Cashier_Dashboard();
            obj.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=MISHAL\\MISHSQL;Initial Catalog=BigError;Integrated Security=True");
            sda = new SqlDataAdapter("select ProductID,ProductName,ProductType,ProductPrice from ProductInfo2", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSaveProducts_Click(object sender, EventArgs e)
        {
            try
            {


                {
                    SqlCommand cmd = new SqlCommand("insert into ProductInfo2 values('" + txtProductID.Text + "','" + txtProductName.Text + "','" + cmbProductType.SelectedItem + "','" + txtProductPrice.Text + "');", sqlCon);


                    int temp = cmd.ExecuteNonQuery();

                    if (temp > 0)
                    {
                        MessageBox.Show("Products Added to Menu Successfully", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Products Fail to Add, Please Try Again", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data" + ex, "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=MISHAL\\MISHSQL;Initial Catalog=BigError;Integrated Security=True");
            sda = new SqlDataAdapter("select ProductID,ProductName,ProductType,ProductPrice from ProductInfo2", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnSearchProducts_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from ProductInfo2 where ProductID = '" + txtProductID.Text + "'", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    txtProductName.Text = dr[1].ToString();
                    cmbProductType.Text = dr[2].ToString();
                    txtProductPrice.Text = dr[3].ToString();
                    
                }
                else
                {
                    MessageBox.Show("Enter a valid Product ID - Eg: PROD1", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }


                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Searching Data" + ex, "Coordinator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            cmbProductType.Text = "";
            txtProductPrice.Text = "";
            
        }
    }
}

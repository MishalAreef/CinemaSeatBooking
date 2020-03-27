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
using System.Configuration;

namespace WindowsFormsApp2
{
    public partial class Form4 : Form
    {
        SqlConnection con;
        SqlDataAdapter sda;
        DataTable dt;
        public Form4()
        {
            try
            {

               DBconnection obj = new DBconnection();
               con = obj.GetConnection();
                
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

        private void Form4_Load(object sender, EventArgs e)
        {
            
        }
        public void Data(string[] data) 
        {
            dataGridView1.Rows.Add(data.Count() - 1);

            dataGridView1.Rows[0].Cells[0].Value = "FirstName";
            dataGridView1.Rows[0].Cells[1].Value = data[0];

            dataGridView1.Rows[1].Cells[0].Value = "LastName";
            dataGridView1.Rows[1].Cells[2].Value = data[1];

            dataGridView1.Rows[2].Cells[0].Value = "PaymentMethod";
            dataGridView1.Rows[2].Cells[3].Value = data[2];

            dataGridView1.Rows[3].Cells[0].Value = "PhoneNo";
            dataGridView1.Rows[3].Cells[4].Value = data[3];

            dataGridView1.Rows[4].Cells[0].Value = "SeatNo";
            dataGridView1.Rows[4].Cells[5].Value = data[4]; //

            dataGridView1.Rows[5].Cells[0].Value = "Food";
            dataGridView1.Rows[5].Cells[6].Value = data[7] + " MVR";

            dataGridView1.Rows[6].Cells[0].Value = "Beverage";
            dataGridView1.Rows[6].Cells[7].Value = data[8] + " MVR";

            dataGridView1.Rows[7].Cells[0].Value = "TicketAmount";
            dataGridView1.Rows[7].Cells[8].Value = data[5] + " MVR";

            dataGridView1.Rows[8].Cells[0].Value = "ServiceFee";
            dataGridView1.Rows[8].Cells[9].Value = data[6] + " MVR";

            dataGridView1.Rows[9].Cells[0].Value = "Total Amount";
            dataGridView1.Rows[9].Cells[10].Value = data[9] + " MVR";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           //Cashier_ViewBills cvb = new Cashier_ViewBills();
           //cvb.txtFN.Text = this.dataGridView1.CurrentRow.Cells[1].Value.ToString();
           //cvb.txtLN.Text = this.dataGridView1.CurrentRow.Cells[2].Value.ToString();
           //cvb.cmbPaymentMethod.SelectedItem = this.dataGridView1.CurrentRow.Cells[3].Value.ToString();
           //cvb.txtPhoneNo.Text = this.dataGridView1.CurrentRow.Cells[4].Value.ToString();
          // cvb.lbSeatNo.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
           //cvb.rbFood.Text = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
           //cvb.rbBeverage.Text = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    //cvb.rbFood.Checked = this.dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    //cvb.rbBeverage.Checked = this.dataGridView1.CurrentRow.Cells[6].Value.ToString();
           //cvb.txtTicketAmount.Text = this.dataGridView1.CurrentRow.Cells[7].Value.ToString();
           //cvb.txtServiceFee.Text = this.dataGridView1.CurrentRow.Cells[8].Value.ToString();
           //cvb.txtTotalAmount.Text = this.dataGridView1.CurrentRow.Cells[10].Value.ToString();



           SqlConnection con = new SqlConnection("Data Source=MISHAL\\MISHSQL;Initial Catalog=BigError;Integrated Security=True");
           sda = new SqlDataAdapter("select FirstName,LastName,PaymentMethod,PhoneNo,SearNo,Food,Beverage,TicketAmount,ServiceFee,TotalAmount from tblBills3", con);
           dt = new DataTable();
           sda.Fill(dt);
           dataGridView1.DataSource = dt;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["Myconnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            this.Close();
            

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {

                string sqlquery = "insert into tblBills3 values(@FirstName,@LastName,@PaymentMethod,@PhoneNo,@SeatNo,@Food,@Beverage,@TicketAmount,@ServiceFee,@TotalAmount)";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlcomm.Parameters.AddWithValue("@FirstName", dr.Cells["Column2"].Value ?? DBNull.Value);
                sqlcomm.Parameters.AddWithValue("@LastName", dr.Cells["Column3"].Value ?? DBNull.Value);
                sqlcomm.Parameters.AddWithValue("@PaymentMethod", dr.Cells["Column4"].Value ?? DBNull.Value);
                sqlcomm.Parameters.AddWithValue("@PhoneNo", dr.Cells["Column5"].Value ?? DBNull.Value);
                sqlcomm.Parameters.AddWithValue("@SeatNo", dr.Cells["Column6"].Value ?? DBNull.Value); //
                sqlcomm.Parameters.AddWithValue("@Food", dr.Cells["Column7"].Value ?? DBNull.Value);
                sqlcomm.Parameters.AddWithValue("@Beverage", dr.Cells["Column8"].Value ?? DBNull.Value);
                sqlcomm.Parameters.AddWithValue("@TicketAmount", dr.Cells["Column9"].Value ?? DBNull.Value);
                sqlcomm.Parameters.AddWithValue("@ServiceFee", dr.Cells["Column10"].Value ?? DBNull.Value);
                sqlcomm.Parameters.AddWithValue("@TotalAmount", dr.Cells["Column11"].Value ?? DBNull.Value);
                sqlconn.Open();
                sqlcomm.ExecuteNonQuery();
                sqlconn.Close();
            }

             
        }
    }
}

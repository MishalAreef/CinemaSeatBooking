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
    public partial class Admin_AddMovies : Form
    {
        SqlConnection sqlCon;
        SqlDataAdapter sda;
        DataTable dt;
        public Admin_AddMovies()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=MISHAL\\MISHSQL;Initial Catalog=BigError;Integrated Security=True");
            sda = new SqlDataAdapter("select MovieID,MovieName,ReleaseDate,Director,Genre,Trailer from MovieInfo", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admin_AddMovies_Load(object sender, EventArgs e)
        {
           
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtMovieID.Text = "";
            txtMovieName.Text = "";
            dtpReleaseDate.Format = DateTimePickerFormat.Short;
            dtpReleaseDate.CustomFormat = " ";
            txtDirector.Text = "";
            cmbGenre.Text = "";
            txtTrailer.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {


                {
                    SqlCommand cmd = new SqlCommand("insert into MovieInfo values('" + txtMovieID.Text + "','" + txtMovieName.Text + "','" + dtpReleaseDate.Text + "','" + txtDirector.Text + "','" + cmbGenre.Text + "','" + txtTrailer.Text + "');", sqlCon);


                    int temp = cmd.ExecuteNonQuery();

                    if (temp > 0)
                    {
                        MessageBox.Show("Movie Records Successfully Added", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Movie Records Fail to Add", "Register Form", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inserting data" + ex, "Register", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=MISHAL\\MISHSQL;Initial Catalog=BigError;Integrated Security=True");
            sda = new SqlDataAdapter("select MovieID,MovieName,ReleaseDate,Director,Genre,Trailer from MovieInfo", con);
            dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * from MovieInfo where MovieID = '" + txtMovieID.Text + "'", sqlCon);
                SqlDataReader dr = cmd.ExecuteReader();
                
                if (dr.Read())
                {
                    txtMovieName.Text = dr[1].ToString();
                    dtpReleaseDate.Text = dr[2].ToString();
                    txtDirector.Text = dr[3].ToString();
                    cmbGenre.Text = dr[4].ToString();
                    txtTrailer.Text = dr[5].ToString();
                }
                else
                {
                    MessageBox.Show("Enter a valid Movie ID - Eg: M1", "FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
                
                
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Searching Data" + ex, "Coordinator", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            


        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            Admin_Dashboard obj = new Admin_Dashboard();
            obj.Show();
            this.Hide();
        }
    }
}

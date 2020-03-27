using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WindowsFormsApp2
{
    class DBconnection
    {
        public SqlConnection GetConnection()
        {

            SqlConnection sqlCon = null;
            try
            {
                sqlCon = new SqlConnection("Data Source=MISHAL\\MISHSQL;Initial Catalog=BigError;Integrated Security=True");
                // Default: "Data Source=10.0.0.4;Initial Catalog=mish;User Id=hnd; Password=hnd"//
                sqlCon.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error connecting to Db" + ex);
            }
            return sqlCon;
        }
    }
}

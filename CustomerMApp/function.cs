using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMApp
{
    internal class function
    {
        protected SqlConnection getConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "data source = DESKTOP-SV3KE10\\SQLEXPRESS01;database =Company_Customers; integrated security =True";
            return conn;
        }
        public DataSet getData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void setData(String query)
        {
            SqlConnection con = getConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();

            MessageBox.Show("Data Processed Sucessfully.","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
    }
}

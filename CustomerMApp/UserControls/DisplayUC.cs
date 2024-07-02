using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMApp.UserControls
{
    public partial class DisplayUC : UserControl
    {
        function fn = new function();
        String query;
        public DisplayUC()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            query = "select * from customers";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void DisplayUC_Load(object sender, EventArgs e)
        {
         
            query = "select * from customers";
           DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            int RefNo;
           String searchInput = guna2TextBox1.Text;
           bool isNumeric = int.TryParse(searchInput, out int refNo);

            if (isNumeric) 
            {
                query = "SELECT iid, Name, Surname, RefNo FROM customers WHERE RefNo like '"+refNo+"' OR Name LIKE '" + searchInput + "%' OR Surname LIKE '" + searchInput + "%'";
            }
            else
            {
                query = "SELECT iid, Name, Surname, RefNo FROM customers WHERE Name LIKE '" + searchInput + "%' OR Surname LIKE '" + searchInput + "%'";
            }

            // Modify the query to search for names and surnames starting with the input
           // query = "SELECT iid, Name, Surname, RefNo FROM customers WHERE Name LIKE '" + searchInput + "%' OR Surname LIKE '" + searchInput + "%'";

            // Get the data set
            DataSet ds = fn.getData(query);

            // Set the data source of the DataGridView to the result set
            guna2DataGridView1.DataSource = ds.Tables[0];
        }


      

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            string query = "select iid, name, surname, RefNo from customers";

            // Check if the checkbox is checked
            if (guna2CheckBox1.Checked)
            {
                // Add the ORDER BY clause if the checkbox is checked
                query += " order by name";
            }

            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }
    }
    }


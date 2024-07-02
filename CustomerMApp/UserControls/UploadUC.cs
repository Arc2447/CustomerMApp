using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMApp.UserControls
{
    public partial class UploadUC : UserControl
    {
        function fn = new function();
        String query;
        public UploadUC()
        {
            InitializeComponent();
        }

    

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //BROWSE
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Text Files (*.txt)|*.txt|CSV Files (*.csv)|*.csv";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Title = "Select Customer File";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                guna2TextBox1.Text = filepath;
                
            }

        }
        private DataTable ReadFileToDataTable(string filepath)
        {
            DataTable dataTable = new DataTable();

            dataTable.Columns.Clear();
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Surname", typeof(string));
            dataTable.Columns.Add("RefNO", typeof(int)); 


            using (StreamReader reader = new StreamReader(filepath))
            {
                
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                  

                    string[] rows = line?.Split(',');
                    if (rows != null && rows.Length >= 3)
                    {
                        DataRow dr = dataTable.NewRow();
                        dr["Name"] = rows[0].Trim();
                        dr["Surname"] = rows[1].Trim();
                        if (int.TryParse(rows[2].Trim(), out int refNo))
                        {
                            dr["RefNO"] = refNo;
                        }
                        else
                        {
                            MessageBox.Show("RefNO must be a valid integer. Skipping row.");
                            continue;
                        }
                        dataTable.Rows.Add(dr);
                    }
                }
            }

            return dataTable;
        }
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            //Upload File
           string filepath = guna2TextBox1.Text;
            if (string.IsNullOrEmpty(filepath))
            {
                MessageBox.Show("Please select a file first");
                return;
            }

            if (!File.Exists(filepath))
            {
                MessageBox.Show("The selected file does not exist");
                return;
            }

            DataTable dataTable = ReadFileToDataTable(filepath);
            dataGridView1.DataSource = dataTable;
        }

        private void UploadUC_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            String connString = "data source = DESKTOP-SV3KE10\\SQLEXPRESS01;database =Company_Customers; integrated security =True";
            // query = 

            using (SqlConnection connection = new SqlConnection(connString))
            {
                connection.Open();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.IsNewRow) continue;

                    string name = row.Cells["Name"].Value?.ToString();
                    string surname = row.Cells["Surname"].Value?.ToString();
                    string refNoStr = row.Cells["RefNo"].Value?.ToString();

                    if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(surname))
                    {
                        MessageBox.Show("Name and Surname cannot be empty");
                        continue;
                    }

                    if (!int.TryParse(refNoStr, out int RefNo))
                    {
                        MessageBox.Show("Ref No Must be a valid integer.");
                        continue;
                    }

                    query = "insert into customers (name, surname, refNo) values (@Name, @Surname, @RefNo)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@Surname", surname);
                        command.Parameters.AddWithValue("@RefNo", RefNo);

                        try
                        {
                            command.ExecuteNonQuery();

                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error inserting data: {ex.Message}");
                        }
                    }
                }
            }
            MessageBox.Show("data Saved successfully"); 
        }
    }
}

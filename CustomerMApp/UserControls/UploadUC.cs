using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            using (StreamReader reader = new StreamReader(filepath))
            {
                string[] headers = reader.ReadLine()?.Split(',');
                if(headers != null)
                {
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header.Trim());
                    }
                    while (!reader.EndOfStream)
                    {
                        string[] rows = reader.ReadLine()?.Split(',');
                        if (rows != null)
                        {
                            DataRow dr = dataTable.NewRow();
                            for (int i = 0; i < headers.Length; i++)
                            {
                                dr[i] = rows[i].Trim();
                            }
                            dataTable.Rows.Add(dr); 
                        }
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
    }
}

﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomerMApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            
            displayUC1.Visible=true;
            displayUC1.BringToFront();
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            uploadUC1.Visible=true;
            uploadUC1.BringToFront();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

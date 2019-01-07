﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TTMMC_ConfigBuilder
{
    public partial class NewDB : Form
    {
        public string IP;
        public string DB;
        public string Username;
        public string Password;
        public bool RequestSecurityInfo;

        public NewDB()
        {
            InitializeComponent();
        }

        private void NewDB_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            IP = textBox1.Text;
            DB = textBox2.Text;
            Username = textBox3.Text;
            Password = textBox4.Text;
            RequestSecurityInfo = checkBox1.Checked;
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

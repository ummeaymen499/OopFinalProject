﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fin
{
    public partial class InventoryManagement : Form
    {
        public InventoryManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            using (AddInventory form = new AddInventory())
            {
                form.ShowDialog();
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            using (EditInventory form = new EditInventory())
            {
                form.ShowDialog();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            this.Hide();
            using (DeleteInventory form = new DeleteInventory())
            {
                form.ShowDialog();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            using (SearchInventory form = new SearchInventory())
            {
                form.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            
        }
    }
}

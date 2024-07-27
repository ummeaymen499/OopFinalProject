using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace fin
{
    public partial class MaintenanceManager : Form
    {
        public MaintenanceManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            using (InventoryManagement man = new InventoryManagement())
            {
                man.ShowDialog();
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form2 man = new Form2())
            {
                man.ShowDialog();
            }
        }
    }
}

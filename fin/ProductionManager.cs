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
    public partial class ProductionManager : Form
    {
   
        public ProductionManager()
        {
            InitializeComponent();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            using (ProductManagement prod = new ProductManagement())
            {
                prod.ShowDialog();
                
            }
            
        }

        private void ProductionManager_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (InventoryManagement prod = new InventoryManagement())
            {
                prod.ShowDialog();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form2 prod = new Form2())
            {
                prod.ShowDialog();

            }
        }
    }
}

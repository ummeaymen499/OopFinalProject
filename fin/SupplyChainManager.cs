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
    public partial class SupplyChainManager : Form
    {
        public SupplyChainManager()
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

        private void SupplyChainManager_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form2 form=new Form2())
            {
                form.ShowDialog();
            }
        }
    }
}

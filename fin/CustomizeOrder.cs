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
    public partial class CustomizeOrder : Form
    {
        public CustomizeOrder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (AddProduct prod = new AddProduct())
            {
                prod.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (EditProduct prod = new EditProduct())
            {
                prod.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (DeleteProduct prod = new DeleteProduct())
            {
                prod.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();
            using (SearchProduct prod = new SearchProduct())
            {
                prod.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Customer prod = new Customer())
            {
                prod.ShowDialog();
            }
        }
    }
}

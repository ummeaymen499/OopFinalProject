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
    public partial class InitiatePurchase : Form
    {
        public InitiatePurchase()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (AddOrder or = new AddOrder())
            {
                or.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (EditOrder or = new EditOrder())
            {
                or.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (DeleteOrder or = new DeleteOrder())
            {
                or.ShowDialog();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Customer cu = new Customer())
            { 
             cu.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
           using (SearchOrder or = new SearchOrder())
           {
               or.ShowDialog();
           }
        }
    }
}

using finBL.BL;
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
    public partial class Customer : Form
    {
       
        public Customer()
        {
            InitializeComponent();
           
        }

        private void Feedback_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (ProvideFeedback form = new ProvideFeedback())
            {
                form.ShowDialog();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form2 form = new Form2())
            {
                form.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (InitiatePurchase form = new InitiatePurchase())
            {
                form.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (CustomizeOrder or = new CustomizeOrder())
            { 
              or.ShowDialog();
            }
        }
    }
}

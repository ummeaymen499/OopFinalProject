using System;
using finBL.BL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace fin
{
    public partial class ProvideFeedback : Form
    {
       
        public ProvideFeedback()
        {
            InitializeComponent();
        }
        public void ReceiveObject(MUserBL user)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Please provide values for all required fields.");
            }
            else
            {
                string feed = richTextBox1.Text;
                AdministratorBL administrator = new AdministratorBL();
                // Only one instance of AdministratorBL is needed
                CustomerBL customer = new CustomerBL(user.getUserName(), user.getUserPassword(), user.getUserRole());
                customer.ProvideFeedback(administrator, feed);
            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Customer cu = new Customer())
            {
                cu.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            /*if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                MessageBox.Show("Please provide values for all required fields.");
            }
            else 
            { 
              string feed=richTextBox1.Text;
              
                
            }*/
        }

        private void ProvideFeedback_Load(object sender, EventArgs e)
        {

        }
    }
}

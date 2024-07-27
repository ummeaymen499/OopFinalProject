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
    public partial class FeedBackShowcase : Form
    {
        public FeedBackShowcase()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdministratorBL administrator = new AdministratorBL();
            List<string> viewFeedbacks = administrator.ViewCustomerFeedback();
            try
            {
                if (viewFeedbacks != null && viewFeedbacks.Count > 0)
                {
                 //   richTextBox1.Text = string.Join(Environment.NewLine, viewFeedbacks);
                    MessageBox.Show("Feedbacks are displayed");
                }
                else
                {
                    MessageBox.Show("No Feedbacks Yet!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form4 cut=new Form4())
            {
                cut.ShowDialog();
            }
        }
    }
}

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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (FeedBackShowcase user = new FeedBackShowcase())
            {

                user.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UserManagement user = new UserManagement())
            {
                this.Hide();
                user.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (SystemConfiguration user = new SystemConfiguration())
            {
               
                user.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form2 user = new Form2())
            {

                user.ShowDialog();
            }
        }
    }
}

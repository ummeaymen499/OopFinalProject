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
    public partial class UserManagement : Form
    {
        public UserManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (AddManager add = new AddManager())
            { 
              add.ShowDialog(this);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (EditManager add = new EditManager())
            {
                add.ShowDialog(this);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (DeleteManager add = new DeleteManager())
            {
                add.ShowDialog(this);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (SearchManager add = new SearchManager())
            {
                add.ShowDialog(this);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form4 add = new Form4())
            {
                add.ShowDialog();
            }
        }
    }
}

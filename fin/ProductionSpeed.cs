using finBL.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fin
{
    public partial class ProductionSpeed : Form
    {
        AdministratorBL adm = new AdministratorBL();
        public ProductionSpeed()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please provide values for all required fields.");
            }
            else
            {

                int value = int.Parse(textBox2.Text);
                if (value > 0)
                {
                    int inc = adm.IncreaseProductionSpeed(value);
                    MessageBox.Show("Production Speed has been increased upto " + inc + " UNITS PER HOUR!");
                }
                else
                {
                    MessageBox.Show("Production Speed remains same 200 UNITS PER HOUR");
                }



            }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Please provide values for all required fields.");
            }
            else
            {
                int value = int.Parse(textBox2.Text);
                if (value > 0)
                {
                    int dec = adm.DecreaseProductionSpeed(value);
                    MessageBox.Show("Production Speed has been Decreased upto " + dec + " UNITS PER HOUR!");
                }
                else
                {
                    MessageBox.Show("Production Speed remains same 200 UNITS PER HOUR");
                }



            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (SystemConfiguration con = new SystemConfiguration())
            {
                con.ShowDialog();
            }
        }
    }
}

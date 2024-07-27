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
    public partial class AlertThreshold : Form
    {
    
        public AlertThreshold()
        {
            InitializeComponent();
        }

        private void AlertThreshold_Load(object sender, EventArgs e)
        {
           
            
        }

        private void label3_Click(object sender, EventArgs e)
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

                AdministratorBL adm = new AdministratorBL(value);
                adm.SetProductionSpeed(200);
                if (value > 0)
                {
                    if (adm.CheckAlertThreshold())
                    {
                        MessageBox.Show("Alert Threshold Exceeds Production Speed!!!");


                    }
                    else
                    {
                        MessageBox.Show("Value within acceptable range!");
                    }
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
            using (SystemConfiguration sys = new SystemConfiguration())
            {
                sys.ShowDialog();
            }
        }
    }
}

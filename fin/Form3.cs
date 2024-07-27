using finBL.BL;
using finBL.DL;
using finBL.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace fin
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
           

            if (string.IsNullOrEmpty(richTextBox1.Text) || string.IsNullOrEmpty(richTextBox2.Text) || string.IsNullOrEmpty(richTextBox3.Text))
            {
                MessageBox.Show("Please provide values for all required fields.");
            }
            else
            {
                try
                {
                    string userName = richTextBox1.Text;
                    string userPassword = richTextBox2.Text;
                    string userRole = richTextBox3.Text;

                    MUserBL userBL = new MUserBL(userName, userPassword, userRole);
                    MUserDLwithDB userDL = MUserDLwithDB.getInstance(ConnectionClass.GetConString());

                    // Check if both userBL and userDL are properly initialized
                    if (userDL != null && userBL != null)
                    {
                        userDL.SignUp(userBL);
                        MessageBox.Show("Congratulations! Your Account has been SignedUp successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Failed to Signed up! Please select UserRole carefully.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
           



        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form2 form = new Form2())
            { 
              form.ShowDialog();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

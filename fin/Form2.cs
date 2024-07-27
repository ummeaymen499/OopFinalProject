using finBL;
using finBL.BL;
using finBL.DL;
using finBL.Utilities;
using finBL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics.Eventing.Reader;
using System.Xml.Linq;


namespace fin
{
    public partial class Form2 : Form
    {
        IMUser User = ObjectHandler.user;
        MUserBL user;
        private ProvideFeedback form2Instance;
        public Form2()
        {
            InitializeComponent();
        }
        private void SomeMethod()
        {
            // Check if Providefeedback instance is not null and open
            if (form2Instance != null && !form2Instance.IsDisposed)
            {
                // Pass the object to Form2
                form2Instance.ReceiveObject(user);
            }
            else
            {
                MessageBox.Show("Form2 is not open.");
            }
        }
      
        private void OpenFeedbackButton_Click(object sender, EventArgs e)
        {
            // Instantiate Form2
            form2Instance = new ProvideFeedback();
            form2Instance.Show();

        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = richTextBox1.Text;
            string userPassword=richTextBox2.Text;
            bool IsAdmin = Validations.IsAdmin(userName, userPassword);
            if(IsAdmin)
            {

                MessageBox.Show("Congratulation! Administrator has been loggedIn Successfully");
                this.Hide();
                using (Form4 form = new Form4())
                { 
                  form.ShowDialog();
                }
            }
            else
            {
                 ManagerBL manager=Validations.IsManager(userName, userPassword);

                if (manager != null)
                {
                    // List<ManagerBL> managerList = ManagerDL.getManagerList();

                    // Check if managerList is not null and iterate over it

                    if (manager.getRank() == "Production Manager")
                    {
                        MessageBox.Show("Congratulation! You have been loggedIn Successfully");
                        this.Hide();
                        using (ProductionManager man = new ProductionManager())
                        {
                            man.ShowDialog();
                        }

                    }
                    else if (manager.getRank() == "Maintenance Manager")
                    {
                        MessageBox.Show("Congratulation! You have been loggedIn Successfully");
                        this.Hide();
                        using (MaintenanceManager man = new MaintenanceManager())
                        {
                            man.ShowDialog();
                        }
                    }
                    else if (manager.getRank() == "Supply Chain Manager")
                    {
                        MessageBox.Show("Congratulation! You have been loggedIn Successfully");
                        this.Hide();
                        using (SupplyChainManager man = new SupplyChainManager())
                        {
                            man.ShowDialog();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Sorry! Manager with the specified rank is not found.");
                    }
                }
                else 
                {
                    user = new MUserBL(userName, userPassword);
                    MUserBL loggeduser=User.SignIn(user);
                    if (loggeduser != null && (loggeduser.getUserRole() == "Customer" || loggeduser.getUserRole()=="customer"))
                    {
                        MessageBox.Show("Congratulation! You have been loggedIn Successfully");
                        this.Hide();
                        using (Customer man = new Customer())
                        {
                            man.ShowDialog();
                        }


                    }
                    else 
                    {
                        MessageBox.Show("Incorrect UserRole");
                    }
                    
                }
                
                
            }
                
          
            
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            using (Form3 form = new Form3())
            {
                form.ShowDialog();
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (Form1 fr = new Form1())
            { 
             fr.ShowDialog();
            }
        }
    }
}

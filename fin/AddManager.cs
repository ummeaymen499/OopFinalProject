using finBL.BL;
using finBL.DL;
using finBL.Interfaces;
using finBL.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fin
{
    public partial class AddManager : Form
    {
        int pictureCounter = 0;
        IManager manager = ObjectHandler.man;
        public AddManager()
        {
            InitializeComponent();
        }

        private void AddManager_Load(object sender, EventArgs e)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Id", typeof(int)).AllowDBNull = true; // Assuming Id is auto-incremented in the database
            datatable.Columns.Add("ManagerID", typeof(int));
            datatable.Columns.Add("Name", typeof(string));
            datatable.Columns.Add("Password", typeof(string));
            datatable.Columns.Add("Rank", typeof(string));
            datatable.Columns.Add("Email", typeof(string));
            datatable.Columns.Add("ContactNumber", typeof(string));
            datatable.Columns.Add("Department", typeof(string));
            datatable.Columns.Add("Salary", typeof(decimal));

            dataGridView1.DataSource = datatable;
            List<int> ManagerIds = ManagerDL.getIDList();
            
            List<ManagerBL> managerslist = ManagerDL.getManagerList();

            for (int i = 0; i < ManagerIds.Count && i < managerslist.Count; i++)
            {
                int managerId = ManagerIds[i];
                ManagerBL manager = managerslist[i];

                // Add manager details to the DataTable row
                datatable.Rows.Add(managerId,manager.getId(),manager.getName(), manager.getPassword(), manager.getRank(), manager.getEmail(), manager.getContactNumber(), manager.getDepartment(), manager.getSalary());
            }

            // Update DataGridView.DataSource after adding all data
            dataGridView1.DataSource = datatable;

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(maskedTextBox1.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox2.Text)||string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please provide values for all required fields.");
            }
            else
            {
                try
                {
                    int id = int.Parse(textBox4.Text);
                    string name = textBox7.Text;
                    string pass = textBox6.Text;
                    string contactNumber = maskedTextBox1.Text;
                    string email = textBox1.Text;
                    string department = textBox3.Text;
                    string rank = comboBox1.Text;
                    decimal salary = decimal.Parse(textBox2.Text);
                    ManagerBL managerobject = new ManagerBL(id,name, pass, rank, email, contactNumber, department, salary);
                    try
                    {
                        manager.AddManager(managerobject);
                        MessageBox.Show("Congratulations! Worker is added successfully");
                        AddManager_Load(null, null);
                    }
                    catch
                    {
                        MessageBox.Show("Sorry! Worker is not added. Try Again after some time");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Display the image in the PictureBox control.
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    pictureCounter++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
            maskedTextBox1.Text = null;
            comboBox1.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (UserManagement user = new UserManagement())
            {
                user.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureCounter == 0)
            {
                MessageBox.Show("Error: Could not load the image. ");
            }
            else
            {
                MessageBox.Show("Image successfully inserted.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

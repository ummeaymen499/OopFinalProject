using finBL.BL;
using finBL.DL;
using finBL.Interfaces;
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

namespace fin
{
    public partial class EditManager : Form
    {
        IManager manager = ObjectHandler.man;
        public EditManager()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ManagerId = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ManagerId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

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
                        manager.UpdateManager(managerobject, ManagerId);
                        MessageBox.Show("Congratulations! Worker is updated successfully");
                        EditManager_Load(null, null);
                    }
                    catch
                    {
                        MessageBox.Show("Sorry! Worker is not updated. Try Again after some time");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please! Fill all required fields with Data In the Data Grid");
            }
        }




        private void EditManager_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int)).AllowDBNull = true; // Assuming Id is auto-incremented in the database
            dataTable.Columns.Add("ManagerId", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));
            dataTable.Columns.Add("Rank", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("ContactNumber", typeof(string));
            dataTable.Columns.Add("Department", typeof(string));
            dataTable.Columns.Add("Salary", typeof(decimal));

            List<int> ManagerIds = ManagerDL.getIDList();
            List<ManagerBL> managersList = ManagerDL.getManagerList();

            for (int i = 0; i < Math.Min(ManagerIds.Count, managersList.Count); i++)
            {
                int managerId = ManagerIds[i];
                ManagerBL manager = managersList[i];

                // Add manager details to the DataTable row
                dataTable.Rows.Add(managerId,manager.getId(), manager.getName(), manager.getPassword(), manager.getRank(), manager.getEmail(), manager.getContactNumber(), manager.getDepartment(), manager.getSalary());
            }

            // Set the DataSource of the DataGridView to the populated DataTable
            dataGridView1.DataSource = dataTable;
        }

            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = selectedRow.Cells[1].Value.ToString();
                textBox7.Text = selectedRow.Cells[2].Value.ToString();
                textBox6.Text = selectedRow.Cells[3].Value.ToString();
                textBox1.Text = selectedRow.Cells[5].Value.ToString();
                maskedTextBox1.Text = selectedRow.Cells[6].Value.ToString();
                textBox3.Text = selectedRow.Cells[7].Value.ToString();
                textBox2.Text = selectedRow.Cells[8].Value.ToString();

                if (selectedRow.Cells[4].Value.ToString() == "Production Manager")
                {
                    comboBox1.Text = "Production Manager"; // Assign the desired text to the ComboBox
                }
                else if (selectedRow.Cells[4].Value.ToString() == "Supply Chain Manager")
                {
                    comboBox1.Text = "Supply Chain Manager";
                }
                else if (selectedRow.Cells[4].Value.ToString() == "Maintenance Manager")
                {
                    comboBox1.Text = "Maintenance Manager";
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

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

namespace fin
{
    public partial class DeleteManager : Form
    {
        IManager manager = ObjectHandler.man;
        public DeleteManager()
        {
            InitializeComponent();
        }

        private void DeleteManager_Load(object sender, EventArgs e)
        {
            List<int> ManagerIds = ManagerDL.getManagerIDList();

            // Clear existing items in the ComboBox
            comboBox2.Items.Clear();

            // Add each Manager ID as an item to the ComboBox
            foreach (int id in ManagerIds)
            {
                comboBox2.Items.Add(id);
            }
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

            List<int> Ids = ManagerDL.getIDList();
            List<ManagerBL> managersList = ManagerDL.getManagerList();

            for (int i = 0; i < Math.Min(Ids.Count, managersList.Count); i++)
            {
                int managerId = Ids[i];
                ManagerBL manager = managersList[i];

                // Add manager details to the DataTable row
                dataTable.Rows.Add(managerId, manager.getId(), manager.getName(), manager.getPassword(), manager.getRank(), manager.getEmail(), manager.getContactNumber(), manager.getDepartment(), manager.getSalary());
            }

            // Set the DataSource of the DataGridView to the populated DataTable
            dataGridView1.DataSource = dataTable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a ManagerId.");
                return; // Exit the method if no ManagerId is selected
            }

            // Retrieve the selected ManagerId from the ComboBox
            int selectedManagerId = Convert.ToInt32(comboBox2.SelectedItem);
            try
            {
                manager.DeleteManager(selectedManagerId);
                MessageBox.Show("Congratulations! Worker is Deleted successfully");
                DeleteManager_Load(null, null);
            }
            catch
            {
                MessageBox.Show("Sorry! Worker is not deleted. Try Again after some time");
            }
            // Call the DeleteManager function with the selected ManagerId
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox2.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (UserManagement user = new UserManagement())
            {
                user.ShowDialog();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

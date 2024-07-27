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
    public partial class SearchManager : Form
    {
        IManager managerDL = ObjectHandler.man;
      
        public SearchManager()
        {
            InitializeComponent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void SearchManager_Load(object sender, EventArgs e)
        {
            List<int> ManagerIds = ManagerDL.getIDList();

            // Clear existing items in the ComboBox
            comboBox2.Items.Clear();

            // Add each Manager ID as an item to the ComboBox
            foreach (int id in ManagerIds)
            {
                comboBox2.Items.Add(id);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Check if a ManagerId is selected
            if (comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Please select a ManagerId.");
                return; // Exit the method if no ManagerId is selected
            }

            // Retrieve the selected ManagerId from the ComboBox
             int selectedManagerId = Convert.ToInt32(comboBox2.SelectedItem);

            // Call the SearchManager function with the selected ManagerId
             SearchManagerWinform(selectedManagerId);
        }
        private void SearchManagerWinform(int selectedManagerId)
        {
            // Call the ManagerDL method to retrieve manager details based on ManagerId
            ManagerBL manager = managerDL.SearchManager(selectedManagerId);

            // Create a DataTable to hold manager data
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("ManagerID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Password", typeof(string));
            dataTable.Columns.Add("Rank", typeof(string));
            dataTable.Columns.Add("Email", typeof(string));
            dataTable.Columns.Add("ContactNumber", typeof(string));
            dataTable.Columns.Add("Department", typeof(string));
            dataTable.Columns.Add("Salary", typeof(decimal));

            if (manager != null)
            {
                // Add the retrieved manager details to the DataTable
                dataTable.Rows.Add(selectedManagerId,manager.getId(), manager.getName(), manager.getPassword(), manager.getRank(), manager.getEmail(), manager.getContactNumber(), manager.getDepartment(), manager.getSalary());
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = dataTable;

            if (manager == null)
            {
                MessageBox.Show("Manager not found."); // Display message if manager is not found
            }
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

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void managerBindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void industriaDataSetBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void managerBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void managerBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

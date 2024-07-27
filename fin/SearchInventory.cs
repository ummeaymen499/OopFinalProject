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
    public partial class SearchInventory : Form
    {
        IInventory inventory = ObjectHandler.inventory;
        public SearchInventory()
        {
            InitializeComponent();
        }

        private void SearchInventory_Load(object sender, EventArgs e)
        {

            List<InventoryBL> InventoryId = inventory.getInventoryList();

            // Clear existing items in the ComboBox
            comboBox1.Items.Clear();

            // Add each Manager ID as an item to the ComboBox
            foreach (InventoryBL inventory in InventoryId)
            {
                comboBox1.Items.Add(inventory.getID());
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Check if a ManagerId is selected
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a InventoryId.");
                return; // Exit the method if no ManagerId is selected
            }

            // Retrieve the selected ManagerId from the ComboBox
            int selectedManagerId = Convert.ToInt32(comboBox1.SelectedItem);

            // Call the SearchManager function with the selected ManagerId
            SearchInventoryWinform(selectedManagerId);
        }
        private void SearchInventoryWinform(int selectedManagerId)
        {
            // Call the ManagerDL method to retrieve manager details based on ManagerId
            InventoryBL inventory1 = inventory.SearchInventory(selectedManagerId);

            DataTable datatable = new DataTable();
            datatable.Columns.Add("InventoryID", typeof(int));
            datatable.Columns.Add("Name", typeof(string));
            datatable.Columns.Add("Price", typeof(float));
            datatable.Columns.Add("Usage", typeof(string));

            dataGridView1.DataSource = datatable;

         

            
                datatable.Rows.Add(inventory1.getID(), inventory1.getName(), inventory1.getPrice(), inventory1.getUsage());
            

            // Update DataGridView.DataSource after adding all data
            dataGridView1.DataSource = datatable;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (InventoryManagement user = new InventoryManagement())
            {
                user.ShowDialog();
            }

        }
    }
}

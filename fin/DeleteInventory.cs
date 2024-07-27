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
    public partial class DeleteInventory : Form
    {
        IInventory inventory = ObjectHandler.inventory;
        public DeleteInventory()
        {
            InitializeComponent();
        }

        private void DeleteInventory_Load(object sender, EventArgs e)
        {
            List<InventoryBL> InventoryList = inventory.getInventoryList();

            // Clear existing items in the ComboBox
            comboBox1.Items.Clear();

            // Add each Manager ID as an item to the ComboBox
            foreach (InventoryBL inventory in InventoryList)
            {
                comboBox1.Items.Add(inventory.getID());
            }
            DataTable datatable = new DataTable();
            datatable.Columns.Add("InventoryID", typeof(int));
            datatable.Columns.Add("Name", typeof(string));
            datatable.Columns.Add("Price", typeof(float));
            datatable.Columns.Add("Usage", typeof(string));

            dataGridView1.DataSource = datatable;

            List<InventoryBL> inventoryobj = inventory.getInventoryList();

            foreach (InventoryBL inventory in inventoryobj)
            {
                // Add inventory details to the DataTable row
                datatable.Rows.Add(inventory.getID(), inventory.getName(), inventory.getPrice(), inventory.getUsage());
            }

            // Update DataGridView.DataSource after adding all data
            dataGridView1.DataSource = datatable;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a InventoryId.");
                return; // Exit the method if no ManagerId is selected
            }

            // Retrieve the selected ManagerId from the ComboBox
            int selectedManagerId = Convert.ToInt32(comboBox1.SelectedItem);
            try
            {
                inventory.DeleteInventory(selectedManagerId);
                MessageBox.Show("Congratulations! Worker is Deleted successfully");
                DeleteInventory_Load(null, null);
            }
            catch
            {
                MessageBox.Show("Sorry! Worker is not deleted. Try Again after some time");
            }
            // Call the DeleteManager function with the selected ManagerId

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (InventoryManagement user = new InventoryManagement())
            {
                user.ShowDialog();
            }

           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
        }
    }
}

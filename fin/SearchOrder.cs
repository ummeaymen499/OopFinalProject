using finBL.Utilities;
using System;
using finBL.Interfaces;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using finBL.BL;

namespace fin
{
    public partial class SearchOrder : Form
    {
        IOrder order = ObjectHandler.order;
        public SearchOrder()
        {
            InitializeComponent();
        }

        private void SearchOrder_Load(object sender, EventArgs e)
        {
            List<int> OrderId = order.getOrderIDList();

            // Clear existing items in the ComboBox
            comboBox1.Items.Clear();

            // Add each Manager ID as an item to the ComboBox
            foreach (int id in OrderId)
            {
                comboBox1.Items.Add(id);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Check if a ManagerId is selected
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a OrderId.");
                return; // Exit the method if no ManagerId is selected
            }

            // Retrieve the selected ManagerId from the ComboBox
            int selectedId = Convert.ToInt32(comboBox1.SelectedItem);

            // Call the SearchManager function with the selected ManagerId
            SearchProductWinform(selectedId);
        }
        private void SearchProductWinform(int selectedManagerId)
        {
            // Call the ManagerDL method to retrieve manager details based on ManagerId
            OrderBL Product1 = order.SearchOrder(selectedManagerId);

            // Create a DataTable to hold manager data

            DataTable datatable = new DataTable();
            datatable.Columns.Add("OrderID", typeof(int)); // Assuming Id is auto-incremented in the database
            datatable.Columns.Add("OrderStatus", typeof(string));
           

            if (Product1 != null)
            {
                // Add the retrieved manager details to the DataTable
                datatable.Rows.Add(Product1.getID(), Product1.getOrderStatus());
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = datatable;

            if (Product1 == null)
            {
                MessageBox.Show("Product not found."); // Display message if manager is not found
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (InitiatePurchase ini = new InitiatePurchase())
            {
                ini.ShowDialog();
            }
        }
    }
}

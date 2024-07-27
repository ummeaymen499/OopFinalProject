using finBL.BL;
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
    public partial class SearchProduct : Form
    {
        IProduct Product = ObjectHandler.product;
        public SearchProduct()
        {
            InitializeComponent();
        }

        private void SearchProduct_Load(object sender, EventArgs e)
        {

            List<int> ProductId = Product.getIDList();

            // Clear existing items in the ComboBox
            comboBox1.Items.Clear();

            // Add each Manager ID as an item to the ComboBox
            foreach (int id in ProductId)
            {
                comboBox1.Items.Add(id);

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Check if a ManagerId is selected
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a ProductId.");
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
            ProductBL Product1 = Product.SearchProduct(selectedManagerId);

            // Create a DataTable to hold manager data

            DataTable datatable = new DataTable();
            datatable.Columns.Add("Id", typeof(int)); // Assuming Id is auto-incremented in the database
            datatable.Columns.Add("ProductID", typeof(int));
            datatable.Columns.Add("Name", typeof(string));
            datatable.Columns.Add("Price", typeof(float));
            datatable.Columns.Add("Usage", typeof(string));


            if (Product1 != null)
            {
                // Add the retrieved manager details to the DataTable
                datatable.Rows.Add(selectedManagerId, Product1.getID(), Product1.getName(), Product1.getPrice(), Product1.getQuantity());
            }

            // Bind the DataTable to the DataGridView
            dataGridView1.DataSource = datatable;

            if (Product1 == null)
            {
                MessageBox.Show("Product not found."); // Display message if manager is not found
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (ProductManagement user = new ProductManagement())
            {
                user.ShowDialog();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

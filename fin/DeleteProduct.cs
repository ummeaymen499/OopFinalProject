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
    public partial class DeleteProduct : Form
    {
        IProduct product = ObjectHandler.product;
        public DeleteProduct()
        {
            InitializeComponent();
        }

        private void DeleteProduct_Load(object sender, EventArgs e)
        {
            List<int> ProductId = product.getProductIdList();

            // Clear existing items in the ComboBox
            comboBox1.Items.Clear();

            // Add each Manager ID as an item to the ComboBox
            foreach (int id in ProductId)
            {
                comboBox1.Items.Add(id);
            }
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Id", typeof(int)).AllowDBNull = true; // Assuming Id is auto-incremented in the database
            datatable.Columns.Add("ProductID", typeof(int));
            datatable.Columns.Add("Name", typeof(string));
            datatable.Columns.Add("Price", typeof(float));
            datatable.Columns.Add("Usage", typeof(string));

            dataGridView1.DataSource = datatable;
            List<int> Ids = product.getIDList();

            List<ProductBL> Productlist = product.getProductList();

            for (int i = 0; i < Ids.Count && i < Productlist.Count; i++)
            {
                int productId = Ids[i];
                ProductBL Product = Productlist[i];

                // Add Product details to the DataTable row
                datatable.Rows.Add(productId, Product.getID(), Product.getName(), Product.getPrice(), Product.getQuantity());
            }

            // Update DataGridView.DataSource after adding all data
            dataGridView1.DataSource = datatable;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a ProductId.");
                return; // Exit the method if no ManagerId is selected
            }

            // Retrieve the selected ManagerId from the ComboBox
            int selectedId = Convert.ToInt32(comboBox1.SelectedItem);
            try
            {
                product.DeleteProduct(selectedId);
                MessageBox.Show("Congratulations! Worker is Deleted successfully");
                DeleteProduct_Load(null, null);
            }
            catch
            {
                MessageBox.Show("Sorry! Worker is not deleted. Try Again after some time");
            }
            // Call the DeleteManager function with the selected ManagerId
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
    }
}

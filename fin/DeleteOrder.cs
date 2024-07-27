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
    public partial class DeleteOrder : Form
    {
        IOrder order = ObjectHandler.order;
        public DeleteOrder()
        {
            InitializeComponent();
        }

        private void DeleteOrder_Load(object sender, EventArgs e)
        {
            List<int> OrderId = order.getOrderIDList();

            // Clear existing items in the ComboBox
            comboBox1.Items.Clear();

            // Add each Manager ID as an item to the ComboBox
            foreach (int id in OrderId)
            {
                comboBox1.Items.Add(id);
            }
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Id", typeof(int)); // Assuming Id is auto-incremented in the database
            datatable.Columns.Add("OrderID", typeof(int));
            datatable.Columns.Add("OrderStatus", typeof(string));
           
            dataGridView1.DataSource = datatable;
            List<int> Ids = order.getIDList();

            List<OrderBL> Orderlist = order.GetOrderList();

            for (int i = 0; i < Ids.Count && i < Orderlist.Count; i++)
            {
                int productId = Ids[i];
                OrderBL Product = Orderlist[i];

                // Add Product details to the DataTable row
                datatable.Rows.Add(productId, Product.getID(), Product.getOrderStatus());
            }

            // Update DataGridView.DataSource after adding all data
            dataGridView1.DataSource = datatable;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Please select a OrderId.");
                return; // Exit the method if no ManagerId is selected
            }

            // Retrieve the selected ManagerId from the ComboBox
            int selectedId = Convert.ToInt32(comboBox1.SelectedItem);
            try
            {
                order.DeleteOrder(selectedId);
                MessageBox.Show("Congratulations! Worker is Deleted successfully");
                DeleteOrder_Load(null, null);
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
            using (InitiatePurchase pur = new InitiatePurchase())
            {
                pur.ShowDialog();
            }
        }
    }
}

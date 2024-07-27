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
    public partial class AddProduct : Form
    {
        IProduct product = ObjectHandler.product;
        public AddProduct()
        {
            InitializeComponent();
        }

        private void AddProduct_Load(object sender, EventArgs e)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Id", typeof(int)).AllowDBNull = true; // Assuming Id is auto-incremented in the database
            datatable.Columns.Add("ProductID", typeof(int));
            datatable.Columns.Add("Name", typeof(string));
            datatable.Columns.Add("Price", typeof(float));
            datatable.Columns.Add("Usage", typeof(string));

            dataGridView1.DataSource = datatable;
            List<int> ProductIds = product.getIDList();

            List<ProductBL> productlist = product.getProductList();

            for (int i = 0; i < ProductIds.Count && i < productlist.Count; i++)
            {
                int productId = ProductIds[i];
                ProductBL product = productlist[i];

                // Add inventory details to the DataTable row
                datatable.Rows.Add(productId, product.getID(), product.getName(), product.getPrice(),product.getQuantity());
            }

            // Update DataGridView.DataSource after adding all data
            dataGridView1.DataSource = datatable;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (ProductManagement user = new ProductManagement())
            {
                user.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Please provide values for all required fields.");
            }
            else
            {
                try
                {
                    int id = int.Parse(textBox7.Text);
                    string name = textBox4.Text;
                    decimal price = decimal.Parse(textBox6.Text);
                    string usage = textBox1.Text;


                    ProductBL productobject = new ProductBL(id, name, price, usage);
                    try
                    {
                        product.AddProduct(productobject);
                        MessageBox.Show("Congratulations! Product is added successfully");
                        AddProduct_Load(null, null);
                    }
                    catch
                    {
                        MessageBox.Show("Sorry! Product is not added. Try Again after some time");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox1.Text = null;

            textBox6.Text = null;
            textBox7.Text = null;
        }
    }
}

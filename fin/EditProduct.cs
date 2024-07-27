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
    public partial class EditProduct : Form
    {
        IProduct Product = ObjectHandler.product;
        public EditProduct()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void EditProduct_Load(object sender, EventArgs e)
        {
            DataTable datatable = new DataTable();
            datatable.Columns.Add("Id", typeof(int)).AllowDBNull = true; // Assuming Id is auto-incremented in the database
            datatable.Columns.Add("ProductID", typeof(int));
            datatable.Columns.Add("Name", typeof(string));
            datatable.Columns.Add("Price", typeof(float));
            datatable.Columns.Add("Usage", typeof(string));

            dataGridView1.DataSource = datatable;
            List<int> ProductIds = Product.getIDList();

            List<ProductBL> Productlist = Product.getProductList();

            for (int i = 0; i < ProductIds.Count && i < Productlist.Count; i++)
            {
                int productId = ProductIds[i];
                ProductBL Product = Productlist[i];

                // Add Product details to the DataTable row
                datatable.Rows.Add(productId, Product.getID(), Product.getName(), Product.getPrice(), Product.getQuantity());
            }

            // Update DataGridView.DataSource after adding all data
            dataGridView1.DataSource = datatable;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ProductId = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                ProductId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                try
                {
                    int id = int.Parse(textBox7.Text);
                    string name = textBox4.Text;
                    decimal price = decimal.Parse(textBox6.Text);
                    string usage = textBox1.Text;
                    ProductBL Productobject = new ProductBL(id, name, price, usage);
                    try
                    {
                        Product.UpdateProduct(Productobject, ProductId);
                        MessageBox.Show("Congratulations! Product is updated successfully");
                        EditProduct_Load(null, null);
                    }
                    catch
                    {
                        MessageBox.Show("Sorry! Product is not updated. Try Again after some time");
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

        private void button3_Click(object sender, EventArgs e)
        {
            textBox4.Text = null;
            textBox1.Text = null;

            textBox6.Text = null;
            textBox7.Text = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (ProductManagement user = new ProductManagement())
            {
                user.ShowDialog();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = selectedRow.Cells[2].Value.ToString();
                textBox7.Text = selectedRow.Cells[1].Value.ToString();
                textBox6.Text = selectedRow.Cells[3].Value.ToString();
                textBox1.Text = selectedRow.Cells[4].Value.ToString();

            }

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}

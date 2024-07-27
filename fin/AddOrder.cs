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
using finBL.BL;
using finBL.DL;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;
using System.Xml.Linq;

namespace fin
{
    public partial class AddOrder : Form
    {
        IOrder Order = ObjectHandler.order;
        IProduct prod = ObjectHandler.product;
        ProductBL Product;
        public AddOrder()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Please provide values for all required fields.");
            }
            else
            {
                try
                {
                    int orderid = int.Parse(textBox2.Text);
                    string orderstatus = textBox3.Text;
                    OrderBL order = new OrderBL(orderid, orderstatus);
                    order.AddProductInProductListInOrderClass(Product);
                    

                      try
                        {
                            Order.AddOrder(order);
                        OrderProductDL.AddOrderProduct(orderid, int.Parse(comboBox1.Text));
                            MessageBox.Show("Congratulations! Order is Placed successfully");

                        }
                        catch
                        {
                            MessageBox.Show("Sorry! You cannot place order with the same Order ID");
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
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        

            textBox6.Text = null;
            comboBox1.Text = null;
            textBox1.Text= null;
        }

        private void AddOrder_Load(object sender, EventArgs e)
        {
            List<int> ProductIds = prod.getProductIdList();
            comboBox1.Items.Clear();
            foreach (int id in ProductIds)
            {
                comboBox1.Items.Add(id);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (InitiatePurchase order = new InitiatePurchase())
            {
                order.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(comboBox1.Text);
            Product=Validations.IsProduct(id);
            if (Product != null)
            {
                MessageBox.Show("Product found with the given ID");
                textBox4.Text = Product.getName();
                decimal priceOfProduct = Product.getPrice();
                textBox6.Text = priceOfProduct.ToString();
                textBox1.Text = Product.getQuantity();
            }
            else 
            {
                MessageBox.Show("Product Id not Found");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

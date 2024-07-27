using finBL.BL;
using finBL.Utilities;
using finBL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using finBL.DL;

namespace fin
{
    public partial class EditOrder : Form
    {
        IOrder Order = ObjectHandler.order;
       
        public EditOrder()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox5.Text = selectedRow.Cells[0].Value.ToString();
                textBox3.Text = selectedRow.Cells[1].Value.ToString();
                textBox4.Text = selectedRow.Cells[3].Value.ToString();
       
                textBox1.Text = selectedRow.Cells[4].Value.ToString();
                textBox2.Text = selectedRow.Cells[5].Value.ToString();


            }
        }

        private void EditOrder_Load(object sender, EventArgs e)
        {
          
            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("OrderID", typeof(int));
            dataTable.Columns.Add("OrderStatus", typeof(string));
            dataTable.Columns.Add("ProductID", typeof(int));
            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Price", typeof(int));
            dataTable.Columns.Add("Quantity", typeof(string));
            textBox4.ReadOnly = true; // Name text box
            textBox1.ReadOnly = true; // Price text box
            textBox2.ReadOnly = true; // Quantity text box
            textBox5.ReadOnly = true;
            List<OrderBL> orderList = Order.GetOrderList();

            foreach (OrderBL orderBL in orderList)
            {
                
                List<ProductBL> productList = Order.GetProductsForOrder(orderBL.getID());

               
                foreach (ProductBL productBL in productList)
                {
                    dataTable.Rows.Add(orderBL.getID(), orderBL.getOrderStatus(), productBL.getID(), productBL.getName(),productBL.getPrice(),productBL.getQuantity());
                }
            }

            dataGridView1.DataSource = dataTable;



        }

        private void button4_Click(object sender, EventArgs e)
        {
          
            int OrderId = 0;
            //if (dataGridView1.SelectedRows.Count > 0)
            {
                OrderId = Convert.ToInt32(textBox5.Text);

                try
                {
                    int orderId = int.Parse(textBox5.Text);
                    string status = textBox3.Text;
                    string name = textBox4.Text;
                    decimal price = decimal.Parse(textBox1.Text);
                    string Quantity=textBox2.Text;
                    OrderBL Orderobject = new OrderBL(orderId, status);
                    try
                    {
                       
                      
                            Order.UpdateOrder(Orderobject);
                            MessageBox.Show("Congratulations! Order is updated successfully");
                            EditOrder_Load(null, null);
                        
                       
                    }
                   catch
                    {
                        MessageBox.Show("Sorry! Order is not updated. Try Again after some time");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //else
            {
                //MessageBox.Show("Please! Fill all required fields with Data In the Data Grid");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (InitiatePurchase inio = new InitiatePurchase())
            { 
              inio.ShowDialog();
            }
        }
    }
}

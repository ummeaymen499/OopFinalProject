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
    public partial class AddInventory : Form
    {
        IInventory inventory = ObjectHandler.inventory;
        public AddInventory()
        {
            InitializeComponent();
        }

        private void AddInventory_Load(object sender, EventArgs e)
        {
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            using (InventoryManagement user = new InventoryManagement())
            {
                user.ShowDialog();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox6.Text) ||  string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox4.Text))
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
                    
               
                    InventoryBL inventoryobject = new InventoryBL(id, name,price,usage);
                    try
                    {
                        inventory.AddInventory(inventoryobject);
                        MessageBox.Show("Congratulations! Inventory is added successfully");
                         AddInventory_Load(null, null);
                    }
                   catch
                    {
                        MessageBox.Show("Sorry! Inventory is not added. Try Again after some time");
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

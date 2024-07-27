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
    public partial class EditInventory : Form
    {
        IInventory inventory = ObjectHandler.inventory;
        public EditInventory()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void EditInventory_Load(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            int InventoryId = 0;
            if (dataGridView1.SelectedRows.Count > 0)
            {
                InventoryId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

                try
                {
                    int id = int.Parse(textBox7.Text);
                    string name = textBox4.Text;
                    decimal price = decimal.Parse(textBox6.Text);
                    string usage = textBox1.Text;
                    InventoryBL Inventoryobject = new InventoryBL(id, name,price,usage);
                    try
                    {
                        inventory.UpdateInventory(Inventoryobject, InventoryId);
                        MessageBox.Show("Congratulations! Inventory is updated successfully");
                        EditInventory_Load(null, null);
                    }
                    catch
                    {
                        MessageBox.Show("Sorry! Inventory is not updated. Try Again after some time");
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = selectedRow.Cells[1].Value.ToString();
                textBox7.Text = selectedRow.Cells[0].Value.ToString();
                textBox6.Text = selectedRow.Cells[2].Value.ToString();
                textBox1.Text = selectedRow.Cells[3].Value.ToString();
               
            }
              
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
            textBox4.Text = null;
            textBox1.Text = null;

            textBox6.Text = null;
            textBox7.Text = null;

        }
    }
}

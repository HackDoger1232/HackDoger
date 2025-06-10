using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ucheni_muzic
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable up = DbConnection.select(@"UPDATE Equipment SET Name = " + "'" + textBox1.Text + "'" + "," + "Type = " + "'" + textBox2.Text + "'" + "," + "Model = " + "'" + textBox3.Text + "'" + "," + "SerialNumber = " + textBox4.Text + "'" + "," + "PurchaseDate = " + "'" + textBox5.Text + "'" + "," + "WarrantyExpirationDate = " + "'" + textBox7.Text + "'" + "," + "WarrantyExpirationDate = " + "'" + textBox8.Text + " WHERE EquipmentID = " + textBox6.Text);
            up = DbConnection.select("SELECT * FROM Equipment");
            dataGridView1.DataSource = up;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
            Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox6.Text = selectedRow.Cells[0].Value.ToString();
            textBox1.Text = selectedRow.Cells[1].Value.ToString();
            textBox2.Text = selectedRow.Cells[2].Value.ToString();
            textBox3.Text = selectedRow.Cells[3].Value.ToString();
            textBox4.Text = selectedRow.Cells[4].Value.ToString();
            textBox5.Text = selectedRow.Cells[5].Value.ToString();
            textBox7.Text = selectedRow.Cells[6].Value.ToString();
            textBox8.Text = selectedRow.Cells[7].Value.ToString();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT * FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

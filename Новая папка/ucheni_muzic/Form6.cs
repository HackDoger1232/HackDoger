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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT EquipmentID FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT Name FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT Type FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT Model FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Заполните поле поиска");
            }
            else
            {
                DataTable data = DbConnection.select(@"SELECT * FROM Equipment WHERE " + comboBox2.Text + " LIKE'" + "%" + textBox3.Text + "%" + "';");
                dataGridView1.DataSource = data;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox6.Text == "") || (textBox2.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox7.Text == "") || (textBox8.Text == "") || (textBox9.Text == ""))
            {
                MessageBox.Show("Заполните ВСЕ поля"); 
           
            }
            else
            {

                DataTable data = DbConnection.select(@"INSERT INTO Equipment (`EquipmentID`, `Name`,`Type`, `Model` ,`SerialNumber` ,`PurchaseDate` ,`WarrantyExpirationDate` ,`OwnerID` ) VALUES ('" + textBox1.Text + "', '" + textBox6.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "' , '" + textBox5.Text + "' , '" + textBox7.Text + "' , '" + textBox8.Text + "' , '" + textBox9.Text + "');");
                data = DbConnection.select(@"SELECT * FROM Equipment");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox4.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                dataGridView1.DataSource = data;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@" DELETE FROM Equipment WHERE EquipmentID=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            data = DbConnection.select(@"SELECT * FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            Hide();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT * FROM `Equipment`");
            dataGridView1.DataSource = data;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT SerialNumber FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT PurchaseDate FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT WarrantyExpirationDate FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT OwnerID FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT * FROM Equipment");
            dataGridView1.DataSource = data;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

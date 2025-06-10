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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox6.Text == "") || (textBox4.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("Заполните ВСЕ поля");
            }
            else
            {

                DataTable data = DbConnection.select(@"INSERT INTO prodavci (surName, Name, Otchesto, login, password) VALUES ('" + textBox1.Text + "', '" + textBox6.Text + "', '" + textBox2.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "')");
                data = DbConnection.select(@"SELECT * FROM prodavci");


                dataGridView1.DataSource = data;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@" DELETE FROM prodavci WHERE idprodavci=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            data = DbConnection.select(@"SELECT * FROM prodavci");
            dataGridView1.DataSource = data;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form12 f12 = new Form12();
            f12.Show();
            Hide();
            DataTable data = DbConnection.select("SELECT * FROM `prodavci`");
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT * FROM prodavci");
            dataGridView1.DataSource= data;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Заполните поле поиска");
            }
            else
            {
                DataTable data = DbConnection.select(@"SELECT * FROM prodavci WHERE " + comboBox2.Text + " LIKE'" + "%" + textBox3.Text + "%" + "';");
                dataGridView1.DataSource = data;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT Otchesto FROM prodavci");
            dataGridView1.DataSource = data;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT surName FROM prodavci");
            dataGridView1.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT Name FROM prodavci");
            dataGridView1.DataSource = data;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT login FROM prodavci");
            dataGridView1.DataSource = data;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT password FROM prodavci");
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

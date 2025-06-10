using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ucheni_muzic
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable id = DbConnection.select("SELECT EquipmentID FROM Equipment WHERE Name = " + "'" + textBox5.Text + "';");
            textBox4.Text = id.Rows[0]["idinstruments"].ToString();

            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("Заполните ВСЕ поля");
            }
            else
            {

                DataTable data = DbConnection.select(@"INSERT INTO musical_instruments (`Name`, `idinstruments`,`price` ) VALUES ('" + textBox1.Text + "', '" + textBox4.Text + "', '" + textBox2.Text + "');");
                data = DbConnection.select(@"SELECT * FROM musical_instruments");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                dataGridView1.DataSource = data;
            }
        }

        private void Form3_Load_1(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT * FROM `EquipmentID`");
            dataGridView1.DataSource = data;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@" DELETE FROM musical_instruments WHERE idmusical_instruments=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            data = DbConnection.select(@"SELECT * FROM musical_instruments");
            dataGridView1.DataSource = data;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            f4.Show();
            Hide();
            DataTable data = DbConnection.select("SELECT * FROM `musical_instruments`");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT Name FROM musical_instruments");
            dataGridView1.DataSource = data;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT idinstruments FROM musical_instruments");
            dataGridView1.DataSource = data;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT price FROM musical_instruments");
            dataGridView1.DataSource = data;
        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            if (comboBox2.Text == "")
            {
                MessageBox.Show("Заполните поле поиска");
            }
            else
            {
                DataTable data = DbConnection.select(@"SELECT * FROM musical_instruments WHERE " + comboBox2.Text + " LIKE'" + "%" + textBox3.Text + "%" + "';");
                dataGridView1.DataSource = data;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT * FROM musical_instruments");
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

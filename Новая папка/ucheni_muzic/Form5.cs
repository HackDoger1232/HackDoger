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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT * FROM instruments");
            dataGridView1.DataSource = data;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable up = DbConnection.select(@"UPDATE instruments SET idinstruments = " + "'" + textBox1.Text + "'" + "," + " Name = " + "'" + textBox2.Text + "'" + " WHERE idinstruments = " + textBox1.Text);
            up = DbConnection.select("SELECT * FROM instruments");
            dataGridView1.DataSource = up;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("Заполните ВСЕ поля");
            }
            else
            {

                DataTable data = DbConnection.select(@"INSERT INTO instruments (`idinstruments`,`Name` ) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "');");
                data = DbConnection.select(@"SELECT * FROM instruments");

                textBox1.Clear();
                textBox2.Clear();
                dataGridView1.DataSource = data;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@" DELETE FROM instruments WHERE idinstruments=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            data = DbConnection.select(@"SELECT * FROM instruments");
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
        }
    }
}

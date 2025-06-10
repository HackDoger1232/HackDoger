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
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.Text == "") || (comboBox2.Text == "") || (comboBox3.Text == "") || (dateTimePicker1.Text == ""))
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                DataTable data = DbConnection.select(@"INSERT INTO history (`idmusical_instruments`, `idprodavci`, `idClients`, `date`) VALUES('" + comboBox1.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "');");
                data = DbConnection.select("SELECT * FROM history");
                dataGridView1.DataSource = data;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataTable up = DbConnection.select(@"UPDATE history SET idmusical_instruments = " + "'" + comboBox1.Text + "'" + "," + " idprodavci = " + "'" + comboBox2.Text + "'" + "," + " idClients = " + "'" + comboBox3.Text + "'" + "," + " date = " + "'" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'" + " WHERE idhistory = " + textBox1.Text);
            up = DbConnection.select("SELECT * FROM history");
            dataGridView1.DataSource = up;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            dateTimePicker1.Text = selectedRow.Cells[4].Value.ToString();
            comboBox1.Text = selectedRow.Cells[1].Value.ToString();
            comboBox2.Text = selectedRow.Cells[2].Value.ToString();
            comboBox3.Text = selectedRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"DELETE FROM history WHERE idhistory = " + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            data = DbConnection.select("SELECT * FROM history");
            dataGridView1.DataSource = data;
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT * FROM history");
            dataGridView1.DataSource = data;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DbConnection.select("SELECT * FROM musical_instruments WHERE idmusical_instruments = " + comboBox1.Text);
            dataGridView2.DataSource = dt;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DbConnection.select("SELECT * FROM prodavci WHERE idprodavci = " + comboBox2.Text);
            dataGridView3.DataSource = dt;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = DbConnection.select("SELECT * FROM Clients WHERE idClients = " + comboBox3.Text);
            dataGridView4.DataSource = dt;
        }
    }
}

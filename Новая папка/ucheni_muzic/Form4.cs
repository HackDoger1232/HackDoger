using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ucheni_muzic;

namespace ucheni_muzic
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DataTable id = DbConnection.select("SELECT idinstruments FROM instruments WHERE Name = " + "'" + comboBox1.Text + "';");
            textBox3.Text = id.Rows[0]["idinstruments"].ToString();

            DataTable up = DbConnection.select(@"UPDATE musical_instruments SET Name = " + "'" + textBox2.Text + "'" + "," + "idinstruments = " + textBox3.Text + "," + "price = " + textBox4.Text + " WHERE idmusical_instruments = " + textBox1.Text);
            up = DbConnection.select("SELECT * FROM musical_instruments");
            dataGridView1.DataSource = up;

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            Hide();
        }

        private void Form4_Load_1(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT * FROM `musical_instruments`");
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[index];
            textBox1.Text = selectedRow.Cells[0].Value.ToString();
            textBox2.Text = selectedRow.Cells[1].Value.ToString();
            textBox3.Text = selectedRow.Cells[2].Value.ToString();
            textBox4.Text = selectedRow.Cells[3].Value.ToString();



            DataTable name = DbConnection.select("SELECT Name FROM instruments WHERE idinstruments = " + textBox3.Text);
            comboBox1.Text = name.Rows[0]["Name"].ToString();

        }
    }
}

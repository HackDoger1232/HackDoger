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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable up = DbConnection.select("UPDATE prodavci SET surName = '" + textBox1.Text + "', Name = '" + textBox2.Text + "', Otchesto = '" + textBox3.Text + "', login = '" + textBox4.Text + "', password = '" + textBox5.Text + "' WHERE idprodavci = '" + textBox6.Text + "'");
            up = DbConnection.select("SELECT * FROM prodavci");
            dataGridView1.DataSource = up;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            Hide();
            DataTable data = DbConnection.select("SELECT * FROM `prodavci`");
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("SELECT * FROM `Owners`");
            dataGridView1.DataSource = data;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == "") || (textBox6.Text == "") || (textBox7.Text == ""))
            {
                MessageBox.Show("Заполните ВСЕ поля");
            }
            else
            {

                DataTable data = DbConnection.select(@"INSERT INTO Owners (`OwnerID`, `FirstName`,`LastName`, `Email` ,`Phone` ,`Login` ,`Password`) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "' , '" + textBox5.Text + "' , '" + textBox6.Text + "', '" + textBox7.Text + "');");
                data = DbConnection.select(@"SELECT * FROM Owners");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox5.Clear();
                textBox4.Clear();
                textBox6.Clear();
                textBox7.Clear();
                dataGridView1.DataSource = data;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form11 f11 = new Form11();
            f11.Show();
            DataTable data = DbConnection.select("SELECT * FROM Owners");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@" DELETE FROM Owners WHERE OwnerID=" + dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            data = DbConnection.select(@"SELECT * FROM Owners");
            dataGridView1.DataSource = data;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT OwnerID FROM Owners");
            dataGridView1.DataSource = data;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT FirstName FROM Owners");
            dataGridView1.DataSource = data;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT LastName FROM Owners");
            dataGridView1.DataSource = data;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT Email FROM Owners");
            dataGridView1.DataSource = data;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT Phone FROM Owners");
            dataGridView1.DataSource = data;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT Login FROM Owners");
            dataGridView1.DataSource = data;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT Password FROM Owners");
            dataGridView1.DataSource = data;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select(@"SELECT * FROM Owners");
            dataGridView1.DataSource = data;
        }
    }
}
         


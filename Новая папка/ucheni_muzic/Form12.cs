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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            Hide();
            DataTable data = DbConnection.select("SELECT * FROM `prodavci`");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable up = DbConnection.select("UPDATE Owners SET Name = '" + textBox1.Text + "', Type = '" + textBox2.Text + "', Model = '" + textBox3.Text + "', SerialNumber = '" + textBox4.Text + "', PurchaseDate = '" + textBox5.Text + "', WarrantyExpirationDate = '" + textBox6.Text + "', Type = '" + textBox7.Text + "'  WHERE EquipmentID = ''");
            up = DbConnection.select("SELECT * FROM Owners");
            dataGridView1.DataSource = up;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ucheni_muzic
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable data = DbConnection.select("select * from `Owners` where Login = '" + textBox1.Text + "' and Password = '" + textBox2.Text + "'");
            if (data.Rows.Count == 1)
            {
                Form2 f2 = new Form2();
                f2.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Неправильный логин или пароль");
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }

    class DbConnection
    {
        public static DataTable select(string sql)
        {
            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
            builder.Server = "cfif31.ru";
            builder.Port = 3306;
            builder.Database = "ISPr24-41_FrolovRV_technique";
            builder.UserID = "ISPr24-41_FrolovRV";
            builder.Password = "ISPr24-41_FrolovRV";
            MySqlConnection connect = new MySqlConnection(builder.ConnectionString);
            try
            {
                connect.Open();
                MySqlCommand command = new MySqlCommand(sql, connect);
                MySqlDataReader reader = command.ExecuteReader();
                DataTable table = new DataTable();
                table.Load(reader);
                return table;

            }
            catch (Exception e)
            {
                MessageBox.Show("При выполнении запроса произошла ошибка! " + e.Message);
                return null;
            }
        }
    }
}

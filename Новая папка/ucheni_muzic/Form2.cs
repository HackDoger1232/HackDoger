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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void музыкальныеИнструментыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3();
            f3.Show();
            DataTable data = DbConnection.select("SELECT * FROM Equipment");
        }

        private void типМузыкальныхИнтсрументToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5();
            f5.Show();
            DataTable data = DbConnection.select("SELECT * FROM instruments");
        }

        private void ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Show();
            DataTable data = DbConnection.select("SELECT * FROM Equipment");
        }

        private void продавцыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form8 f8 = new Form8();
            f8.Show();
            DataTable data = DbConnection.select("SELECT * FROM prodavci");
        }

        private void историяПродажToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form10 f10 = new Form10();
            f10.Show();
            DataTable data = DbConnection.select("SELECT * FROM history");
        }

        private void оборудованиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form9 f9 = new Form9();
            f9.Show();
            DataTable data = DbConnection.select("SELECT * FROM Owners");
        }
    }
}

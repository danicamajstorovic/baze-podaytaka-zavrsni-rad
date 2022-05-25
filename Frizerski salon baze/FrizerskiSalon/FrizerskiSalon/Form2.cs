using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrizerskiSalon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.konektovanje();
            SqlCommand komanda = new SqlCommand("SELECT datum, Frizer.ime, FrizerskiSalon.adresa FROM Rezervacija JOIN Frizer ON Frizer.id = frizer_id JOIN FrizerskiSalon ON FrizerskiSalon.id = frizerskisalon_id  WHERE  korisnik_id ="+Program.id, veza);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataTable tabelica = new DataTable();
            adapter.Fill(tabelica);

            dataGridView1.DataSource = tabelica;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 forma = new Form3();
            forma.Show();
        }
    }
}

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
    public partial class Form3 : Form
    {
        int id_salon, id_frizer;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            MessageBox.Show(comboBox1.Text);
            if (comboBox1.Text=="" || comboBox2.Text == "")
            {
                MessageBox.Show("Niste uneli sve podatke");
            }
            else
            {
                SqlConnection veza = Konekcija.konektovanje();
                SqlCommand komanda = new SqlCommand("SELECT id From FrizerskiSalon WHERE adresa='"+comboBox1.Text+"'", veza);
                SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                DataTable tabelica = new DataTable();
                adapter.Fill(tabelica);
                id_salon = Convert.ToInt32(tabelica.Rows[0]["id"]);

                komanda = new SqlCommand("SELECT * FROM Frizer",veza);
                adapter = new SqlDataAdapter(komanda);
                tabelica = new DataTable();
                adapter.Fill(tabelica);
                for (int i = 0; i < tabelica.Rows.Count; i++)
                {
                    if (comboBox2.Text == (tabelica.Rows[i]["ime"].ToString() + " " + tabelica.Rows[i]["prezime"].ToString()))
                    {
                        id_frizer = Convert.ToInt32(tabelica.Rows[i]["id"]);
                        break;
                    }
                }

                komanda = new SqlCommand("SELECT * FROM Rezervacija WHERE frizerskisalon_id = "+id_salon+ " AND frizer_id = "+id_frizer+" AND datum = '"+dateTimePicker1.Value.ToString ("yyyy-MM-dd")+"'", veza);
                
                SqlDataAdapter adapt = new SqlDataAdapter(komanda);
                DataTable tabel = new DataTable();
                adapt.Fill(tabel);
                
                if (tabel.Rows.Count > 0)
                {
                    MessageBox.Show("Zauzeto");
                }
                else 
                {
                    komanda = new SqlCommand("EXEC Dodaj_Rezervacija " + Program.id + ", " + id_salon + ", " + id_frizer + ", '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '00:00'", veza);
                    veza.Open();
                    komanda.ExecuteNonQuery();
                    veza.Close();
                    MessageBox.Show("Usesno zakazano");
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection veza = Konekcija.konektovanje();
            SqlCommand komanda = new SqlCommand("SELECT adresa From FrizerskiSalon", veza);
            SqlDataAdapter adapter = new SqlDataAdapter(komanda);
            DataTable tabelica = new DataTable();
            adapter.Fill(tabelica);
            for (int i = 0; i < tabelica.Rows.Count; i++)
            {
                comboBox1.Items.Add(tabelica.Rows[i]["adresa"].ToString());

            }
            komanda = new SqlCommand("SELECT ime,prezime FROM Frizer", veza);
            adapter = new SqlDataAdapter(komanda);
            tabelica = new DataTable();
            adapter.Fill(tabelica);
            for (int i = 0; i < tabelica.Rows.Count; i++)
            {
                comboBox2.Items.Add(tabelica.Rows[i]["ime"].ToString()+" "+ tabelica.Rows[i]["prezime"].ToString());

            }
           
        }
    }
}

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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (username.Text == "" || password.Text == "")
            {
                MessageBox.Show("Унесите јузернејм и лозинку");
            }
            else 
            {
                SqlConnection veza = Konekcija.konektovanje();
                SqlCommand komanda = new SqlCommand("SELECT * FROM Korisnik WHERE email='"+ username.Text +"'",veza);
                SqlDataAdapter adapter = new SqlDataAdapter(komanda);
                DataTable tabelica = new DataTable();
                adapter.Fill(tabelica);

                int broj_redova = tabelica.Rows.Count;
                if (broj_redova > 0)
                {
                    if (tabelica.Rows[0]["password"].ToString() == password.Text)
                    {
                        MessageBox.Show("Најс успео си брат мој");
                        Program.id = Convert.ToInt32(tabelica.Rows[0]["id"]);
                        this.Hide();
                        Form2 forma = new Form2();
                        forma.Show();
                    }
                    else
                    {
                        MessageBox.Show("Унео си погрешну лозинку браћале");
                    }
                }
                else 
                {
                    MessageBox.Show("Унеси тачан мејл браћале");
                }
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace FinaleProjekta
{
    public partial class Prijava : UserControl
    {
        // Svojstva
        private Konobar konobar;
        public Prijava()
        {
            InitializeComponent();

        }

        internal Konobar Konobar { get => konobar; set => konobar = value; }
        public event EventHandler<Konobar> prijava;
        public event EventHandler<Konobar> prijava_vlasnik;

        private void btnPrijava_Click(object sender, EventArgs e)
        {
            Konobar trenutni = new Konobar();

            Baza veza = new Baza();
            MySqlCommand naredba;
            MySqlDataReader citac;

            string korisnickoime = txtIme.Text;
            int lozinka;
            try
            {
                lozinka = int.Parse(txtLozinka.Text);
                veza.Connect();
                veza.baza.Open();
                naredba = new MySqlCommand("SELECT sifra_konobar, ime, prezime " +
                    "FROM Konobar WHERE korisnicko_ime=@IME AND lozinka=@LOZ", veza.baza);
                naredba.Parameters.Add("@IME", MySqlDbType.VarChar).Value = korisnickoime;
                naredba.Parameters.Add("@LOZ", MySqlDbType.Int32).Value = lozinka;

                citac = naredba.ExecuteReader();
                if (citac.HasRows)
                {
                    while (citac.Read())
                    {
                        int sifra = int.Parse(citac[0].ToString());
                        string ime = citac[1].ToString();
                        string prezime = citac[2].ToString();
                        trenutni = new Konobar(sifra, ime, prezime, korisnickoime, lozinka);
                    }
                    //MessageBox.Show(trenutni.Ime + trenutni.Prezime);
                    prijava(this, trenutni);
                }
                else
                {
                    MessageBox.Show("Pogrešna prijava!");
                    txtIme.Text = "";
                    txtLozinka.Text = "";
                }
                citac.Close();
                veza.baza.Close();
            }
            catch(Exception greska)
            {
                MessageBox.Show(greska.Message);
                txtIme.Text = "";
                txtLozinka.Text = "";
            }
            txtIme.Text = "";
            txtLozinka.Text = "";
        }

        private void Prijava_Load(object sender, EventArgs e)
        {

        }

        private void btnPrijavaKaoVlasnik_Click(object sender, EventArgs e)
        {
             Konobar trenutni = new Konobar();

            Baza veza = new Baza();
            MySqlCommand naredba;
            MySqlDataReader citac;

            string korisnickoime = txtIme.Text;
            int lozinka;
            try
            {
                lozinka = int.Parse(txtLozinka.Text);
                veza.Connect();
                veza.baza.Open();
                naredba = new MySqlCommand("SELECT sifra_konobar, ime, prezime,vlasnik " +
                    "FROM Konobar WHERE korisnicko_ime=@IME AND lozinka=@LOZ AND vlasnik=@VLASNIK ", veza.baza);
                naredba.Parameters.Add("@IME", MySqlDbType.VarChar).Value = korisnickoime;
                naredba.Parameters.Add("@LOZ", MySqlDbType.Int32).Value = lozinka;
                naredba.Parameters.Add("@VLASNIK", MySqlDbType.Int32).Value = 1;

                citac = naredba.ExecuteReader();
                if (citac.HasRows)
                {
                    while (citac.Read())
                    {
                        int sifra = int.Parse(citac[0].ToString());
                        string ime = citac[1].ToString();
                        string prezime = citac[2].ToString();
                        trenutni = new Konobar(sifra, ime, prezime, korisnickoime, lozinka);
                    }
                   
                    prijava_vlasnik(this, trenutni);
                }
                else
                {
                    MessageBox.Show("Pogrešna prijava!");
                    txtIme.Text = "";
                    txtLozinka.Text = "";
                }
                citac.Close();
                veza.baza.Close();
            }
            catch(Exception greska)
            {
                MessageBox.Show(greska.Message);
                txtIme.Text = "";
                txtLozinka.Text = "";
            }
            txtIme.Text = "";
            txtLozinka.Text = "";
        }

      
    }
}

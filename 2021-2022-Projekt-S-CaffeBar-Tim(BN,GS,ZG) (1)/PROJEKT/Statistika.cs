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
    public partial class Statistika : Form
    {
        private Baza veza;
        private Dictionary<string, int> popisZaStatistiku;
        public Statistika()
        {
            InitializeComponent();
        }
        public Statistika(Baza b)
        {
            InitializeComponent();
            veza = b;
        }

        private void Statistika_Load(object sender, EventArgs e)
        {
            popisZaStatistiku = new Dictionary<string, int>();
            try
            {
                veza.Connect();
                veza.baza.Open();
                MySqlCommand command;
                command = new MySqlCommand("SELECT naziv_pica, sifra_pica FROM Pice", veza.baza);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string naziv = reader[0].ToString();
                    listBox1.Items.Add(naziv);
                    popisZaStatistiku.Add(naziv, int.Parse(reader[1].ToString()));
                }
                veza.baza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime pocetak = dateTimePicker1.Value;
            DateTime kraj = dateTimePicker2.Value;
            if(pocetak == null || kraj == null || pocetak > kraj)
            {
                MessageBox.Show("Niste dobro izabrali datume! Pokušajte ponovo.");
            }
            else
            {
                string naziv = (string)listBox1.SelectedItem;
                foreach(KeyValuePair<string, int> par in popisZaStatistiku)
                {
                    if(par.Key == naziv)
                    {
                        // U bazi u tablici računa pogledaj sve račune
                        int broj = pozivRacunaIzBaze(par.Value, pocetak, kraj);
                        if (broj == -1)
                            MessageBox.Show("Greška u komunikaciji s bazom!");
                        else
                        {
                            MessageBox.Show("Ovaj artikal se u određenom vremenu naručio " + broj.ToString() + " puta.");
                        }
                    }
                }
            }
        }

        private int pozivRacunaIzBaze(int sifra, DateTime pocetak, DateTime kraj)
        {
            int broj_pojavljivanja = 0;
            try
            {
                veza.Connect();
                veza.baza.Open();
                MySqlCommand command;
                command = new MySqlCommand("SELECT datum, zapis FROM Racun", veza.baza);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DateTime temp = DateTime.Parse(reader[0].ToString()) ;
                    if(temp >= pocetak && temp <= kraj)
                    {
                        string zapis = reader[1].ToString();
                        string[] niz = zapis.Split(',');
                        foreach (string el in niz)
                        {
                            if (int.Parse(el.ToString()) == sifra)
                                broj_pojavljivanja++;
                        }
                    }
                }
                veza.baza.Close();
            }
            catch
            {
                broj_pojavljivanja = -1;
            }

            return broj_pojavljivanja;
        }

        private void btnIzadji_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

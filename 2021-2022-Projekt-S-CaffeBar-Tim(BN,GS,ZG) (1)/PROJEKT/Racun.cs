using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace FinaleProjekta
{
    public class Racun
    {
        private int broj_racuna;
        static int broj_r;
        private int broj_stola;
        private Konobar konobar;
        private double ukupan_iznos;
        public DateTime datum;
        public string putanja; // Za spremanje računa u bazu, odnosno spremanje putanje do nj

        // rječnik za popis pića na računu
        // Ključ je određeno piće, a vrijednost broj_pojavljivanja * cijena tog pića
        public Dictionary<Pice, double> popis_na_racunu;

        public int Broj_stola { get => broj_stola; set => broj_stola = value; }
        public Konobar Konobar { get => konobar; set => konobar = value; }
        public double Ukupan_iznos { get => ukupan_iznos; set => ukupan_iznos = value; }
        public int Broj_racuna { get => broj_racuna; set => broj_racuna = value; }

        public Racun(int broj_stola, Konobar konobar)
        {
            Broj_stola = broj_stola;
            Konobar = konobar;
            broj_racuna = broj_r;
            broj_r++;
            // svakom računu stvori novi rječnik
            this.popis_na_racunu = new Dictionary<Pice, double>();
            this.datum = DateTime.Now;
        }

        // Pri zaključivanju računa, želimo u bazu spremiti dovoljno naznaka za lakši pronalazak istog kasnije
        // Koristimo se jednom instancom klase Baza za spajanje s bazom podataka
        public void SpremiUBazu(Baza veza, string putanja, string zapis)
        { 

            try
            {
                veza.Connect();
                veza.baza.Open();
                MySqlCommand command;
                command = new MySqlCommand("INSERT INTO Racun(broj_racuna,konobar_sifra,putanja,datum,zapis) VALUES(@broj, @sifra, @putanja,@datum, @zapis)", veza.baza);
                command.Parameters.AddWithValue("@broj", this.broj_racuna);
                command.Parameters.AddWithValue("@sifra", this.konobar.Sifra_konobar);
                command.Parameters.AddWithValue("@putanja", putanja);
                command.Parameters.AddWithValue("@datum", this.datum);
                command.Parameters.AddWithValue("@zapis", zapis);
                command.ExecuteNonQuery();
                veza.baza.Close();
            }

            catch
            {
                //
            }
        }

    }
}

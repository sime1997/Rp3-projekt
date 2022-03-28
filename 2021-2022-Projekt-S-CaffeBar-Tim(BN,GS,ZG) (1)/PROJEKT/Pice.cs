using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleProjekta
{
    public class Pice
    {
        private int sifra_pica;

        // Vrsta za lakše grupiranje pića: Topli napitak, Sokovi, Pivo, Vino i Žestoko piće
        private string vrsta;

        // sifra_stanje i sifra_stanje_dodatno su instance klase Stanje
        // Pomažu nam pravilno dekrementirati stanja u bazi pri zaključivanju računa

        // Zašto dodatno: Kava s mlijekom troši iz stanja i kavu i mlijeko

        private Stanje sifra_stanje; // Koje piće troši iz svih vrsta pića
        private Stanje sifra_stanje_dodatno; 

        private int sifra_stanje1;//dodala samo sa šifrom jer mi je lakše zbog konstruktora
        private int sifra_stanje_dodatno1;

        private int broj_pica_na_racunu; // samo za račun
        private string naziv_pica;
        private double cijena;
        private double happy_hour_cijena;

        public int Sifra_pica { get => sifra_pica; set => sifra_pica = value; }
        public Stanje Sifra_stanje { get => sifra_stanje; set => sifra_stanje = value; }
        public Stanje Sifra_stanje_dodatno { get => sifra_stanje_dodatno; set => sifra_stanje_dodatno = value; }
        public string Naziv_pica { get => naziv_pica; set => naziv_pica = value; }
        public double Cijena { get => cijena; set => cijena = value; }
        public double Happy_hour_cijena { get => happy_hour_cijena; set => happy_hour_cijena = value; }
        public string Vrsta { get => vrsta; set => vrsta = value; }
        public int Sifra_stanje_dodatno1 { get => sifra_stanje_dodatno1; set => sifra_stanje_dodatno1 = value; }
        public int Sifra_stanje1 { get => sifra_stanje1; set => sifra_stanje1 = value; }
        public int Broj_pica_na_racunu { get => broj_pica_na_racunu; set => broj_pica_na_racunu = value; }

        // Još dodati svojstvo koje će odgovarati vremenu happy hour-a
        public Pice() { }
        public Pice(int sifra, string vrsta, int sifra_dodatno, int sifra_dodatno_2, string naziv, double cijena, double happy_hour)
        {
            this.sifra_pica = sifra;
            this.Vrsta = vrsta;
            this.sifra_stanje1 = sifra_dodatno;
            this.sifra_stanje = new Stanje(sifra_dodatno);
            this.sifra_stanje_dodatno1 = sifra_dodatno_2;
            this.sifra_stanje_dodatno = new Stanje(sifra_dodatno_2);
            this.naziv_pica = naziv;
            this.cijena = cijena;
            this.happy_hour_cijena = happy_hour;
            //ode se mogu jos neke stvari dodavat, provjeravat
        }

    }
}

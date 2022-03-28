using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinaleProjekta
{
    public class Stanje
    {
        // Stanje kao klasu smo odvojili zbog pića koja bi trebala trošiti istu vrstu robe, a različita su.
        private int sifra_stanje;
        private string naziv;
        private int kolicina_kafic;
        private int kolicina_skladiste;
        private int dostava;

        public int Sifra_stanje { get => sifra_stanje; set => sifra_stanje = value; }
        public string Naziv { get => naziv; set => naziv = value; }
        public int Kolicina_kafic { get => kolicina_kafic; set => kolicina_kafic = value; }
        public int Kolicina_skladiste { get => kolicina_skladiste; set => kolicina_skladiste = value; }
        public int Dostava { get => dostava; set => dostava = value; }

        public Stanje(int sifra)
        {
            kolicina_kafic = 0;
            kolicina_skladiste = 0;
            dostava = 0;
        }
        public Stanje(int sifra_stanje, string naziv, int kolicina_kafic, int kolicina_skladiste)
        {
            this.Sifra_stanje = sifra_stanje;
            this.naziv = naziv;
            this.kolicina_kafic = kolicina_kafic;
            this.kolicina_skladiste = kolicina_skladiste;
        }
        public Stanje(int sifra_stanje, string naziv, int kolicina_kafic, int kolicina_skladiste, int dostava)
        {
            this.Sifra_stanje = sifra_stanje;
            this.naziv = naziv;
            this.kolicina_kafic = kolicina_kafic;
            this.kolicina_skladiste = kolicina_skladiste;
            this.dostava = dostava;
        }

    }
}

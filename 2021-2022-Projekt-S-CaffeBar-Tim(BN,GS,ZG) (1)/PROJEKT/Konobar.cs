using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace FinaleProjekta
{
    public class Konobar
    {
        // Svojstva koja opisuju konobara - u potpunosti se slaže s tablicom Konobar u bazi podataka

        // sifra_konobar je jedistvena za svakog konobara - ključ u tablici u bazi podataka
        private int sifra_konobar;
        private string ime;
        private string prezime;

        //konobar se u aplikaciju ulogira pomoću svog korisničkog imena i lozinke
        private string korisnicko_ime;
        private int lozinka;



        public int Sifra_konobar { get => sifra_konobar; set => sifra_konobar = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Korisnicko_ime { get => korisnicko_ime; set => korisnicko_ime = value; }
        public int Lozinka { get => lozinka; set => lozinka = value; }


        /*
         *  S obzirom da aplikacija nudi mogućnost ostavljanja računa otvorenog na nekom stolu,
         *  kod konobara, onog trenutno prijavljenog, pamtimo listu otvorenih računa
         *  Dakle, u bazu podataka spremamo samo zaključene račune, a otvorene pamtimo u listi.
         *  Na početku smjene lista je inicijalno prazna.
         * 
         * */
        public List<Racun> otvoreniRacuni;
        public List<Racun> zatvoreniRacuni;

        public bool kava;
        public int broji_kave;
        public bool cijedjeni_sok;
        public Konobar()
        {

        }
        public Konobar(int sifra, string ime, string prezime, string kor_ime, int loz)
        {
            Sifra_konobar = sifra;
            Ime = ime;
            Prezime = prezime;
            Korisnicko_ime = kor_ime;
            Lozinka = loz;

            kava = false;
            cijedjeni_sok = false;
            broji_kave = 0;

            stvoriListuRacuna();
        }

        public void stvoriListuRacuna()
        {
            otvoreniRacuni = new List<Racun>();
            zatvoreniRacuni = new List<Racun>();
        }

        /*
         * Konobar može provjeriti, nakon što je odabrao stol, postoji li otvoren račun za tim stolom.
         * Ako postoji, vrati taj isti račun i na njega dalje dodaje pića. Ako ne postoji, vraća null vrijednost
         */
        public Racun provjeriJeLiOtvoren(int broj_stola)
        {
            if (this.otvoreniRacuni.Count < 1)
            {
                return null; // Ako je lista prazna
            }
            foreach (Racun r in this.otvoreniRacuni)
            {
                if (r.Broj_stola == broj_stola)
                {
                    return r; // Ako smo pronašli otvoren račun za tim stolom
                }
            }

            return null;
        }

        /*
         * Konobar dodaje piće trenutnom računu.
         * Ako lista otvorenih računa ne  sadrži taj račun, stavimo ga u listu i na nj dodajemo piće
         * Ako pak sadrži, mijenjamo (inkrementiramo) broj pojavljivanja tog pića na ovom trenutnom računu.
         * 
         * Dodavanje pića na račun: ako konobar sebi toči piće, onda pazimo na njegove povlastice:
         *      dvije besplatne kave dnevno i jedan cijeđeni sok, a sve ostalo s popustom od 20%,
         *      inače normalne cijene za svaki artikal.
         * 
         * trenutnom računu pamtimo broj pojavljivanja pića, ukupnu cijenu tog isto pića te sveukupan iznos
         * Ako se piće prvi put bira, postavljamo broj pojavljivanja tog pića (pice.Broj_pica_na_racunu) na 1
         * 
         */
        public void dodajPice(Racun trenutni, Pice pice)
        {
            if (this.otvoreniRacuni.Contains(trenutni))
            {
                if (trenutni.popis_na_racunu.ContainsKey(pice))
                {
                    double iznos = trenutni.popis_na_racunu[pice];
                    pice.Broj_pica_na_racunu++;
                    if(trenutni.Broj_stola == 0) // Ako je konobar sebi uzeo piće
                    {
                        if((pice.Sifra_stanje1 == 1 || pice.Sifra_stanje_dodatno1 ==  2) && broji_kave < 2)
                        {
                            trenutni.popis_na_racunu[pice] = 0;
                            broji_kave++;
                        }
                        else
                        {
                            trenutni.popis_na_racunu[pice] = iznos + (pice.Cijena * 0.8);
                            trenutni.Ukupan_iznos += (pice.Cijena * 0.8);
                        }
                       
                    }
                    else
                    { 
                        trenutni.popis_na_racunu[pice] = iznos + pice.Cijena;
                        trenutni.Ukupan_iznos += pice.Cijena;
                    }
                }

                else
                {
                    pice.Broj_pica_na_racunu = 1;
                    pice.Sifra_stanje = new Stanje(pice.Sifra_stanje1);
                    if (pice.Sifra_stanje_dodatno1 > 0)
                        pice.Sifra_stanje_dodatno = new Stanje(pice.Sifra_stanje_dodatno1);
                    if(trenutni.Broj_stola == 0)
                    {
                        if ((pice.Sifra_stanje1 == 1 || pice.Sifra_stanje_dodatno1 == 2) && broji_kave < 2)
                        {
                            trenutni.Ukupan_iznos += 0;
                            trenutni.popis_na_racunu.Add(pice, 0);
                            broji_kave++;
                        }
                        else if (pice.Naziv_pica == "Cijeđeni sok" && cijedjeni_sok == false)
                        {
                            trenutni.Ukupan_iznos += 0;
                            trenutni.popis_na_racunu.Add(pice, 0);
                            cijedjeni_sok = true;
                        }
                        else
                        {
                            trenutni.popis_na_racunu.Add(pice, pice.Cijena * 0.8);
                            trenutni.Ukupan_iznos += (pice.Cijena * 0.8);
                        }

                    }
                    else
                    {
                        trenutni.Ukupan_iznos += pice.Cijena;
                        trenutni.popis_na_racunu.Add(pice, pice.Cijena);
                    }
                    
                }
            }
            else
            {
                pice.Broj_pica_na_racunu = 1;
                trenutni.popis_na_racunu.Add(pice, pice.Cijena);
                trenutni.Ukupan_iznos += pice.Cijena;
                this.otvoreniRacuni.Add(trenutni);
            }
        }

        /*
         *  Konobar može u svakom trenutku provjeriti Stanje u bazi
         *  Zbog liste otvorenih računa, ona će se često razlikovati od stanja u bazi, ali ovako smo smanjili konekciju s bazom
         *  i time ubrzali program
         */
        public List<Stanje> provjeriStanje(Baza veza)
        {
            List<Stanje> stanjePica = new List<Stanje>();

            /* mysql upit na stanja */

            MySqlCommand naredba;
            MySqlDataReader citac;

            try
            {
                veza.Connect();
                veza.baza.Open();
                naredba = new MySqlCommand("SELECT * FROM Stanje", veza.baza);

                citac = naredba.ExecuteReader();
                if (citac.HasRows)
                {
                    while (citac.Read())
                    {
                        int sifra = int.Parse(citac[0].ToString());
                        string naziv = citac[1].ToString();
                        int kolicina_kafic = int.Parse(citac[2].ToString());
                        int kolicina_skladiste = int.Parse(citac[3].ToString());
                        int dostava = int.Parse(citac[4].ToString());
                        stanjePica.Add(new Stanje(sifra, naziv, kolicina_kafic, kolicina_skladiste, dostava));
                    }

                    //   ode ce ic neki event za otvorit contorlu Stanje prijava(this, trenutni);
                }
                citac.Close();
                veza.baza.Close();
            }
            catch
            {
                // nista

            }

            return stanjePica;
        }

        public List<Pice> ucitajPica(Baza veza)
        {
            List<Pice> ucitajPica = new List<Pice>();

            /* mysql upit na stanja */

            MySqlCommand naredba;
            MySqlDataReader citac;

            try
            {
                veza.Connect();
                veza.baza.Open();
                naredba = new MySqlCommand("SELECT * FROM Pice", veza.baza);

                citac = naredba.ExecuteReader();
                if (citac.HasRows)
                {
                    while (citac.Read())
                    {
                        int sifra = int.Parse(citac[0].ToString());
                        string vrsta = citac[1].ToString();
                        int sifra_dodatno = int.Parse(citac[2].ToString());
                        int sifra_dodatno_2;
                        try
                        {
                            sifra_dodatno_2 = int.Parse(citac[3].ToString());
                        }
                        catch
                        {
                            sifra_dodatno_2 = -1;
                        }
                        string naziv = citac[4].ToString();
                        double cijena = double.Parse(citac[5].ToString());
                        double happy_hour;
                        try
                        {
                            happy_hour = double.Parse(citac[6].ToString());
                        }
                        catch
                        {
                            happy_hour = -1;
                        }
                        ucitajPica.Add(new Pice(sifra, vrsta, sifra_dodatno, sifra_dodatno_2, naziv, cijena, happy_hour));
                    }

                    //   ode ce ic neki event za otvorit contorlu Stanje prijava(this, trenutni);
                }
                citac.Close();
                veza.baza.Close();
            }
            catch
            {
                // nista

            }

            return ucitajPica;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient; // Za mogućnost konekcije s bazom

namespace FinaleProjekta
{
    public partial class Stol : UserControl
    {
        // Jedna korisnička kotrola za svaki stol
        private Racun racunNaStolu;
        private int brojStola;
        private Konobar trenutnoRadi;
        private List<Pice> listaPica; // Na početku dohvatimo popis pića iz baze
        private List<Stanje> listaStanja; // Na početku dohvatimo popis stanja
        private List<Stanje> staroStanjeBaze; //
        private Baza veza;

        public Stol()
        {
            InitializeComponent();
        }
        public Racun RacunNaStolu { get => racunNaStolu; set => racunNaStolu = value; }
        public int BrojStola { get => brojStola; set => brojStola = value; }
        public Konobar TrenutnoRadi { get => trenutnoRadi; set => trenutnoRadi = value; }
        public List<Pice> ListaPica { get => listaPica; set => listaPica = value; }
        public Baza Veza { get => veza; set => veza = value; }
        public List<Stanje> ListaStanja { get => listaStanja; set => listaStanja = value; }
        public List<Stanje> StaroStanjeBaze { get => staroStanjeBaze; set => staroStanjeBaze = value; }

        // Za grupiranje pića po svojoj vrsti
        private List<String> odvojiVrstePica(List<Pice> lista)
        {
            List<String> VrstePica = new List<string>();
            foreach (Pice p in lista)
            {
                if (!VrstePica.Contains(p.Vrsta))
                {
                    VrstePica.Add(p.Vrsta);
                }
            }
            return VrstePica;
        }

        private Pice nadjiPoNazivu(String naziv)
        {
            foreach (Pice p in ListaPica)
            {
                if (p.Naziv_pica == naziv)
                    return p;
            }
            return null;
        }

        // Metoda koja svojstvu računNaStolu pridruži prije otvoren račun, ako takav postoji,
        // inače stvori novi račun i stvori ga u listu otvorenih računa konobara
        private void StvoriRacun()
        {
            if (trenutnoRadi.provjeriJeLiOtvoren(BrojStola) != null)
            {
                racunNaStolu = trenutnoRadi.provjeriJeLiOtvoren(BrojStola);
            }
            else
            {
                racunNaStolu = new Racun(brojStola, trenutnoRadi);
                trenutnoRadi.otvoreniRacuni.Add(racunNaStolu);
            }

        }
        // Metoda koja reagira na događaj - klik gumba
        public void btnclick_Click(object sender, EventArgs e)
        {
            // gumb predstavlja vrstu pića
            // klikom na njega pokažemo sva pića te vrste
            // U Tag svojstvu gumba koji je izazvao događaj spremi Panel koji sadrži sva pića kojemu je btn predstavnik - vrsta

            // klik samo otkriva i sakriva sva pića (reprezentirana gumbima) te vrste
            Button btn = (Button)sender;
            Panel panela = (Panel)btn.Tag;
            if (panela.MinimumSize == panela.Size)
            {
                btn.BackColor = Color.LightPink;
                panela.Size = panela.MaximumSize;
            }
            else if (panela.MaximumSize == panela.Size)
            {
                btn.BackColor = Color.White;
                panela.Size = panela.MinimumSize;
            }
        }

      // Provjera starog stanja, tj trenutno aktualnog u bazi
        private Stanje vratiStanje(Stanje st)
        {
            foreach(Stanje k in StaroStanjeBaze)
            {
                if (k.Sifra_stanje == st.Sifra_stanje)
                    return k;
            }
            return null;
        }

        
        // klikom na neko piće (gumb) trebamo smanjiti stanje tog pića u kafiću, odnosno skladištu
        // metodi šaljemo odabrano piće
        // Dopuštamo konobaru da, ako nije napunio frižider na vrijeme, a hitno mu treba, može otići u skladište po piće
       private int smanjiStanje(Pice p)
        {
             foreach (Stanje s in listaStanja)
                {
                    if (s.Sifra_stanje == p.Sifra_stanje1)
                    {
                    Stanje staro = vratiStanje(s); // Na vrijeme upozoravamo konobara da mu nestaje artikala u kafiću i da napuni frižidere
                    if (s.Kolicina_kafic < staro.Kolicina_kafic * 0.3)
                        MessageBox.Show("Vrijeme vam je napuniti frižider!");
                    if (s.Kolicina_skladiste < staro.Kolicina_skladiste * 0.3) // isto tako upozoravamo ako se skladište prazni da na vrijeme naruči piće
                        MessageBox.Show("Naručite robu, lagano nestaje u skladištu!");
                        if (s.Kolicina_kafic < 1)
                        {
                            if (s.Kolicina_skladiste < 1)
                                return -1; // Nepoželjna situacija, ako je nestalo pića skroz
                            else
                            {
                                // Ako nema u kafiću, može otići u skladište
                                p.Sifra_stanje.Kolicina_skladiste++; // Piću povećavamo stanje skladišta kako bismo na kraju lakše oduzimali pri spremanju u bazu
                                s.Kolicina_skladiste--;
                                return 0;
                            }
                        }
                        else
                        {
                            p.Sifra_stanje.Kolicina_kafic++;
                            s.Kolicina_kafic--;
                            return 1;
                        }
                    }

                }
                return 2;
        }

        // Ako postoji dodatni artikal kojeg neko piće u pripremi troši, moramo i njega smanjiti
        private int smanjiDodatnoStanje(Pice p)
        {
            foreach (Stanje s in listaStanja)
            {
                if (s.Sifra_stanje == p.Sifra_stanje_dodatno1)
                {
                    Stanje staro = vratiStanje(s);
                    if (s.Kolicina_kafic < staro.Kolicina_kafic * 0.3)
                        MessageBox.Show("Vrijeme vam je napuniti frižider!");
                    if (s.Kolicina_skladiste < staro.Kolicina_skladiste * 0.3)
                        MessageBox.Show("Naručite robu, lagano nestaje u skladištu!");
                    if (s.Kolicina_kafic < 1)
                    {
                        if (s.Kolicina_skladiste < 1)
                            return -1;
                        else
                        {

                            p.Sifra_stanje_dodatno.Kolicina_skladiste++;
                            s.Kolicina_skladiste--;
                            return 0;
                        }
                    }
                    else
                    {
                        p.Sifra_stanje_dodatno.Kolicina_kafic++;
                        s.Kolicina_kafic--;
                        return 1;
                    }
                }

            }
            return 2;
        }

        // Fja koja update-a stanje nakon zaključenog računa
        public void SpremiStanjeUBazu()
        {
            try
            {
                veza.Connect();
                veza.baza.Open();
                MySqlCommand naredba;

                foreach (KeyValuePair<Pice, double> par in RacunNaStolu.popis_na_racunu)
                {
                    foreach (Stanje k in StaroStanjeBaze)
                    {

                        if (par.Key.Sifra_stanje1 == k.Sifra_stanje)
                        {
                            // U svakom piću na računu smo pamtili (povećavajući) stanje da ga ovdje lakše smanjimo
                            // i samo tu dobivenu vrijednost spremimo u bazu
                            int kafic = k.Kolicina_kafic - par.Key.Sifra_stanje.Kolicina_kafic;
                            int skladiste = k.Kolicina_skladiste - par.Key.Sifra_stanje.Kolicina_skladiste;

                            naredba = new MySqlCommand("UPDATE Stanje SET kolicina_kafic=@kafic, kolicina_skladiste=@skladiste WHERE sifra_stanje=@sifra", veza.baza);
                            naredba.Parameters.AddWithValue("@kafic", kafic);
                            naredba.Parameters.AddWithValue("@skladiste", skladiste);
                            naredba.Parameters.AddWithValue("@sifra", par.Key.Sifra_stanje1);

                            naredba.ExecuteNonQuery();

                        }

                        if(par.Key.Sifra_stanje_dodatno1 == k.Sifra_stanje)
                        {
                            int kafic = k.Kolicina_kafic - par.Key.Sifra_stanje_dodatno.Kolicina_kafic;
                            int skladiste = k.Kolicina_skladiste - par.Key.Sifra_stanje_dodatno.Kolicina_skladiste;

                            naredba = new MySqlCommand("UPDATE Stanje SET kolicina_kafic=@kafic, kolicina_skladiste=@skladiste WHERE sifra_stanje=@sifra", veza.baza);
                            naredba.Parameters.AddWithValue("@kafic", kafic);
                            naredba.Parameters.AddWithValue("@skladiste", skladiste);
                            naredba.Parameters.AddWithValue("@sifra", par.Key.Sifra_stanje_dodatno1);

                            naredba.ExecuteNonQuery();
                        }
                    }
                }
                veza.baza.Close();
            }
            catch
            {
                MessageBox.Show("Greška u komunikaciji s bazom!");

            }
        }

        // Metoda koja reagira na događaj klik na određeno piće
        // Ako je moguće (Ako tog pića ima na stanju) dodaje ga na račun
        public void button_click(Object sender, EventArgs args)
        {
            Button btn = (Button)sender;
            Pice p = nadjiPoNazivu(btn.Name);
            StvoriRacun();
            int i = smanjiStanje(p);
            int k = -3;
            if (p.Sifra_stanje_dodatno1 > 0)
                k = smanjiDodatnoStanje(p);
            if (i == -1 || k == -1)
                MessageBox.Show("Hitno zovite dostavu! OVog pića više nemate na stanju!");
            else if (i == 2)
                MessageBox.Show("Greška na meniju!");
            else
            {
                if (i == 0 || k == 0)
                    MessageBox.Show("Nedostaju Van neki sastojci. Otiđite u skladište po to!");
                trenutnoRadi.dodajPice(racunNaStolu,p);
                ispis();
            }

        }
        private void stvoriMenu(List<Pice> lista)
        {
            // na početku crta panele s gumbima razvrstavajući ih po vrsti pića
            SuspendLayout();

            if (lista != null)
            {
                List<String> vrstePica = odvojiVrstePica(lista);
                foreach (String vrsta in vrstePica)
                {
                    var btn = new Button();
                    btn.BackColor = Color.White;
                    btn.Font = new Font("Maiandra GD", 10, FontStyle.Regular);
                    btn.Name = vrsta;
                    btn.Text = vrsta;
                    btn.Width = panelGumbi.Width;
                    btn.Click += new EventHandler(btnclick_Click);

                    Panel panela = new Panel();
                    btn.Dock = DockStyle.Top;
                    btn.Tag = panela;
                    panela.Controls.Add(btn);
                    panela.MinimumSize = new System.Drawing.Size(btn.Width, btn.Height);
                    int sirina = btn.Width;
                    int visina = btn.Height;

                    // Za svaku vrstu pića stvori posebni panel i njega sakrij/prikaži ovisno o kliku na gumb s vrstom pića
                    int broj = 0;
                    foreach (Pice p in listaPica)
                    {
                        if (p.Vrsta == vrsta)
                        {
                            broj++;
                            var botun = new Button();

                            botun.BackColor = Color.White;
                            botun.Font = new Font("Maiandra GD", 10, FontStyle.Regular);
                            botun.Name = p.Naziv_pica;
                            botun.Text = p.Naziv_pica;
                            botun.Top = btn.Height * broj;
                            botun.Width = btn.Width;
                            botun.Click += new EventHandler(button_click);

                            visina += botun.Height;

                            panela.Controls.Add(botun);
                        }
                    }
                    panela.MaximumSize = new System.Drawing.Size(sirina, visina);
                    panela.Size = panela.MinimumSize;
                    panelGumbi.Controls.Add(panela); // Svaki panel koji sadrži i/ili skriva pića stavljamo dinamički u jedan FlowLayOutPanel
                }

            }
            ResumeLayout();
        }

        // ispis pića u dva listboxa - samo zbog estetski ljepšeg prikaza
        private void ispis()
        {
            lsbPopisNaRacunu.Items.Clear();
            lsbNaziviPica.Items.Clear();
            if (racunNaStolu.popis_na_racunu.Count > 0)
            {
                string tekst = "";
                tekst = "Količina:\tCijena:\tUkupno:";
                lsbNaziviPica.Items.Add("Naziv pića:");
                lsbPopisNaRacunu.Items.Add(tekst);
                foreach (KeyValuePair<Pice, double> par in RacunNaStolu.popis_na_racunu)
                {
                    
                    tekst = par.Key.Broj_pica_na_racunu.ToString() + "\t " + par.Key.Cijena.ToString() + " kn\t" + par.Value.ToString() + " kn";
                    lsbNaziviPica.Items.Add(par.Key.Naziv_pica);
                    lsbPopisNaRacunu.Items.Add(tekst);
                }
                lsbNaziviPica.Items.Add("Ukupan iznos:");
                lsbPopisNaRacunu.Items.Add(RacunNaStolu.Ukupan_iznos.ToString() + "kn");
            }
        }

        // Ako konobar želi ostaviti račun otvoren i vratiti se kontroli Kafic
        public event EventHandler OstaviOtvoren;
        private void btnOstaviOtvoren_Click_1(object sender, EventArgs e)
        {
            RacunNaStolu = null;
            OstaviOtvoren(this, null);
        }

        public void Stol_Load_1(object sender, EventArgs e)
        {
            if (trenutnoRadi != null)
            {
                if (panelGumbi.Controls.Count < 1)
                    stvoriMenu(ListaPica);
                StvoriRacun();
                ispis();
            }
        }

        // Gost je zvao za račun - konobar ga izdaje na sljedeći način:
        private void btnZakljuciRacun_Click(object sender, EventArgs e)
        {
            string zapis_za_racunanje = ""; // string kojeg spremamo u bazu i koji predstavljaju niz šifri pića (Za kasnije lakše pretraživanje - tražeći statistiku)
          
            // string račun spremamo u .txt file - ispis računa
            string racun = "";
            racun += "Broj računa: " + RacunNaStolu.Broj_racuna + "\n";
            racun += "Vrijeme: " + racunNaStolu.datum.Date.ToString() + "\n";
            racun += "Konobar: " + trenutnoRadi.Ime + " " + trenutnoRadi.Prezime + "\n";
            racun += "\n";
            racun += "Naziv pića:\t\tCijena:\t\tKoličina:\t Ukupno:\n";

            foreach (KeyValuePair<Pice, double> par in racunNaStolu.popis_na_racunu)
            {
                racun += par.Key.Naziv_pica + "\t\t" + par.Key.Cijena + "\t\t" + par.Key.Broj_pica_na_racunu + "\t\t" + par.Value + " kn";
                for(int i = 0; i < par.Key.Broj_pica_na_racunu; i++)
                {
                    zapis_za_racunanje += par.Key.Sifra_pica.ToString() + ",";
                }
                int b = 0; // da zarez ne bude posljednji
                zapis_za_racunanje += b.ToString();
                racun += "\n";
            }

            racun += "\n";
            racun += "Ukupan iznos računa: " + RacunNaStolu.Ukupan_iznos + " kn\n";
            racun += "\n Ugodan dan!";

            // stvori direktorij, ako ne postoji već i u njega spremaj datoteke koje predstavljaju račune
            string direktorij = Path.GetFullPath("rp3");
            string zaRacune = Path.Combine(direktorij, "ZatvoreniRacuni");

            if (!Directory.Exists(zaRacune))
            {
                Directory.CreateDirectory(zaRacune);
            }
            string fileName = RacunNaStolu.datum.Day + "_" + RacunNaStolu.datum.Month + "_" + RacunNaStolu.datum.Year + "_" 
                + RacunNaStolu.datum.Hour + "_" + racunNaStolu.datum.Minute + "_" + RacunNaStolu.Broj_racuna.ToString() + ".txt";
            zaRacune = Path.Combine(zaRacune, fileName);


            if (File.Exists(zaRacune))
            {
                MessageBox.Show("Racun već postoji - neka je greška u pitanju.");
            }
            else
            {
                File.WriteAllText(zaRacune, racun);
                RacunNaStolu.putanja = zaRacune;

                
                //s obzirom da se racun zakljucio, izbacujemo ga iz liste otvorenih i stavljamo u listu zatvorenih racuna 
                //za smjenu konobara koji radi

                // plaćanje poziva novu formu - daje mogućnost izbora načina plaćanja i računanja ostatka novca ako je riječ o gotovinskom plaćanju
                if(BrojStola > 0)
                {
                    PlacanjeRacuna placanje = new PlacanjeRacuna(RacunNaStolu.Ukupan_iznos);
                    placanje.Show();
                }
                

                RacunNaStolu.SpremiUBazu(veza, zaRacune, zapis_za_racunanje);
                
                lsbPopisNaRacunu.Items.Clear();
                lsbNaziviPica.Items.Clear();

                SpremiStanjeUBazu();
                trenutnoRadi.zatvoreniRacuni.Add(RacunNaStolu);
                trenutnoRadi.otvoreniRacuni.Remove(RacunNaStolu);

                StaroStanjeBaze = trenutnoRadi.provjeriStanje(veza);
                listaStanja = trenutnoRadi.provjeriStanje(veza);
                osvjezilistuStanja();

                OstaviOtvoren(this, null); // Još napraviti da čeka dok se druga forma ne zatvori

            }
         
        }

        private void osvjezilistuStanja()
        {
            foreach(Racun r in trenutnoRadi.otvoreniRacuni)
            {
                foreach(KeyValuePair<Pice, double> par in r.popis_na_racunu)
                {
                    foreach(Stanje s in listaStanja)
                    {
                        if(par.Key.Sifra_stanje1 == s.Sifra_stanje)
                        {
                            s.Kolicina_kafic -= par.Key.Sifra_stanje.Kolicina_kafic;
                            s.Kolicina_skladiste -= par.Key.Sifra_stanje.Kolicina_skladiste;
                        }
                        if(par.Key.Sifra_stanje_dodatno1 == s.Sifra_stanje)
                        {
                            s.Kolicina_kafic -= par.Key.Sifra_stanje_dodatno.Kolicina_kafic;
                            s.Kolicina_skladiste -= par.Key.Sifra_stanje_dodatno.Kolicina_skladiste;
                        }
                    }
                    
                }
            }
        }
    }
}




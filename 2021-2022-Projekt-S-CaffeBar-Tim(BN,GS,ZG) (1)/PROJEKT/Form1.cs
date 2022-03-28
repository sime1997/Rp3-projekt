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
    public partial class forma : Form
    {
        Baza veza = new Baza();


        public List<Pice> listaPica;
        public List<Stanje> listaStanja;
        public Konobar k;
        public forma()
        {
            
            InitializeComponent();
            prijava1.Visible = true;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = false;
            makniKonobara1.Visible = false;
            dodajKonobara1.Visible = false;
            promijeniCijenu1.Visible = false;
            makniPice1.Visible = false;
            dostava1.Visible = false;
            kafic1.Baza = veza;
            lsbStanje.Veza = veza;
            dostava1.Veza = veza;
            dodajPice1.Visible = false;
            happyHour1.Visible = false;
            happyHour1.Veza = veza;

        }




        private void forma_Load(object sender, EventArgs e)
        {
            lsbStanje.Visible = false;
           
        }

        private void dodajKonobara1_vrati_se_1(object sender, string e)
        {
            prijava1.Visible = false;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = true;
            dodajKonobara1.Visible = false;
            makniKonobara1.Visible = false;
            promijeniCijenu1.Visible = false;
            makniPice1.Visible = false;
        }

       

        /*-----------------------------------------------------------------------------------------*/


        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void prijava1_prijava_1(object sender, Konobar e)
        {
            k = e;
            prijava1.Visible = false;
            kafic1.Konobar = k;
            kafic1.Visible = true;
            dodajPice1.Visible = false;
            stol1.TrenutnoRadi = k;
            stol1.Veza = veza;
            stol1.StaroStanjeBaze = k.provjeriStanje(veza);
            listaStanja = k.provjeriStanje(veza);
            listaPica = k.ucitajPica(veza);
            stol1.ListaPica = listaPica;
            stol1.ListaStanja = listaStanja;
        }

        private void prijava1_prijava_vlasnik_1(object sender, Konobar e)
        {
            prijava1.Visible = false;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = true;
        }

        private void vlasnik1_dodaj_pice_1(object sender, string e)
        {
            prijava1.Visible = false;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = true;
            dodajKonobara1.Visible = false;
            makniKonobara1.Visible = false;
            promijeniCijenu1.Visible = false;
            makniPice1.Visible = false;
            dodajPice1.Visible = true;
            lsbStanje.Visible = false;
            happyHour1.Visible = false;
        }

        private void vlasnik1_makni_pice(object sender, string e)
        {
            prijava1.Visible = false;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = true;
            makniKonobara1.Visible = false;
            promijeniCijenu1.Visible = false;
            makniPice1.Visible = true;
            makniPice1.Help();
            dodajPice1.Visible = false;
            lsbStanje.Visible = false;
            happyHour1.Visible = false;
            promijeniCijenu1.Visible = false;
        }

        private void vlasnik1_promijeni_cijenu(object sender, string e)
        {
            prijava1.Visible = false;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = true;
            makniKonobara1.Visible = false;
            promijeniCijenu1.Visible = true;
            makniPice1.Visible = false;
            dodajPice1.Visible = false;
            lsbStanje.Visible = false;
            happyHour1.Visible = false;
            dodajKonobara1.Visible = false;
        }

        private void vlasnik1_dodaj_konobara(object sender, string e)
        {
            prijava1.Visible = false;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = true;
            makniKonobara1.Visible = false;
            dodajKonobara1.Visible = true;
            makniPice1.Visible = false;
            dodajPice1.Visible = false;
            lsbStanje.Visible = false;
            happyHour1.Visible = false;
            promijeniCijenu1.Visible = false;
        }

        private void vlasnik1_makni_konobara(object sender, string e)
        {
            prijava1.Visible = false;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = true;
            makniKonobara1.Visible = true;
            makniKonobara1.Help();
            dodajKonobara1.Visible = false;
            makniPice1.Visible = false;
            dodajPice1.Visible = false;
            lsbStanje.Visible = false;
            happyHour1.Visible = false;
            promijeniCijenu1.Visible = false;
        }

        private void vlasnik1_naruci_1(object sender, string e)
        {
            //evo naruci
            lsbStanje.Stanja = new Konobar().provjeriStanje(veza); //ne drugim mjestima sam slala s ListArgs, ovdje mi je lakse ovako jer nemam konobara
            lsbStanje.napuniLsb();
            lsbStanje.Visible = true;
            lsbStanje.JeliVlasnik = 1;
            //promijeni samo naziv buttona 
            lsbStanje.button2.Text = "Naruči";
            lsbStanje.label1.Text = "Količina za naručiti:";
            vlasnik1.Visible = true;
            dodajKonobara1.Visible = false;
            makniKonobara1.Visible = false;
            promijeniCijenu1.Visible = false;
            makniPice1.Visible = false;
            //happyHour1.Visible = false;
            dodajPice1.Visible = false;
        }

        private void vlasnik1_happy_hour_2(object sender, string e)
        {
            happyHour1.ucitajHappyHours();
            vlasnik1.Visible = true;
            dodajKonobara1.Visible = false;
            makniKonobara1.Visible = false;
            promijeniCijenu1.Visible = false;
            makniPice1.Visible = false;
            happyHour1.Visible = false;
            dodajPice1.Visible = false;
            happyHour1.Visible = true;
            lsbStanje.Visible = false;
            happyHour1.ListaPica = new Konobar().ucitajPica(veza);
            happyHour1.napuniCombo();
            happyHour1.Visible = true;
        }

        private void vlasnik1_odjavi_se(object sender, string e)
        {
            prijava1.Visible = true;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = false;
            makniKonobara1.Visible = false;
            dodajKonobara1.Visible = false;
            makniPice1.Visible = false;
            dodajPice1.Visible = false;
            lsbStanje.Visible = false;
            happyHour1.Visible = false;
            promijeniCijenu1.Visible = false;
            lsbStanje.JeliVlasnik = 0;

        }

        private void lsbStanje_zatvoriStanje_1(object sender, string e)
        {
            if (lsbStanje.JeliVlasnik == 0)
            {
                kafic1.Visible = true;
            }
            else
            {
                vlasnik1.Visible = true;
            }

            lsbStanje.Visible = false;
        }

        private void makniKonobara1_povratak(object sender, string e)
        {
            dodajKonobara1_vrati_se_1(sender, e);
        }

        private void promijeniCijenu1_vrati_se(object sender, string e)
        {
            dodajKonobara1_vrati_se_1(sender, e);
        }

        private void makniPice1_vrati_se_1(object sender, string e)
        {
            dodajKonobara1_vrati_se_1(sender, e);
        }

        private void dostava1_zatvoriDostavu_1(object sender, EventArgs e)
        {
            dostava1.Visible = false;
            kafic1.Visible = true;
            lsbStanje.napuniLsb();
        }

        private void kafic1_odjava_1(object sender, EventArgs e)
        {
            kafic1.Visible = false;


            //provjera je li ostao ijedan otvoren, a neprazan račun
            int f = 0;
            for(int i = 0; i < kafic1.Konobar.otvoreniRacuni.Count; i++)
            {
                if (kafic1.Konobar.otvoreniRacuni[i].popis_na_racunu.Count > 0)
                    f = 1;
            }
            if( f == 1)
            {
                MessageBox.Show("Imate nezatvorenih računa!");
                kafic1.Visible = true;
                return;
            }

            IspisPrometa promet = new IspisPrometa();

            //prije odjave konobar mora dobiti ispis prometa, to ćemo javljati u posebnoj formi 
            // u kojoj se očitava svaki artikal sa svakog računa i ukupan promet smjene klikom na odjava
            promet.ispis(kafic1.Konobar.zatvoreniRacuni);

            promet.ShowDialog();
            kafic1.Visible = false;
            prijava1.Visible = true;
        }

        private void kafic1_pokaziStanje(object sender, Kafic.ListArgs e)
        {
            lsbStanje.Stanja = e.List;
            lsbStanje.napuniLsb();
            kafic1.Visible = false;
            lsbStanje.Visible = true;
            lsbStanje.JeliVlasnik = 0;
            lsbStanje.button2.Text = "Prenesi";
            lsbStanje.label1.Text = "Prenesi u kafić:";
        }

        private void kafic1_otvori_stol(object sender, Racun e)
        {
            kafic1.Visible = false;
            stol1.Visible = true;
            stol1.RacunNaStolu = e;
            stol1.StaroStanjeBaze = kafic1.Konobar.provjeriStanje(veza);
            stol1.BrojStola = kafic1.Broj_stola;
            stol1.Stol_Load_1(this, null);
        }

        private void kafic1_pokaziDostavu(object sender, Kafic.ListArgs e)
        {
            kafic1.Visible = false;
            dostava1.Visible = true;
            dostava1.PopisPica = e.List;
            dostava1.provjeriDostavu();
        }

        private void dodajPice1_povratak(object sender, string e)
        {
            prijava1.Visible = false;
            kafic1.Visible = false;
            stol1.Visible = false;
            vlasnik1.Visible = true;
            dodajKonobara1.Visible = false;
            makniKonobara1.Visible = false;
            promijeniCijenu1.Visible = false;
            makniPice1.Visible = false;
            dodajPice1.Visible = false;

        }

        private void stol1_OstaviOtvoren(object sender, EventArgs e)
        {
            stol1.Visible = false;
            //kafic1.Broj_stola = -1;
            kafic1.Visible = true;
        }

        private void vlasnik1_Load(object sender, EventArgs e)
        {

        }
    }
}

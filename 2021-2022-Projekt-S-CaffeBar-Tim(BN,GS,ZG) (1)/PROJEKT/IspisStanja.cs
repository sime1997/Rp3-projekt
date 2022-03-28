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
    public partial class IspisStanja : UserControl
    {
        //ova se kontrola koristi na 2 mjesta, kod vlasnika za naručivanje artikala i kod konobara za prenošenje artikala
        //iz skladišta u hladnjak te konobaru za praćenje stanja u hladnjaku i skladištu
        //razlikujemo ta 2 slučaja u ovisnosti o svojstvu JeliVlasnik, jer se funkcionalnost razlikuje u komunikaciji s bazom u 
        //ovisnosti tko koristi kontrolu, vlasnik ili konobar
        
        private Baza veza;
        private List<Stanje> stanja;
        private string odabran;
        private int kol_skl; //količina u skladištu artikla
        private int kol_kaf; //količina u kafiću
        private int prebaci;
        private int indeks_odabranog; //indeks odabranog artikla iz ListView-a
        private int jeliVlasnik;
        public void napuniLsb()
        {
            lsbStanje.Clear();
            lsbStanje.GridLines = true;
            if (stanja != null)
            {
                lsbStanje.Columns.Add("Naziv");
                lsbStanje.Columns.Add("Kolicina kafic");
                lsbStanje.Columns.Add("Kolicina skladiste");

                for (int i = 0; i < stanja.Count; i++)
                    lsbStanje.Items.Add(new ListViewItem(new String[] { stanja[i].Naziv, stanja[i].Kolicina_kafic.ToString(), stanja[i].Kolicina_skladiste.ToString() }));
            }
            else
            {
                MessageBox.Show("PRAZNO!");
            }
            lsbStanje.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        public IspisStanja()
        {
            InitializeComponent();
            lsbStanje.MultiSelect = false;
        }

        public List<Stanje> Stanja { get => stanja; set => stanja = value; }
        public Baza Veza { get => veza; set => veza = value; }
        public int Kol_skl { get => kol_skl; set => kol_skl = value; }
        public int Kol_kaf { get => kol_kaf; set => kol_kaf = value; }
        public int Prebaci { get => prebaci; set => prebaci = value; }
        public int Indeks_odabranog { get => indeks_odabranog; set => indeks_odabranog = value; }
        public int JeliVlasnik { get => jeliVlasnik; set => jeliVlasnik = value; }

        public event EventHandler<string> zatvoriStanje;

        private void button1_Click(object sender, EventArgs e)
        {
            zatvoriStanje(this,"zatvori");
        }

        private void IspisStanja_Load(object sender, EventArgs e)
        {
            numericUpDown1.Visible = false;
            label1.Visible = false;
        }

        private void lsbStanje_SelectedIndexChanged(object sender, EventArgs e)
        {
            //za prenosenje iz skladista u kafic, maksimalno prenosimo koliko je u skladištu
            
            numericUpDown1.Visible = true;
            label1.Visible = true;
            numericUpDown1.Minimum = 0;

            if (lsbStanje.SelectedIndices.Count != 0)
            {
                if (JeliVlasnik == 0)
                    numericUpDown1.Maximum = stanja[lsbStanje.SelectedIndices[0]].Kolicina_skladiste;
                else
                    numericUpDown1.Maximum = 100;
                numericUpDown1.Value = numericUpDown1.Maximum;
                Kol_kaf = stanja[lsbStanje.SelectedIndices[0]].Kolicina_kafic;
                Kol_skl = stanja[lsbStanje.SelectedIndices[0]].Kolicina_skladiste;
                odabran = stanja[lsbStanje.SelectedIndices[0]].Naziv;
                Indeks_odabranog = lsbStanje.SelectedIndices[0];

            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (JeliVlasnik == 0)
            {
                //tu ce ic sql upit
                MySqlCommand naredba;
                Prebaci = int.Parse(numericUpDown1.Value.ToString());

                //update-amo u bazi količine u kafiću i skladištu ako se nešto prebacivalo

                try
                {
                    veza.Connect();
                    veza.baza.Open();
                    naredba = new MySqlCommand("UPDATE Stanje SET kolicina_skladiste=@SKL, kolicina_kafic=@KAF WHERE naziv=@NAZ", veza.baza);
                    naredba.Parameters.AddWithValue("@SKL", Kol_skl - prebaci);
                    naredba.Parameters.AddWithValue("@KAF", Kol_kaf + prebaci);
                    naredba.Parameters.AddWithValue("@NAZ", odabran); //ode myb bolje po sifri

                    naredba.ExecuteNonQuery();



                    veza.baza.Close();
                    stanja[indeks_odabranog].Kolicina_kafic = Kol_kaf + prebaci;
                    stanja[indeks_odabranog].Kolicina_skladiste = Kol_skl - prebaci;
                    napuniLsb();


                }
                catch
                {
                    // nista

                }
            }
            else
            {
                //ovdje verzija za vlasnika
                MySqlCommand naredba;
                Prebaci = int.Parse(numericUpDown1.Value.ToString());


                try
                {
                    veza.Connect();
                    veza.baza.Open();

                    naredba = new MySqlCommand("UPDATE Stanje SET dostava=@DOS WHERE naziv=@NAZ", veza.baza);
                    naredba.Parameters.AddWithValue("@DOS", Prebaci);
                    naredba.Parameters.AddWithValue("@NAZ", odabran); 

                    //Naruceno.Add(new Stanje(odabran, Prebaci));
                    MessageBox.Show("Naručeno:" + odabran + ", " + Prebaci);

                    naredba.ExecuteNonQuery();

                    veza.baza.Close();

                    napuniLsb();


                }
                catch
                {
                    // nista

                }
            }
        }
    }
}

using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinaleProjekta
{
    public partial class Dostava : UserControl
    {

        // Kontrola u kojoj konobar mora unijeti što je naručeno, točnije kako bismo prikazali funkcionalnost 
        // naručivanja i dostave, kada vlasnik naruči artikle, oni se automatski konobaru u idućem logiranju pojave kao 
        // da su dostavljeni i da ih mora samo prihvatiti. Na taj način stupac dostava u bazi Stanje "glumi" poštu.
        private List<Stanje> popisPica;
        private Baza veza;

        public Dostava()
        {
            InitializeComponent();
        }

        public List<Stanje> PopisPica { get => popisPica; set => popisPica = value; }
        public Baza Veza { get => veza; set => veza = value; }

        private void Dostava_Load(object sender, EventArgs e)
        {

        }
        public void provjeriDostavu()
        {
            lsbDostava.Clear();
            lsbDostava.GridLines = true;
            if (popisPica != null)
            {
                lsbDostava.Columns.Add("Naziv");
                lsbDostava.Columns.Add("Kolicina dostava");

                for (int i = 0; i < popisPica.Count; i++)
                {
                    if(popisPica[i].Dostava > 0)
                        lsbDostava.Items.Add(new ListViewItem(new String[] { popisPica[i].Naziv, popisPica[i].Dostava.ToString() }));

                }
                if (lsbDostava.Items.Count == 0)
                {
                    MessageBox.Show("Nema artikala na dostavi!");
                    zatvoriDostavu(this, new EventArgs());
                }
            }
            else
            {
              //  MessageBox.Show("PRAZNO!");                
            }
        }
        public event EventHandler zatvoriDostavu;
        private void button1_Click(object sender, EventArgs e)
        {
            //na botun Unesi se stupac dostava za sve artikle s dostave postavlja na 0 ponovo
            MySqlCommand naredba;         

            try
            {
                veza.Connect();
                veza.baza.Open();

                naredba = new MySqlCommand("UPDATE Stanje SET kolicina_skladiste=kolicina_skladiste+dostava WHERE dostava>1", veza.baza);
                naredba.ExecuteNonQuery();

                naredba = new MySqlCommand("UPDATE Stanje SET dostava=0 WHERE dostava>1", veza.baza);
                naredba.ExecuteNonQuery();

                veza.baza.Close();

                zatvoriDostavu(this, e);


            }
            catch
            {
                // nista

            }
        }
    }
}

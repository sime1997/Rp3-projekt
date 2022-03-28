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
    public partial class Vlasnik : UserControl
    {
        public event EventHandler<string> makni_konobara;
        public event EventHandler<string> dodaj_konobara;
        public event EventHandler<string> promijeni_cijenu;
        public event EventHandler<string> makni_pice;
        public event EventHandler<string> dodaj_pice;
        public event EventHandler<string> odjavi_se;
        public event EventHandler<string> naruci;
        public event EventHandler<string> happy_hour;
        public Vlasnik()
        {
            InitializeComponent();
        }

        private void Vlasnik_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//dodaj pice
        {
            if (dodaj_pice != null)
                dodaj_pice(this, "");
        }

        private void makniPice_Click(object sender, EventArgs e)//makni pice
        {
            if (makni_pice != null)
                makni_pice(this, "");
        }

        private void promijeniCijenu_Click(object sender, EventArgs e)//promijeni cijenu
        {
            if (promijeni_cijenu != null)
                promijeni_cijenu(this, "");
        }

        private void dodajKonobara_Click(object sender, EventArgs e)//dodaj konobaea
        {
            if (dodaj_konobara != null)
                dodaj_konobara(this, " ");
        }

        private void makniKonobara_Click(object sender, EventArgs e)//makni konobara
        {
            if (makni_konobara != null)
            {
                makni_konobara(this, " ");
            }
        }

        private void odjava_Click(object sender, EventArgs e)
        {
            if (odjavi_se != null)
                odjavi_se(this, " ");
        }

        private void naruci_Click(object sender, EventArgs e)
        {
            naruci(this, "");
        }
       

        private void happyHour_Click(object sender, EventArgs e)
        {
            happy_hour(this, e.ToString());   
        }

        private void btnStatistika_Click(object sender, EventArgs e)
        {
            Baza veza = new Baza();
            Statistika stat = new Statistika(veza);
            stat.Show();
        }
    }
}

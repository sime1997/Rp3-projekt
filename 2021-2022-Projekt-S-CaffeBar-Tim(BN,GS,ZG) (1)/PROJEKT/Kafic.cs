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
    public partial class Kafic : UserControl
    {
        private int broj_stola;
        private Konobar konobar;
        private Baza baza;
        private List<Stanje> listaStanja;
        private List<Pice> listaPica;


        public Kafic()
        {
            InitializeComponent();
        }

        public int Broj_stola { get => broj_stola; set => broj_stola = value; }
        public Konobar Konobar { get => konobar; set => konobar = value; }
        internal Baza Baza { get => baza; set => baza = value; }
        public List<Pice> ListaPica { get => listaPica; set => listaPica = value; }
        public List<Stanje> ListaStanja { get => listaStanja; set => listaStanja = value; }

        public event EventHandler<Racun> otvori_stol;

        private void ucitajRacun(object sender, EventArgs e)
        {
            var picBoxName = ((PictureBox)sender).Name;
            
            try
            {
                Broj_stola = int.Parse(picBoxName[7].ToString());
                //MessageBox.Show(Broj_stola.ToString());
                Racun racun = Konobar.provjeriJeLiOtvoren(Broj_stola);
                otvori_stol(this, racun);
            }
            catch
            {
                MessageBox.Show("Greska s brojem stola!");
            }
        }
        public event EventHandler<ListArgs> pokaziStanje;
        public class ListArgs : EventArgs//koristili kako bismo poslali listu preko EventArgs-a
        {
            public List<Stanje> List;
        }
        private void stanje(object sender, EventArgs e)
        {
            List<Stanje> lista = konobar.provjeriStanje(baza); // konobaru saljem instancu veze da se ne stvara nova
            //MessageBox.Show(lista[0].Naziv);
           
            
            ListArgs posalji = new ListArgs();
            posalji.List = lista;
            pokaziStanje(this, posalji);
           
        }
        public event EventHandler<ListArgs> pokaziDostavu;
        private void dostava(object sender, EventArgs e)
        {
            List<Stanje> lista = konobar.provjeriStanje(baza);
            //MessageBox.Show(lista[0].Dostava.ToString());
            ListArgs posalji = new ListArgs();
            posalji.List = lista;
            pokaziDostavu(this, posalji);
        }

        private void Kafic_Load(object sender, EventArgs e)
        {
            
        }

        public event EventHandler odjava;
        private void btnOdjava_Click(object sender, EventArgs e)
        {
            odjava(this, e);
        }

        private void btnProvjeriStatistiku_Click(object sender, EventArgs e)
        {
            Statistika stat = new Statistika(baza);
            stat.Show();
        }
    }
}

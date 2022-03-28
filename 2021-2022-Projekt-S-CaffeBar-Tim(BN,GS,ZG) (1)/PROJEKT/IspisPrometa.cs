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
    public partial class IspisPrometa : Form
    {
        //Forma koja se otvara kad se konobar odjavljuje i prikazuje mu ispis prometa tog dana, detaljno po artiklima
        public IspisPrometa()
        {
            InitializeComponent();
        }
        public void ispis(List<Racun> zatvoreniRacuni)
        {
            //ukupan promet čitamo iz liste zatvorenih računa konobara koji je radio u smjeni
            listView1.Clear();
            listView1.GridLines = true;            

            listView1.Columns.Add("Broj racuna");
            listView1.Columns.Add("Artikal");
            listView1.Columns.Add("Kolicina");
            listView1.Columns.Add("Cijena");

            double ukupan_promet = 0.0;
            for (int i = 0; i < zatvoreniRacuni.Count; i++)
            {
                foreach(Pice p in zatvoreniRacuni[i].popis_na_racunu.Keys)
                {
                    listView1.Items.Add(new ListViewItem(new String[] {zatvoreniRacuni[i].Broj_racuna.ToString(),
                                                    p.Naziv_pica, p.Broj_pica_na_racunu.ToString(), (p.Cijena*p.Broj_pica_na_racunu).ToString()})); 
                }
                ukupan_promet += zatvoreniRacuni[i].Ukupan_iznos;
               
            }
            listView1.Items.Add(new ListViewItem(new String[] {"",
                                                   "", "Ukupan promet:", ukupan_promet.ToString()}));

            listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void IspisPrometa_Load(object sender, EventArgs e)
        {

        }
    }
}

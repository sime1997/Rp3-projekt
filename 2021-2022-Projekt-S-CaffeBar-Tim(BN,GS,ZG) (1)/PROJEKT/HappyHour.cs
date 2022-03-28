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
    public partial class HappyHour : UserControl
    {
        private Baza veza; //veza se šalje jedna iz Form1, kako ne bismo s previše konekcija preopteretili bazu
        private List<Pice> listaPica;
        public HappyHour()
        {
            InitializeComponent();
        }

        public Baza Veza { get => veza; set => veza = value; }
        public List<Pice> ListaPica { get => listaPica; set => listaPica = value; }

        public event EventHandler zatvoriHappyHour;
        private void button1_Click(object sender, EventArgs e)
        {
            //klikom na botun Unesi, čitamo podatke iz kontrola kako bismo u tablicu Piće u bazi
            //unijeli happy hour za odabrano piće, tj. datum i sat početka i kraja trajanja akcije
            //dok je piće na akciji, prodaje se po happy hour cijeni iz baze
            try
            {
                int cijena = int.Parse(textBox1.Text);
                string naziv = comboBox1.SelectedItem.ToString();
                int sifra = 0;

                for (int i = 0; i < listaPica.Count; i++)
                {
                    if (listaPica[i].Naziv_pica == naziv)
                    {
                        sifra = listaPica[i].Sifra_pica;
                        break;
                    }
                }

                MySqlCommand naredba;


                try
                {
                    veza.Connect();
                    veza.baza.Open();
                    naredba = new MySqlCommand("UPDATE Pice SET pocetak=@POC, kraj=@KRJ, happy_hour_cijena=@CIJENA WHERE sifra_pica=@SIF", veza.baza);
                    naredba.Parameters.AddWithValue("@POC", dtpPocetak.Value);
                    naredba.Parameters.AddWithValue("@KRJ", dtpKraj.Value);
                    naredba.Parameters.AddWithValue("@CIJENA", cijena);
                    naredba.Parameters.AddWithValue("@SIF", sifra); 
                    naredba.ExecuteNonQuery();

                    MessageBox.Show(dtpPocetak + "," + dtpKraj + "," + naziv + "," + cijena);

                    veza.baza.Close();

                    //u listview dodamo happy hour-e trenutno dodane da ne pozivamo bazu
                    //dok je stalno u istoj kontroli, a poslije ce se svakako ucitat iz baze opet

                    listView1.Items.Add(new ListViewItem(new String[] { naziv, cijena.ToString(), dtpPocetak.Value.ToString(), dtpKraj.Value.ToString() }));

                    //zatvoriHappyHour(this, e);
                }
                catch
                {
                    // nista

                }
                MessageBox.Show(dtpPocetak + "," + dtpKraj + "," + naziv + "," + cijena);

            }
            catch
            {
                MessageBox.Show("Pogrešan unos cijene!");

            }

        }

        private void HappyHour_Load(object sender, EventArgs e)
        {

        }

        public void napuniCombo()
        {
            for (int i = 0; i < listaPica.Count; i++)
                comboBox1.Items.Add(listaPica[i].Naziv_pica);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zatvoriHappyHour(this, e);
        }
        public void ucitajHappyHours() //metoda kojom iz Form1 ucitavamo sve trenutne happy hour-e u ListView ove kontrole
        {
            MySqlCommand naredba;

            try
            {
                veza.Connect();
                veza.baza.Open();
                naredba = new MySqlCommand("SELECT  naziv_pica, happy_hour_cijena, pocetak, kraj FROM Pice WHERE @POC BETWEEN pocetak AND kraj", veza.baza);
                naredba.Parameters.AddWithValue("@POC", DateTime.Now);

                MySqlDataReader citac = naredba.ExecuteReader();

               

                listView1.Clear();
                listView1.GridLines = true;


                listView1.Columns.Add("Artikal");
                listView1.Columns.Add("Happy hour cijena");
                listView1.Columns.Add("Početak");
                listView1.Columns.Add("Kraj");



                if (citac.HasRows)
                {
                    while (citac.Read())
                    {
                        string naziv = citac[0].ToString();
                        double happy_hour_cijena= int.Parse(citac[1].ToString());
                        DateTime pocetak = DateTime.Parse(citac[2].ToString());
                        DateTime kraj = DateTime.Parse(citac[3].ToString());

                        listView1.Items.Add(new ListViewItem(new String[] { naziv, happy_hour_cijena.ToString(), pocetak.ToString(), kraj.ToString()}));
                        
                    }

                    
                }
                listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                citac.Close();
                veza.baza.Close();
            }
            catch
            {
                // nista
               

            }
        }

    }

}

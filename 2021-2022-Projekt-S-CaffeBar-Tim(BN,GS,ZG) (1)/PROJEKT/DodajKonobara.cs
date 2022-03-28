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
    public partial class DodajKonobara : UserControl
    {
        Baza veza = new Baza();
        public event EventHandler<string> vrati_se;
        public DodajKonobara()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)//dodaj konabara
        {veza.Connect();
            int kontrola = 1;//provjera postoji li korisnik  s istim korisnickim imenom u tablici
            try
            {
                
                veza.baza.Open();
                MySqlCommand command;
                command = new MySqlCommand("SELECT * FROM Konobar WHERE korisnicko_ime='"+textBox3.Text+"'", veza.baza);
                MySqlDataReader reader = command.ExecuteReader();
               
                while (reader.Read())
                {
                    kontrola = 0;
                }
                veza.baza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }



            if (textBox1.Text!="" && textBox2.Text!="" && textBox3.Text!="" && textBox4.Text!="" && kontrola==1)
            {
                try
                {
                   
                    veza.baza.Open();
                    MySqlCommand command;
                    command = new MySqlCommand("INSERT INTO Konobar(ime,prezime,korisnicko_ime,lozinka) VALUES(@ime, @prezime,@korisnicko_ime,@lozinka)", veza.baza);
                    command.Parameters.AddWithValue("@ime", textBox1.Text);
                    command.Parameters.AddWithValue("@prezime", textBox2.Text);
                    command.Parameters.AddWithValue("@korisnicko_ime", textBox3.Text);
                    command.Parameters.AddWithValue("@lozinka", textBox4.Text);
                    command.ExecuteNonQuery();
                    veza.baza.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
              
            }
            else
            {
                MessageBox.Show("Unos novog konobara nije uspio");
            }
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void DodajKonobara_Load(object sender, EventArgs e)
        {

        }

       

        private void button1_Click_1(object sender, EventArgs e)
        {
        if(vrati_se!=null)
            vrati_se(this, "");
       
        }
    }
}

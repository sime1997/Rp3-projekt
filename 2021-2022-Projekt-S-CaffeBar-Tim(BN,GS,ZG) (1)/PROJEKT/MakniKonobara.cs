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
    public partial class MakniKonobara : UserControl
    {
       
        Baza veza = new Baza();
        public event EventHandler<string> povratak;
        public MakniKonobara()
        {
            InitializeComponent();
        }

        private void MakniKonobara_Load(object sender, EventArgs e)//dohvaca sve konobare iz baze
        {
           
        }

        private void btnMakni_Click(object sender, EventArgs e)//micemo sve oznacene konabare
        {
            MySqlCommand command;
            string strItem;

            try
            {
                veza.Connect();
                veza.baza.Open();
                foreach (Object selecteditem in listaKonobara.CheckedItems)
                {
                    strItem = selecteditem as String;
                    command = new MySqlCommand("DELETE FROM Konobar WHERE korisnicko_ime='" + strItem + "'", veza.baza);
                    command.ExecuteNonQuery();

                }
                veza.baza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            listaKonobara.Items.Clear();
            listaKonobara.SelectedIndex = -1;
            this.Help();
        }

        private void povratakMakni_Click(object sender, EventArgs e)
        {
            if (povratak != null)
                povratak(this, null);
        }
        public void Help()
        {
            listaKonobara.Items.Clear();
            listaKonobara.SelectedIndex = -1;
            try
            {
                veza.Connect();
                veza.baza.Open();
                MySqlCommand command;
                command = new MySqlCommand("SELECT korisnicko_ime FROM Konobar", veza.baza);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listaKonobara.Items.Add(reader[0].ToString());
                }
                veza.baza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

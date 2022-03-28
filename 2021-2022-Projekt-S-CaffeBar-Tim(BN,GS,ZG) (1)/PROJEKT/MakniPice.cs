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
    public partial class MakniPice : UserControl
    {
        Baza veza = new Baza();
        public event EventHandler<string> vrati_se;
        public MakniPice()
        {
            InitializeComponent();
           
        }

        private void btnMakni_Click(object sender, EventArgs e)
        {
            List<string> sifre = new List<string>();
            veza.Connect();


            try
            {
                string strItem;
                //iz ponude se micu sva oznacena pica
                veza.baza.Open();
                MySqlCommand command;
                MySqlDataReader reader = null;
                foreach (Object selecteditem in listaPica.CheckedItems)//prvo nadjemo sifre svih pica koja ce se izbaciti da bi ih mogli izbaciti iz tablice Stanje
                {
                   
                    strItem = selecteditem as String;
                    command = new MySqlCommand("SELECT Fsifra_stanje FROM Pice WHERE naziv_pica='" + strItem + "'", veza.baza);
                    reader = command.ExecuteReader();//u readeru imam redove s tim nazivom
                    while(reader.Read())
                    {
                        sifre.Add(reader[0].ToString());
                    }    
                    reader.Close();
                 }
               
                veza.baza.Close();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            //brise iz baza Pice
           try
            {
                string str;
                veza.baza.Open();
                MySqlCommand command2;
                foreach (Object selecteditem in listaPica.CheckedItems)
                {
                    str = selecteditem as String;
                    command2 = new MySqlCommand("DELETE FROM Pice WHERE naziv_pica='" + str + "'", veza.baza);
                    command2.ExecuteNonQuery();
                  
                }
                veza.baza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            //brise iz tablice stanje



            try//brise iz baze stanja na temelju brojeva iz liste sifre
            {
               
                veza.baza.Open();
                MySqlCommand command3;
                foreach (string str2 in sifre)
                {
                   
                    command3 = new MySqlCommand("DELETE FROM Stanje WHERE sifra_stanje='" + str2 + "'", veza.baza);
                    command3.ExecuteNonQuery();
                 }
                veza.baza.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
           
            listaPica.Items.Clear();
            listaPica.SelectedIndex = -1;
            this.Help();
        }

        private void MakniPice_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vrati_se != null)
                vrati_se(this,"");
        }

        public void Help()
        {
            listaPica.Items.Clear();
            listaPica.SelectedIndex = -1;
            try
            {
                veza.Connect();
                veza.baza.Open();
                MySqlCommand command;
                command = new MySqlCommand("SELECT naziv_pica FROM Pice", veza.baza);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listaPica.Items.Add(reader[0].ToString());
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

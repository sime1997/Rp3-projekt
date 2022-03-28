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
    public partial class PromijeniCijenu : UserControl
    {
        Baza veza = new Baza();
        public event EventHandler<string> vrati_se;
        public PromijeniCijenu()
        {
            InitializeComponent();
          
        }

        private void PromijeniCijenu_Load(object sender, EventArgs e)
        {
            try //pregled trenutne ponude pica u kaficu
            {
                veza.Connect();
                veza.baza.Open();
                MySqlCommand command;
                command = new MySqlCommand("SELECT naziv_pica,cijena FROM Pice", veza.baza);
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

        private void btnPromijeniCijenu_Click(object sender, EventArgs e)
        {
            double nova_cijena = Double.Parse(novaCijena.Text);
            try 
            {
                veza.Connect();
                veza.baza.Open();
                MySqlCommand command;
                string strItem;

                foreach (Object selecteditem in listaPica.CheckedItems)//dodavanje nove cijene svim napitcima koji su oznaceni
                {
                    strItem = selecteditem as String;
                    command = new MySqlCommand("UPDATE Pice SET cijena='" + nova_cijena.ToString() + "' WHERE naziv_pica='" + strItem + "'", veza.baza);
                    command.ExecuteNonQuery();
                }
                veza.baza.Close();

            }//string part=Mystring.SubString(0,Mystring.IndexOf(','));
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());

            }
            listaPica.Items.Clear();
            listaPica.SelectedIndex = -1;
            this.PromijeniCijenu_Load(sender, e);
            novaCijena.Text = "";
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vrati_se != null)
                vrati_se(this, "");
        }

        private void listaPica_MouseClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show(listaPica.SelectedItem.ToString());
        }

    }
    }


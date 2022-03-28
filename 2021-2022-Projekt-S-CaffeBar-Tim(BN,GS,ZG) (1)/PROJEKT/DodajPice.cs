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
    public partial class DodajPice : UserControl
    {
        Baza veza = new Baza();
        public event EventHandler<string> povratak;
        public DodajPice()/// popis svih vrsta napisatala
        {
            InitializeComponent();
            SuspendLayout();
            listBox1.Items.Add("Topli napitak");
            listBox1.Items.Add("Pivo");
            listBox1.Items.Add("Vino");
            listBox1.Items.Add("Žestoko piće");
            listBox1.Items.Add("Sok");
            ResumeLayout();
        }

        private void button1_Click(object sender, EventArgs e)//dodaj pice
        {
            if (listBox1.SelectedItems.Count > 0 && textBox1.Text != "" && double.TryParse(textBox2.Text, out _))
            {   string vrsta = listBox1.SelectedItem.ToString();
                string naziv = textBox1.Text;
                string nazivStanje = naziv.ToLower();
                nazivStanje = nazivStanje.Replace(' ', '_');
                //pogledaj u bazi postoji li pice s istim imenom
                int kontrola = 1;
                try//provjera postoji li vec pice u bazi
                {
                    veza.Connect();
                    veza.baza.Open();
                    MySqlCommand command;
                    command = new MySqlCommand("SELECT * FROM Pice WHERE naziv_pica='"+naziv+"'", veza.baza);
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



                if (kontrola == 1)//ne postoji pice s tim imenom vec u bazi
                {

                    try//ubacujemo prvo u tablicu Stanje, dohvacamo sifru i onda ubacujemo u tablicu Pice
                    {
                        veza.Connect();
                        veza.baza.Open();
                        MySqlCommand command;
                        command = new MySqlCommand("INSERT INTO Stanje(naziv,kolicina_kafic,kolicina_skladiste) VALUES(@naziv, @kolicina_kafic,@kolicina_skladiste)", veza.baza);
                        command.Parameters.AddWithValue("@naziv", nazivStanje);
                        command.Parameters.AddWithValue("@kolicina_kafic", 0);
                        command.Parameters.AddWithValue("@kolicina_skladiste", 0);

                        command.ExecuteNonQuery();
                        veza.baza.Close();
                        //dodan na stanje
                        try
                        {
                            int sifra = 0;

                            veza.baza.Open();
                            MySqlCommand command2;
                            command2 = new MySqlCommand("SELECT sifra_stanje FROM Stanje WHERE naziv='" + nazivStanje + "'", veza.baza);
                            MySqlDataReader reader = command2.ExecuteReader();

                            while (reader.Read())
                            {
                                sifra = int.Parse(reader[0].ToString());
                            }
                            veza.baza.Close();
                            //imam sifra sad dodajem u pice
                            try
                            {
                                veza.baza.Open();
                                MySqlCommand command3;
                                command3 = new MySqlCommand("INSERT INTO Pice(vrsta,Fsifra_stanje,naziv_pica,cijena) VALUES(@vrsta,@sifra_stanje,@naziv_pica,@cijena)", veza.baza);
                                command3.Parameters.AddWithValue("@vrsta", vrsta);
                                command3.Parameters.AddWithValue("@sifra_stanje", sifra);
                                command3.Parameters.AddWithValue("@naziv_pica", naziv);
                                command3.Parameters.AddWithValue("@cijena", int.Parse(textBox2.Text));
                                command3.ExecuteNonQuery();
                                veza.baza.Close();
                            }

                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }





                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }

                }
                
            }
            textBox1.Clear();
            textBox2.Clear();
            listBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (povratak != null)
                povratak(this, "");
        }

        private void DodajPice_Load(object sender, EventArgs e)
        {

        }
    }
}

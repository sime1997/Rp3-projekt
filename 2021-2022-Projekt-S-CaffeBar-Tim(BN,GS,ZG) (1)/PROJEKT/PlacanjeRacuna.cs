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
    public partial class PlacanjeRacuna : Form
    {
        private double iznos;
        private double novac;

        public PlacanjeRacuna()
        {
            InitializeComponent();
            if (iznos > 0)
                lblUkupanIznos.Text = iznos + " kn";
        }

        public PlacanjeRacuna(double i)
        {
            iznos = i;
            InitializeComponent();
            if (iznos > 0)
                lblUkupanIznos.Text = iznos + " kn";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (rdbKartica.Checked)
            {
                MessageBox.Show("Plaćeno karticom.");
                this.Close();
            }
            else if (rdbGotovina.Checked)
            {
                if (iznos != 0)
                {
                    try
                    {
                        novac = double.Parse(textBox1.Text);
                        if (novac < iznos)
                        {
                            MessageBox.Show("To nije dovoljno za platiti račun!");
                            textBox1.Text = "";
                        }
                        else
                        {
                            novac -= iznos;
                            MessageBox.Show("Vratite: " + novac.ToString() + " kn.");
                            this.Close();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Niste dobro unijeli podatke! Pokušajte ponovo!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Morate izabrati način plaćanja!");
            }
        }
    }
}




namespace FinaleProjekta
{
    partial class forma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        /// 
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.vlasnik1 = new FinaleProjekta.Vlasnik();
            this.happyHour1 = new FinaleProjekta.HappyHour();
            this.promijeniCijenu1 = new FinaleProjekta.PromijeniCijenu();
            this.makniPice1 = new FinaleProjekta.MakniPice();
            this.makniKonobara1 = new FinaleProjekta.MakniKonobara();
            this.dodajPice1 = new FinaleProjekta.DodajPice();
            this.dodajKonobara1 = new FinaleProjekta.DodajKonobara();
            this.dostava1 = new FinaleProjekta.Dostava();
            this.stol1 = new FinaleProjekta.Stol();
            this.kafic1 = new FinaleProjekta.Kafic();
            this.lsbStanje = new FinaleProjekta.IspisStanja();
            this.prijava1 = new FinaleProjekta.Prijava();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.vlasnik1);
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.happyHour1);
            this.splitContainer1.Panel2.Controls.Add(this.promijeniCijenu1);
            this.splitContainer1.Panel2.Controls.Add(this.makniPice1);
            this.splitContainer1.Panel2.Controls.Add(this.makniKonobara1);
            this.splitContainer1.Panel2.Controls.Add(this.dodajPice1);
            this.splitContainer1.Panel2.Controls.Add(this.dodajKonobara1);
            this.splitContainer1.Panel2.Controls.Add(this.dostava1);
            this.splitContainer1.Panel2.Controls.Add(this.stol1);
            this.splitContainer1.Panel2.Controls.Add(this.kafic1);
            this.splitContainer1.Panel2.Controls.Add(this.lsbStanje);
            this.splitContainer1.Panel2.Controls.Add(this.prijava1);
            this.splitContainer1.Size = new System.Drawing.Size(848, 613);
            this.splitContainer1.SplitterDistance = 190;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 0;
            // 
            // vlasnik1
            // 
            this.vlasnik1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.vlasnik1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vlasnik1.Location = new System.Drawing.Point(0, 283);
            this.vlasnik1.Margin = new System.Windows.Forms.Padding(2);
            this.vlasnik1.Name = "vlasnik1";
            this.vlasnik1.Size = new System.Drawing.Size(190, 330);
            this.vlasnik1.TabIndex = 5;
            this.vlasnik1.makni_konobara += new System.EventHandler<string>(this.vlasnik1_makni_konobara);
            this.vlasnik1.dodaj_konobara += new System.EventHandler<string>(this.vlasnik1_dodaj_konobara);
            this.vlasnik1.promijeni_cijenu += new System.EventHandler<string>(this.vlasnik1_promijeni_cijenu);
            this.vlasnik1.makni_pice += new System.EventHandler<string>(this.vlasnik1_makni_pice);
            this.vlasnik1.dodaj_pice += new System.EventHandler<string>(this.vlasnik1_dodaj_pice_1);
            this.vlasnik1.odjavi_se += new System.EventHandler<string>(this.vlasnik1_odjavi_se);
            this.vlasnik1.naruci += new System.EventHandler<string>(this.vlasnik1_naruci_1);
            this.vlasnik1.happy_hour += new System.EventHandler<string>(this.vlasnik1_happy_hour_2);
            this.vlasnik1.Load += new System.EventHandler(this.vlasnik1_Load);
            // 
            // happyHour1
            // 
            this.happyHour1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.happyHour1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.happyHour1.ListaPica = null;
            this.happyHour1.Location = new System.Drawing.Point(0, 0);
            this.happyHour1.Margin = new System.Windows.Forms.Padding(2);
            this.happyHour1.Name = "happyHour1";
            this.happyHour1.Size = new System.Drawing.Size(655, 613);
            this.happyHour1.TabIndex = 10;
            this.happyHour1.Veza = null;
            // 
            // promijeniCijenu1
            // 
            this.promijeniCijenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.promijeniCijenu1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.promijeniCijenu1.Location = new System.Drawing.Point(0, 0);
            this.promijeniCijenu1.Margin = new System.Windows.Forms.Padding(2);
            this.promijeniCijenu1.Name = "promijeniCijenu1";
            this.promijeniCijenu1.Size = new System.Drawing.Size(655, 613);
            this.promijeniCijenu1.TabIndex = 9;
            this.promijeniCijenu1.vrati_se += new System.EventHandler<string>(this.promijeniCijenu1_vrati_se);
            // 
            // makniPice1
            // 
            this.makniPice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.makniPice1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makniPice1.Location = new System.Drawing.Point(0, 0);
            this.makniPice1.Margin = new System.Windows.Forms.Padding(2);
            this.makniPice1.Name = "makniPice1";
            this.makniPice1.Size = new System.Drawing.Size(655, 613);
            this.makniPice1.TabIndex = 8;
            this.makniPice1.vrati_se += new System.EventHandler<string>(this.makniPice1_vrati_se_1);
            // 
            // makniKonobara1
            // 
            this.makniKonobara1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.makniKonobara1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.makniKonobara1.Location = new System.Drawing.Point(0, 0);
            this.makniKonobara1.Margin = new System.Windows.Forms.Padding(2);
            this.makniKonobara1.Name = "makniKonobara1";
            this.makniKonobara1.Size = new System.Drawing.Size(655, 613);
            this.makniKonobara1.TabIndex = 7;
            this.makniKonobara1.povratak += new System.EventHandler<string>(this.makniKonobara1_povratak);
            // 
            // dodajPice1
            // 
            this.dodajPice1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dodajPice1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajPice1.Location = new System.Drawing.Point(0, 0);
            this.dodajPice1.Margin = new System.Windows.Forms.Padding(2);
            this.dodajPice1.Name = "dodajPice1";
            this.dodajPice1.Size = new System.Drawing.Size(655, 613);
            this.dodajPice1.TabIndex = 6;
            this.dodajPice1.povratak += new System.EventHandler<string>(this.dodajPice1_povratak);
            // 
            // dodajKonobara1
            // 
            this.dodajKonobara1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dodajKonobara1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dodajKonobara1.Location = new System.Drawing.Point(0, 0);
            this.dodajKonobara1.Margin = new System.Windows.Forms.Padding(2);
            this.dodajKonobara1.Name = "dodajKonobara1";
            this.dodajKonobara1.Size = new System.Drawing.Size(655, 613);
            this.dodajKonobara1.TabIndex = 5;
            // 
            // dostava1
            // 
            this.dostava1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dostava1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dostava1.Location = new System.Drawing.Point(0, 0);
            this.dostava1.Margin = new System.Windows.Forms.Padding(2);
            this.dostava1.Name = "dostava1";
            this.dostava1.PopisPica = null;
            this.dostava1.Size = new System.Drawing.Size(655, 613);
            this.dostava1.TabIndex = 4;
            this.dostava1.Veza = null;
            this.dostava1.zatvoriDostavu += new System.EventHandler(this.dostava1_zatvoriDostavu_1);
            // 
            // stol1
            // 
            this.stol1.BrojStola = 0;
            this.stol1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stol1.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stol1.ListaPica = null;
            this.stol1.ListaStanja = null;
            this.stol1.Location = new System.Drawing.Point(0, 0);
            this.stol1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.stol1.Name = "stol1";
            this.stol1.RacunNaStolu = null;
            this.stol1.Size = new System.Drawing.Size(655, 613);
            this.stol1.TabIndex = 3;
            this.stol1.TrenutnoRadi = null;
            this.stol1.Veza = null;
            this.stol1.OstaviOtvoren += new System.EventHandler(this.stol1_OstaviOtvoren);
            // 
            // kafic1
            // 
            this.kafic1.AutoSize = true;
            this.kafic1.Broj_stola = 0;
            this.kafic1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kafic1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kafic1.Konobar = null;
            this.kafic1.ListaPica = null;
            this.kafic1.ListaStanja = null;
            this.kafic1.Location = new System.Drawing.Point(0, 0);
            this.kafic1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.kafic1.Name = "kafic1";
            this.kafic1.Size = new System.Drawing.Size(655, 613);
            this.kafic1.TabIndex = 2;
            this.kafic1.Tag = "-1";
            this.kafic1.otvori_stol += new System.EventHandler<FinaleProjekta.Racun>(this.kafic1_otvori_stol);
            this.kafic1.pokaziStanje += new System.EventHandler<FinaleProjekta.Kafic.ListArgs>(this.kafic1_pokaziStanje);
            this.kafic1.pokaziDostavu += new System.EventHandler<FinaleProjekta.Kafic.ListArgs>(this.kafic1_pokaziDostavu);
            this.kafic1.odjava += new System.EventHandler(this.kafic1_odjava_1);
            // 
            // lsbStanje
            // 
            this.lsbStanje.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsbStanje.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbStanje.Indeks_odabranog = 0;
            this.lsbStanje.JeliVlasnik = 0;
            this.lsbStanje.Kol_kaf = 0;
            this.lsbStanje.Kol_skl = 0;
            this.lsbStanje.Location = new System.Drawing.Point(0, 0);
            this.lsbStanje.Margin = new System.Windows.Forms.Padding(2);
            this.lsbStanje.Name = "lsbStanje";
            this.lsbStanje.Prebaci = 0;
            this.lsbStanje.Size = new System.Drawing.Size(655, 613);
            this.lsbStanje.Stanja = null;
            this.lsbStanje.TabIndex = 1;
            this.lsbStanje.Veza = null;
            this.lsbStanje.zatvoriStanje += new System.EventHandler<string>(this.lsbStanje_zatvoriStanje_1);
            // 
            // prijava1
            // 
            this.prijava1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.prijava1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.prijava1.Location = new System.Drawing.Point(0, 0);
            this.prijava1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.prijava1.Name = "prijava1";
            this.prijava1.Size = new System.Drawing.Size(655, 613);
            this.prijava1.TabIndex = 0;
            this.prijava1.prijava += new System.EventHandler<FinaleProjekta.Konobar>(this.prijava1_prijava_1);
            this.prijava1.prijava_vlasnik += new System.EventHandler<FinaleProjekta.Konobar>(this.prijava1_prijava_vlasnik_1);
            // 
            // forma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(848, 613);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "forma";
            this.Text = "Cafe bar";
            this.Load += new System.EventHandler(this.forma_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Vlasnik vlasnik1;
        private HappyHour happyHour1;
        private PromijeniCijenu promijeniCijenu1;
        private MakniPice makniPice1;
        private MakniKonobara makniKonobara1;
        private DodajPice dodajPice1;
        private DodajKonobara dodajKonobara1;
        private Dostava dostava1;
        private Stol stol1;
        private Kafic kafic1;
        private IspisStanja lsbStanje;
        private Prijava prijava1;
    }
}


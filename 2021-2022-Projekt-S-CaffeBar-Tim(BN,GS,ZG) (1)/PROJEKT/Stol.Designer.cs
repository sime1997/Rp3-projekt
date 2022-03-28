
namespace FinaleProjekta
{
    partial class Stol
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelGumbi = new System.Windows.Forms.FlowLayoutPanel();
            this.lsbPopisNaRacunu = new System.Windows.Forms.ListBox();
            this.btnZakljuciRacun = new System.Windows.Forms.Button();
            this.btnOstaviOtvoren = new System.Windows.Forms.Button();
            this.lsbNaziviPica = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // panelGumbi
            // 
            this.panelGumbi.AutoScroll = true;
            this.panelGumbi.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelGumbi.Location = new System.Drawing.Point(0, 0);
            this.panelGumbi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelGumbi.Name = "panelGumbi";
            this.panelGumbi.Size = new System.Drawing.Size(233, 586);
            this.panelGumbi.TabIndex = 0;
            // 
            // lsbPopisNaRacunu
            // 
            this.lsbPopisNaRacunu.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbPopisNaRacunu.FormattingEnabled = true;
            this.lsbPopisNaRacunu.ItemHeight = 16;
            this.lsbPopisNaRacunu.Location = new System.Drawing.Point(413, 24);
            this.lsbPopisNaRacunu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbPopisNaRacunu.Name = "lsbPopisNaRacunu";
            this.lsbPopisNaRacunu.Size = new System.Drawing.Size(212, 388);
            this.lsbPopisNaRacunu.TabIndex = 1;
            // 
            // btnZakljuciRacun
            // 
            this.btnZakljuciRacun.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnZakljuciRacun.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZakljuciRacun.Location = new System.Drawing.Point(275, 470);
            this.btnZakljuciRacun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnZakljuciRacun.Name = "btnZakljuciRacun";
            this.btnZakljuciRacun.Size = new System.Drawing.Size(136, 75);
            this.btnZakljuciRacun.TabIndex = 2;
            this.btnZakljuciRacun.Text = "Zaključi račun";
            this.btnZakljuciRacun.UseVisualStyleBackColor = false;
            this.btnZakljuciRacun.Click += new System.EventHandler(this.btnZakljuciRacun_Click);
            // 
            // btnOstaviOtvoren
            // 
            this.btnOstaviOtvoren.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnOstaviOtvoren.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOstaviOtvoren.Location = new System.Drawing.Point(463, 470);
            this.btnOstaviOtvoren.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOstaviOtvoren.Name = "btnOstaviOtvoren";
            this.btnOstaviOtvoren.Size = new System.Drawing.Size(124, 75);
            this.btnOstaviOtvoren.TabIndex = 3;
            this.btnOstaviOtvoren.Text = "Ostavi otvoren račun";
            this.btnOstaviOtvoren.UseVisualStyleBackColor = false;
            this.btnOstaviOtvoren.Click += new System.EventHandler(this.btnOstaviOtvoren_Click_1);
            // 
            // lsbNaziviPica
            // 
            this.lsbNaziviPica.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsbNaziviPica.FormattingEnabled = true;
            this.lsbNaziviPica.ItemHeight = 16;
            this.lsbNaziviPica.Location = new System.Drawing.Point(239, 24);
            this.lsbNaziviPica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lsbNaziviPica.Name = "lsbNaziviPica";
            this.lsbNaziviPica.Size = new System.Drawing.Size(160, 388);
            this.lsbNaziviPica.TabIndex = 4;
            // 
            // Stol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lsbNaziviPica);
            this.Controls.Add(this.btnOstaviOtvoren);
            this.Controls.Add(this.btnZakljuciRacun);
            this.Controls.Add(this.lsbPopisNaRacunu);
            this.Controls.Add(this.panelGumbi);
            this.Font = new System.Drawing.Font("Maiandra GD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Stol";
            this.Size = new System.Drawing.Size(651, 586);
            this.Load += new System.EventHandler(this.Stol_Load_1);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelGumbi;
        private System.Windows.Forms.ListBox lsbPopisNaRacunu;
        private System.Windows.Forms.Button btnZakljuciRacun;
        private System.Windows.Forms.Button btnOstaviOtvoren;
        private System.Windows.Forms.ListBox lsbNaziviPica;
    }
}

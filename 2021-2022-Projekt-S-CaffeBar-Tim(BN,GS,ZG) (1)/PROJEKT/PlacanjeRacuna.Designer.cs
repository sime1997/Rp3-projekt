
namespace FinaleProjekta
{
    partial class PlacanjeRacuna
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rdbGotovina = new System.Windows.Forms.RadioButton();
            this.rdbKartica = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUkupanIznos = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(81, 220);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 52);
            this.button1.TabIndex = 23;
            this.button1.Text = "Zaključi račun";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(152, 174);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(116, 23);
            this.textBox1.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(124, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 21;
            this.label2.Text = "Plaćanje:";
            // 
            // rdbGotovina
            // 
            this.rdbGotovina.AutoSize = true;
            this.rdbGotovina.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbGotovina.Location = new System.Drawing.Point(44, 174);
            this.rdbGotovina.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbGotovina.Name = "rdbGotovina";
            this.rdbGotovina.Size = new System.Drawing.Size(79, 20);
            this.rdbGotovina.TabIndex = 20;
            this.rdbGotovina.TabStop = true;
            this.rdbGotovina.Text = "Gotovina";
            this.rdbGotovina.UseVisualStyleBackColor = true;
            // 
            // rdbKartica
            // 
            this.rdbKartica.AutoSize = true;
            this.rdbKartica.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbKartica.Location = new System.Drawing.Point(57, 130);
            this.rdbKartica.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.rdbKartica.Name = "rdbKartica";
            this.rdbKartica.Size = new System.Drawing.Size(64, 20);
            this.rdbKartica.TabIndex = 19;
            this.rdbKartica.TabStop = true;
            this.rdbKartica.Text = "Kartica";
            this.rdbKartica.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Ukupan iznos:";
            // 
            // lblUkupanIznos
            // 
            this.lblUkupanIznos.AutoSize = true;
            this.lblUkupanIznos.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUkupanIznos.Location = new System.Drawing.Point(208, 58);
            this.lblUkupanIznos.Name = "lblUkupanIznos";
            this.lblUkupanIznos.Size = new System.Drawing.Size(38, 16);
            this.lblUkupanIznos.TabIndex = 17;
            this.lblUkupanIznos.Text = "label1";
            // 
            // PlacanjeRacuna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 308);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rdbGotovina);
            this.Controls.Add(this.rdbKartica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblUkupanIznos);
            this.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PlacanjeRacuna";
            this.Text = "PlacanjeRacuna";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdbGotovina;
        private System.Windows.Forms.RadioButton rdbKartica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUkupanIznos;
        public System.Windows.Forms.Button button1;
    }
}
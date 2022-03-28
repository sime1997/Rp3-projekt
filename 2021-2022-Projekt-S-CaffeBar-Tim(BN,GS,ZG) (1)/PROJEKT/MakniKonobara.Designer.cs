
namespace FinaleProjekta
{
    partial class MakniKonobara
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
            this.label1 = new System.Windows.Forms.Label();
            this.listaKonobara = new System.Windows.Forms.CheckedListBox();
            this.btnMakni = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(2, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberi konobara:";
            // 
            // listaKonobara
            // 
            this.listaKonobara.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listaKonobara.FormattingEnabled = true;
            this.listaKonobara.Location = new System.Drawing.Point(138, 16);
            this.listaKonobara.Margin = new System.Windows.Forms.Padding(2);
            this.listaKonobara.Name = "listaKonobara";
            this.listaKonobara.Size = new System.Drawing.Size(105, 92);
            this.listaKonobara.TabIndex = 1;
            // 
            // btnMakni
            // 
            this.btnMakni.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnMakni.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMakni.Location = new System.Drawing.Point(138, 134);
            this.btnMakni.Margin = new System.Windows.Forms.Padding(2);
            this.btnMakni.Name = "btnMakni";
            this.btnMakni.Size = new System.Drawing.Size(105, 38);
            this.btnMakni.TabIndex = 2;
            this.btnMakni.Text = "Makni konobara";
            this.btnMakni.UseVisualStyleBackColor = false;
            this.btnMakni.Click += new System.EventHandler(this.btnMakni_Click);
            // 
            // MakniKonobara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnMakni);
            this.Controls.Add(this.listaKonobara);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MakniKonobara";
            this.Size = new System.Drawing.Size(252, 178);
            this.Load += new System.EventHandler(this.MakniKonobara_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox listaKonobara;
        private System.Windows.Forms.Button btnMakni;
    }
}

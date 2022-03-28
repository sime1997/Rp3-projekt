
namespace FinaleProjekta
{
    partial class PromijeniCijenu
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
            this.listaPica = new System.Windows.Forms.CheckedListBox();
            this.btnPromijeniCijenu = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.novaCijena = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberi piće:";
            // 
            // listaPica
            // 
            this.listaPica.FormattingEnabled = true;
            this.listaPica.Location = new System.Drawing.Point(100, 12);
            this.listaPica.Margin = new System.Windows.Forms.Padding(2);
            this.listaPica.Name = "listaPica";
            this.listaPica.Size = new System.Drawing.Size(192, 136);
            this.listaPica.TabIndex = 1;
            this.listaPica.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listaPica_MouseClick);
            // 
            // btnPromijeniCijenu
            // 
            this.btnPromijeniCijenu.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnPromijeniCijenu.Location = new System.Drawing.Point(100, 249);
            this.btnPromijeniCijenu.Margin = new System.Windows.Forms.Padding(2);
            this.btnPromijeniCijenu.Name = "btnPromijeniCijenu";
            this.btnPromijeniCijenu.Size = new System.Drawing.Size(191, 38);
            this.btnPromijeniCijenu.TabIndex = 2;
            this.btnPromijeniCijenu.Text = "Promijeni cijenu";
            this.btnPromijeniCijenu.UseVisualStyleBackColor = false;
            this.btnPromijeniCijenu.Click += new System.EventHandler(this.btnPromijeniCijenu_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 194);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nova cijena:";
            // 
            // novaCijena
            // 
            this.novaCijena.Location = new System.Drawing.Point(100, 194);
            this.novaCijena.Margin = new System.Windows.Forms.Padding(2);
            this.novaCijena.Name = "novaCijena";
            this.novaCijena.Size = new System.Drawing.Size(192, 27);
            this.novaCijena.TabIndex = 4;
           
            // 
            // PromijeniCijenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.novaCijena);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnPromijeniCijenu);
            this.Controls.Add(this.listaPica);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Maiandra GD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "PromijeniCijenu";
            this.Size = new System.Drawing.Size(294, 297);
            this.Load += new System.EventHandler(this.PromijeniCijenu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox listaPica;
        private System.Windows.Forms.Button btnPromijeniCijenu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox novaCijena;
    }
}

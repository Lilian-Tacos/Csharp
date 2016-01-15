namespace Pendu
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.motaff = new System.Windows.Forms.Label();
            this.buttoninit = new System.Windows.Forms.Button();
            this.inlettre = new System.Windows.Forms.TextBox();
            this.inmot = new System.Windows.Forms.TextBox();
            this.validermot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fautes = new System.Windows.Forms.Label();
            this.fin = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // motaff
            // 
            this.motaff.AutoSize = true;
            this.motaff.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.motaff.Location = new System.Drawing.Point(138, 103);
            this.motaff.Name = "motaff";
            this.motaff.Size = new System.Drawing.Size(70, 26);
            this.motaff.TabIndex = 0;
            this.motaff.Text = "label1";
            // 
            // buttoninit
            // 
            this.buttoninit.Location = new System.Drawing.Point(126, 166);
            this.buttoninit.Name = "buttoninit";
            this.buttoninit.Size = new System.Drawing.Size(75, 23);
            this.buttoninit.TabIndex = 1;
            this.buttoninit.Text = "Nouveau";
            this.buttoninit.UseVisualStyleBackColor = true;
            this.buttoninit.Click += new System.EventHandler(this.buttoninit_Click);
            // 
            // inlettre
            // 
            this.inlettre.Location = new System.Drawing.Point(126, 64);
            this.inlettre.Name = "inlettre";
            this.inlettre.Size = new System.Drawing.Size(100, 20);
            this.inlettre.TabIndex = 2;
            this.inlettre.TextChanged += new System.EventHandler(this.inlettre_TextChanged);
            // 
            // inmot
            // 
            this.inmot.Location = new System.Drawing.Point(126, 24);
            this.inmot.Name = "inmot";
            this.inmot.Size = new System.Drawing.Size(100, 20);
            this.inmot.TabIndex = 3;
            // 
            // validermot
            // 
            this.validermot.Location = new System.Drawing.Point(276, 21);
            this.validermot.Name = "validermot";
            this.validermot.Size = new System.Drawing.Size(75, 23);
            this.validermot.TabIndex = 4;
            this.validermot.Text = "Valider mot";
            this.validermot.UseVisualStyleBackColor = true;
            this.validermot.Click += new System.EventHandler(this.validermot_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Mot";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Lettre";
            // 
            // fautes
            // 
            this.fautes.AutoSize = true;
            this.fautes.Location = new System.Drawing.Point(313, 108);
            this.fautes.Name = "fautes";
            this.fautes.Size = new System.Drawing.Size(39, 13);
            this.fautes.TabIndex = 7;
            this.fautes.Text = "Fautes";
            // 
            // fin
            // 
            this.fin.AutoSize = true;
            this.fin.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fin.Location = new System.Drawing.Point(69, 227);
            this.fin.Name = "fin";
            this.fin.Size = new System.Drawing.Size(139, 46);
            this.fin.TabIndex = 8;
            this.fin.Text = "Gagné";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 350);
            this.Controls.Add(this.fin);
            this.Controls.Add(this.fautes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.validermot);
            this.Controls.Add(this.inmot);
            this.Controls.Add(this.inlettre);
            this.Controls.Add(this.buttoninit);
            this.Controls.Add(this.motaff);
            this.Name = "Form1";
            this.Text = "Pendu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label motaff;
        private System.Windows.Forms.Button buttoninit;
        private System.Windows.Forms.TextBox inlettre;
        private System.Windows.Forms.TextBox inmot;
        private System.Windows.Forms.Button validermot;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label fautes;
        private System.Windows.Forms.Label fin;
    }
}


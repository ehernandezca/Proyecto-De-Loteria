namespace Proyecto_De_Loteria
{
    partial class Inicio
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
            this.BtnFormasDeGanar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnMultijugador = new System.Windows.Forms.Button();
            this.btnJugarSolo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnFormasDeGanar
            // 
            this.BtnFormasDeGanar.Location = new System.Drawing.Point(57, 120);
            this.BtnFormasDeGanar.Name = "BtnFormasDeGanar";
            this.BtnFormasDeGanar.Size = new System.Drawing.Size(114, 35);
            this.BtnFormasDeGanar.TabIndex = 7;
            this.BtnFormasDeGanar.Text = "Drag & Drop";
            this.BtnFormasDeGanar.UseVisualStyleBackColor = true;
            this.BtnFormasDeGanar.Click += new System.EventHandler(this.BtnFormasDeGanar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(57, 161);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 6;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnMultijugador
            // 
            this.btnMultijugador.Location = new System.Drawing.Point(57, 91);
            this.btnMultijugador.Name = "btnMultijugador";
            this.btnMultijugador.Size = new System.Drawing.Size(75, 23);
            this.btnMultijugador.TabIndex = 5;
            this.btnMultijugador.Text = "Multijugador";
            this.btnMultijugador.UseVisualStyleBackColor = true;
            this.btnMultijugador.Click += new System.EventHandler(this.btnMultijugador_Click);
            // 
            // btnJugarSolo
            // 
            this.btnJugarSolo.Location = new System.Drawing.Point(57, 51);
            this.btnJugarSolo.Name = "btnJugarSolo";
            this.btnJugarSolo.Size = new System.Drawing.Size(75, 23);
            this.btnJugarSolo.TabIndex = 4;
            this.btnJugarSolo.Text = "Jugar solo";
            this.btnJugarSolo.UseVisualStyleBackColor = true;
            this.btnJugarSolo.Click += new System.EventHandler(this.btnJugarSolo_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(254, 340);
            this.Controls.Add(this.BtnFormasDeGanar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnMultijugador);
            this.Controls.Add(this.btnJugarSolo);
            this.Name = "Inicio";
            this.Text = "Inicio";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BtnFormasDeGanar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnMultijugador;
        private System.Windows.Forms.Button btnJugarSolo;
    }
}
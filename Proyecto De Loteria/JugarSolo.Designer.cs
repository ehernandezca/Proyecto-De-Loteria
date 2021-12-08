namespace Proyecto_De_Loteria
{
    partial class JugarSolo
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
            this.SuspendLayout();
            // 
            // JugarSolo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1130, 652);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "JugarSolo";
            this.Text = "JugarSolo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.JugarSolo_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BtnBuenas;
        private System.Windows.Forms.Button Btncartas;
        private System.Windows.Forms.Button BtnIniciar;
        private System.Windows.Forms.Button BtnCrearTabla;
        private System.Windows.Forms.Button BtnIralmenu;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Generar1;
        private System.Windows.Forms.Button Generar2;
        private System.Windows.Forms.Button Generar3;
        private System.Windows.Forms.Button Generar4;
        private System.Windows.Forms.Button Btnregresar;
        private System.Windows.Forms.Button btnmenos;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label lblcuenta;
        private System.Windows.Forms.Label lblcontadordecartas;
        private System.Windows.Forms.RadioButton RadioDiaonalInveso;
        private System.Windows.Forms.RadioButton RadioDosDiagonales;
        private System.Windows.Forms.RadioButton RadioGanarEnPolla;
        private System.Windows.Forms.RadioButton RadioDiagonal;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton RadioHorizontal;
        private System.Windows.Forms.Button BtnCPU;
        private System.Windows.Forms.Button BtnQuitar;
    }
}
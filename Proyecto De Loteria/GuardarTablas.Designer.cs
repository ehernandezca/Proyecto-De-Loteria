namespace Proyecto_De_Loteria
{
    partial class GuardarTablas
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
            this.Regresar = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.txtnombretabla = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Regresar
            // 
            this.Regresar.Location = new System.Drawing.Point(148, 203);
            this.Regresar.Name = "Regresar";
            this.Regresar.Size = new System.Drawing.Size(115, 36);
            this.Regresar.TabIndex = 0;
            this.Regresar.Text = "Regresar";
            this.Regresar.UseVisualStyleBackColor = true;
            this.Regresar.Click += new System.EventHandler(this.Regresar_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(148, 149);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(115, 36);
            this.BtnGuardar.TabIndex = 1;
            this.BtnGuardar.Text = "Guardar Tabla";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // txtnombretabla
            // 
            this.txtnombretabla.Location = new System.Drawing.Point(148, 110);
            this.txtnombretabla.Name = "txtnombretabla";
            this.txtnombretabla.Size = new System.Drawing.Size(115, 20);
            this.txtnombretabla.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombra la tabla";
            // 
            // GuardarTablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(347, 295);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtnombretabla);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.Regresar);
            this.Name = "GuardarTablas";
            this.Text = "Drag";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Drag_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Drag_DragEnter);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Drag_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Regresar;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.TextBox txtnombretabla;
        private System.Windows.Forms.Label label1;
    }
}
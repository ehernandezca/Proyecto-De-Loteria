using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_De_Loteria
{
    public partial class CrearTablas : Form
    {
        int[] mazo = new int[54];
        int[] cartas = new int[54];
        Random r = new Random();
        int X = 0, Y = 0;
        int contador, contador2;
        PictureBox[,] tabla1 = new PictureBox[5, 5];
        PictureBox[,] tabla2 = new PictureBox[5, 5];
        PictureBox[,] tabla3 = new PictureBox[5, 5];
        PictureBox[,] tabla4 = new PictureBox[5, 5];
        public CrearTablas()
        {
            InitializeComponent();
        }
        private void CREARTABLA1()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla1[i, j] = new PictureBox();
                    tabla1[i, j].Location = new Point(((i + 1) * 45), ((j + 2) * 65));
                    tabla1[i, j].Size = new Size(40, 60);
                    tabla1[i, j].BackColor = Color.White;
                    this.Controls.Add(tabla1[i, j]);
                }
            }
        }
        private void CREARTABLA2()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla2[i, j] = new PictureBox();
                    tabla2[i, j].Location = new Point(((i + 7) * 45), ((j + 2) * 65));
                    tabla2[i, j].Size = new Size(40, 60);
                    tabla2[i, j].BackColor = Color.White;
                    this.Controls.Add(tabla2[i, j]);
                }
            }
        }
        private void CREARTABLA3()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla3[i, j] = new PictureBox();
                    tabla3[i, j].Location = new Point(((i + 13) * 45), ((j + 2) * 65));
                    tabla3[i, j].Size = new Size(40, 60);
                    tabla3[i, j].BackColor = Color.White;
                    this.Controls.Add(tabla3[i, j]);
                }
            }
        }

        private void BtnBarajear_Click(object sender, EventArgs e)
        {
            int swap = 0;
            mazo = new int[54];
            for (int i = 0; i < mazo.Length; i++)
            {
                mazo[i] = i + 1;
            }
            for (int i = 0; i < mazo.Length; i++)
            {
                int aleatorio = r.Next(0, 53);
                swap = mazo[i];
                mazo[i] = mazo[r.Next(0, 53)];
                mazo[r.Next(0, 53)] = swap;
            }
            X = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla1[i, j].Image = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + mazo[X++] + ".jpeg");
                    tabla1[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Multijugador JugarMultiJugador = new Multijugador();
            JugarMultiJugador.Visible = true;
            Visible = false;
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            JugarSolo Solo = new JugarSolo();
            Solo.Visible = true;
            Visible = true;
        }

        private void CrearTablas_Load_1(object sender, EventArgs e)
        {
            // 
            // BtnCrearTablas
            // 
            this.BtnCrearTablas = new System.Windows.Forms.Button();
            this.BtnCrearTablas.BackColor = System.Drawing.Color.MintCream;
            this.BtnCrearTablas.ForeColor = System.Drawing.Color.Black;
            this.BtnCrearTablas.Location = new System.Drawing.Point(435, 23);
            this.BtnCrearTablas.Name = "BtnCrearTablas";
            this.BtnCrearTablas.Size = new System.Drawing.Size(95, 32);
            this.BtnCrearTablas.TabIndex = 8;
            this.BtnCrearTablas.Text = "Crear Tablas";
            this.BtnCrearTablas.UseVisualStyleBackColor = false;
            this.BtnCrearTablas.Click += new System.EventHandler(this.BtnCrearTablas_Click);
            this.Controls.Add(this.BtnCrearTablas);
            // 
            // groupBox1
            // 
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.BackColor = System.Drawing.Color.Cornsilk;
            
            this.groupBox1.Location = new System.Drawing.Point(120, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 48);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tablas";
            this.Controls.Add(this.groupBox1);
            // 
            // Radio4
            // 
            this.Radio4 = new System.Windows.Forms.RadioButton();
            this.Radio4.AutoSize = true;
            this.Radio4.Location = new System.Drawing.Point(217, 19);
            this.Radio4.Name = "Radio4";
            this.Radio4.Size = new System.Drawing.Size(66, 17);
            this.Radio4.TabIndex = 3;
            this.Radio4.TabStop = true;
            this.Radio4.Text = "4 Tablas";
            this.Radio4.UseVisualStyleBackColor = true;
            this.Controls.Add(this.Radio4);
            this.groupBox1.Controls.Add(this.Radio4);
            // 
            // Radio3
            // 
            this.Radio3 = new System.Windows.Forms.RadioButton();
            this.Radio3.AutoSize = true;
            this.Radio3.Location = new System.Drawing.Point(145, 19);
            this.Radio3.Name = "Radio3";
            this.Radio3.Size = new System.Drawing.Size(66, 17);
            this.Radio3.TabIndex = 2;
            this.Radio3.TabStop = true;
            this.Radio3.Text = "3 Tablas";
            this.Radio3.UseVisualStyleBackColor = true;
            this.Controls.Add(this.Radio3);
            this.groupBox1.Controls.Add(this.Radio3);
            // 
            // Radio2
            // 
            this.Radio2 = new System.Windows.Forms.RadioButton();
            this.Radio2.AutoSize = true;
            this.Radio2.Location = new System.Drawing.Point(73, 19);
            this.Radio2.Name = "Radio2";
            this.Radio2.Size = new System.Drawing.Size(66, 17);
            this.Radio2.TabIndex = 1;
            this.Radio2.TabStop = true;
            this.Radio2.Text = "2 Tablas";
            this.Radio2.UseVisualStyleBackColor = true;
            this.Controls.Add(this.Radio2);
            this.groupBox1.Controls.Add(this.Radio2);
            // 
            // Radio1
            // 
            this.Radio1 = new System.Windows.Forms.RadioButton();
            this.Radio1.AutoSize = true;
            this.Radio1.Location = new System.Drawing.Point(6, 19);
            this.Radio1.Name = "Radio1";
            this.Radio1.Size = new System.Drawing.Size(61, 17);
            this.Radio1.TabIndex = 0;
            this.Radio1.TabStop = true;
            this.Radio1.Text = "1 Tabla";
            this.Radio1.UseVisualStyleBackColor = true;
            this.Controls.Add(this.Radio1);
            this.groupBox1.Controls.Add(this.Radio1);
            // 
            // BtnRegresar
            // 
            this.BtnRegresar = new System.Windows.Forms.Button();
            this.BtnRegresar.BackColor = System.Drawing.Color.MintCream;
            this.BtnRegresar.ForeColor = System.Drawing.Color.Blue;
            this.BtnRegresar.Location = new System.Drawing.Point(12, 12);
            this.BtnRegresar.Name = "BtnRegresar";
            this.BtnRegresar.Size = new System.Drawing.Size(88, 48);
            this.BtnRegresar.TabIndex = 6;
            this.BtnRegresar.Text = "Jugar En Solitario";
            this.BtnRegresar.UseVisualStyleBackColor = false;
            this.BtnRegresar.Click += new System.EventHandler(this.BtnRegresar_Click);
            this.Controls.Add(this.BtnRegresar);
            // 
            // BtnGuardarTabla1
            // 
            this.BtnGuardarTabla1 = new System.Windows.Forms.Button();
            this.BtnGuardarTabla1.BackColor = System.Drawing.Color.MintCream;
            this.BtnGuardarTabla1.ForeColor = System.Drawing.Color.Blue;
            this.BtnGuardarTabla1.Location = new System.Drawing.Point(106, 478);
            this.BtnGuardarTabla1.Name = "BtnGuardarTabla1";
            this.BtnGuardarTabla1.Size = new System.Drawing.Size(88, 35);
            this.BtnGuardarTabla1.TabIndex = 9;
            this.BtnGuardarTabla1.Text = "GuardarTabla 1";
            this.BtnGuardarTabla1.UseVisualStyleBackColor = false;
            this.BtnGuardarTabla1.Visible = false;
            this.Controls.Add(this.BtnGuardarTabla1);
            // 
            // BtnGuardarTabla2
            // 
            this.BtnGuardarTabla2 = new System.Windows.Forms.Button();
            this.BtnGuardarTabla2.BackColor = System.Drawing.Color.MintCream;
            this.BtnGuardarTabla2.ForeColor = System.Drawing.Color.Blue;
            this.BtnGuardarTabla2.Location = new System.Drawing.Point(391, 478);
            this.BtnGuardarTabla2.Name = "BtnGuardarTabla2";
            this.BtnGuardarTabla2.Size = new System.Drawing.Size(88, 35);
            this.BtnGuardarTabla2.TabIndex = 10;
            this.BtnGuardarTabla2.Text = "GuardarTabla 2";
            this.BtnGuardarTabla2.UseVisualStyleBackColor = false;
            this.BtnGuardarTabla2.Visible = false;
            this.Controls.Add(this.BtnGuardarTabla2);
            // 
            // BtnGuardarTabla3
            // 
            this.BtnGuardarTabla3 = new System.Windows.Forms.Button();
            this.BtnGuardarTabla3.BackColor = System.Drawing.Color.White;
            this.BtnGuardarTabla3.ForeColor = System.Drawing.Color.Blue;
            this.BtnGuardarTabla3.Location = new System.Drawing.Point(649, 478);
            this.BtnGuardarTabla3.Name = "BtnGuardarTabla3";
            this.BtnGuardarTabla3.Size = new System.Drawing.Size(88, 35);
            this.BtnGuardarTabla3.TabIndex = 11;
            this.BtnGuardarTabla3.Text = "GuardarTabla 3";
            this.BtnGuardarTabla3.UseVisualStyleBackColor = false;
            this.BtnGuardarTabla3.Visible = false;
            this.Controls.Add(this.BtnGuardarTabla3);
            // 
            // BtnGuardarTabla4
            // 
            this.BtnGuardarTabla4 = new System.Windows.Forms.Button();
            this.BtnGuardarTabla4.BackColor = System.Drawing.Color.Aqua;
            this.BtnGuardarTabla4.ForeColor = System.Drawing.Color.Blue;
            this.BtnGuardarTabla4.Location = new System.Drawing.Point(914, 478);
            this.BtnGuardarTabla4.Name = "BtnGuardarTabla4";
            this.BtnGuardarTabla4.Size = new System.Drawing.Size(88, 35);
            this.BtnGuardarTabla4.TabIndex = 12;
            this.BtnGuardarTabla4.Text = "GuardarTabla 4";
            this.BtnGuardarTabla4.UseVisualStyleBackColor = false;
            this.BtnGuardarTabla4.Visible = false;
            this.Controls.Add(this.BtnGuardarTabla4);
            // 
            // BtnBarajear
            // 
            this.BtnBarajear = new System.Windows.Forms.Button();
            this.BtnBarajear.BackColor = System.Drawing.Color.White;
            this.BtnBarajear.ForeColor = System.Drawing.Color.Black;
            this.BtnBarajear.Location = new System.Drawing.Point(548, 23);
            this.BtnBarajear.Name = "BtnBarajear";
            this.BtnBarajear.Size = new System.Drawing.Size(95, 32);
            this.BtnBarajear.TabIndex = 13;
            this.BtnBarajear.Text = "Barajear";
            this.BtnBarajear.UseVisualStyleBackColor = false;
            this.BtnBarajear.Click += new System.EventHandler(this.BtnBarajear_Click);
            this.Controls.Add(this.BtnBarajear);
            // 
            // button1
            // 
            this.button1 = new System.Windows.Forms.Button();
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Location = new System.Drawing.Point(12, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 48);
            this.button1.TabIndex = 14;
            this.button1.Text = "Jugar En Multijugador";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.Controls.Add(this.button1);
            // 
            // CrearTablas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Red;
            this.ClientSize = new System.Drawing.Size(1120, 678);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BtnBarajear);
            this.Controls.Add(this.BtnGuardarTabla4);
            this.Controls.Add(this.BtnGuardarTabla3);
            this.Controls.Add(this.BtnGuardarTabla2);
            this.Controls.Add(this.BtnGuardarTabla1);
            this.Controls.Add(this.BtnCrearTablas);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnRegresar);
            this.Name = "CrearTablas";
            this.Text = "CrearTablas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
        }

        private void CREARTABLA4()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla4[i, j] = new PictureBox();
                    tabla4[i, j].Location = new Point(((i + 19) * 45), ((j + 2) * 65));
                    tabla4[i, j].Size = new Size(40, 60);
                    tabla4[i, j].BackColor = Color.White;
                    this.Controls.Add(tabla4[i, j]);
                }
            }
            
            
        }

        private void BtnCrearTablas_Click(object sender, EventArgs e)
        {
            if (Radio1.Checked)
            {
                CREARTABLA1();
                BtnGuardarTabla1.Visible = true;
                BtnGuardarTabla2.Visible = false;
                BtnGuardarTabla3.Visible = false;
                BtnGuardarTabla4.Visible = false;
                
            }
           
            if (Radio2.Checked)
            {
                CREARTABLA1();
                BtnGuardarTabla1.Visible = true;
                CREARTABLA2();
                BtnGuardarTabla2.Visible = true;
                BtnGuardarTabla3.Visible = false;
                BtnGuardarTabla4.Visible = false;
            }
            if (Radio3.Checked)
            {
                CREARTABLA1();
                BtnGuardarTabla1.Visible = true;
                CREARTABLA2();
                BtnGuardarTabla2.Visible = true;
                CREARTABLA3();
                BtnGuardarTabla3.Visible = true;
                BtnGuardarTabla4.Visible = false;
            }
            if (Radio4.Checked)
            {
                CREARTABLA1();
                BtnGuardarTabla1.Visible = true;
                CREARTABLA2();
                BtnGuardarTabla2.Visible = true;
                CREARTABLA3();
                BtnGuardarTabla3.Visible = true;
                CREARTABLA4();
                BtnGuardarTabla4.Visible = true;
            }
        }
    }
}

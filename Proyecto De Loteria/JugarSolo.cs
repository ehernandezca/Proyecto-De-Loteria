using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Proyecto_De_Loteria
{
    public partial class JugarSolo : Form
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        List<VoiceInfo> vocesInfo = new List<VoiceInfo>();
        int[] mazo = new int[54];
        int temp = 0;
        int R = 3;
        int[] revueltas;
        int[] Point;
        int contador = 54;
        Image[] cartas = new Image[54];
        Random r = new Random();
        int X = 0, Y = 0;
        int tiempo = 1000;
        bool Z = false;
        bool vertical = false;
        bool diagonal = false;
        bool Horizontal = false;
        bool PollaG = false;
        bool DosDiagonales = false;
        int resumen;
        int regresar;
        int regresar2;
        int cuenta = 1;
        int[] mazoCartas;
        int i = 0;
        int pos, leer;
        string[] tarjetaCopia = new string[54];
        int[] tarjeta = new int[54];
        string[,] tabla2Copia = new string[5, 5];
        string[,] tabla3Copia = new string[5, 5];
        string[,] tabla4Copia = new string[5, 5];
        string[,] tabla1Copia = new string[5, 5];
        PictureBox[,] tabla1 = new PictureBox[5, 5];
        PictureBox[,] tabla2 = new PictureBox[5, 5];
        PictureBox[,] tabla3 = new PictureBox[5, 5];
        PictureBox[,] tabla4 = new PictureBox[5, 5];
        public JugarSolo()
        {
            InitializeComponent();
            int[] mazo = new int[54];
            int[] point = barajearCartas(mazo);
            

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                   
                    tabla1[i, j] = new PictureBox();
                    tabla1[i, j].Size = new Size(73, 107);
                    tabla1[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla1[i, j].Location = new Point((i * 70) + 50, (j * 105) + 25);
                    tabla1[i, j].Click += new EventHandler(ponerFicha);
                    tabla1[i, j].DoubleClick += new EventHandler(QuitarFicha);
                    this.Controls.Add(tabla1[i, j]);

                    tabla2[i, j] = new PictureBox();
                    tabla2[i, j].Size = new Size(73, 107);
                    tabla2[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla2[i, j].Location = new Point((i * 70) + 450, (j * 105) + 25);
                    tabla2[i, j].Click += new EventHandler(ponerFicha);
                    tabla2[i, j].DoubleClick += new EventHandler(QuitarFicha);
                    this.Controls.Add(tabla2[i, j]);

                    tabla3[i, j] = new PictureBox();
                    tabla3[i, j].Size = new Size(50, 80);
                    tabla3[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla3[i, j].Click += new EventHandler(ponerFicha);
                    tabla3[i, j].DoubleClick += new EventHandler(QuitarFicha);
                    tabla3[i, j].Location = new Point((i * 40) + 610, (j * 75) + 125);
                    tabla3[i, j].Visible = false;
                    this.Controls.Add(tabla3[i, j]);

                    tabla4[i, j] = new PictureBox();
                    tabla4[i, j].Size = new Size(50, 80);
                    tabla4[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla4[i, j].Click += new EventHandler(ponerFicha);
                    tabla4[i, j].DoubleClick += new EventHandler(QuitarFicha);
                    tabla4[i, j].Location = new Point((i * 50) + 960, (j * 80) + 270);
                    tabla4[i, j].Visible = false;
                    this.Controls.Add(tabla4[i, j]);

                }
            }
        }
        private void BtnIralmenu_Click(object sender, EventArgs e)
        {
            Inicio Regresar = new Inicio();
            Regresar.Visible = true;
            Visible = false;
        }
        private void QuitarFicha(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = null;
            ((PictureBox)sender).Name = "";
        }

        private void BtnCrearTabla_Click(object sender, EventArgs e)
        {
            CrearTablas crear = new CrearTablas();
            crear.Visible = true;
            Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }
        private void barajear()
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

        }

        private void Generar1_Click(object sender, EventArgs e)
        {
            mazoCartas = new int[54];
            Point = barajearCartas(mazoCartas);

            int x = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla1[i, j].BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (Point[x++]) + ".jpeg");
                    tabla1[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla1Copia[i, j] = Point[x - 1] + "";
                    tabla2[i, j].Visible = false;
                    tabla3[i, j].Visible = false;
                    tabla4[i, j].Visible = false;
                    tabla1[i, j].Size = new Size(50, 80);
                    tabla1[i, j].Location = new Point((i * 50) + 120, (j * 80) + 270);
                }
            }

        }
        
        private void Generar2_Click(object sender, EventArgs e)
        {
            int[] mazo = new int[54];
            int[] point = barajearCartas(mazo);

            int x = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla2[i, j].BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (point[x++]) + ".jpeg");
                    tabla2[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla2Copia[i, j] = point[x - 1] + "";
                    tabla1[i, j].Visible = true;
                    tabla2[i, j].Visible = true;
                    tabla3[i, j].Visible = false;
                    tabla4[i, j].Visible = false;
                    tabla2[i, j].Size = new Size(50, 80);
                    tabla2[i, j].Location = new Point((i * 50) + 400, (j * 80) + 270);
                    tabla1[i, j].Size = new Size(50, 80);
                    tabla1[i, j].Location = new Point((i * 50) + 120, (j * 80) + 270);
                }
            }
        }

        private void Generar3_Click(object sender, EventArgs e)
        {
            int[] mazo = new int[54];
            int[] point = barajearCartas(mazo);

            int x = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla3[i, j].BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (point[x++]) + ".jpeg");
                    tabla3[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla3Copia[i, j] = point[x - 1] + "";
                    tabla4[i, j].Visible = false;
                    tabla3[i, j].Visible = true;
                    tabla2[i, j].Visible = true;
                    tabla3[i, j].Size = new Size(50, 80);
                    tabla1[i, j].Size = new Size(50, 80);
                    tabla1[i, j].Location = new Point((i * 50) + 120, (j * 80) + 270);
                    tabla2[i, j].Size = new Size(50, 80);
                    tabla2[i, j].Location = new Point((i * 50) + 400, (j * 80) + 270);
                    tabla3[i, j].Location = new Point((i * 50) + 680, (j * 80) + 270);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + revueltas[pos++] + ".jpeg");
            leer = revueltas[pos - 1];
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            tarjeta[i++] = revueltas[pos - 1];
            tarjetaCopia[i - 1] = revueltas[pos - 1].ToString();
            resumen = revueltas[pos - 1];
            lblcuenta.Text = (contador - pos).ToString();
            if (revueltas[pos - 1] == revueltas[53])
            {
                timer1.Stop();
                pictureBox2.Image = null;
                BtnIniciar.Enabled = false;
            }
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            temp = 0;
            timer1.Interval = 3000;
            Btnregresar.Enabled = true;

            if (timer1.Enabled)
            {
                timer1.Stop();
                BtnIniciar.Text = "Comenzar";
            }
            else
            {
                timer1.Start();
                BtnIniciar.Text = "Pausar";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = timer1.Interval - tiempo;
                synthesizer.Rate += R;

            }
            catch (Exception)
            {

                MessageBox.Show("No es posible seguir");
            }
        }

        private void lblcontadordecartas_Click(object sender, EventArgs e)
        {

        }

        private void btnmenos_Click(object sender, EventArgs e)
        {
            timer1.Interval = timer1.Interval + tiempo;
        }

        private void Btnsiguiente_Click(object sender, EventArgs e)
        {

        }

        private void Btnregresar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                int atras = tarjeta[pos - (temp + 2)];
                pictureBox2.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + atras + ".jpeg");
                temp++;
                if (atras == tarjeta[0])
                {
                    pictureBox2.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + atras + ".jpeg");
                    MessageBox.Show("Ya no hay cartas");
                    Btnregresar.Enabled = false;
                    Btncartas.Enabled = true;
                }
            }
        }

        private void JugarSolo_Load(object sender, EventArgs e)
        {
            // 
            // pictureBox2
            //
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox2.BackColor = System.Drawing.Color.Beige;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Location = new System.Drawing.Point(148, 14);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(105, 184);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.Controls.Add(this.pictureBox2);
            // 
            // BtnBuenas
            // 
            this.BtnBuenas = new System.Windows.Forms.Button();
            this.BtnBuenas.BackColor = System.Drawing.Color.MintCream;
            this.BtnBuenas.Location = new System.Drawing.Point(276, 155);
            this.BtnBuenas.Name = "BtnBuenas";
            this.BtnBuenas.Size = new System.Drawing.Size(156, 41);
            this.BtnBuenas.TabIndex = 14;
            this.BtnBuenas.Text = "Buenas";
            this.BtnBuenas.UseVisualStyleBackColor = false;
            this.BtnBuenas.Click += new System.EventHandler(this.BtnBuenas_Click);
            this.Controls.Add(this.BtnBuenas);
            // 
            // Btncartas
            // 
            this.Btncartas = new System.Windows.Forms.Button();
            this.Btncartas.BackColor = System.Drawing.Color.MintCream;
            this.Btncartas.Location = new System.Drawing.Point(276, 111);
            this.Btncartas.Name = "Btncartas";
            this.Btncartas.Size = new System.Drawing.Size(156, 38);
            this.Btncartas.TabIndex = 13;
            this.Btncartas.Text = "Cartas";
            this.Btncartas.UseVisualStyleBackColor = false;
            this.Btncartas.Click += new System.EventHandler(this.Btncartas_Click);
            this.Controls.Add(this.Btncartas);
            // 
            // BtnIniciar
            // 
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.BtnIniciar.BackColor = System.Drawing.Color.MintCream;
            this.BtnIniciar.Location = new System.Drawing.Point(276, 12);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(156, 40);
            this.BtnIniciar.TabIndex = 12;
            this.BtnIniciar.Text = "Iniciar";
            this.BtnIniciar.UseVisualStyleBackColor = false;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            this.Controls.Add(this.BtnIniciar);
            // 
            // BtnCrearTabla
            // 
            this.BtnCrearTabla = new System.Windows.Forms.Button();
            this.BtnCrearTabla.BackColor = System.Drawing.Color.MintCream;
            this.BtnCrearTabla.ForeColor = System.Drawing.Color.Black;
            this.BtnCrearTabla.Location = new System.Drawing.Point(445, 12);
            this.BtnCrearTabla.Name = "BtnCrearTabla";
            this.BtnCrearTabla.Size = new System.Drawing.Size(119, 40);
            this.BtnCrearTabla.TabIndex = 11;
            this.BtnCrearTabla.Text = "Crear Tabla";
            this.BtnCrearTabla.UseVisualStyleBackColor = false;
            this.BtnCrearTabla.Click += new System.EventHandler(this.BtnCrearTabla_Click);
            this.Controls.Add(this.BtnCrearTabla);
            // 
            // BtnIralmenu
            // 
            this.BtnIralmenu = new System.Windows.Forms.Button();
            this.BtnIralmenu.BackColor = System.Drawing.Color.White;
            this.BtnIralmenu.ForeColor = System.Drawing.Color.DarkBlue;
            this.BtnIralmenu.Location = new System.Drawing.Point(12, 12);
            this.BtnIralmenu.Name = "BtnIralmenu";
            this.BtnIralmenu.Size = new System.Drawing.Size(113, 34);
            this.BtnIralmenu.TabIndex = 9;
            this.BtnIralmenu.Text = "ir al inicio ";
            this.BtnIralmenu.UseVisualStyleBackColor = false;
            this.BtnIralmenu.Click += new System.EventHandler(this.BtnIralmenu_Click);
            this.Controls.Add(this.BtnIralmenu);
            // 
            // timer1
            // 
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.Location = new System.Drawing.Point(635, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 94);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formas de ganar ";
            this.Controls.Add(this.groupBox1);
            // 
            // RadioDiaonalInveso
            // 
            this.RadioDiaonalInveso = new System.Windows.Forms.RadioButton();
            this.RadioDiaonalInveso.AutoSize = true;
            this.RadioDiaonalInveso.Location = new System.Drawing.Point(107, 66);
            this.RadioDiaonalInveso.Name = "RadioDiaonalInveso";
            this.RadioDiaonalInveso.Size = new System.Drawing.Size(130, 17);
            this.RadioDiaonalInveso.TabIndex = 5;
            this.RadioDiaonalInveso.TabStop = true;
            this.RadioDiaonalInveso.Text = "RadioDiagonalInversa";
            this.RadioDiaonalInveso.UseVisualStyleBackColor = true;
            this.RadioDiaonalInveso.CheckedChanged += new System.EventHandler(this.RadioDiaonalInveso_CheckedChanged);
            this.groupBox1.Controls.Add(this.RadioDiaonalInveso);

            // 
            // RadioDosDiagonales
            // 
            this.RadioDosDiagonales = new System.Windows.Forms.RadioButton();
            this.RadioDosDiagonales.AutoSize = true;
            this.RadioDosDiagonales.Location = new System.Drawing.Point(107, 42);
            this.RadioDosDiagonales.Name = "RadioDosDiagonales";
            this.RadioDosDiagonales.Size = new System.Drawing.Size(100, 17);
            this.RadioDosDiagonales.TabIndex = 4;
            this.RadioDosDiagonales.TabStop = true;
            this.RadioDosDiagonales.Text = "Dos Diagonales";
            this.RadioDosDiagonales.UseVisualStyleBackColor = true;
            this.RadioDosDiagonales.CheckedChanged += new System.EventHandler(this.RadioDosDiagonales_CheckedChanged);
            this.groupBox1.Controls.Add(this.RadioDosDiagonales);
            // 
            // RadioGanarEnPolla
            // 
            this.RadioGanarEnPolla = new System.Windows.Forms.RadioButton();
            this.RadioGanarEnPolla.AutoSize = true;
            this.RadioGanarEnPolla.Location = new System.Drawing.Point(107, 19);
            this.RadioGanarEnPolla.Name = "RadioGanarEnPolla";
            this.RadioGanarEnPolla.Size = new System.Drawing.Size(96, 17);
            this.RadioGanarEnPolla.TabIndex = 3;
            this.RadioGanarEnPolla.TabStop = true;
            this.RadioGanarEnPolla.Text = "Ganar En Polla";
            this.RadioGanarEnPolla.UseVisualStyleBackColor = true;
            this.RadioGanarEnPolla.CheckedChanged += new System.EventHandler(this.RadioGanarEnPolla_CheckedChanged);
            this.groupBox1.Controls.Add(this.RadioGanarEnPolla);
            // 
            // RadioDiagonal
            // 
            this.RadioDiagonal = new System.Windows.Forms.RadioButton();
            this.RadioDiagonal.AutoSize = true;
            this.RadioDiagonal.Location = new System.Drawing.Point(8, 63);
            this.RadioDiagonal.Name = "RadioDiagonal";
            this.RadioDiagonal.Size = new System.Drawing.Size(67, 17);
            this.RadioDiagonal.TabIndex = 2;
            this.RadioDiagonal.TabStop = true;
            this.RadioDiagonal.Text = "Diagonal";
            this.RadioDiagonal.UseVisualStyleBackColor = true;
            this.RadioDiagonal.CheckedChanged += new System.EventHandler(this.RadioDiagonal_CheckedChanged);
            this.groupBox1.Controls.Add(this.RadioDiagonal);
            // 
            // radioButton2
            // 
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(8, 39);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(60, 17);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Vertical";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            this.groupBox1.Controls.Add(this.radioButton2);
            // 
            // RadioHorizontal
            // 
            this.RadioHorizontal = new System.Windows.Forms.RadioButton();
            this.RadioHorizontal.AutoSize = true;
            this.RadioHorizontal.Location = new System.Drawing.Point(8, 19);
            this.RadioHorizontal.Name = "RadioHorizontal";
            this.RadioHorizontal.Size = new System.Drawing.Size(72, 17);
            this.RadioHorizontal.TabIndex = 0;
            this.RadioHorizontal.TabStop = true;
            this.RadioHorizontal.Text = "Horizontal";
            this.RadioHorizontal.UseVisualStyleBackColor = true;
            this.RadioHorizontal.CheckedChanged += new System.EventHandler(this.RadioHorizontal_CheckedChanged);
            this.groupBox1.Controls.Add(this.RadioHorizontal);

            // 
            // Generar1
            // 
            this.Generar1 = new System.Windows.Forms.Button();
            this.Generar1.BackColor = System.Drawing.Color.White;
            this.Generar1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Generar1.Location = new System.Drawing.Point(635, 144);
            this.Generar1.Name = "Generar1";
            this.Generar1.Size = new System.Drawing.Size(93, 34);
            this.Generar1.TabIndex = 17;
            this.Generar1.Text = "Generar Tabla 1 Random";
            this.Generar1.UseVisualStyleBackColor = false;
            this.Generar1.Click += new System.EventHandler(this.Generar1_Click);
            this.Controls.Add(this.Generar1);
            // 
            // Generar2
            // 
            this.Generar2 = new System.Windows.Forms.Button();
            this.Generar2.BackColor = System.Drawing.Color.White;
            this.Generar2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Generar2.Location = new System.Drawing.Point(734, 144);
            this.Generar2.Name = "Generar2";
            this.Generar2.Size = new System.Drawing.Size(93, 34);
            this.Generar2.TabIndex = 18;
            this.Generar2.Text = "Generar Tabla 2 Random";
            this.Generar2.UseVisualStyleBackColor = false;
            this.Generar2.Click += new System.EventHandler(this.Generar2_Click);
            this.Controls.Add(this.Generar2);
            // 
            // Generar3
            // 
            this.Generar3 = new System.Windows.Forms.Button();
            this.Generar3.BackColor = System.Drawing.Color.White;
            this.Generar3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Generar3.Location = new System.Drawing.Point(833, 144);
            this.Generar3.Name = "Generar3";
            this.Generar3.Size = new System.Drawing.Size(93, 34);
            this.Generar3.TabIndex = 19;
            this.Generar3.Text = "Generar Tabla 3 Random";
            this.Generar3.UseVisualStyleBackColor = false;
            this.Generar3.Click += new System.EventHandler(this.Generar3_Click);
            this.Controls.Add(this.Generar3);
            // 
            // Generar4
            // 
            this.Generar4 = new System.Windows.Forms.Button();
            this.Generar4.BackColor = System.Drawing.Color.White;
            this.Generar4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Generar4.Location = new System.Drawing.Point(932, 144);
            this.Generar4.Name = "Generar4";
            this.Generar4.Size = new System.Drawing.Size(93, 34);
            this.Generar4.TabIndex = 20;
            this.Generar4.Text = "Generar Tabla 4 Random";
            this.Generar4.UseVisualStyleBackColor = false;
            this.Generar4.Click += new System.EventHandler(this.Generar4_Click);
            this.Controls.Add(this.Generar4);
            // 
            // Btnregresar
            // 
            this.Btnregresar = new System.Windows.Forms.Button();
            this.Btnregresar.BackColor = System.Drawing.Color.MintCream;
            this.Btnregresar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Btnregresar.Location = new System.Drawing.Point(276, 55);
            this.Btnregresar.Name = "Btnregresar";
            this.Btnregresar.Size = new System.Drawing.Size(156, 23);
            this.Btnregresar.TabIndex = 21;
            this.Btnregresar.Text = "Regresar";
            this.Btnregresar.UseVisualStyleBackColor = false;
            this.Btnregresar.Click += new System.EventHandler(this.Btnregresar_Click);
            this.Controls.Add(this.Btnregresar);
            // 
            // btnmenos
            // 
            this.btnmenos = new System.Windows.Forms.Button();
            this.btnmenos.BackColor = System.Drawing.Color.MintCream;
            this.btnmenos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnmenos.Location = new System.Drawing.Point(276, 82);
            this.btnmenos.Name = "btnmenos";
            this.btnmenos.Size = new System.Drawing.Size(75, 26);
            this.btnmenos.TabIndex = 23;
            this.btnmenos.Text = "-";
            this.btnmenos.UseVisualStyleBackColor = false;
            this.btnmenos.Click += new System.EventHandler(this.btnmenos_Click);
            this.Controls.Add(this.btnmenos);
            // 
            // button4
            // 
            this.button4 = new System.Windows.Forms.Button();
            this.button4.BackColor = System.Drawing.Color.MintCream;
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(357, 82);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 26);
            this.button4.TabIndex = 24;
            this.button4.Text = "+";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            this.Controls.Add(this.button4);
            // 
            // lblcuenta
            // 
            this.lblcuenta = new System.Windows.Forms.Label();
            this.lblcuenta.AutoSize = true;
            this.lblcuenta.Location = new System.Drawing.Point(213, 242);
            this.lblcuenta.Name = "lblcuenta";
            this.lblcuenta.Size = new System.Drawing.Size(40, 13);
            this.lblcuenta.TabIndex = 25;
            this.lblcuenta.Text = "cuenta";
            this.Controls.Add(this.lblcuenta);
            // 
            // lblcontadordecartas
            // 
            this.lblcontadordecartas = new System.Windows.Forms.Label();
            this.lblcontadordecartas.AutoSize = true;
            this.lblcontadordecartas.Location = new System.Drawing.Point(159, 242);
            this.lblcontadordecartas.Name = "lblcontadordecartas";
            this.lblcontadordecartas.Size = new System.Drawing.Size(40, 13);
            this.lblcontadordecartas.TabIndex = 26;
            this.lblcontadordecartas.Text = "cuenta";
            this.lblcontadordecartas.Click += new System.EventHandler(this.lblcontadordecartas_Click);
            this.Controls.Add(this.lblcontadordecartas);
            // 
            // BtnCPU
            // 
            this.BtnCPU = new System.Windows.Forms.Button();
            this.BtnCPU.BackColor = System.Drawing.Color.MintCream;
            this.BtnCPU.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnCPU.Location = new System.Drawing.Point(445, 99);
            this.BtnCPU.Name = "BtnCPU";
            this.BtnCPU.Size = new System.Drawing.Size(119, 50);
            this.BtnCPU.TabIndex = 27;
            this.BtnCPU.Text = "CPU";
            this.BtnCPU.UseVisualStyleBackColor = false;
            this.BtnCPU.Click += new System.EventHandler(this.BtnCPU_Click);
            this.Controls.Add(this.BtnCPU);
            // 
            // BtnQuitar
            // 
            this.BtnQuitar = new System.Windows.Forms.Button();
            this.BtnQuitar.BackColor = System.Drawing.Color.MintCream;
            this.BtnQuitar.Location = new System.Drawing.Point(445, 53);
            this.BtnQuitar.Name = "BtnQuitar";
            this.BtnQuitar.Size = new System.Drawing.Size(119, 38);
            this.BtnQuitar.TabIndex = 28;
            this.BtnQuitar.Text = "Quitar Fichas";
            this.BtnQuitar.UseVisualStyleBackColor = false;
            this.BtnQuitar.Click += new System.EventHandler(this.BtnQuitar_Click);
            this.Controls.Add(this.BtnQuitar);

            for (int i = 0; i < 54; i++)
            {

                cartas[i] = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (i + 1).ToString() + ".jpeg");
            }

            int[] mazo = new int[54];
            revueltas = barajearCartas(mazo);
            pos = 0;
        }

        private void Generar4_Click(object sender, EventArgs e)
        {
            int[] mazo = new int[54];
            int[] point = barajearCartas(mazo);

            int x = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla4[i, j].BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (point[x++]) + ".jpeg");
                    tabla4[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla4Copia[i, j] = point[x - 1] + "";
                    tabla4[i, j].Visible = true;
                    tabla3[i, j].Visible = true;
                    tabla2[i, j].Visible = true;
                    tabla1[i, j].Visible = true;
                    tabla1[i, j].Size = new Size(50, 80);
                    tabla1[i, j].Location = new Point((i * 50) + 120, (j * 80) + 270);
                    tabla2[i, j].Size = new Size(50, 80);
                    tabla2[i, j].Location = new Point((i * 50) + 400, (j * 80) + 270);
                    tabla3[i, j].Size = new Size(50, 80);
                    tabla3[i, j].Location = new Point((i * 50) + 680, (j * 80) + 270);
                }
            }
        }

        private void RadioHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioHorizontal.Checked)
            {
                Horizontal = true;
            }
        }

        private void ponerFicha(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\coca.png");
            ((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;
            ((PictureBox)sender).BackColor = Color.Transparent;
            ((PictureBox)sender).BackgroundImageLayout = ImageLayout.Stretch;
        }
        public int[] mostrar(int[] baraja)
        {
            int inter = 0;
            baraja = new int[54];
            for (int i = 0; i < baraja.Length; i++)
            {
                baraja[i] = i + 1;
            }
            for (int i = 0; i < baraja.Length; i++)
            {
                int aleatorio = r.Next(0, 53);
                inter = baraja[i];
                baraja[i] = baraja[aleatorio];
                baraja[aleatorio] = inter;
            }
            return baraja;
        }
        

        private void Btncartas_Click(object sender, EventArgs e)
        {
            pictureBox2.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + resumen + ".jpeg");
            Btnregresar.Enabled = true;
            temp = 0;
        }


        private void BtnBuenas_Click(object sender, EventArgs e)
        {
            if (diagonal==true)
            {
                GanarDiagonal();
            }
            if (Horizontal==true)
            {
                
            }
            if (PollaG==true)
            {
                
            }
            if (DosDiagonales==true)
            {
              
            }
            
        }

        private void RadioDiagonal_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioDiagonal.Checked)
            {
                diagonal = true;
            }
               
        }

        private void BtnCPU_Click(object sender, EventArgs e)
        {
            CPU COM = new CPU();
            COM.Visible = true;
            Visible = false;
        }

        private void BtnQuitar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla1[i, j].Image = null;
                    tabla2[i, j].Image = null;
                    tabla3[i, j].Image = null;
                    tabla4[i, j].Image = null;
                }
            }
        }

        public int[] barajearCartas(int[] x)
        {
            int swap = 0;
            x = new int[54];
            for (int i = 0; i < x.Length; i++)
            {
                x[i] = i + 1;
            }
            for (int i = 0; i < x.Length; i++)
            {
                int aleatorio = r.Next(0, 54);
                swap = x[i];
                x[i] = x[aleatorio];
                x[aleatorio] = swap;
            }
            return x;
        }

        private void RadioGanarEnPolla_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioGanarEnPolla.Checked)
            {
                
                PollaG = false;
                DosDiagonales = false;

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (vertical)
            {
                vertical = true;  
            }
        }

        private void RadioDiaonalInveso_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void RadioDosDiagonales_CheckedChanged(object sender, EventArgs e)
        {
          
        }
        private void GanarDiagonal()
        {
            for (int i = 0; i < 5; i++)
            {
                if (

                    (tarjetaCopia.Contains(tabla1Copia[i, i]) == true)

                   )
                {
                    if (

                        (tabla1[i, i].Name == "•")

                       )
                    {
                        Z = true;
                    }
                    else
                    {
                        Z = false;
                        break;
                    }
                }
                else
                {
                    Z = false;
                    break;
                }
            }
            if (Z == true)
            {
                timer1.Stop();
                MessageBox.Show("GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Speech.Synthesis;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Threading;
using System.Speech;
using System.Windows.Forms;

namespace Proyecto_De_Loteria
{
    public partial class Multijugador : Form
    {
        private System.Windows.Forms.Button BtnIralmenu;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button BtnBuenas;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Button BtnIniciar;
        private System.Windows.Forms.Button BtnCrearTabla;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button Tabla1R;
        private System.Windows.Forms.Button Tabla2R;
        private System.Windows.Forms.Button Tabla4R;
        private System.Windows.Forms.Button Tabla3R;
        private System.Windows.Forms.Button Btnsiguinte;
        private System.Windows.Forms.Button Btnmas;
        private System.Windows.Forms.Button Btnmenos;
        private System.Windows.Forms.Button BtnChat;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label LabelConectado;
        private System.Windows.Forms.Button BtnConectar;
        private System.Windows.Forms.Button BtnIiniciar;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.TextBox txtMensaje;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtClientePuerto;
        private System.Windows.Forms.TextBox txtServerPuerto;
        private System.Windows.Forms.TextBox txtClienteIP;
        private System.Windows.Forms.TextBox txtServerIP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label LabelCartasRestantes;
        private System.Windows.Forms.Button BtnLimpiar;
        private System.Windows.Forms.GroupBox GrupoChat;
        private System.Windows.Forms.GroupBox GrupoFromasDeGanar;
        private System.Windows.Forms.RadioButton RadioHorzontal;
        private System.Windows.Forms.RadioButton RadioDiagonalInversa;
        private System.Windows.Forms.RadioButton RadioCruz;
        private System.Windows.Forms.RadioButton RadioFormaTChica;
        private System.Windows.Forms.RadioButton RadioFormaT;
        private System.Windows.Forms.RadioButton RadioDosDiagonales;
        private System.Windows.Forms.RadioButton RadioPollaChica;
        private System.Windows.Forms.RadioButton RadioFormaL;
        private System.Windows.Forms.RadioButton RadioPolla;
        private System.Windows.Forms.RadioButton RadioDiagonal;
        private System.Windows.Forms.Button BtnBuenas2;

        private TcpClient cliente;
        public StreamReader sr;
        string[] tarjetaCopia = new string[54];
        string[,] tabla1Copia = new string[5, 5];
        string[,] tabla2Copia = new string[5, 5];
        string[,] tabla3Copia = new string[5, 5];
        string[,] tabla4Copia = new string[5, 5];
        string[] tarjetaCliente = new string[54];
        bool Horizontal = false;
        bool diagonal = false;
        bool PollaG = false;
        bool Ele = false;
        bool Z = false;
        bool PCH = false;
        bool DosDiagonales = true;
        bool TGrande = false;
        bool TChica = false;
        bool DiagInversa = false;
        bool Cruz = false;
        public StreamWriter sw;
        public string recive;
        public string TextToSend;
        int[] revueltas;
        int[] mazoCartas;
        int[] point;
        string name;
        string[] cartasCliente = new string[54];
        byte[] byRec = new byte[255];
        byte[] byEnv = new byte[255];
        PictureBox[,] tabla1 = new PictureBox[5, 5];
        PictureBox[,] tabla2 = new PictureBox[5, 5];
        PictureBox[,] tabla3 = new PictureBox[5, 5];
        PictureBox[,] tabla4 = new PictureBox[5, 5];
        int[] tarjeta = new int[54];
        int cuenta;
        int temp = 0;
        int regresar, regresar2;
        int tiempo = 1500;
        int[] cartas = new int[54];
        int[] mazo = new int[54];
        int X;
        int pos, leer;
        int contador = 54;
        int resumen;
        int i = 0;
        Random r = new Random();
        public Multijugador()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            IPAddress[] LocalIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in LocalIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {

                }
            }
          for (int I = 0; I < 5; I++)
          {

                for (int j = 0; j < 5; j++)
                {

                    tabla1[I, j] = new PictureBox();
                    tabla1[I, j].Size = new Size(40, 60);
                    tabla1[I, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla1[I, j].Location = new Point((i * 50) + 70, (j * 70) + 250);
                    tabla1[I, j].Click += new EventHandler(ponerFicha);
                    tabla1[I, j].DoubleClick += new EventHandler(QuitarFicha);
                    this.Controls.Add(tabla1[I, j]);

                    tabla2[I, j] = new PictureBox();
                    tabla2[I, j].Size = new Size(73, 107);
                    tabla2[I, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla2[I, j].Location = new Point((I * 70) + 450, (j * 105) + 25);
                    tabla2[I, j].Click += new EventHandler(ponerFicha);
                    tabla2[I, j].DoubleClick += new EventHandler(QuitarFicha);
                    this.Controls.Add(tabla2[I, j]);

                    tabla3[I, j] = new PictureBox();
                    tabla3[I, j].Size = new Size(50, 80);
                    tabla3[I, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla3[I, j].Click += new EventHandler(ponerFicha);
                    tabla3[I, j].DoubleClick += new EventHandler(QuitarFicha);
                    tabla3[I, j].Location = new Point((I * 40) + 610, (j * 75) + 125);
                    tabla3[I, j].Visible = false;
                    this.Controls.Add(tabla3[I, j]);

                    tabla4[I, j] = new PictureBox();
                    tabla4[I, j].Size = new Size(40, 70);
                    tabla4[I, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla4[I, j].Click += new EventHandler(ponerFicha);
                    tabla4[I, j].DoubleClick += new EventHandler(QuitarFicha);
                    tabla4[I, j].Location = new Point((I * 40) + 400, (j * 70) + 380);
                    tabla4[I, j].Visible = false;
                    this.Controls.Add(tabla4[I, j]);


                }
          }

        }
        private void QuitarFicha(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = null;
            ((PictureBox)sender).Name = "";
        }


        private void BtnIralmenu_Click(object sender, EventArgs e)
        {
            Inicio inicio = new Inicio();
            inicio.Visible = true;
            Visible = false;
        }

        private void BtnCrearTabla_Click(object sender, EventArgs e)
        {
            CrearTablas crear = new CrearTablas();
            crear.Visible = true;
            Visible = false;
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
        private void creartabla1()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla1[i, j] = new PictureBox();
                    tabla1[i, j].Location = new Point(((i + 1) * 45), ((j + 4) * 65));
                    tabla1[i, j].Size = new Size(40, 60);
                    tabla1[i, j].BackColor = Color.White;
                    tabla1[i, j].Click += new EventHandler(ponerFicha);
                    this.Controls.Add(tabla1[i, j]);
                }
            }

        }
        private void CrearTabla2()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla2[i, j] = new PictureBox();
                    tabla2[i, j].Location = new Point(((i + 7) * 45), ((j + 4) * 65));
                    tabla2[i, j].Size = new Size(40, 60);
                    tabla2[i, j].BackColor = Color.White;
                    tabla2[i, j].Click += new EventHandler(ponerFicha);
                    this.Controls.Add(tabla2[i, j]);
                }
            }
        }

        private void Tabla1R_Click(object sender, EventArgs e)
        {
            mazoCartas = new int[54];
            point = barajearCartas(mazoCartas);

            int x = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla1[i, j].BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (point[x++]) + ".jpeg");
                    tabla1[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla1Copia[i, j] = point[x - 1] + "";
                    tabla2[i, j].Visible = false;
                    tabla3[i, j].Visible = false;
                    tabla4[i, j].Visible = false;
                    tabla1[i, j].Size = new Size(52, 72);
                    tabla1[i, j].Location = new Point((i * 50) + 70, (j * 70) + 250);
                }
            }
        }

        private void Tabla2R_Click(object sender, EventArgs e)
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
                    tabla2[i, j].Size = new Size(52, 72);
                    tabla2[i, j].Location = new Point((i * 50) + 335, (j * 70) + 250);
                    tabla1[i, j].Size = new Size(52, 72);
                    tabla1[i, j].Location = new Point((i * 50) + 70, (j * 70) + 250);
                }
            }
        }
        private void ponerFicha(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\coca.png");
            ((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;
            ((PictureBox)sender).BackColor = Color.Transparent;
            ((PictureBox)sender).BackgroundImageLayout = ImageLayout.Stretch;
        }
    

        private void Tabla3R_Click(object sender, EventArgs e)
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
                    tabla1[i, j].Visible = true;
                    tabla2[i, j].Visible = true;
                    tabla3[i, j].Visible = false;
                    tabla4[i, j].Visible = false;
                    tabla3[i, j].Size = new Size(52, 72);
                    tabla3[i, j].Location = new Point((i * 50) + 335, (j * 70) + 250);
                    tabla1[i, j].Size = new Size(52, 72);
                    tabla1[i, j].Location = new Point((i * 50) + 70, (j * 70) + 250);
                }
            }
        }


        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == false)
            {
                BtnIniciar.Text = "Pausar";
                timer1.Start();
                timer1.Enabled = true;
                return;
            }
            if (timer1.Enabled == true)
            {
                BtnIniciar.Text = "Iniciar";
                timer1.Enabled = false;
                timer1.Stop();
                return;
            }
        }

        private void Btnmas_Click(object sender, EventArgs e)
        {
            if (tiempo > 500)
            {

                tiempo = tiempo - 300;
                timer1.Interval = tiempo;
                timer1.Start();
            }
        }

        private void Btnmenos_Click(object sender, EventArgs e)
        {
            tiempo = tiempo - 300;
            timer1.Interval = tiempo;
            timer1.Start();
        }

        private void Btnsiguinte_Click(object sender, EventArgs e)
        {
            tiempo = tiempo + 300;
            timer1.Interval = tiempo;
            timer1.Start();
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
                 Btnsiguinte.Enabled = true;
                 for (int i = 0; i < 1; i++)
                 {
                     int atras = tarjeta[pos - (temp + 2)];
                     pictureBox2.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + atras + ".jpeg");
                     temp++;
                     if (atras == tarjeta[0])
                     {
                         pictureBox2.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + atras + ".jpeg");
                         MessageBox.Show("Ya no hay cartas");
                         btnRegresar.Enabled = false;
                         Btnsiguinte.Enabled = true;
                     }
                 }
        }

        private void Tabla4R_Click(object sender, EventArgs e)
        {
            mazoCartas = new int[54];
            point = barajearCartas(mazoCartas);
            int x = 1;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla4[i, j].BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (point[x++]) + ".jpeg");
                    tabla4[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla4Copia[i, j] = point[x - 1] + "";
                    tabla1[i, j].Visible = true;
                    tabla2[i, j].Visible = true;
                    tabla3[i, j].Visible = false;
                    tabla4[i, j].Visible = false;
                    tabla4[i, j].Size = new Size(52, 72);
                    tabla4[i, j].Location = new Point((i * 50) + 335, (j * 70) + 250);
                    tabla1[i, j].Size = new Size(52, 72);
                    tabla1[i, j].Location = new Point((i * 50) + 70, (j * 70) + 250);
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
            txtMensaje.Text = revueltas[pos - 1].ToString();

            if (txtMensaje.Text != "")
            {
                TextToSend = txtMensaje.Text;
                backgroundWorker2.RunWorkerAsync();

            }
            txtMensaje.Text = "";

            resumen = revueltas[pos - 1];
            LabelCartasRestantes.Text = (contador - pos).ToString();
            if (revueltas[pos - 1] == revueltas[53])
            {
                timer1.Stop();
                pictureBox2.Image = null;
                BtnIniciar.Enabled = false;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (cliente.Connected)
            {
                try
                {
                    recive = sr.ReadLine();
                    this.txtChat.Invoke(new MethodInvoker(delegate ()
                    {
                        txtChat.AppendText("El :" + recive +"" +"\n");
                    }));
                    recive = "";
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message.ToString());
               
                }
            }
        }

        private void BtnChat_Click(object sender, EventArgs e)
        {
            GrupoChat.Visible = true;
        }

        private void BtnConectar_Click(object sender, EventArgs e)
        {
            cliente = new TcpClient();
            IPEndPoint iPEnd = new IPEndPoint(IPAddress.Parse(txtClienteIP.Text), int.Parse(txtClientePuerto.Text));
            try
            {
                cliente.Connect(iPEnd);
                if (cliente.Connected)
                {
                    txtChat.AppendText("conectando a servidor"+ "\n") ;
                    sr = new StreamReader(cliente.GetStream());
                    sw = new StreamWriter(cliente.GetStream());
                    sw.AutoFlush = true;
                    backgroundWorker1.RunWorkerAsync();
                    backgroundWorker2.WorkerSupportsCancellation = true;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

            BtnBuenas.Visible = true;

        }

        private void BtnIiniciar_Click(object sender, EventArgs e)
        {

            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(txtServerPuerto.Text));
            listener.Start();
            cliente = listener.AcceptTcpClient();
            sr = new StreamReader(cliente.GetStream());
            sw = new StreamWriter(cliente.GetStream());
            sw.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;

            BtnBuenas.Visible = true;
        }

        private void Multijugador_Load(object sender, EventArgs e)
        {
            
       
            int[] mazo = new int[54];

            revueltas = barajearCartas(mazo);
            pos = 0;
            timer1.Interval = 6000;
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla1[i, j].Image = null;
                    tabla1[i, j].Name = "";
                    tabla2[i, j].Image = null;
                    tabla2[i, j].Name = "";
                    tabla3[i, j].Image = null;
                    tabla3[i, j].Name = "";
                    tabla4[i, j].Image = null;
                    tabla4[i, j].Name = "";
                }
            }
        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtMensaje.Text != "")
            {
                TextToSend = txtMensaje.Text;
                backgroundWorker2.RunWorkerAsync();

            }
            txtMensaje.Text = "";
        }

        private void txtChat_TextChanged(object sender, EventArgs e)
        {

        }

        private void RadioHorzontal_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioHorzontal.Checked)
            {
                Horizontal = true;
            }
        }

        private void RadioDiagonal_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioDiagonal.Checked)
            {
                diagonal = true;
            }
        }

        private void RadioPolla_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioDiagonal.Checked)
            {
                PollaG = true;
            }
        }

        private void RadioFormaL_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioFormaL.Checked)
            {
                Ele = true;
            }
        }

        private void RadioFormaT_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioFormaT.Checked)
            {
                TGrande = true;
            }
        }

        private void RadioDiagonalInversa_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioDiagonalInversa.Checked)
            {
                DiagInversa = true;
            }
        }

        private void RadioDosDiagonales_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioDosDiagonales.Checked)
            {
                DosDiagonales = true;
            }
        }

        private void RadioPollaChica_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioPollaChica.Checked)
            {
                PCH = true;
            }
        }

        private void RadioCruz_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioCruz.Checked)
            {
                Cruz = true;
            }
        }

        private void RadioFormaTChica_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioFormaTChica.Checked)
            {
                TChica = true;
            }
        }

        private void BtnBuenas_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            if (Horizontal == true)
            {
                GanarHorizontal(tabla1Copia, tabla1, "Tabla 1: ");
                GanarHorizontal(tabla2Copia, tabla2, "Tabla 2: ");
            }
            if (diagonal == true)
            {
                GanarDiagonal(tabla1Copia, tabla1, "Tabla 1: ");
                GanarDiagonal(tabla2Copia, tabla2, "Tabla 2: ");
            }
            if (PollaG == true)
            {
                GanarPollaGrande(tabla1Copia, tabla1, "Tabla 1: ");
                GanarPollaGrande(tabla2Copia, tabla2, "Tabla 2: ");
            }
            if (DosDiagonales == true)
            {
                GanarDosDiag(tabla1Copia, tabla1, "Tabla 1: ");
                GanarDosDiag(tabla2Copia, tabla2, "Tabla 2: ");
            }

            if (DiagInversa == true)
            {
                GanarDiagonalInversa(tabla1Copia, tabla1, "Tabla 1: ");
                GanarDiagonalInversa(tabla2Copia, tabla2, "Tabla 2: ");

            }
            if (TChica == true)
            {
                GanarTChica(tabla1Copia, tabla1, "Tabla 1: ");
                GanarTChica(tabla2Copia, tabla2, "Tabla 2: ");
            }
            if (TGrande == true)
            {
                GanarTgrande(tabla1Copia, tabla1, "Tabla 1: ");
                GanarTgrande(tabla2Copia, tabla2, "Tabla 2: ");
            }
            if (PCH == true)
            {
                GanarPollaChica(tabla1Copia, tabla1, "Tabla 1: ");
                GanarPollaChica(tabla2Copia, tabla2, "Tabla 2: ");
            }
            if (Ele == true)
            {
                GanarEle(tabla1Copia, tabla1, "Tabla 1: ");
                GanarEle(tabla2Copia, tabla2, "Tabla 2: ");
            }
            if (Cruz == true)
            {
                GanarCruz(tabla1Copia, tabla1, "Tabla 1: ");
                GanarCruz(tabla2Copia, tabla2, "Tabla 2: ");
            }
        }

        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (cliente.Connected)
            {
                sw.WriteLine(TextToSend);
                this.txtChat.Invoke(new MethodInvoker(delegate()
                {
                    txtChat.AppendText("Yo Mero: " + TextToSend + "\n");

                }));
            }
            else
            {
                MessageBox.Show("Sending falled");

            }
            backgroundWorker2.CancelAsync();
            }
            catch (Exception)
            {
                
                MessageBox.Show("Conectate Con alguien Antes De Iniciar");
            }
        }
        private void GanarCruz(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 1; i < 3; i++)
            {
                if
                (

                (tarjetaCopia.Contains(x[i, 2]) == true && tarjetaCopia.Contains(x[2, i]) == true)

                )
                {
                    if
                    (

                    (y[i, 2].Name == "•" && y[2, i].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarEle(string[,] x, PictureBox[,] y, string tabla)
        {

            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(x[0, i]) == true && tarjetaCopia.Contains(x[i, 4]) == true)

                )
                {
                    if
                    (

                    (y[0, i].Name == "•" && y[i, 4].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarTChica(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 1; i < 4; i++)
            {
                if
                (

                (tarjetaCopia.Contains(x[i, 1]) == true && tarjetaCopia.Contains(x[2, i]) == true)

                )
                {
                    if
                    (

                    (y[i, 1].Name == "•" && y[2, i].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarDiagonalInversa(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if (tarjetaCopia.Contains(x[i, j--]) == true)
                {
                    if ((y[i, j + 1].Name == "•"))
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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarPollaChica(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if
                (

                    (tarjetaCopia.Contains(x[1, 1]) == true && tarjetaCopia.Contains(x[1, 3]) == true &&
                    tarjetaCopia.Contains(x[2, 2]) == true && tarjetaCopia.Contains(x[3, 1]) == true &&
                    tarjetaCopia.Contains(x[3, 3]))

                )
                {
                    if
                    (

                     (y[1, 1].Name == "•" && y[1, 3].Name == "•" && y[2, 2].Name == "•" && y[3, 1].Name == "•"
                        && y[3, 3].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarTgrande(string[,] x, PictureBox[,] y, string tabla)
        {
            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(x[i, 0]) == true && tarjetaCopia.Contains(x[2, i]) == true)

                )
                {
                    if
                    (

                    (y[i, 0].Name == "•" && y[2, i].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarDosDiag(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(x[i, i]) == true && tarjetaCopia.Contains(x[i, j--]) == true)

                )
                {
                    if
                    (

                    (y[i, i].Name == "•" && y[i, j + 1].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarHorizontal(string[,] x, PictureBox[,] y, string tabla)
        {
            for (int i = 0; i < 5; i++)
            {
                if ((tarjetaCopia.Contains(x[0, i]) == true || tarjetaCopia.Contains(x[1, i]) == true ||
                    tarjetaCopia.Contains(x[2, i]) == true || tarjetaCopia.Contains(x[3, i]) == true ||
                    tarjetaCopia.Contains(x[4, i]) == true))

                {
                    if ((y[0, i].Name == "•" || y[1, i].Name == "•" || y[2, i].Name == "•" || y[3, i].Name == "•" ||
                        y[4, i].Name == "•"))
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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");

            }
            

        }
        private void GanarPollaGrande(string[,] x, PictureBox[,] y, string tabla)
        {
            for (int i = 0; i < 5; i++)
            {
                if (

                    (tarjetaCopia.Contains(x[0, 0]) == true && tarjetaCopia.Contains(x[4, 0]) == true &&
                    tarjetaCopia.Contains(x[2, 2]) == true && tarjetaCopia.Contains(x[0, 4]) == true &&
                    tarjetaCopia.Contains(x[4, 4]))

                    )
                {
                    if (

                        (y[0, 0].Name == "•" && y[0, 4].Name == "•" && y[2, 2].Name == "•" && y[0, 4].Name == "•"
                        && y[4, 4].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarDiagonal(string[,] x, PictureBox[,] y, string tabla)
        {
            for (int i = 0; i < 5; i++)
            {
                if (tarjetaCopia.Contains(x[i, i]) == true)
                {
                    if ((y[i, i].Name == "•"))
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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void BtnBuenas2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            if (Horizontal == true)
            {
                GanarHorizontalCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarHorizontalCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarHorizontalCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarHorizontalCliente(tabla4Copia, tabla4, "Tabla 4: ");


            }
            if (diagonal == true)
            {
                GanarDiagonalCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarDiagonalCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarDiagonalCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarDiagonalCliente(tabla4Copia, tabla4, "Tabla 4: ");

            }
            if (PollaG == true)
            {
                GanarPollaGrandeCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarPollaGrandeCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarPollaGrandeCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarPollaGrandeCliente(tabla4Copia, tabla4, "Tabla 4: ");
            }
            if (DosDiagonales == true)
            {
                GanarDosDiagCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarDosDiagCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarDosDiagCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarDosDiagCliente(tabla4Copia, tabla4, "Tabla 4: ");
            }

            if (DiagInversa == true)
            {
                GanarDiagonalInversaCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarDiagonalInversaCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarDiagonalInversaCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarDiagonalInversaCliente(tabla4Copia, tabla4, "Tabla 4: ");


            }
            if (TChica == true)
            {
                GanarTChicaCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarTChicaCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarTChicaCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarTChicaCliente(tabla4Copia, tabla4, "Tabla 4: ");

            }
            if (TGrande == true)
            {
                GanarTgrandeCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarTgrandeCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarTgrandeCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarTgrandeCliente(tabla4Copia, tabla4, "Tabla 4: ");
            }
            if (PCH == true)
            {
                GanarPollaChicaCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarPollaChicaCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarPollaChicaCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarPollaChicaCliente(tabla4Copia, tabla4, "Tabla 4: ");
            }
            if (Ele == true)
            {
                GanarEleCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarEleCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarEleCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarEleCliente(tabla4Copia, tabla4, "Tabla 4: ");
            }
            if (Cruz == true)
            {
                GanarCruzCliente(tabla1Copia, tabla1, "Tabla 1: ");
                GanarCruzCliente(tabla2Copia, tabla2, "Tabla 2: ");
                GanarCruzCliente(tabla3Copia, tabla3, "Tabla 3: ");
                GanarCruzCliente(tabla4Copia, tabla4, "Tabla 4: ");
            }
        }
        private void GanarDiagonalCliente(string[,] x, PictureBox[,] y, string tabla)
        {
            for (int i = 0; i < 5; i++)
            {
                if (tarjetaCliente.Contains(x[i, i]) == true)
                {
                    if ((y[i, i].Name == "•"))
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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarHorizontalCliente(string[,] x, PictureBox[,] y, string tabla)
        {
            for (int i = 0; i < 5; i++)
            {
                if ((tarjetaCliente.Contains(x[0, i]) == true || tarjetaCliente.Contains(x[1, i]) == true ||
                    tarjetaCliente.Contains(x[2, i]) == true || tarjetaCliente.Contains(x[3, i]) == true ||
                    tarjetaCliente.Contains(x[4, i]) == true))

                {
                    if ((y[0, i].Name == "•" || y[1, i].Name == "•" || y[2, i].Name == "•" || y[3, i].Name == "•" ||
                        y[4, i].Name == "•"))
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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");

            }
        }
        private void GanarDosDiagCliente(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCliente.Contains(x[i, i]) == true && tarjetaCliente.Contains(x[i, j--]) == true)

                )
                {
                    if
                    (

                    (y[i, i].Name == "•" && y[i, j + 1].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarTgrandeCliente(string[,] x, PictureBox[,] y, string tabla)
        {
            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCliente.Contains(x[i, 0]) == true && tarjetaCliente.Contains(x[2, i]) == true)

                )
                {
                    if
                    (

                    (y[i, 0].Name == "•" && y[2, i].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarPollaChicaCliente(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if
                (

                    (tarjetaCliente.Contains(x[1, 1]) == true && tarjetaCliente.Contains(x[1, 3]) == true &&
                    tarjetaCliente.Contains(x[2, 2]) == true && tarjetaCliente.Contains(x[3, 1]) == true &&
                    tarjetaCliente.Contains(x[3, 3]))

                )
                {
                    if
                    (

                     (y[1, 1].Name == "•" && y[1, 3].Name == "•" && y[2, 2].Name == "•" && y[3, 1].Name == "•"
                        && y[3, 3].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarDiagonalInversaCliente(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if (tarjetaCliente.Contains(x[i, j--]) == true)
                {
                    if ((y[i, j + 1].Name == "•"))
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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarTChicaCliente(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 1; i < 4; i++)
            {
                if
                (

                (tarjetaCliente.Contains(x[i, 1]) == true && tarjetaCliente.Contains(x[2, i]) == true)

                )
                {
                    if
                    (

                    (y[i, 1].Name == "•" && y[2, i].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarEleCliente(string[,] x, PictureBox[,] y, string tabla)
        {

            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCliente.Contains(x[0, i]) == true && tarjetaCliente.Contains(x[i, 4]) == true)

                )
                {
                    if
                    (

                    (y[0, i].Name == "•" && y[i, 4].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }

        private void Multijugador_Load_1(object sender, EventArgs e)
        {
            // 
            // BtnIralmenu
            // 
            this.BtnIralmenu = new System.Windows.Forms.Button();
            this.BtnIralmenu.BackColor = System.Drawing.Color.MintCream;
            this.BtnIralmenu.Location = new System.Drawing.Point(12, 12);
            this.BtnIralmenu.Name = "BtnIralmenu";
            this.BtnIralmenu.Size = new System.Drawing.Size(113, 34);
            this.BtnIralmenu.TabIndex = 0;
            this.BtnIralmenu.Text = "Ir al menu";
            this.BtnIralmenu.UseVisualStyleBackColor = false;
            this.BtnIralmenu.Click += new System.EventHandler(this.BtnIralmenu_Click);
            this.Controls.Add(this.BtnIralmenu);
            // 
            // BtnBuenas
            // 
            this.BtnBuenas = new System.Windows.Forms.Button();
            this.BtnBuenas.BackColor = System.Drawing.Color.MintCream;
            this.BtnBuenas.Location = new System.Drawing.Point(599, 31);
            this.BtnBuenas.Name = "BtnBuenas";
            this.BtnBuenas.Size = new System.Drawing.Size(114, 46);
            this.BtnBuenas.TabIndex = 21;
            this.BtnBuenas.Text = "Buenas";
            this.BtnBuenas.UseVisualStyleBackColor = false;
            this.BtnBuenas.Click += new System.EventHandler(this.BtnBuenas_Click);
            this.Controls.Add(this.BtnBuenas);
            // 
            // btnRegresar
            // 
            this.btnRegresar = new System.Windows.Forms.Button();
            this.btnRegresar.BackColor = System.Drawing.Color.MintCream;
            this.btnRegresar.Location = new System.Drawing.Point(599, 133);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(233, 29);
            this.btnRegresar.TabIndex = 20;
            this.btnRegresar.Text = "Regresar";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            this.Controls.Add(this.btnRegresar);
            // 
            // BtnIniciar
            // 
            this.BtnIniciar = new System.Windows.Forms.Button();
            this.BtnIniciar.BackColor = System.Drawing.Color.MintCream;
            this.BtnIniciar.Location = new System.Drawing.Point(599, 81);
            this.BtnIniciar.Name = "BtnIniciar";
            this.BtnIniciar.Size = new System.Drawing.Size(233, 46);
            this.BtnIniciar.TabIndex = 19;
            this.BtnIniciar.Text = "Iniciar";
            this.BtnIniciar.UseVisualStyleBackColor = false;
            this.BtnIniciar.Click += new System.EventHandler(this.BtnIniciar_Click);
            this.Controls.Add(this.BtnIniciar);
            // 
            // BtnCrearTabla
            // 
            this.BtnCrearTabla = new System.Windows.Forms.Button();
            this.BtnCrearTabla.BackColor = System.Drawing.Color.Silver;
            this.BtnCrearTabla.ForeColor = System.Drawing.Color.Black;
            this.BtnCrearTabla.Location = new System.Drawing.Point(906, 81);
            this.BtnCrearTabla.Name = "BtnCrearTabla";
            this.BtnCrearTabla.Size = new System.Drawing.Size(140, 46);
            this.BtnCrearTabla.TabIndex = 18;
            this.BtnCrearTabla.Text = "Crear Tabla";
            this.BtnCrearTabla.UseVisualStyleBackColor = false;
            this.BtnCrearTabla.Click += new System.EventHandler(this.BtnCrearTabla_Click);
            this.Controls.Add(this.BtnCrearTabla);
            // 
            // timer1
            // 
            this.timer1 = new System.Windows.Forms.Timer();
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            // 
            // Tabla1R
            // 
            this.Tabla1R = new System.Windows.Forms.Button();
            this.Tabla1R.Location = new System.Drawing.Point(169, 81);
            this.Tabla1R.Name = "Tabla1R";
            this.Tabla1R.Size = new System.Drawing.Size(100, 46);
            this.Tabla1R.TabIndex = 23;
            this.Tabla1R.Text = "Tabla 1 Random";
            this.Tabla1R.UseVisualStyleBackColor = true;
            this.Tabla1R.Click += new System.EventHandler(this.Tabla1R_Click);
            this.Controls.Add(this.Tabla1R);
            // 
            // Tabla2R
            // 
            this.Tabla2R = new System.Windows.Forms.Button();
            this.Tabla2R.Location = new System.Drawing.Point(275, 81);
            this.Tabla2R.Name = "Tabla2R";
            this.Tabla2R.Size = new System.Drawing.Size(107, 46);
            this.Tabla2R.TabIndex = 24;
            this.Tabla2R.Text = "Tabla 2 Random";
            this.Tabla2R.UseVisualStyleBackColor = true;
            this.Tabla2R.Click += new System.EventHandler(this.Tabla2R_Click);
            this.Controls.Add(this.Tabla2R);
            // 
            // Tabla4R
            // 
            this.Tabla4R = new System.Windows.Forms.Button();
            this.Tabla4R.Location = new System.Drawing.Point(1167, 81);
            this.Tabla4R.Name = "Tabla4R";
            this.Tabla4R.Size = new System.Drawing.Size(107, 46);
            this.Tabla4R.TabIndex = 26;
            this.Tabla4R.Text = "Tabla 2 Random";
            this.Tabla4R.UseVisualStyleBackColor = true;
            this.Tabla4R.Visible = false;
            this.Tabla4R.Click += new System.EventHandler(this.Tabla4R_Click);
            this.Controls.Add(this.Tabla4R);
            // 
            // Tabla3R
            // 
            this.Tabla3R = new System.Windows.Forms.Button();
            this.Tabla3R.Location = new System.Drawing.Point(1061, 81);
            this.Tabla3R.Name = "Tabla3R";
            this.Tabla3R.Size = new System.Drawing.Size(100, 46);
            this.Tabla3R.TabIndex = 25;
            this.Tabla3R.Text = "Tabla 1 Random";
            this.Tabla3R.UseVisualStyleBackColor = true;
            this.Tabla3R.Visible = false;
            this.Tabla3R.Click += new System.EventHandler(this.Tabla3R_Click);
            this.Controls.Add(this.Tabla3R);
            // 
            // Btnsiguinte
            // 
            this.Btnsiguinte = new System.Windows.Forms.Button();
            this.Btnsiguinte.BackColor = System.Drawing.Color.MintCream;
            this.Btnsiguinte.Location = new System.Drawing.Point(433, 81);
            this.Btnsiguinte.Name = "Btnsiguinte";
            this.Btnsiguinte.Size = new System.Drawing.Size(140, 46);
            this.Btnsiguinte.TabIndex = 27;
            this.Btnsiguinte.Text = "Cartas";
            this.Btnsiguinte.UseVisualStyleBackColor = false;
            this.Btnsiguinte.Click += new System.EventHandler(this.Btnsiguinte_Click);
            this.Controls.Add(this.Btnsiguinte);
            // 
            // Btnmas
            // 
            this.Btnmas = new System.Windows.Forms.Button();
            this.Btnmas.BackColor = System.Drawing.Color.MintCream;
            this.Btnmas.Location = new System.Drawing.Point(599, 168);
            this.Btnmas.Name = "Btnmas";
            this.Btnmas.Size = new System.Drawing.Size(73, 29);
            this.Btnmas.TabIndex = 28;
            this.Btnmas.Text = "Mas";
            this.Btnmas.UseVisualStyleBackColor = false;
            this.Btnmas.Click += new System.EventHandler(this.Btnmas_Click);
            this.Controls.Add(this.Btnmas);
            // 
            // Btnmenos
            // 
            this.Btnmenos = new System.Windows.Forms.Button();
            this.Btnmenos.BackColor = System.Drawing.Color.MintCream;
            this.Btnmenos.Location = new System.Drawing.Point(678, 168);
            this.Btnmenos.Name = "Btnmenos";
            this.Btnmenos.Size = new System.Drawing.Size(73, 29);
            this.Btnmenos.TabIndex = 29;
            this.Btnmenos.Text = "Menos";
            this.Btnmenos.UseVisualStyleBackColor = false;
            this.Btnmenos.Click += new System.EventHandler(this.Btnmenos_Click);
            this.Controls.Add(this.Btnmenos);
            // 
            // BtnChat
            // 
            this.BtnChat = new System.Windows.Forms.Button();
            this.BtnChat.Location = new System.Drawing.Point(678, 203);
            this.BtnChat.Name = "BtnChat";
            this.BtnChat.Size = new System.Drawing.Size(75, 23);
            this.BtnChat.TabIndex = 30;
            this.BtnChat.Text = "Chat";
            this.BtnChat.UseVisualStyleBackColor = true;
            this.BtnChat.Click += new System.EventHandler(this.BtnChat_Click);
            this.Controls.Add(this.BtnChat);
            // 
            // pictureBox2
            // 
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox2.BackColor = System.Drawing.Color.Lime;
            this.pictureBox2.Location = new System.Drawing.Point(641, 245);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(152, 218);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 22;
            this.pictureBox2.TabStop = false;
            this.Controls.Add(this.pictureBox2);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1 = new BackgroundWorker();
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2 = new BackgroundWorker();
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // LabelConectado
            // 
            this.LabelConectado = new System.Windows.Forms.Label();
            this.LabelConectado.AutoSize = true;
            this.LabelConectado.Location = new System.Drawing.Point(425, 100);
            this.LabelConectado.Name = "LabelConectado";
            this.LabelConectado.Size = new System.Drawing.Size(35, 13);
            this.LabelConectado.TabIndex = 95;
            this.LabelConectado.Text = "label7";
            this.Controls.Add(this.LabelConectado);
            // 
            // BtnConectar
            // 
            this.BtnConectar = new System.Windows.Forms.Button();
            this.BtnConectar.Location = new System.Drawing.Point(400, 132);
            this.BtnConectar.Name = "BtnConectar";
            this.BtnConectar.Size = new System.Drawing.Size(75, 23);
            this.BtnConectar.TabIndex = 94;
            this.BtnConectar.Text = "Conectar";
            this.BtnConectar.UseVisualStyleBackColor = true;
            this.BtnConectar.Click += new System.EventHandler(this.BtnConectar_Click);
            this.Controls.Add(this.BtnConectar);
            // 
            // BtnIiniciar
            // 
            this.BtnIiniciar = new System.Windows.Forms.Button();
            this.BtnIiniciar.Location = new System.Drawing.Point(400, 58);
            this.BtnIiniciar.Name = "BtnIiniciar";
            this.BtnIiniciar.Size = new System.Drawing.Size(75, 23);
            this.BtnIiniciar.TabIndex = 93;
            this.BtnIiniciar.Text = "Iniciar";
            this.BtnIiniciar.UseVisualStyleBackColor = true;
            this.BtnIiniciar.Click += new System.EventHandler(this.BtnIiniciar_Click);
            this.Controls.Add(this.BtnIiniciar);
            // 
            // btnEnviar
            // 
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnviar.Location = new System.Drawing.Point(415, 276);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(60, 29);
            this.btnEnviar.TabIndex = 92;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.UseVisualStyleBackColor = true;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            this.Controls.Add(this.btnEnviar);
            // 
            // txtMensaje
            // 
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.txtMensaje.Location = new System.Drawing.Point(17, 276);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.Size = new System.Drawing.Size(392, 29);
            this.txtMensaje.TabIndex = 91;
            this.txtMensaje.TextChanged += new System.EventHandler(this.txtMensaje_TextChanged);
            this.Controls.Add(this.txtMensaje);
            // 
            // txtChat
            // 
            this.txtChat = new System.Windows.Forms.TextBox();
            this.txtChat.Location = new System.Drawing.Point(16, 193);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtChat.Size = new System.Drawing.Size(459, 77);
            this.txtChat.TabIndex = 90;
            this.txtChat.TextChanged += new System.EventHandler(this.txtChat_TextChanged);
            this.Controls.Add(this.txtChat);
            // 
            // label6
            // 
            this.label6 = new System.Windows.Forms.Label();
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(158, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 25);
            this.label6.TabIndex = 89;
            this.label6.Text = "Cliente";
            this.Controls.Add(this.label6);
            // 
            // label5
            // 
            this.label5 = new System.Windows.Forms.Label();
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(158, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 25);
            this.label5.TabIndex = 88;
            this.label5.Text = "Servidor";
            this.Controls.Add(this.label5);
            // 
            // txtClientePuerto
            // 
            this.txtClientePuerto = new System.Windows.Forms.TextBox();
            this.txtClientePuerto.Location = new System.Drawing.Point(258, 137);
            this.txtClientePuerto.Name = "txtClientePuerto";
            this.txtClientePuerto.Size = new System.Drawing.Size(112, 20);
            this.txtClientePuerto.TabIndex = 87;
            this.Controls.Add(this.txtClientePuerto);
            // 
            // txtServerPuerto
            // 
            this.txtServerPuerto = new System.Windows.Forms.TextBox();
            this.txtServerPuerto.Location = new System.Drawing.Point(258, 58);
            this.txtServerPuerto.Name = "txtServerPuerto";
            this.txtServerPuerto.Size = new System.Drawing.Size(112, 20);
            this.txtServerPuerto.TabIndex = 86;
            this.Controls.Add(this.txtServerPuerto);
            // 
            // txtClienteIP
            // 
            this.txtClienteIP = new System.Windows.Forms.TextBox();
            this.txtClienteIP.Location = new System.Drawing.Point(50, 137);
            this.txtClienteIP.Name = "txtClienteIP";
            this.txtClienteIP.Size = new System.Drawing.Size(116, 20);
            this.txtClienteIP.TabIndex = 85;
            this.Controls.Add(this.txtClienteIP);
            // 
            // txtServerIP
            // 
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerIP = new System.Windows.Forms.TextBox();
            this.txtServerIP.Location = new System.Drawing.Point(50, 58);
            this.txtServerIP.Name = "txtServerIP";
            this.txtServerIP.Size = new System.Drawing.Size(116, 20);
            this.txtServerIP.TabIndex = 84;
            this.Controls.Add(this.txtServerIP);
            // 
            // label4
            // 
            this.label4 = new System.Windows.Forms.Label();
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(196, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 18);
            this.label4.TabIndex = 83;
            this.label4.Text = "Puerto";
            this.Controls.Add(this.label4);
            // 
            // label3
            // 
            this.label3 = new System.Windows.Forms.Label();
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 18);
            this.label3.TabIndex = 82;
            this.label3.Text = "IP";
            this.Controls.Add(this.label3);
            // 
            // label2
            // 
            this.label2 = new System.Windows.Forms.Label();
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 81;
            this.label2.Text = "Puerto";
            this.Controls.Add(this.label2);
            // 
            // label1
            // 
            this.label1 = new System.Windows.Forms.Label();
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 18);
            this.label1.TabIndex = 80;
            this.label1.Text = "IP";
            this.Controls.Add(this.label1);
            // 
            // LabelCartasRestantes
            // 
            this.LabelCartasRestantes = new System.Windows.Forms.Label();
            this.LabelCartasRestantes.AutoSize = true;
            this.LabelCartasRestantes.Location = new System.Drawing.Point(698, 229);
            this.LabelCartasRestantes.Name = "LabelCartasRestantes";
            this.LabelCartasRestantes.Size = new System.Drawing.Size(41, 13);
            this.LabelCartasRestantes.TabIndex = 96;
            this.LabelCartasRestantes.Text = "Cuenta";
            this.Controls.Add(this.LabelCartasRestantes);
            // 
            // BtnLimpiar
            // 
            this.BtnLimpiar = new System.Windows.Forms.Button();
            this.BtnLimpiar.Location = new System.Drawing.Point(757, 168);
            this.BtnLimpiar.Name = "BtnLimpiar";
            this.BtnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.BtnLimpiar.TabIndex = 97;
            this.BtnLimpiar.Text = "Limpiar";
            this.BtnLimpiar.UseVisualStyleBackColor = true;
            this.BtnLimpiar.Click += new System.EventHandler(this.BtnLimpiar_Click);
            Btnsiguinte.Enabled = false;
            this.Controls.Add(this.BtnLimpiar);
            // 
            // GrupoChat
            // 
            this.GrupoChat = new System.Windows.Forms.GroupBox();
            this.GrupoChat.Controls.Add(this.label5);
            this.GrupoChat.Controls.Add(this.label2);
            this.GrupoChat.Controls.Add(this.label4);
            this.GrupoChat.Controls.Add(this.label3);
            this.GrupoChat.Controls.Add(this.LabelConectado);
            this.GrupoChat.Controls.Add(this.label1);
            this.GrupoChat.Controls.Add(this.txtServerIP);
            this.GrupoChat.Controls.Add(this.BtnConectar);
            this.GrupoChat.Controls.Add(this.txtClienteIP);
            this.GrupoChat.Controls.Add(this.BtnIiniciar);
            this.GrupoChat.Controls.Add(this.txtServerPuerto);
            this.GrupoChat.Controls.Add(this.btnEnviar);
            this.GrupoChat.Controls.Add(this.txtClientePuerto);
            this.GrupoChat.Controls.Add(this.txtMensaje);
            this.GrupoChat.Controls.Add(this.label6);
            this.GrupoChat.Controls.Add(this.txtChat);
            this.GrupoChat.Location = new System.Drawing.Point(844, 229);
            this.GrupoChat.Name = "GrupoChat";
            this.GrupoChat.Size = new System.Drawing.Size(489, 338);
            this.GrupoChat.TabIndex = 98;
            this.GrupoChat.TabStop = false;
            this.GrupoChat.Text = "Chat";
            this.GrupoChat.Visible = false;
            this.Controls.Add(this.GrupoChat);
            // 
            // GrupoFromasDeGanar
            // 
            this.GrupoFromasDeGanar = new System.Windows.Forms.GroupBox();
            this.GrupoFromasDeGanar.Location = new System.Drawing.Point(613, 469);
            this.GrupoFromasDeGanar.Name = "GrupoFromasDeGanar";
            this.GrupoFromasDeGanar.Size = new System.Drawing.Size(219, 143);
            this.GrupoFromasDeGanar.TabIndex = 99;
            this.GrupoFromasDeGanar.TabStop = false;
            this.GrupoFromasDeGanar.Text = "Formas De Ganar";
            this.Controls.Add(this.GrupoFromasDeGanar);
            // 
            // RadioDiagonalInversa
            // 
            this.RadioDiagonalInversa = new System.Windows.Forms.RadioButton();
            this.RadioDiagonalInversa.AutoSize = true;
            this.RadioDiagonalInversa.Location = new System.Drawing.Point(84, 22);
            this.RadioDiagonalInversa.Name = "RadioDiagonalInversa";
            this.RadioDiagonalInversa.Size = new System.Drawing.Size(99, 17);
            this.RadioDiagonalInversa.TabIndex = 9;
            this.RadioDiagonalInversa.TabStop = true;
            this.RadioDiagonalInversa.Text = "Digonal Inversa";
            this.RadioDiagonalInversa.UseVisualStyleBackColor = true;
            this.RadioDiagonalInversa.CheckedChanged += new System.EventHandler(this.RadioDiagonalInversa_CheckedChanged);
            this.Controls.Add(this.RadioDiagonalInversa);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioDiagonalInversa);
            // 
            // RadioCruz
            // 
            this.RadioCruz = new System.Windows.Forms.RadioButton();
            this.RadioCruz.AutoSize = true;
            this.RadioCruz.Location = new System.Drawing.Point(84, 91);
            this.RadioCruz.Name = "RadioCruz";
            this.RadioCruz.Size = new System.Drawing.Size(46, 17);
            this.RadioCruz.TabIndex = 8;
            this.RadioCruz.TabStop = true;
            this.RadioCruz.Text = "Cruz";
            this.RadioCruz.UseVisualStyleBackColor = true;
            this.RadioCruz.CheckedChanged += new System.EventHandler(this.RadioCruz_CheckedChanged);
            this.Controls.Add(this.RadioCruz);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioCruz);
            // 
            // RadioFormaTChica
            // 
            this.RadioFormaTChica = new System.Windows.Forms.RadioButton();
            this.RadioFormaTChica.AutoSize = true;
            this.RadioFormaTChica.Location = new System.Drawing.Point(84, 114);
            this.RadioFormaTChica.Name = "RadioFormaTChica";
            this.RadioFormaTChica.Size = new System.Drawing.Size(94, 17);
            this.RadioFormaTChica.TabIndex = 7;
            this.RadioFormaTChica.TabStop = true;
            this.RadioFormaTChica.Text = "Forma T Chica";
            this.RadioFormaTChica.UseVisualStyleBackColor = true;
            this.RadioFormaTChica.CheckedChanged += new System.EventHandler(this.RadioFormaTChica_CheckedChanged);
            this.Controls.Add(this.RadioFormaTChica);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioFormaTChica);
            // 
            // RadioFormaT
            // 
            this.RadioFormaT = new System.Windows.Forms.RadioButton();
            this.RadioFormaT.AutoSize = true;
            this.RadioFormaT.Location = new System.Drawing.Point(6, 114);
            this.RadioFormaT.Name = "RadioFormaT";
            this.RadioFormaT.Size = new System.Drawing.Size(64, 17);
            this.RadioFormaT.TabIndex = 6;
            this.RadioFormaT.TabStop = true;
            this.RadioFormaT.Text = "Forma T";
            this.RadioFormaT.UseVisualStyleBackColor = true;
            this.RadioFormaT.CheckedChanged += new System.EventHandler(this.RadioFormaT_CheckedChanged);
            this.Controls.Add(this.RadioFormaT);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioFormaT);
            // 
            // RadioDosDiagonales
            // 
            this.RadioDosDiagonales = new System.Windows.Forms.RadioButton();
            this.RadioDosDiagonales.AutoSize = true;
            this.RadioDosDiagonales.Location = new System.Drawing.Point(84, 45);
            this.RadioDosDiagonales.Name = "RadioDosDiagonales";
            this.RadioDosDiagonales.Size = new System.Drawing.Size(100, 17);
            this.RadioDosDiagonales.TabIndex = 5;
            this.RadioDosDiagonales.TabStop = true;
            this.RadioDosDiagonales.Text = "Dos Diagonales";
            this.RadioDosDiagonales.UseVisualStyleBackColor = true;
            this.RadioDosDiagonales.CheckedChanged += new System.EventHandler(this.RadioDosDiagonales_CheckedChanged);
            this.Controls.Add(this.RadioDosDiagonales);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioDosDiagonales);
            // 
            // RadioPollaChica
            // 
            this.RadioPollaChica = new System.Windows.Forms.RadioButton();
            this.RadioPollaChica.AutoSize = true;
            this.RadioPollaChica.Location = new System.Drawing.Point(84, 68);
            this.RadioPollaChica.Name = "RadioPollaChica";
            this.RadioPollaChica.Size = new System.Drawing.Size(78, 17);
            this.RadioPollaChica.TabIndex = 4;
            this.RadioPollaChica.TabStop = true;
            this.RadioPollaChica.Text = "Polla Chica";
            this.RadioPollaChica.UseVisualStyleBackColor = true;
            this.RadioPollaChica.CheckedChanged += new System.EventHandler(this.RadioPollaChica_CheckedChanged);
            this.Controls.Add(this.RadioPollaChica);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioPollaChica);
            // 
            // RadioFormaL
            // 
            this.RadioFormaL = new System.Windows.Forms.RadioButton();
            this.RadioFormaL.AutoSize = true;
            this.RadioFormaL.Location = new System.Drawing.Point(6, 91);
            this.RadioFormaL.Name = "RadioFormaL";
            this.RadioFormaL.Size = new System.Drawing.Size(63, 17);
            this.RadioFormaL.TabIndex = 3;
            this.RadioFormaL.TabStop = true;
            this.RadioFormaL.Text = "Forma L";
            this.RadioFormaL.UseVisualStyleBackColor = true;
            this.RadioFormaL.CheckedChanged += new System.EventHandler(this.RadioFormaL_CheckedChanged);
            this.Controls.Add(this.RadioFormaL);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioFormaL);
            // 
            // RadioPolla
            // 
            this.RadioPolla = new System.Windows.Forms.RadioButton();
            this.RadioPolla.AutoSize = true;
            this.RadioPolla.Location = new System.Drawing.Point(6, 68);
            this.RadioPolla.Name = "RadioPolla";
            this.RadioPolla.Size = new System.Drawing.Size(48, 17);
            this.RadioPolla.TabIndex = 2;
            this.RadioPolla.TabStop = true;
            this.RadioPolla.Text = "Polla";
            this.RadioPolla.UseVisualStyleBackColor = true;
            this.RadioPolla.CheckedChanged += new System.EventHandler(this.RadioPolla_CheckedChanged);
            this.Controls.Add(this.RadioPolla);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioPolla);
            // 
            // RadioDiagonal
            // 
            this.RadioDiagonal = new System.Windows.Forms.RadioButton();
            this.RadioDiagonal.AutoSize = true;
            this.RadioDiagonal.Location = new System.Drawing.Point(6, 45);
            this.RadioDiagonal.Name = "RadioDiagonal";
            this.RadioDiagonal.Size = new System.Drawing.Size(67, 17);
            this.RadioDiagonal.TabIndex = 1;
            this.RadioDiagonal.TabStop = true;
            this.RadioDiagonal.Text = "Diagonal";
            this.RadioDiagonal.UseVisualStyleBackColor = true;
            this.RadioDiagonal.CheckedChanged += new System.EventHandler(this.RadioDiagonal_CheckedChanged);
            this.Controls.Add(this.RadioDiagonal);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioDiagonal);
            // 
            // RadioHorzontal
            // 
            this.RadioHorzontal = new System.Windows.Forms.RadioButton();
            this.RadioHorzontal.AutoSize = true;
            this.RadioHorzontal.Location = new System.Drawing.Point(6, 19);
            this.RadioHorzontal.Name = "RadioHorzontal";
            this.RadioHorzontal.Size = new System.Drawing.Size(72, 17);
            this.RadioHorzontal.TabIndex = 0;
            this.RadioHorzontal.TabStop = true;
            this.RadioHorzontal.Text = "Horizontal";
            this.RadioHorzontal.UseVisualStyleBackColor = true;
            this.RadioHorzontal.CheckedChanged += new System.EventHandler(this.RadioHorzontal_CheckedChanged);
            this.Controls.Add(this.RadioHorzontal);
            this.GrupoFromasDeGanar.Controls.Add(this.RadioHorzontal);
            // 
            // BtnBuenas2
            // 
            this.BtnBuenas2 = new System.Windows.Forms.Button();
            this.BtnBuenas2.BackColor = System.Drawing.Color.MintCream;
            this.BtnBuenas2.Location = new System.Drawing.Point(719, 31);
            this.BtnBuenas2.Name = "BtnBuenas2";
            this.BtnBuenas2.Size = new System.Drawing.Size(113, 46);
            this.BtnBuenas2.TabIndex = 100;
            this.BtnBuenas2.Text = " Buenas 2";
            this.BtnBuenas2.UseVisualStyleBackColor = false;
            this.BtnBuenas2.Click += new System.EventHandler(this.BtnBuenas2_Click);
            this.Controls.Add(this.BtnBuenas2);
            // 
            // Multijugador
            // 

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(1370, 661);
            this.Controls.Add(this.BtnBuenas2);
            this.Controls.Add(this.GrupoFromasDeGanar);
            this.Controls.Add(this.GrupoChat);
            this.Controls.Add(this.BtnLimpiar);
            this.Controls.Add(this.LabelCartasRestantes);
            this.Controls.Add(this.BtnChat);
            this.Controls.Add(this.Btnmenos);
            this.Controls.Add(this.Btnmas);
            this.Controls.Add(this.Btnsiguinte);
            this.Controls.Add(this.Tabla4R);
            this.Controls.Add(this.Tabla3R);
            this.Controls.Add(this.Tabla2R);
            this.Controls.Add(this.Tabla1R);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.BtnBuenas);
            this.Controls.Add(this.btnRegresar);
            this.Controls.Add(this.BtnIniciar);
            this.Controls.Add(this.BtnCrearTabla);
            this.Controls.Add(this.BtnIralmenu);
            this.Name = "Multijugador";
            this.Text = "Multijugador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Multijugador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.GrupoChat.ResumeLayout(false);
            this.GrupoChat.PerformLayout();
            this.GrupoFromasDeGanar.ResumeLayout(false);
            this.GrupoFromasDeGanar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void GanarCruzCliente(string[,] x, PictureBox[,] y, string tabla)
        {
            int j = 4;
            for (int i = 1; i < 3; i++)
            {
                if
                (

                (tarjetaCliente.Contains(x[i, 2]) == true && tarjetaCliente.Contains(x[2, i]) == true)

                )
                {
                    if
                    (

                    (y[i, 2].Name == "•" && y[2, i].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
        private void GanarPollaGrandeCliente(string[,] x, PictureBox[,] y, string tabla)
        {
            for (int i = 0; i < 5; i++)
            {
                if (

                    (tarjetaCliente.Contains(x[0, 0]) == true && tarjetaCliente.Contains(x[4, 0]) == true &&
                    tarjetaCliente.Contains(x[2, 2]) == true && tarjetaCliente.Contains(x[0, 4]) == true &&
                    tarjetaCliente.Contains(x[4, 4]))

                    )
                {
                    if (

                        (y[0, 0].Name == "•" && y[0, 4].Name == "•" && y[2, 2].Name == "•" && y[0, 4].Name == "•"
                        && y[4, 4].Name == "•")

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
                MessageBox.Show(tabla + "GANASTE");
            }
            else
            {
                MessageBox.Show("Algunas de las cartas aun no han venido o no la marcaste");
            }
        }
    }
}

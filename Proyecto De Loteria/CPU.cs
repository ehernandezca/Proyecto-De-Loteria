using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Proyecto_De_Loteria
{
    public partial class CPU : Form
    {
        SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        List<VoiceInfo> vocesInfo = new List<VoiceInfo>();
        PictureBox[,] tabla1 = new PictureBox[5, 5];
        string[,] tabla1Copia = new string[5, 5];
        string[,] tabla2Copia = new string[5, 5];
        string[,] tabla3Copia = new string[5, 5];
        string[,] tabla4Copia = new string[5, 5];
        PictureBox[,] tablaPC = new PictureBox[5, 5];
        string[,] tablaPCCopia = new string[5, 5];
        PictureBox[,] tabla2 = new PictureBox[5, 5];
        PictureBox[,] tabla3 = new PictureBox[5, 5];
        PictureBox[,] tabla4 = new PictureBox[5, 5];
        Random random = new Random();
        Random rmd = new Random();
        Image[] cartas = new Image[55];
        Image[] copia = new Image[54];
        int[] tarjeta = new int[54];
        int R = 3;
        bool PollaG = false;
        bool diagonal = false;
        bool Cruz = false;
        bool Hor = false;
        bool Ele = false;
        bool T = false;
        bool TChica;
        bool Z = false;
        bool DosDiagonales = false;
        bool DiagInversa = false;
        string[] tarjetaCopia = new string[54];
        int[] revueltas;
        int[] mazoCartas;
        int t = 1000;
        int[] recipiente = new int[55];
        int pos, leer;
        int i = 0;
        string[] Guardada1 = new string[25];
        string[] Guardada2 = new string[25];
        string[] Guardada3 = new string[25];
        string[] Guardada4 = new string[25];
        string[] fraces = new string[54];
        int contador = 54;
        int resumen;
        int[] point;
        int temp = 0;
        public CPU()

        {
            InitializeComponent();
            int[] mazo = new int[54];
            int[] point = barajearCartas(mazo);
            int x = 0;

            for (int I = 0; I < 5; I++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla1[I, j] = new PictureBox();
                    tabla1[I, j].Size = new Size(50, 80);
                    tabla1[I, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla1[I, j].Location = new Point((I * 70) + 50, (j * 105) + 25);
                    tabla1[I, j].Click += new EventHandler(ponerFicha);
                    tabla1[I, j].DoubleClick += new EventHandler(QuitarFicha);
                    this.Controls.Add(tabla1[I, j]);

                    tablaPC[I, j] = new PictureBox();
                    tablaPC[I, j].Size = new Size(50, 80);
                    tablaPC[I, j].BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (point[x++]) + ".jpeg");
                    tablaPC[I, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tablaPCCopia[I, j] = point[x - 1] + "";
                    tablaPC[I, j].Location = new Point((I * 50) + 900, (j * 80) + 115);
                    tablaPC[I, j].Click += new EventHandler(ponerFicha);
                    tablaPC[I, j].DoubleClick += new EventHandler(QuitarFicha);
                    this.Controls.Add(tablaPC[I, j]);
                }
            }

            timer1.Interval = 2500;

        }
        private void correrProceso()
        {
            Thread.Sleep(10);
            
        }
        private void correrProcesoTablaPC()
        {

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (tarjetaCopia.Contains(tablaPCCopia[i, j]))
                    {
                        tablaPC[i, j].Image = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\");
                        tablaPC[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        tablaPC[i, j].Name = "•";
                    }
                }
            }
        }
        private void ponerFicha(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\");
            ((PictureBox)sender).SizeMode = PictureBoxSizeMode.StretchImage;
            ((PictureBox)sender).Name = "•";
            Btnlimpiar.Visible = true;
        }
        private void QuitarFicha(object sender, EventArgs e)
        {
            ((PictureBox)sender).Image = null;
            ((PictureBox)sender).Name = "";
        }

        private void Btnlimpiar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla1[i, j].Image = null;
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                   tablaPC[i, j].Image = null;
                }
            }

        }
        bool T1 = false;
        private void Btncreartabla_Click(object sender, EventArgs e)
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
                    tabla1[i, j].Size = new Size(50, 80);
                    tabla1[i, j].Location = new Point((i * 50) + 120, (j * 80) + 115);
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
                int aleatorio = rmd.Next(0, 54);
                swap = x[i];
                x[i] = x[aleatorio];
                x[aleatorio] = swap;
            }
            return x;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + revueltas[pos++] + ".jpeg");
            leer = revueltas[pos - 1];
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            tarjeta[i++] = revueltas[pos - 1];
            tarjetaCopia[i - 1] = revueltas[pos - 1].ToString();
            resumen = revueltas[pos - 1];
            lblcartasrestantes.Text = (contador - pos).ToString();
            if (revueltas[pos - 1] == revueltas[53])
            {
                timer1.Stop();
                pictureBox1.Image = null;
                BtnComenzar.Enabled = false;
            }
            ThreadStart delegado1 = new ThreadStart(correrProceso);
            Thread hilo1 = new Thread(delegado1);
            hilo1.Start();
            ThreadStart delegado = new ThreadStart(correrProcesoTablapc);
            Thread hilo = new Thread(delegado);

            hilo.Start();
            if (diagonal == true)
            { 
                GanarDiagonalPC();
            }
            if (DosDiagonales == true)
            {
                GanarDosDiagPC();
            }
            if (DiagInversa == true)
            {
                GanarDiagonalInversaPC();
            }
            if (Hor == true)
            {
                GanarHorizontalPC();
            }
            if (PollaG == true)
            {
                GanarPollaPC();
            }
            if (Cruz == true)
            {
                GanarCruzPC();
            }
            if (Ele==true)
            {
                GanarElePC();
            }
            if (T==true)
            {
                GanarTPC();
            }
            if (TChica == true)
            {
                GanarTChicaPC();
            }
        }
        private void BtnComenzar_Click(object sender, EventArgs e)
        {
            temp = 0;
            BtnRegresar.Enabled = true;

            if (timer1.Enabled)
            {
                timer1.Stop();
                BtnComenzar.Text = "Comenzar";
            }
            else
            {
                timer1.Start();
                BtnComenzar.Text = "Pausar";
            }
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                int atras = tarjeta[pos - (temp + 2)];
                pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + atras + ".jpeg");
                temp++;
                if (atras == tarjeta[0])
                {
                    pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + atras + ".jpeg");
                    MessageBox.Show("Ya no hay cartas");
                    BtnRegresar.Enabled = false;
                    BtnResumen.Enabled = true;
                }
            }
        }

        private void BtnResumen_Click(object sender, EventArgs e)
        {
            pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + resumen + ".jpeg");
            BtnRegresar.Enabled = true;
            temp = 0;
        }
        private void correrProcesoTablapc()
        {

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (tarjetaCopia.Contains(tablaPCCopia[i, j]))
                    {
                        tablaPC[i, j].Image = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\");
                        tablaPC[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                        tablaPC[i, j].Name = "•";
                    }
                }
            }
        }

        private void BtnLento_Click(object sender, EventArgs e)
        {
            timer1.Interval = timer1.Interval + t;
        }

        private void BtnRapido_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Interval = timer1.Interval - t;
                synthesizer.Rate += R;

            }
            catch (Exception)
            {

                MessageBox.Show("No es posible seguir");
            }
        }

        private void Btniralmenu_Click(object sender, EventArgs e)
        {
            Inicio form = new Inicio();
            form.Visible = true;
            this.Close();
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 1; i++)
            {
                int siguiente = tarjeta[pos + (temp - 4 )];
                pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + siguiente + ".jpeg");
                temp++;
                if (siguiente == tarjeta[53])
                {
                    pictureBox1.BackgroundImage = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + siguiente + ".jpeg");
                    MessageBox.Show("Ya no hay cartas");
                    BtnRegresar.Enabled = false;
                    BtnResumen.Enabled = true;
                }
            }

        }
      
        private void BtnBuenas_Click(object sender, EventArgs e)
        {
            if (diagonal == true)
            {
                GanarDiagonal();
            }
            if (DosDiagonales==true)
            {
                GanarDosDiag();
            }
            if (Hor==true)
            {
                GanarHorizontal();
            }
            if (PollaG==true)
            {
                GanarPolla();
            }
            if (Cruz==true)
            {
                GanarCruz();
            }
            if (Ele==true)
            {
                GanarEle();
            }
            if (T==true)
            {
                GanarT();
            }
            if (TChica==true)
            {
                GanarTChica();
            }
        }

        private void CPU_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 54; i++)
            {
                cartas[i] = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (i + 1).ToString() + ".jpeg");
            }
            BtnResumen.Enabled = false;

            int[] mazo = new int[54];
            revueltas = barajearCartas(mazo);
            pos = 0;
            MessageBox.Show("Elije una forma de ganar antes de iniciar");
        }

        private void BtnDiagonal_Click(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                diagonal = true;
            }
            
        }

        private void radiodosdiagonales_CheckedChanged(object sender, EventArgs e)
        {
            if (radiodosdiagonales.Checked)
            {
                DosDiagonales = true;
            }
        }

        private void GanarDiagonalPC()
        {
            for (int i = 0; i < 5; i++)
            {
                if (

                    (tarjetaCopia.Contains(tablaPCCopia[i, i]) == true)

                   )
                {
                    if (

                        (tablaPC[i, i].Name == "•")

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
                MessageBox.Show("PC A GANADO");
                BtnBuenas.Enabled = false;



            }

        }
        private void GanarDiagonalInversaPC()
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if (tarjetaCopia.Contains(tablaPCCopia[i, j--]) == true)
                {
                    if ((tablaPC[i, j + 1].Name == "•"))
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
                MessageBox.Show("PC A GANADO");
                BtnBuenas.Enabled = false;
            }

        }
        private void GanarPollaPC()
        {
            for (int i = 0; i < 5; i++)
            {
                if (

                    (tarjetaCopia.Contains(tablaPCCopia[0, 0]) == true && tarjetaCopia.Contains(tablaPCCopia[4, 0]) == true &&
                    tarjetaCopia.Contains(tablaPCCopia[2, 2]) == true && tarjetaCopia.Contains(tablaPCCopia[0, 4]) == true &&
                    tarjetaCopia.Contains(tablaPCCopia[4, 4]))
                    )
                {
                    if (

                        (tablaPC[0, 0].Name == "•" && tablaPC[0, 4].Name == "•" && tablaPC[2, 2].Name == "•" && tablaPC[0, 4].Name == "•"
                        && tablaPC[4, 4].Name == "•")
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
                MessageBox.Show("PC A GANADO");
                BtnBuenas.Enabled = false;


            }

        }
        private void GanarCruzPC()
        {

            for (int i = 1; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tablaPCCopia[i, 2]) == true && tarjetaCopia.Contains(tablaPCCopia[2, i]) == true)

                )
                {
                    if
                    (

                    (tablaPC[i, 2].Name == "•" && tablaPC[2, i].Name == "•")

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
                MessageBox.Show("PC A GANADO");
                BtnBuenas.Enabled = false;
            }

        }
        private void GanarElePC()
        {

            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tablaPCCopia[0, i]) == true && tarjetaCopia.Contains(tablaPCCopia[i, 4]) == true)

                )
                {
                    if
                    (

                    (tablaPC[0, i].Name == "•" && tablaPC[i, 4].Name == "•")

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
                MessageBox.Show("PC A GANADO");
                BtnBuenas.Enabled = false;
            }

        }
        private void GanarTPC()
        {
           
            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tablaPCCopia[i, 0]) == true && tarjetaCopia.Contains(tablaPCCopia[2, i]) == true)

                )
                {
                    if
                    (

                    (tablaPC[i, 0].Name == "•" && tablaPC[2, i].Name == "•")

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
                MessageBox.Show("PC A GANADO");
                BtnBuenas.Enabled = false;
            }

        }
        private void GanarHorizontalPC()
        {
            for (int i = 0; i < 5; i++)
            {
                if (

                    (tarjetaCopia.Contains(tablaPCCopia[0, i]))

                    )
                {
                    if (

                        (tablaPC[0, i].Name == "•")

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
                MessageBox.Show("PC A GANADO");
                BtnBuenas.Enabled = false;
            }
        }
        private void GanarDosDiagPC()
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tablaPCCopia[i, i]) == true && tarjetaCopia.Contains(tablaPCCopia[i, j--]) == true))

                {
                    if ((tablaPC[i, i].Name == "•" && tablaPC[i, j + 1].Name == "•"))
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
                MessageBox.Show("PC A GANADO");
                BtnBuenas.Enabled = false;


            }

        }
        private void GanarTChicaPC()
        {
            
            for (int i = 1; i < 4; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tablaPCCopia[i, 1]) == true && tarjetaCopia.Contains(tablaPCCopia[2, i]) == true)

                )
                {
                    if
                    (

                    (tablaPC[i, 1].Name == "•" && tablaPC[2, i].Name == "•")

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
                MessageBox.Show("PC A GANADO");
                BtnBuenas.Enabled = false;
            }

        }

        private void Radiodiagonalinversa_CheckedChanged(object sender, EventArgs e)
        {
            if (Radiodiagonalinversa.Checked)
            {
                DiagInversa = true;
            }
        }

        private void RadioHorizontal_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioHorizontal.Checked)
            {
                Hor = true;
            }
        }

        private void GanarDiagonalInversa()
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if (tarjetaCopia.Contains(tabla1Copia[i, j--]) == true)
                {
                    if ((tabla1[i, j + 1].Name == "•"))
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
        private void GanarHorizontal()
        {
            for (int i = 0; i < 5; i++)
            {
                if (

                    (tarjetaCopia.Contains(tabla1Copia[0, i]))

                    )
                {
                    if (

                        (tabla1[0, i].Name == "•")

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
        private void GanarPolla()
        {
            for (int i = 0; i < 5; i++)
            {
                if (

                    (tarjetaCopia.Contains(tabla1Copia[0, 0]) == true && tarjetaCopia.Contains(tabla1Copia[4, 0]) == true &&
                    tarjetaCopia.Contains(tabla1Copia[2, 2]) == true && tarjetaCopia.Contains(tabla1Copia[0, 4]) == true &&
                    tarjetaCopia.Contains(tabla1Copia[4, 4]))
                    )
                {
                    if (

                        (tabla1[0, 0].Name == "•" && tabla1[4, 0].Name == "•" && tabla1[2, 2].Name == "•" && tabla1[0, 4].Name == "•"
                        && tabla1[4, 4].Name == "•")
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
        private void GanarCruz()
        {
            
            for (int i = 1; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tabla1Copia[i, 2]) == true && tarjetaCopia.Contains(tabla1Copia[2, i]) == true)

                )
                {
                    if
                    (

                    (tabla1[i, 2].Name == "•" && tabla1[2, i].Name == "•")

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
        private void GanarEle()
        {

            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tabla1Copia[0, i]) == true && tarjetaCopia.Contains(tabla1Copia[i, 4]) == true)

                )
                {
                    if
                    (

                    (tabla1[0, i].Name == "•" && tabla1[i, 4].Name == "•")

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
        private void GanarT()
        {
           
            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tabla1Copia[i, 0]) == true && tarjetaCopia.Contains(tabla1Copia[2, i]) == true)

                )
                {
                    if
                    (

                    (tabla1[i, 0].Name == "•" && tabla1[2, i].Name == "•")

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
        private void GanarDosDiag()
        {
            int j = 4;
            for (int i = 0; i < 5; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tabla1Copia[i, i]) == true && tarjetaCopia.Contains(tabla1Copia[i, j--]) == true))

                {
                    if ((tabla1[i, i].Name == "•" && tabla1[i, j + 1].Name == "•"))
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
        private void GanarTChica()
        {
           
            for (int i = 1; i < 4; i++)
            {
                if
                (

                (tarjetaCopia.Contains(tabla1Copia[i, 1]) == true && tarjetaCopia.Contains(tabla1Copia[2, i]) == true)

                )
                {
                    if
                    (

                    (tabla1[i, 1].Name == "•" && tabla1[2, i].Name == "•")

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
        private void RadioPollaG_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioPollaG.Checked)
            {
                PollaG = true;
            }
        }

        private void RadioCruz_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioCruz.Checked)
            {
                Cruz = true;
            }
        }

        private void RadioGanarL_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioGanarL.Checked)
            {
                Ele = true;
            }
        }

        private void RadioFomaTCh_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioFomaTCh.Checked)
            {
                TChica = true;
            }
        }

        private void RadioFormaT_CheckedChanged(object sender, EventArgs e)
        {
            if (RadioFormaT.Checked)
            {
                T = true;
            }
        }

        
    }
}

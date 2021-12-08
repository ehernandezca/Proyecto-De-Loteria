using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Proyecto_De_Loteria
{
    public partial class GuardarTablas : Form
    {
        PictureBox[,] cartas = new PictureBox[27, 2];
        PictureBox[,] tabla = new PictureBox[5, 5];
        int x = 1;
        object outputFile1;
        public GuardarTablas()
        {
            InitializeComponent();
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    cartas[i, j] = new PictureBox();
                    cartas[i, j].Location = new Point(((i + 2) * 45), ((j + 1) * 65));
                    cartas[i, j].Size = new Size(40, 60);
                    cartas[i, j].BackColor = Color.Black;
                    cartas[i, j].Image = Image.FromFile(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + (x++) + ".jpeg");
                    cartas[i, j].SizeMode = PictureBoxSizeMode.StretchImage;
                    cartas[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    cartas[i, j].AllowDrop = true;
                    cartas[i, j].DragDrop += Drag_DragDrop;
                    cartas[i, j].MouseDown += Drag_MouseDown;
                    cartas[i, j].DragEnter += Drag_DragEnter;
                    this.Controls.Add(cartas[i, j]);
                }
            }
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    tabla[i, j] = new PictureBox();
                    tabla[i, j].Location = new Point(((i + 7) * 70), ((j + 3) * 90));
                    tabla[i, j].Size = new Size(60, 85);
                    tabla[i, j].BackColor = Color.Violet;
                    tabla[i, j].BackgroundImageLayout = ImageLayout.Stretch;
                    tabla[i, j].AllowDrop = true;
                    tabla[i, j].DragDrop += Drag_DragDrop;
                    tabla[i, j].MouseDown += Drag_MouseDown;
                    tabla[i, j].DragEnter += Drag_DragEnter;
                    this.Controls.Add(tabla[i, j]);
                }
            }
        }

        private void Drag_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Drag_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                PictureBox pic = (PictureBox)sender;
                outputFile1 = sender;
                if (e.Button == MouseButtons.Left)
                {
                    if (pic.Image != null)
                    {
                        pic.DoDragDrop(pic.Image, DragDropEffects.Copy);
                    }
                }

            }
            catch (Exception)
            {

               MessageBox.Show("Arrastra la imagen hacia la tabla");
            }
        }

        private void Drag_DragDrop(object sender, DragEventArgs e)
        {
            PictureBox img = sender as PictureBox;
            img.BackgroundImage = (Image)e.Data.GetData(DataFormats.Bitmap);
        }

        private void Regresar_Click(object sender, EventArgs e)
        {
            Inicio form = new Inicio();
            form.Visible = true;
            Visible = false;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            string nombreTabla;
            nombreTabla = txtnombretabla.Text;
            using (StreamWriter sw = new StreamWriter(@"C:\Users\ACER.LAP\Desktop\Proyecto Loteria\Proyecto De Loteria\Proyecto De Loteria\bin\Debug\" + nombreTabla + ".txt"))

                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        string nombre = tabla[i, j].Name;
                        sw.WriteLine(nombre);
                    }
                }
        }
    }
}

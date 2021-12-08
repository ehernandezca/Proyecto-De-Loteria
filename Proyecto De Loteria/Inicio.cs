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
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void btnMultijugador_Click(object sender, EventArgs e)
        {
            Multijugador frm = new Multijugador();
            frm.Show();
        }

        private void btnJugarSolo_Click(object sender, EventArgs e)
        {
            JugarSolo frm = new JugarSolo();
            frm.Show();
        }

        private void BtnFormasDeGanar_Click(object sender, EventArgs e)
        {
            FormasDeGanar frm = new FormasDeGanar();
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

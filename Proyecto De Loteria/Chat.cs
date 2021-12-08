using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proyecto_De_Loteria
{
    public partial class Chat : Form
    {
        private TcpClient cliente;
        string[] tarjetaCliente = new string[54];
               
        public StreamReader sr;
        public StreamWriter sw;
        public string recive;
        public string TextToSend;
        string name;
        string[] cartasCliente = new string[54];
        byte[] byRec = new byte[255];
        byte[] byEnv = new byte[255];
        public Chat()
        {
            InitializeComponent();
            IPAddress[] LocalIP = Dns.GetHostAddresses(Dns.GetHostName());
            foreach (IPAddress address in LocalIP)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                {
                    txtServerIP.Text = address.ToString();
                }
            }

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (txtMensaje.Text != "")
            {
                TextToSend = name + ": " + txtMensaje.Text;
                backgroundWorker2.RunWorkerAsync();

            }
            txtMensaje.Text = "";
        }

        private void Chat_Load(object sender, EventArgs e)
        {

        }
        int imagen;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 0;
            while (cliente.Connected)
            {
                try
                {

                    recive = sr.ReadLine();
                    this.txtChat.Invoke(new MethodInvoker(delegate()
                    {
                        txtChat.AppendText(recive + "\n");
                        imagen = int.Parse(recive);
                        tarjetaCliente[x++] = recive;

                    }));
                    recive = "";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());

                }
            }
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            TcpListener listener = new TcpListener(IPAddress.Any, int.Parse(txtServerPuerto.Text));
            listener.Start();
            cliente = listener.AcceptTcpClient();
            sr = new StreamReader(cliente.GetStream());
            sw = new StreamWriter(cliente.GetStream());
            sw.AutoFlush = true;
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.WorkerSupportsCancellation = true;
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
                    LabelConectado.Text = ("Se conectó con éxito");
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
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            if (cliente.Connected)
            {
                sw.WriteLine(TextToSend);
                this.txtChat.Invoke(new MethodInvoker(delegate()
                {
                    txtChat.AppendText(TextToSend + "\n");

                }));
            }
            else
            {
                MessageBox.Show("Sending falled");

            }
            backgroundWorker2.CancelAsync();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (txtMensaje.Text != "")
            {
                TextToSend = txtMensaje.Text;
                backgroundWorker2.RunWorkerAsync();
            }
            txtMensaje.Text = "";
        }
    }
}

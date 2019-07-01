using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;


namespace ServidorRemoto
{
    public partial class Display : Form
    {
        public int porta;
        private TcpClient cliente;
        private TcpListener server;
        private NetworkStream stream;

        private readonly Thread listening;
        private readonly Thread GetImage;

        private int x, y;
        Mouse mouse;

   


        BinaryWriter binaryWriter;

        public Display(int porta)
        {



            this.porta = porta;

            cliente = new TcpClient();
            listening = new Thread(startListening);
            GetImage = new Thread(receiveImage);

            mouse = new Mouse();
           

            InitializeComponent();

        }

        private void startListening() {
            while (!cliente.Connected) {
                server.Start();
                cliente = server.AcceptTcpClient();
            }
            GetImage.Start();
        }

        private void stoplistening() {
            server.Stop();
            cliente = null;

            if (listening.IsAlive) listening.Abort();
            if (GetImage.IsAlive) listening.Abort();
        }

        private void SetarImagem(Image image )
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate () { SetarImagem(image); }));
            }
            else
            {
                this.pictureBox.Image = image;
                this.pictureBox.Size = image.Size;
                this.painel.AutoScroll = true;
            }
        }

        private void receiveImage() {

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            while (cliente.Connected) {
                stream = cliente.GetStream();
             
                
                this.SetarImagem((Image)binaryFormatter.Deserialize(stream));


                binaryWriter = new BinaryWriter(stream);



                mouse.x = x;
                mouse.y = y;

                String mouseJson = JsonConvert.SerializeObject(mouse);

                binaryWriter.Write(mouseJson);
                Console.WriteLine(mouseJson);


                mouse.limpar();
                Thread.Sleep(500);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            server = new TcpListener(IPAddress.Any, porta);
            listening.Start();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            stoplistening();
        }

        private void pictureBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            mouse.duploClique = true;
        }

        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            
            if (e.Button == MouseButtons.Left)
            {
                mouse.mouseDown = true;
            }
        }

        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
                {
                    mouse.mouseUp = true;
                }
            
        }




        //---- eventos do mouse

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.Location.X;
            y = e.Location.Y;

        }

        private void pictureBox_Click(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) {
                mouse.cliqueDireito = true;
            }
            else if (e.Button == MouseButtons.Left ){
                mouse.cliqueEsquerdo = true;
            }
            
        }


    }
}

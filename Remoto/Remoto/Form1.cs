using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Remoto
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);






        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
        const Int32 CURSOR_SHOWING = 0x00000001;

        private readonly TcpClient tcpCliente  = new TcpClient();
        private NetworkStream networkStream;
        private BinaryReader binaryReader;
        private int portNumber;
        Boolean usarescala = false;
        int scala = 1;
        int velocidadeThread = 500;
        int qualidade = 50;

        int x, y;
        Boolean cliqueEsquerdo, cliqueDireito;

        private readonly Thread readMensagem;

        Point pt;

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private Image getImage() {
      

            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenShot = new Bitmap( bounds.Width, bounds.Height, PixelFormat.Format16bppRgb555);
            Graphics graphic = Graphics.FromImage(screenShot);

            graphic.CopyFromScreen(bounds.X, bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size, CopyPixelOperation.SourceCopy);

            if (usarescala) {
                Size size = new Size();
                size.Height = Screen.PrimaryScreen.Bounds.Size.Height / scala;
                size.Width = Screen.PrimaryScreen.Bounds.Size.Width / scala;

                return resizeImage((Image)screenShot, size);
            }
            else {
               
                return screenShot;
            }
        }



        private void sendDesktopImage() {
            qualidade = Convert.ToInt32(numericUpDownQualidade.Value);
            usarescala = checkSacala.Checked;
            if (usarescala)
            {      
                scala = Convert.ToInt32(numericUpDownEscala.Value);
            }
            else {
                scala = 1;
            }
            

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            networkStream = tcpCliente.GetStream();

            Image imagem = getImage();

            imagem = Image.FromStream(Util.ToStream(getImage(), ImageFormat.Jpeg, qualidade));

            binaryFormatter.Serialize(networkStream, imagem);

            binaryReader = new BinaryReader(networkStream);

        }

        public Form1()
        {   
            
            pt = new Point();
            readMensagem = new Thread(EscutarServidor);
            InitializeComponent();
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            portNumber = int.Parse(txtPorta.Text);

            try {
                tcpCliente.Connect(txtIp.Text, portNumber);
                MessageBox.Show("conectado!");
            }
            catch (Exception) {
                MessageBox.Show("não conectado!");
            }
        }

        private void btnCompartilhar_Click(object sender, EventArgs e)
        {
            if (btnCompartilhar.Text.StartsWith("Compartilhar"))
            {
                timer.Start();
                btnCompartilhar.Text = "Parar";
                readMensagem.Start();
            }
            else {
                timer.Start();
                btnCompartilhar.Text = "Compartilhar";
            }
        }

        private void checkSacala_CheckedChanged(object sender, EventArgs e)
        {
            usarescala = checkSacala.Checked;
            if (usarescala)
            {
                scala = Convert.ToInt32(numericUpDownEscala.Value);
            }
            else
            {
                scala = 1;
            }
        }

        private void numericUpDownVelocidadeThread_ValueChanged(object sender, EventArgs e)
        {
            velocidadeThread = Convert.ToInt32(numericUpDownVelocidadeThread.Value);
        }

        private void numericUpDownQualidade_ValueChanged(object sender, EventArgs e)
        {
            qualidade = Convert.ToInt32(numericUpDownQualidade.Value);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Thread.Sleep(velocidadeThread);
            sendDesktopImage();
        }

        //escuta

        public void EscutarServidor()
        {
            
            string messageReceived = "";
            do
            {
                if (binaryReader != null) {
                    messageReceived = binaryReader.ReadString();
                    Mouse mouse = new Mouse();
                    mouse = JsonConvert.DeserializeObject<Mouse>(messageReceived);

                    cliqueDireito = mouse.cliqueDireito;
                    cliqueEsquerdo = mouse.cliqueEsquerdo;

                    mouse.x = mouse.x * scala;
                    mouse.y = mouse.y * scala;

                    if (mouse.x != x)
                    {
                        x = mouse.x;
                        pt.X = x;

                        Cursor.Position = pt;
                    }
                    if (mouse.y != y){ 
                        y = mouse.y;
                        pt.Y = y;

                        Cursor.Position = pt;
                    }

                    Console.WriteLine(messageReceived);


                    if (mouse.cliqueEsquerdo) {
                        //perform click            
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    }
                    else if (mouse.cliqueDireito) {
                        //perform click            
                        mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
                    } else if (mouse.duploClique) {
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);

                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    } else if (mouse.mouseDown) {
                        mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                    } else if (mouse.mouseUp) {
                        mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
                    }


                    mouse.limpar();
                }
            }
            while
             (tcpCliente.Connected);
        }

    }

    public static class Util {

        public static Stream ToStream(this Image image, ImageFormat format, int qualidade)
        {
            var stream = new System.IO.MemoryStream();

            EncoderParameter myEncoderParameter;
            EncoderParameters myEncoderParameters;
            myEncoderParameters = new EncoderParameters(1);
            myEncoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qualidade);
            myEncoderParameters.Param[0] = myEncoderParameter;

            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }


    }
}

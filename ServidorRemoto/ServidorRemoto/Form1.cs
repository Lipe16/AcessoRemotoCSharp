using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ServidorRemoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

          
        }

        private void btnLiberar_Click(object sender, EventArgs e)
        {
            new Display( int.Parse(txtPorta.Text)).Show();
        }
    }
}

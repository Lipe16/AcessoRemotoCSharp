using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Remoto
{
    class Mouse
    {
        public Boolean cliqueEsquerdo { get; set; }

        public Boolean duploClique { get; set; }

        public Boolean mouseUp { get; set; }

        public Boolean mouseDown { get; set; }

        public Boolean cliqueDireito { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        public void limpar()
        {
            cliqueEsquerdo = false;
            cliqueDireito = false;
            duploClique = false;
            mouseDown = false;
            mouseUp = false;
        }
    }
}
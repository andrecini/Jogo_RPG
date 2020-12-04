using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Exemplo_Colecoes
{
    public class Coleta
    {
        public PictureBox Pocao1;
        public PictureBox Pocao2;
        public PictureBox Espatula;
        public PictureBox Arcoiro;
        public PictureBox espatulaP;
        public PictureBox arcoiroP;
        public PictureBox pocao1P;
        public PictureBox pocao2P;
        public TextBox numArcoiro, numEspatula;

        public void ContatoAux(PictureBox Fred, PictureBox item, PictureBox itemp, TextBox numArcoiro, TextBox numEspatula)
        {
            if (Fred.Bounds.IntersectsWith(item.Bounds))
            {
                item.Left = -50;
                itemp.BackColor = Color.FromArgb(254, 233, 207);
                itemp.Enabled = true;
                if (item == Arcoiro) numArcoiro.Text = "5";
                else if (item == Espatula) numEspatula.Text = "3";
            }
        }
        public void Contato(PictureBox Fred)
        {
            ContatoAux(Fred, Pocao1, pocao1P, numArcoiro, numEspatula);
            ContatoAux(Fred, Pocao2, pocao2P, numArcoiro, numEspatula);
            ContatoAux(Fred, Espatula, espatulaP, numArcoiro, numEspatula);
            ContatoAux(Fred, Arcoiro, arcoiroP, numArcoiro, numEspatula);
        }

    }
}

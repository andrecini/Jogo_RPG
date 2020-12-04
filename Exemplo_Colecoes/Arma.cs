using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Exemplo_Colecoes
{
    public class Arma
    {
        public static int arma = 0;
        public PictureBox FlechaEsquerda;
        public PictureBox FlechaDireita;
        public PictureBox FlechaCima;
        public PictureBox FlechaBaixo;
        public PictureBox Fred;
        
        public void AtacarEspada(ref PictureBox Espadas, PictureBox Fred)
        {
            Espadas.Left = Fred.Left-30;
            Espadas.Top = Fred.Top-23;
            
        }

        public void AtacarFlechas()
        {
            FlechaEsquerda.Location = new Point(Fred.Location.X - 35, Fred.Location.Y);

            FlechaDireita.Location = new Point(Fred.Location.X + 30, Fred.Location.Y);

            FlechaCima.Location = new Point(Fred.Location.X, Fred.Location.Y - 35);

            FlechaBaixo.Location = new Point(Fred.Location.X, Fred.Location.Y + 35);

        }
    }
}

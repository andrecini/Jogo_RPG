using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Exemplo_Colecoes
{
    public class MovimentaInimigos
    {
        public PictureBox[] Inimigos = new PictureBox[6];
        Random rdm = new Random();
        private void Mexer(PictureBox Inimigo, PictureBox Fred, int velocidade, int prob)
        {
            if (rdm.Next(1, 7) <= prob)
            {
                Inimigo.Left += velocidade * rdm.Next(-1, 2);
                Inimigo.Top += velocidade * rdm.Next(-1, 2);
            }
            else
            {
                if (Inimigo.Left > Fred.Left) Inimigo.Left -= velocidade;
                else Inimigo.Left += velocidade;
                if (Inimigo.Top > Fred.Top) Inimigo.Top -= velocidade;
                else Inimigo.Top += velocidade;
            }
        }
        public void SetPositions(PictureBox Fred)
        {
            Mexer(Inimigos[0], Fred, 3, 2);
            Mexer(Inimigos[1], Fred, 3, 2);
            Mexer(Inimigos[2], Fred, 8, 3);
            Mexer(Inimigos[3], Fred, 8, 3);
            Mexer(Inimigos[4], Fred, 5, 4);
            Mexer(Inimigos[5], Fred, 5, 4);
        }
    }
}

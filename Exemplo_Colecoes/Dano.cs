using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Exemplo_Colecoes
{
    class Dano
    {
        public PictureBox[] Minotouro= new PictureBox[2];
        public PictureBox[] Fantasma = new PictureBox[2]; 
        public PictureBox[] Povo= new PictureBox[2];
        public TextBox numArcoiro, numEspatula;

        #region Inimigos
        private void AtaqueInimigoAux(PictureBox inimigo, PictureBox Fred, int dano,ref ProgressBar a)
        {
            try
            {
                if (Fred.Bounds.IntersectsWith(inimigo.Bounds))
                {
                    a.Value -= dano;
                }
            }
            catch
            {
                a.Value = 0;
            }
        }

        public void AtaqueInimigo(PictureBox Fred,ref ProgressBar a)
        {
            AtaqueInimigoAux(Minotouro[0], Fred, 30, ref a);
            AtaqueInimigoAux(Minotouro[1], Fred, 30, ref a);
            AtaqueInimigoAux(Fantasma[0], Fred, 10, ref a);
            AtaqueInimigoAux(Fantasma[1], Fred, 10, ref a);
            AtaqueInimigoAux(Povo[0], Fred, 20, ref a);
            AtaqueInimigoAux(Povo[1], Fred, 20, ref a);
        }
        #endregion

        #region Espatula
        public bool AtaqueEspada(PictureBox Espadas ,Label polvos, Label fantasmas, Label minotouro, Control x)
        {
            
                if (x is PictureBox && x.Tag.ToString() == "Minotouro")
                {
                    return UsaArma(x, minotouro, Espadas);
                     
                }
                if (x is PictureBox && x.Tag.ToString() == "Povo")
                {
                    return UsaArma(x, polvos, Espadas);
                   
                }
                if (x is PictureBox && x.Tag.ToString() == "Fantasma")
                {
                    return UsaArma(x, fantasmas, Espadas);
                    
                }
                return false;
        }

        public bool UsaArma(Control x, Label lbl, PictureBox Espadas)
        {
            if (Espadas.Bounds.IntersectsWith(x.Bounds))
            {
                x.Left = 10000;
                if ((int.Parse(lbl.Text) > 0))
                {
                    lbl.Text = (int.Parse(lbl.Text) - 1).ToString();
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Arcoiro
        public bool AtaqueFlecha(PictureBox[] flecha, Label polvos, Label fantasmas, Label minotouro, Control x)
        {

            if (x is PictureBox && x.Tag.ToString() == "Minotouro")
            {
                return UsaArma(x, minotouro, flecha);

            }
            if (x is PictureBox && x.Tag.ToString() == "Povo")
            {
                return UsaArma(x, polvos, flecha);

            }
            if (x is PictureBox && x.Tag.ToString() == "Fantasma")
            {
                return UsaArma(x, fantasmas, flecha);

            }
            return false;
        }

        public bool UsaArma(Control x, Label lbl, PictureBox[] flechas)
        {
            for (int i = 0; i < flechas.Length; i++)
            {
                if (flechas[i].Bounds.IntersectsWith(x.Bounds))
                {
                    x.Left = 10000;
                    flechas[0].Left = 10000;
                    flechas[1].Left = 10000;
                    flechas[2].Left = 10000;
                    flechas[3].Left = 10000;

                    if ((int.Parse(lbl.Text) > 0))
                    {
                        lbl.Text = (int.Parse(lbl.Text) - 1).ToString();
                    }
                    return true;
                }
            }
            return false;
        }
        #endregion
    }
}

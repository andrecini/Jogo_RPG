using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Exemplo_Colecoes
{
    public class MovimentaPersonagem
    {
        public PictureBox Fred;
        public bool cima, baixo, esquerda, direita;

        #region Botões Controle

        /// <summary>
        /// Botão pressionado
        /// </summary>
        /// <param name="e"></param>
        public void Pressionar(Keys e)
        {
            if (e == Keys.Up)
            {
                cima = true;
                            }
            if (e == Keys.Down)
            {
                baixo = true;
            }
            if (e == Keys.Left)
            {
                esquerda = true;
            }
            if (e == Keys.Right)
            {
                direita = true;
            }
        }

        /// <summary>
        /// Botão despressionado
        /// </summary>
        /// <param name="e"></param>
        public void Soltar(Keys e)
        {
            if (e == Keys.Up)
            {
                cima = false;

            }
            if (e == Keys.Down)
            {
                baixo = false;

            }
            if (e == Keys.Left)
            {
                esquerda = false;

            }
            if (e == Keys.Right)
            {
                direita = false;
            }
        }

        #endregion

        /// <summary>
        /// Movimenta o jogador para cima,
        /// baixo, direita e esquerda na 
        /// tela principal.
        /// </summary>
        public void Movimenta()
        {
            if (cima)
            {
                Fred.Top -= 5;
            }
            if (baixo)
            {
                Fred.Top += 5;
            }
            if (esquerda)
            {
                Fred.Left -= 5;
            }
            if (direita)
            {
                Fred.Left += 5;
            }
        }

        /// <summary>
        /// Verifica se o personagem não 
        /// ultrapassou os limites do mapa
        /// </summary>
        public void VerificaExtremos()
        {
            if (baixo && Fred.Top >= 232)
            {
                Fred.Top = 232;
                baixo = false;
            }
            if (cima && Fred.Top <= 0)
            {
                Fred.Top = 0;
                cima = false;
            }
            if (esquerda && Fred.Left <= 0)
            {
                Fred.Left = 0;
                esquerda = false;
            }
            if (direita && Fred.Left >= 420)
            {
                Fred.Left = 420;
                direita = false;
            }
        }
    }
}

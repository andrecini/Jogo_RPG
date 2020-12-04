using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Drawing;

namespace Exemplo_Colecoes
{
    public class CriacaoPosicao
    {
        public PictureBox Fred;
        public PictureBox Pocao1;
        public PictureBox Pocao2;
        public PictureBox Espatula;
        public PictureBox Arcoiro;
        public PictureBox Povo1;
        public PictureBox Povo2;
        public PictureBox Minotouro1;
        public PictureBox Minotouro2;
        public PictureBox Fantasma1;
        public PictureBox Fantasma2;
        
        private int aleatorio()
        {
            Random random = new Random();
            return random.Next(1, 4);
        }

        private string[] LeArquivoPosicao()
        {
            int aux = aleatorio();
            return File.ReadAllLines(aux.ToString() + ".txt");
        }

        public void GeraPosicao()
        {
            string[] posicoes = LeArquivoPosicao();

            Fred.Location = new Point(int.Parse(posicoes[0].Split(',')[0]), int.Parse(posicoes[0].Split(',')[1]));
            Pocao1.Location = new Point(int.Parse(posicoes[1].Split(',')[0]), int.Parse(posicoes[1].Split(',')[1]));
            Pocao2.Location = new Point(int.Parse(posicoes[2].Split(',')[0]), int.Parse(posicoes[2].Split(',')[1]));
            Minotouro1.Location = new Point(int.Parse(posicoes[3].Split(',')[0]), int.Parse(posicoes[3].Split(',')[1]));
            Minotouro2.Location = new Point(int.Parse(posicoes[4].Split(',')[0]), int.Parse(posicoes[4].Split(',')[1]));
            Espatula.Location = new Point(int.Parse(posicoes[5].Split(',')[0]), int.Parse(posicoes[5].Split(',')[1]));
            Arcoiro.Location = new Point(int.Parse(posicoes[6].Split(',')[0]), int.Parse(posicoes[6].Split(',')[1]));
            Fantasma1.Location = new Point(int.Parse(posicoes[7].Split(',')[0]), int.Parse(posicoes[7].Split(',')[1]));
            Fantasma2.Location = new Point(int.Parse(posicoes[8].Split(',')[0]), int.Parse(posicoes[8].Split(',')[1]));
            Povo1.Location = new Point(int.Parse(posicoes[9].Split(',')[0]), int.Parse(posicoes[9].Split(',')[1]));
            Povo2.Location = new Point(int.Parse(posicoes[10].Split(',')[0]), int.Parse(posicoes[10].Split(',')[1]));
            
        }

       

       
    }
    
}

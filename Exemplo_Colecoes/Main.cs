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
    public partial class Main : Form
    {
        #region variaveis
        int start = 0;
        int contador_flecha = 0;
        int contador_Espatula = 0;
        int contador_UsoArma = 0;
        public PictureBox[] flechas = new PictureBox[4];
        public bool cima, baixo, esquerda, direita;
        #endregion
        
        #region classes instanciadas
        Arma armas = new Arma();
        Coleta coleta = new Coleta();
        CriacaoPosicao posicao = new CriacaoPosicao();
        MovimentaPersonagem movPersonagem = new MovimentaPersonagem();
        BarraDeItens barra = new BarraDeItens();
        Dano dano = new Dano();
        MovimentaInimigos movInim = new MovimentaInimigos();
        #endregion

        public Main()
        {
            InitializeComponent();
            movPersonagem.Fred = Fred;
            
            porcentagemVida.Text = Saude.Value.ToString() + "%";

            #region Objetos Classe CriacaoPosicao
            posicao.Fred = Fred;
            posicao.Pocao1 = Pocao1;
            posicao.Pocao2 = Pocao2;
            posicao.Minotouro1 = Miotouro1;
            posicao.Minotouro2 = Miotouro2;
            posicao.Espatula = Espatula;
            posicao.Arcoiro = ArcoIro;
            posicao.Fantasma1 = Fantasma1;
            posicao.Fantasma2 = Fantasma2;
            posicao.Povo1 = Povo1;
            posicao.Povo2 = Povo2;
            #endregion

            #region Objetos Classe MovimentaInimigos
            movInim.Inimigos[0] = Miotouro1;
            movInim.Inimigos[1] = Miotouro2;
            movInim.Inimigos[2] = Fantasma1;
            movInim.Inimigos[3] = Fantasma2;
            movInim.Inimigos[4] = Povo1;
            movInim.Inimigos[5] = Povo2;
            #endregion

            #region Objetos Classe Coleta
            coleta.Pocao1 = Pocao1;
            coleta.pocao1P = pocao1P;
            coleta.Pocao2 = Pocao2;
            coleta.pocao2P = pocao2P;
            coleta.Espatula = Espatula;
            coleta.espatulaP = espatulaP;
            coleta.arcoiroP = arcoiroP;
            coleta.Arcoiro = ArcoIro;
            coleta.numArcoiro = textBox2;
            coleta.numEspatula = textBox1;
            #endregion

            #region Objetos Classe Dano
            dano.numArcoiro = textBox2;
            dano.numEspatula = textBox1;
            dano.Minotouro[0] = Miotouro1;
            dano.Minotouro[1] = Miotouro2;
            dano.Fantasma[0] = Fantasma1;
            dano.Fantasma[1] = Fantasma2;
            dano.Povo[0] = Povo1;
            dano.Povo[1] = Povo2;
            flechas[0] = FlechaBaixo;
            flechas[1] = FlechaCima;
            flechas[2] = FlechaDireita;
            flechas[3] = FlechaEsquerda;
            #endregion

            #region Objetos Classe Armas
            armas.FlechaBaixo = FlechaBaixo;
            armas.FlechaCima = FlechaCima;
            armas.FlechaDireita = FlechaDireita;
            armas.FlechaEsquerda = FlechaEsquerda;
            armas.Fred = Fred;
            #endregion
            
            Espadas.Left = -100;
                     
            posicao.GeraPosicao();  
        }

        private void Play_Click(object sender, EventArgs e)
        {
            Timer.Enabled = true;
            Timer.Start();
            timer1.Enabled = true;
            timer1.Start();
            timer2.Enabled = true;
            DanoTempo.Enabled = true;
        }

        #region Eventos de Click
        private void Main_KeyDown(object sender, KeyEventArgs e)
        {
            movPersonagem.Pressionar(e.KeyCode);

            if (e.KeyCode == Keys.Enter && start == 0)
            {
                start = 1;
                Timer.Enabled = true;
                Timer.Start();
                timer1.Enabled = true;
                timer1.Start();
                timer2.Enabled = true;
                DanoTempo.Enabled = true;
            }

            if (e.KeyCode == Keys.S && Arma.arma == 1  && int.Parse(textBox1.Text) > 0)
            {
                contador_Espatula = 1;
                contador_UsoArma++;
                if (int.Parse(textBox1.Text) > 0)
                    textBox1.Text = (int.Parse(textBox1.Text) - 1).ToString();
            }

            if (e.KeyCode == Keys.A && Arma.arma == 2 && contador_flecha == 0 && int.Parse(textBox2.Text) > 0)
            {
                armas.AtacarFlechas();

                tmrFlecha.Enabled = true;

                contador_flecha = 1;
                contador_UsoArma++;

                if (int.Parse(textBox2.Text) > 0)
                    textBox2.Text = (int.Parse(textBox2.Text) - 1).ToString();
            }

            if (e.KeyCode == Keys.D2 && espatulaP.BackColor == Color.FromArgb(254, 233, 207)) Arma.arma = 1;
            if (e.KeyCode == Keys.D1 && arcoiroP.BackColor == Color.FromArgb(254, 233, 207)) Arma.arma = 2;
            if (e.KeyCode == Keys.D3 && pocao1P.BackColor == Color.FromArgb(254, 233, 207)) barra.ClickPocao(pocao1P, Saude);
            if (e.KeyCode == Keys.D4 && pocao2P.BackColor == Color.FromArgb(254, 233, 207)) barra.ClickPocao(pocao2P, Saude);
        }

        private void Main_KeyUp(object sender, KeyEventArgs e)
        {
            movPersonagem.Soltar(e.KeyCode);
        }
        #endregion

        #region Timers
        private void TimerPrincipal_Tick(object sender, EventArgs e)
        {
            movPersonagem.Movimenta();
            movPersonagem.VerificaExtremos();
            coleta.Contato(Fred);
            porcentagemVida.Text = Saude.Value.ToString() + "%";
            if (contador_Espatula != 0 && contador_Espatula < 5)
            {
                armas.AtacarEspada(ref Espadas, Fred);
                contador_Espatula++;
            }
            else
            {
                contador_Espatula = 0;
                Espadas.Left = -100;
            }

            if (contador_UsoArma == 1)
            {
                foreach (Control x in panel3.Controls)
                {
                    if (dano.AtaqueEspada(Espadas, LabelP, LabelF, LabelC, x))
                    {
                        contador_UsoArma = 0;
                        break;
                    }
                    if (dano.AtaqueFlecha(flechas, LabelP, LabelF, LabelC, x))
                    {
                        contador_UsoArma = 0;
                        break;
                    }
                }
                
            }

        }
        private void TimerFlecha_Tick(object sender, EventArgs e)
        {
            if (contador_flecha > 0 && contador_flecha < 51)
            {
                FlechaBaixo.Top += 10;
                FlechaCima.Top -= 10;
                FlechaDireita.Left += 10;
                FlechaEsquerda.Left -= 10;
                contador_flecha++;
            }
            else
            {
                contador_flecha = 0;
                tmrFlecha.Enabled = false;
            }
        }
        private void TimerMovimentaInimigos_Tick(object sender, EventArgs e)
        {
            movInim.SetPositions(Fred);
        }
        private void TimerStamina_Tick(object sender, EventArgs e)
        {
            if(Stamina.Value != 0) Stamina.Value -= 1;
        }
        private void TimerDanoTempo_Tick(object sender, EventArgs e)
        {
            dano.AtaqueInimigo(Fred, ref Saude);
            if (Saude.Value == 0)
            {
                DanoTempo.Stop();
                MessageBox.Show("Game Over");
            }
        }
        #endregion

        #region Inventário
        private void pocao1P_Click(object sender, EventArgs e)
        {
            barra.ClickPocao(pocao1P, Saude);
        }
        private void pocao2P_Click(object sender, EventArgs e)
        {
            barra.ClickPocao(pocao2P, Saude);
        }
        private void espatulaP_Click(object sender, EventArgs e)
        {
            if (espatulaP.BackColor == Color.FromArgb(254, 233, 207)) Arma.arma = 1;
        }

        private void arcoiroP_Click(object sender, EventArgs e)
        {
            if (arcoiroP.BackColor == Color.FromArgb(254, 233, 207)) Arma.arma = 2;
        }


        #endregion
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Exemplo_Colecoes
{
    public class BarraDeItens
    {
        public void ClickPocao(PictureBox pic, ProgressBar a)
        {
            pic.Enabled = false;
            pic.BackColor = Color.LightSlateGray;
            if (a.Value <= 80)
            {
                a.Value += 20;
            }
            else a.Value = 100;
            
        }
       
    }
}

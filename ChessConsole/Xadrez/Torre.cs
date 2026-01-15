using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez
{
    public class Torre : Peca
    {
        public Torre(Cor cor,Tabuleiro.Tabuleiro tabuleiro) : base(cor,tabuleiro)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}

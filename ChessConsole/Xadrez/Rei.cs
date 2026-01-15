using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez
{
    public class Rei : Peca
    {

        public Rei(Cor cor, Tabuleiro.Tabuleiro tab) : base(cor, tab)
        {
        }

        public override string ToString()
        {
            return "R";
        }

    }
}

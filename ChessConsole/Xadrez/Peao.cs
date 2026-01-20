using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez
{
    public class Peao : Peca
    {
        public Peao(Cor cor,Tabuleiro.Tabuleiro tab) : base(cor,tab)
        {

        }

        public override bool[,] MovimentosPossiveis() {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "P";
        }
    }
}

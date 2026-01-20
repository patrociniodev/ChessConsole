using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez
{
    public class Cavalo : Peca
    {
        public Cavalo(Cor cor,Tabuleiro.Tabuleiro tabuleiro) : base(cor,tabuleiro)
        {
        }

        public override bool[,] MovimentosPossiveis() {
            throw new NotImplementedException();
        }

        public override string? ToString()
        {
            return "C";
        }
    }
}

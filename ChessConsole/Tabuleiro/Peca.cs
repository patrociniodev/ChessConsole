using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    public abstract class Peca
    {
        public Posicao? Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdMovimentosFeitos { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }

        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            Cor = cor;
            Tabuleiro = tabuleiro;
            Posicao = null;
            QtdMovimentosFeitos = 0;
        }

        public void IncrementarQtdMovimentos()
        {
            QtdMovimentosFeitos++;
        }

        public bool PodeMover(Posicao pos)
        {
            Peca p = Tabuleiro.ObterPecaPorPosicao(pos);
            return p == null || p.Cor != Cor;
        }

        public bool IsPecaInimiga(Posicao pos)
        {
            Peca p = Tabuleiro.ObterPecaPorPosicao(pos);
            return p != null && p.Cor != Cor;
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}

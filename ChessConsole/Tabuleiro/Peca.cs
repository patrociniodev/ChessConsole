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

        public abstract bool[,] MovimentosPossiveis();

        public void IncrementarQtdMovimentos()
        {
            QtdMovimentosFeitos++;
        }

        public void DecrementarQtdMovimentos()
        {
            QtdMovimentosFeitos--;
        }

        public bool IsMovimentoPossivel(Posicao pos)
        {
            return this.MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public bool PodeMoverPara(Posicao pos)
        {
            Peca p = Tabuleiro.ObterPecaNaPosicao(pos);
            return p == null || p.Cor != Cor;
        }
        public bool IsPecaInimiga(Posicao pos)
        {
            Peca p = Tabuleiro.ObterPecaNaPosicao(pos);
            return p != null && p.Cor != Cor;
        }

        public bool PossuiAlgumMovimentoPossivel()
        {
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (MovimentosPossiveis()[i, j])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}

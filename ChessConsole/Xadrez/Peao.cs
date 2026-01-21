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
        public override string ToString()
        {
            return "P";
        }

        private bool EstaLivre(Posicao pos)
        {
            return Tabuleiro.ObterPecaNaPosicao(pos) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matrizPosicoesLivres = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            if(Cor == Cor.Branca)
            {

                pos.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if(Tabuleiro.IsPosicaoValida(pos) && EstaLivre(pos))
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValoresPosicao(Posicao.Linha - 2, Posicao.Coluna);
                if(Tabuleiro.IsPosicaoValida(pos) && EstaLivre(pos) && QtdMovimentosFeitos == 0)
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.IsPosicaoValida(pos) && IsPecaInimiga(pos))
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValoresPosicao(Posicao.Linha - 1 , Posicao.Coluna + 1);
                if (Tabuleiro.IsPosicaoValida(pos) && IsPecaInimiga(pos))
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                pos.DefinirValoresPosicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.IsPosicaoValida(pos) && EstaLivre(pos))
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValoresPosicao(Posicao.Linha + 2, Posicao.Coluna);
                if (Tabuleiro.IsPosicaoValida(pos) && EstaLivre(pos) && QtdMovimentosFeitos == 0)
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValoresPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.IsPosicaoValida(pos) && IsPecaInimiga(pos))
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValoresPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.IsPosicaoValida(pos) && IsPecaInimiga(pos))
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }
            }

            return matrizPosicoesLivres;
        }

    }
}

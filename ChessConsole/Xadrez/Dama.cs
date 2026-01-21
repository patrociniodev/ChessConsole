using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez
{
    public class Dama : Peca
    {
        public Dama(Cor cor, Tabuleiro.Tabuleiro tab) : base(cor, tab)
        {

        }
        public override string ToString()
        {
            return "D";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizPosicoesLivres = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna);
            while (Tabuleiro.IsPosicaoValida(pos) && PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                if (IsPecaInimiga(pos))
                {
                    break;
                }

                pos.Linha = pos.Linha - 1;
            }

            // À direita
            pos.DefinirValoresPosicao(Posicao.Linha, Posicao.Coluna + 1);
            while (Tabuleiro.IsPosicaoValida(pos) && PodeMoverPara(pos))
            {
                if (IsPecaInimiga(pos))
                {
                    break;
                }
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;

                pos.Coluna = pos.Coluna + 1;
            }
            // Abaixo
            pos.DefinirValoresPosicao(Posicao.Linha + 1, Posicao.Coluna);
            while (Tabuleiro.IsPosicaoValida(pos) && PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;

                if (IsPecaInimiga(pos))
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            // À esquerda
            pos.DefinirValoresPosicao(Posicao.Linha, Posicao.Coluna - 1);
            while (Tabuleiro.IsPosicaoValida(pos) && PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;

                if (IsPecaInimiga(pos))
                {
                    break;
                }

                pos.Coluna = pos.Coluna - 1;
            }

            // NO
            pos.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.IsPosicaoValida(pos) && PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                if (IsPecaInimiga(pos))
                {
                    break;
                }

                pos.DefinirValoresPosicao(pos.Linha - 1, pos.Coluna - 1);
            }

            // NE
            pos.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while (Tabuleiro.IsPosicaoValida(pos) && PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                if (IsPecaInimiga(pos))
                {
                    break;
                }

                pos.DefinirValoresPosicao(pos.Linha - 1, pos.Coluna + 1);
            }

            // SE
            pos.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while (Tabuleiro.IsPosicaoValida(pos) && PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                if (IsPecaInimiga(pos))
                {
                    break;
                }

                pos.DefinirValoresPosicao(pos.Linha - 1, pos.Coluna - 1);
            }

            // SO
            pos.DefinirValoresPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.IsPosicaoValida(pos) && PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                if (IsPecaInimiga(pos))
                {
                    break;
                }

                pos.DefinirValoresPosicao(pos.Linha + 1, pos.Coluna + 1);
            }


            return matrizPosicoesLivres;
        }

    }
}

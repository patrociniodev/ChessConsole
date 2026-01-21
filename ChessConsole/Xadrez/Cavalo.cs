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
        public Cavalo(Cor cor, Tabuleiro.Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }
        public override string? ToString()
        {
            return "C";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizPosicoesLivres = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao p = new Posicao(0, 0);

            p.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna - 2);
            if (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
            }

            p.DefinirValoresPosicao(Posicao.Linha - 2, Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
            }

            p.DefinirValoresPosicao(Posicao.Linha - 2, Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
            }

            p.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
            }

            p.DefinirValoresPosicao(Posicao.Linha + 1, Posicao.Coluna + 2);
            if (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
            }

            p.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna + 2);
            if (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
            }

            p.DefinirValoresPosicao(Posicao.Linha + 2, Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
            }

            p.DefinirValoresPosicao(Posicao.Linha + 2, Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
            }

            p.DefinirValoresPosicao(Posicao.Linha + 1, Posicao.Coluna - 2);
            if (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
            }

            return matrizPosicoesLivres;
        }

    }
}

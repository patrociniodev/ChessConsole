using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez
{
    public class Bispo : Peca
    {
        public Bispo(Cor cor, Tabuleiro.Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizPosicoesLivres = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao p = new Posicao(0, 0);

            p.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
            while(Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
                if(IsPecaInimiga(p))
                {
                    break;
                }

                p.DefinirValoresPosicao(p.Linha - 1, p.Coluna - 1);
            }

            p.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
            while(Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
                if(IsPecaInimiga(p))
                {
                    break;
                }

                p.DefinirValoresPosicao(p.Linha - 1, p.Coluna + 1);
            }

            p.DefinirValoresPosicao(Posicao.Linha + 1, Posicao.Coluna + 1);
            while (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
                if (IsPecaInimiga(p))
                {
                    break;
                }

                p.DefinirValoresPosicao(p.Linha + 1, p.Coluna + 1);
            }

            p.DefinirValoresPosicao(Posicao.Linha + 1, Posicao.Coluna - 1);
            while (Tabuleiro.IsPosicaoValida(p) && PodeMoverPara(p))
            {
                matrizPosicoesLivres[p.Linha, p.Coluna] = true;
                if (IsPecaInimiga(p))
                {
                    break;
                }

                p.DefinirValoresPosicao(p.Linha + 1, p.Coluna - 1);
            }

            return matrizPosicoesLivres;
        }
    }
}

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
        public Torre(Cor cor, Tabuleiro.Tabuleiro tabuleiro) : base(cor, tabuleiro)
        {
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizPosicoesLivres = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            //Verifica se está livre na posição acima
            pos.DefinirValoresPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna);
            while (Tabuleiro.IsPosicaoValida(pos) && IsMovimentoPossivel(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                if (IsPecaInimiga(pos))
                {
                    break;
                }

                pos.Linha = pos.Linha - 1;
            }

            //Verifica se está livre na posição à direita
            pos.DefinirValoresPosicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
            while (Tabuleiro.IsPosicaoValida(pos) && IsMovimentoPossivel(pos))
            {
                if (IsPecaInimiga(pos))
                {
                    break;
                }
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;

                pos.Coluna = pos.Coluna + 1;
            }
            //Verifica se está livre na posição abaixo
            pos.DefinirValoresPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna);
            while (Tabuleiro.IsPosicaoValida(pos) && IsMovimentoPossivel(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;

                if (IsPecaInimiga(pos))
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }
            //Verifica se está livre na posição à esquerda
            pos.DefinirValoresPosicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
            while (Tabuleiro.IsPosicaoValida(pos) && IsMovimentoPossivel(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;

                if (IsPecaInimiga(pos))
                {
                    break;
                }

                pos.Coluna = pos.Coluna - 1;
            }

            return matrizPosicoesLivres;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}

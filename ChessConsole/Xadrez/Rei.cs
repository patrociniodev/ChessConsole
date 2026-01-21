using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez {
    public class Rei : Peca {

        public Rei(Cor cor, Tabuleiro.Tabuleiro tab) : base(cor, tab) {
        }

        private bool PodeMoverPara(Posicao pos)
        {
            Peca p = Tabuleiro.ObterPecaNaPosicao(pos);
            return p == null || p.Cor != Cor;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matrizPosicoesLivres = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            //Verifica se está livre na posição acima
            pos.DefinirValoresPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos)) {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            //Verifica se está livre na posição à nordeste
            pos.DefinirValoresPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos)) {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            //Verifica se está livre na posição à direita
            pos.DefinirValoresPosicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos)) {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            //Verifica se está livre na posição à sudeste
            pos.DefinirValoresPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos)) {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            //Verifica se está livre na posição abaixo
            pos.DefinirValoresPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos)) {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            //Verifica se está livre na posição à sudoeste
            pos.DefinirValoresPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos)) {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            //Verifica se está livre na posição à esquerda
            pos.DefinirValoresPosicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos)) {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            //Verifica se está livre na posição à noroeste
            pos.DefinirValoresPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos)) {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            return matrizPosicoesLivres;
        }
        public override string ToString() {
            return "R";
        }

    }
}

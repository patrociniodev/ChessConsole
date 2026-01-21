using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez
{
    public class Rei : Peca
    {

        private PartidaDeXadrez Partida;
        public Rei(Cor cor, Tabuleiro.Tabuleiro tab, PartidaDeXadrez partida) : base(cor, tab)
        {
            Partida = partida;
        }

        public override string ToString()
        {
            return "R";
        }

        private bool TesteTorreParaRoque(Posicao pos)
        {
            Peca peca = Tabuleiro.ObterPecaNaPosicao(pos);
            return peca != null && peca is Torre && peca.Cor == Cor;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizPosicoesLivres = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];

            Posicao pos = new Posicao(0, 0);

            // Acima
            pos.DefinirValoresPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            // À nordeste
            pos.DefinirValoresPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            // À direita
            pos.DefinirValoresPosicao(this.Posicao.Linha, this.Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            // À sudeste
            pos.DefinirValoresPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            // Abaixo
            pos.DefinirValoresPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            // SE
            pos.DefinirValoresPosicao(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            // À esquerda
            pos.DefinirValoresPosicao(this.Posicao.Linha, this.Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            // NO
            pos.DefinirValoresPosicao(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            if (Tabuleiro.IsPosicaoValida(pos) && this.PodeMoverPara(pos))
            {
                matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
            }

            // Jogada especial roque
            if(QtdMovimentosFeitos == 0 && !Partida.Xeque)
            {
                //Roque pequeno
                Posicao posicaoTorre1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3);
                if(TesteTorreParaRoque(posicaoTorre1))
                {
                    Posicao posicaoUmaCasaADireitaDoRei = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao posicaoDuasCasasADireitaDoRei = new Posicao(Posicao.Linha, Posicao.Coluna + 2);

                    if(Tabuleiro.ObterPecaNaPosicao(posicaoUmaCasaADireitaDoRei) == null && Tabuleiro.ObterPecaNaPosicao(posicaoDuasCasasADireitaDoRei) == null)
                    {
                        matrizPosicoesLivres[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                //Roque grande
                Posicao posicaoTorre2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4);
                if(TesteTorreParaRoque(posicaoTorre2))
                {
                    Posicao posicaoUmaCasaAEsquerdaDoRei = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao posicaoDuasCasasAEsquerdaDoRei = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao posicaoTresCasasAEsquerdaDoRei = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if(Tabuleiro.ObterPecaNaPosicao(posicaoUmaCasaAEsquerdaDoRei) == null && Tabuleiro.ObterPecaNaPosicao(posicaoDuasCasasAEsquerdaDoRei) == null && Tabuleiro.ObterPecaNaPosicao(posicaoTresCasasAEsquerdaDoRei) == null)
                    {
                        matrizPosicoesLivres[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return matrizPosicoesLivres;
        }


    }
}

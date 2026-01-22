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
        private PartidaDeXadrez Partida;

        public Peao(Cor cor, Tabuleiro.Tabuleiro tab, PartidaDeXadrez partida) : base(cor, tab)
        {
            Partida = partida;
        }
        public override string ToString()
        {
            return "P";
        }

        private bool EstaLivre(Posicao pos)
        {
            return Tabuleiro.ObterPecaNaPosicao(pos) == null;
        }

        public override bool[,] MovimentosPossiveis()
        {
            bool[,] matrizPosicoesLivres = new bool[Tabuleiro.Linhas, Tabuleiro.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca)
            {

                pos.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.IsPosicaoValida(pos) && EstaLivre(pos))
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValoresPosicao(Posicao.Linha - 2, Posicao.Coluna);
                if (Tabuleiro.IsPosicaoValida(pos) && EstaLivre(pos) && QtdMovimentosFeitos == 0)
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.IsPosicaoValida(pos) && IsPecaInimiga(pos))
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValoresPosicao(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.IsPosicaoValida(pos) && IsPecaInimiga(pos))
                {
                    matrizPosicoesLivres[pos.Linha, pos.Coluna] = true;
                }

                // Jogada especial en passant para peças brancas
                if (Posicao.Linha == 3)
                {
                    Posicao posicaoAEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Peca pecaAEsquerda = Tabuleiro.ObterPecaNaPosicao(posicaoAEsquerda);
                    if (Tabuleiro.IsPosicaoValida(posicaoAEsquerda) && IsPecaInimiga(posicaoAEsquerda) && pecaAEsquerda == Partida.VulneravelEnPassant)
                    {
                        matrizPosicoesLivres[posicaoAEsquerda.Linha - 1, posicaoAEsquerda.Coluna] = true;
                    }

                    Posicao posicaoADireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Peca pecaADireita = Tabuleiro.ObterPecaNaPosicao(posicaoADireita);
                    if (Tabuleiro.IsPosicaoValida(posicaoADireita) && IsPecaInimiga(posicaoADireita) && pecaADireita == Partida.VulneravelEnPassant)
                    {
                        matrizPosicoesLivres[posicaoADireita.Linha - 1, posicaoADireita.Coluna] = true;
                    }
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

                // Jogada especial en passant para peças pretas
                if (Posicao.Linha == 4)
                {
                    Posicao posicaoAEsquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Peca pecaAEsquerda = Tabuleiro.ObterPecaNaPosicao(posicaoAEsquerda);
                    if (Tabuleiro.IsPosicaoValida(posicaoAEsquerda) && IsPecaInimiga(posicaoAEsquerda) && pecaAEsquerda == Partida.VulneravelEnPassant)
                    {
                        matrizPosicoesLivres[posicaoAEsquerda.Linha + 1, posicaoAEsquerda.Coluna] = true;
                    }

                    Posicao posicaoADireita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Peca pecaADireita = Tabuleiro.ObterPecaNaPosicao(posicaoADireita);
                    if (Tabuleiro.IsPosicaoValida(posicaoADireita) && IsPecaInimiga(posicaoADireita) && pecaADireita == Partida.VulneravelEnPassant)
                    {
                        matrizPosicoesLivres[posicaoADireita.Linha + 1, posicaoADireita.Coluna] = true;
                    }
                }
            }

            return matrizPosicoesLivres;
        }

    }
}

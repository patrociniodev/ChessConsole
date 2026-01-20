using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    public class Tabuleiro
    {

        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Pecas;
        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }
        public Peca ObterPecaNaPosicao(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca ObterPecaNaPosicao(Posicao pos)
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return ObterPecaNaPosicao(pos) != null;
        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException($"Já existe uma peça na posição {pos.Linha}, {pos.Coluna}");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;

        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (ObterPecaNaPosicao(pos) == null)
            {
                return null;
            }
            Peca aux = ObterPecaNaPosicao(pos);
            aux.Posicao = null;
            Pecas[pos.Linha, pos.Coluna] = null;

            return aux;
        }

        public bool IsPosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!IsPosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}

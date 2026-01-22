using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez;
public class PartidaDeXadrez
{

    public Tabuleiro.Tabuleiro Tabuleiro { get; private set; }
    public int Turno { get; private set; }
    public Cor JogadorDaVez { get; private set; }
    public bool Terminada { get; set; }
    private HashSet<Peca> PecasEmJogo;
    private HashSet<Peca> PecasCapturadas;
    public bool Xeque { get; set; }
    public Peca VulneravelEnPassant { get; set; }

    public PartidaDeXadrez()
    {
        PecasEmJogo = new HashSet<Peca>();
        PecasCapturadas = new HashSet<Peca>();
        Tabuleiro = new Tabuleiro.Tabuleiro(8, 8);

        ColocarPecas();
        Turno = 1;
        JogadorDaVez = Cor.Branca;
        Terminada = false;
        Xeque = false;
        VulneravelEnPassant = null;
    }

    public Peca ExecutarMovimentoNoTabuleiro(Posicao origem, Posicao destino)
    {
        Peca p = Tabuleiro.RetirarPeca(origem);
        p.IncrementarQtdMovimentos();
        Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
        Tabuleiro.ColocarPeca(p, destino);
        if (pecaCapturada != null)
        {
            PecasCapturadas.Add(pecaCapturada);
        }

        // Jogada especial roque pequeno
        if (p is Rei && destino.Coluna == origem.Coluna + 2)
        {
            Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
            Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
            Peca torre = Tabuleiro.RetirarPeca(origemTorre);
            torre.IncrementarQtdMovimentos();
            Tabuleiro.ColocarPeca(torre, destinoTorre);
        }

        // Jogada especial roque grande
        if (p is Rei && destino.Coluna == origem.Coluna - 2)
        {
            Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
            Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
            Peca torre = Tabuleiro.RetirarPeca(origemTorre);
            torre.IncrementarQtdMovimentos();
            Tabuleiro.ColocarPeca(torre, destinoTorre);
        }

        // Jogada especial en passant
        if (p is Peao)
        {
            if (origem.Coluna != destino.Coluna && pecaCapturada == null)
            {
                Posicao posicaoPeao;

                if (p.Cor == Cor.Branca)
                {
                    posicaoPeao = new Posicao(p.Posicao.Linha + 1, p.Posicao.Coluna);
                }
                else
                {
                    posicaoPeao = new Posicao(p.Posicao.Linha - 1, p.Posicao.Coluna);
                }
                pecaCapturada = Tabuleiro.RetirarPeca(posicaoPeao);
                PecasCapturadas.Add(pecaCapturada);
            }
        }

        return pecaCapturada;
    }

    public void DesfazerMovimentoNoTabuleiro(Posicao origem, Posicao destino, Peca? pecaCapturada)
    {
        Peca p = Tabuleiro.RetirarPeca(destino);
        p.DecrementarQtdMovimentos();
        if (pecaCapturada != null)
        {
            Tabuleiro.ColocarPeca(pecaCapturada, destino);
            PecasCapturadas.Remove(pecaCapturada);
        }
        Tabuleiro.ColocarPeca(p, origem);

        //Jogada especial roque pequeno
        if (p is Rei && destino.Coluna == origem.Coluna + 2)
        {
            Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna + 3);
            Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna + 1);
            Peca torre = Tabuleiro.RetirarPeca(destinoTorre);
            torre.DecrementarQtdMovimentos();
            Tabuleiro.ColocarPeca(torre, origemTorre);
        }

        // Jogada especial roque grande
        if (p is Rei && destino.Coluna == origem.Coluna - 2)
        {
            Posicao origemTorre = new Posicao(origem.Linha, origem.Coluna - 4);
            Posicao destinoTorre = new Posicao(origem.Linha, origem.Coluna - 1);
            Peca torre = Tabuleiro.RetirarPeca(destinoTorre);
            torre.DecrementarQtdMovimentos();
            Tabuleiro.ColocarPeca(torre, origemTorre);
        }

        // Jogada especial en passant
        if (p is Peao)
        {
            if (origem.Coluna != destino.Coluna && pecaCapturada == VulneravelEnPassant)
            {
                Peca peao = Tabuleiro.RetirarPeca(destino);
                Posicao posicaoPeao;
                if (p.Cor == Cor.Branca)
                {
                    posicaoPeao = new Posicao(3, destino.Coluna);
                }
                else
                {
                    posicaoPeao = new Posicao(4, destino.Coluna);
                }
                Tabuleiro.ColocarPeca(p, posicaoPeao);
            }
        }
    }

    public void RealizarJogada(Posicao origem, Posicao destino)
    {
        Peca pecaCapturada = ExecutarMovimentoNoTabuleiro(origem, destino);
        if (EstaEmXeque(JogadorDaVez))
        {
            DesfazerMovimentoNoTabuleiro(origem, destino, pecaCapturada);
            throw new TabuleiroException("Você não pode se colocar em xeque!");
        }

        Peca peca = Tabuleiro.ObterPecaNaPosicao(destino);

        // Jogada especial promocao
        if(peca is Peao)
        {
            if(peca.Cor == Cor.Branca && destino.Linha == 0 || peca.Cor == Cor.Preta && destino.Linha == 7)
            {
                Tabuleiro.RetirarPeca(destino);
                PecasEmJogo.Remove(peca);
                Peca dama = new Dama(peca.Cor, Tabuleiro);
                Tabuleiro.ColocarPeca(dama, destino);
                PecasEmJogo.Add(dama);
            }
        }

        if (EstaEmXeque(CorAdversaria(JogadorDaVez)))
        {
            Xeque = true;
        }
        else
        {
            Xeque = false;
        }

        if (EstaEmXequeMate(CorAdversaria(JogadorDaVez)))
        {
            Terminada = true;
        }
        else
        {
            Turno++;
            MudarJogadorDaVez();
        }

        // Jogada especial en passant
        if (peca is Peao && destino.Linha == origem.Linha - 2 || destino.Linha == origem.Linha + 2)
        {
            VulneravelEnPassant = peca;
        }
        else
        {
            VulneravelEnPassant = null;
        }

    }

    private void MudarJogadorDaVez()
    {
        JogadorDaVez = JogadorDaVez == Cor.Branca ? Cor.Preta : Cor.Branca;
    }

    public HashSet<Peca> PecasCapturadasFiltradasPorCor(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca peca in PecasCapturadas)
        {
            if (peca.Cor == cor)
            {
                aux.Add(peca);
            }
        }
        return aux;
    }

    public HashSet<Peca> PecasEmJogoFiltradasPorCor(Cor cor)
    {
        HashSet<Peca> aux = new HashSet<Peca>();
        foreach (Peca peca in PecasEmJogo)
        {
            if (peca.Cor == cor)
            {
                aux.Add(peca);
            }
        }

        aux.ExceptWith(PecasCapturadasFiltradasPorCor(cor));
        return aux;
    }

    public void ValidarPosicaoOrigem(Posicao pos)
    {
        if (Tabuleiro.ObterPecaNaPosicao(pos) == null)
        {
            throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
        }
        if (Tabuleiro.ObterPecaNaPosicao(pos).Cor != JogadorDaVez)
        {
            throw new TabuleiroException("Ainda não é a vez da peça escolhida!");
        }
        if (!Tabuleiro.ObterPecaNaPosicao(pos).PossuiAlgumMovimentoPossivel())
        {
            throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
        }
    }

    public void ValidarPosicaoDestino(Posicao origem, Posicao destino)
    {
        if (!Tabuleiro.ObterPecaNaPosicao(origem).IsMovimentoPossivel(destino))
        {
            throw new TabuleiroException("A posição de destino é inválida!");
        }
    }

    public void ColocarNovaPeca(char linha, int coluna, Peca p)
    {
        Tabuleiro.ColocarPeca(p, new PosicaoXadrez(linha, coluna).ToPosicao());
        PecasEmJogo.Add(p);
    }

    private void ColocarPecas()
    {
        //Brancas
        ColocarNovaPeca('a', 1, new Torre(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('b', 1, new Cavalo(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('c', 1, new Bispo(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('d', 1, new Dama(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('e', 1, new Rei(Cor.Branca, Tabuleiro, this));
        ColocarNovaPeca('f', 1, new Bispo(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('g', 1, new Cavalo(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('h', 1, new Torre(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('a', 2, new Peao(Cor.Branca, Tabuleiro, this));
        ColocarNovaPeca('b', 2, new Peao(Cor.Branca, Tabuleiro, this));
        ColocarNovaPeca('c', 2, new Peao(Cor.Branca, Tabuleiro, this));
        ColocarNovaPeca('d', 2, new Peao(Cor.Branca, Tabuleiro, this));
        ColocarNovaPeca('e', 2, new Peao(Cor.Branca, Tabuleiro, this));
        ColocarNovaPeca('f', 2, new Peao(Cor.Branca, Tabuleiro, this));
        ColocarNovaPeca('g', 2, new Peao(Cor.Branca, Tabuleiro, this));
        ColocarNovaPeca('h', 2, new Peao(Cor.Branca, Tabuleiro, this));

        //Pretas
        ColocarNovaPeca('a', 8, new Torre(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('b', 8, new Cavalo(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('c', 8, new Bispo(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('d', 8, new Dama(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('e', 8, new Rei(Cor.Preta, Tabuleiro, this));
        ColocarNovaPeca('f', 8, new Bispo(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('g', 8, new Cavalo(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('h', 8, new Torre(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('a', 7, new Peao(Cor.Preta, Tabuleiro, this));
        ColocarNovaPeca('b', 7, new Peao(Cor.Preta, Tabuleiro, this));
        ColocarNovaPeca('c', 7, new Peao(Cor.Preta, Tabuleiro, this));
        ColocarNovaPeca('d', 7, new Peao(Cor.Preta, Tabuleiro, this));
        ColocarNovaPeca('e', 7, new Peao(Cor.Preta, Tabuleiro, this));
        ColocarNovaPeca('f', 7, new Peao(Cor.Preta, Tabuleiro, this));
        ColocarNovaPeca('g', 7, new Peao(Cor.Preta, Tabuleiro, this));
        ColocarNovaPeca('h', 7, new Peao(Cor.Preta, Tabuleiro, this));
    }

    private Cor CorAdversaria(Cor cor)
    {
        return (cor == Cor.Branca) ? Cor.Preta : Cor.Branca;
    }

    private Peca Rei(Cor cor)
    {
        var pecas = PecasEmJogoFiltradasPorCor(cor);
        foreach (Peca p in pecas)
        {
            if (p is Rei)
            {
                return p;
            }
        }

        return null;
    }

    public bool EstaEmXeque(Cor cor)
    {
        Peca pecaRei = (Rei)Rei(cor);

        if (pecaRei == null)
        {
            throw new TabuleiroException($"Não há rei da cor {cor} no tabuleiro!");
        }

        foreach (Peca p in PecasEmJogoFiltradasPorCor(CorAdversaria(cor)))
        {
            bool[,] movimentos = p.MovimentosPossiveis();

            if (movimentos[pecaRei.Posicao.Linha, pecaRei.Posicao.Coluna])
            {
                return true;
            }
        }

        return false;
    }

    public bool EstaEmXequeMate(Cor cor)
    {
        if (!EstaEmXeque(cor))
        {
            return false;
        }

        foreach (Peca p in PecasEmJogoFiltradasPorCor(cor))
        {
            bool[,] movimentos = p.MovimentosPossiveis();
            for (int i = 0; i < Tabuleiro.Linhas; i++)
            {
                for (int j = 0; j < Tabuleiro.Colunas; j++)
                {
                    if (movimentos[i, j])
                    {
                        Posicao origem = p.Posicao;
                        Posicao destino = new Posicao(i, j);
                        Peca pecaCapturada = ExecutarMovimentoNoTabuleiro(origem, destino);

                        bool aindaEstaEmXeque = EstaEmXeque(cor);
                        DesfazerMovimentoNoTabuleiro(origem, destino, pecaCapturada);
                        if (!aindaEstaEmXeque)
                        {
                            return false;
                        }
                    }
                }
            }
        }

        return true;
    }
}
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

    public PartidaDeXadrez()
    {
        Tabuleiro = new Tabuleiro.Tabuleiro(8, 8);
        Turno = 1;
        JogadorDaVez = Cor.Branca;
        ColocarPecas();
        Terminada = false;
    }

    public void ExecutarMovimentoNoTabuleiro(Posicao origem, Posicao destino)
    {
        Peca p = Tabuleiro.RetirarPeca(origem);
        p.IncrementarQtdMovimentos();
        Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
        Tabuleiro.ColocarPeca(p, destino);
    }

    public void RealizarJogada(Posicao origem, Posicao destino)
    {
        ExecutarMovimentoNoTabuleiro(origem, destino);
        Turno++;
        MudarJogadorDaVez();
    }

    private void MudarJogadorDaVez()
    {
        JogadorDaVez = JogadorDaVez == Cor.Branca ? Cor.Preta : Cor.Branca;
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
        if(!Tabuleiro.ObterPecaNaPosicao(origem).PodeMoverPara(destino))
        {
            throw new TabuleiroException("A posição de destino é inválida!");
        }
    }

    private void ColocarPecas()
    {
        Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 2).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
        Tabuleiro.ColocarPeca(new Rei(Cor.Branca, Tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.Branca, Tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());

        Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 8).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('c', 7).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 7).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('g', 8).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.Preta, Tabuleiro), new PosicaoXadrez('e', 7).ToPosicao());
        Tabuleiro.ColocarPeca(new Rei(Cor.Preta, Tabuleiro), new PosicaoXadrez('d', 8).ToPosicao());
    }
}

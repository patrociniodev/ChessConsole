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

    public PartidaDeXadrez()
    {
        PecasEmJogo = new HashSet<Peca>();
        PecasCapturadas = new HashSet<Peca>();
        Tabuleiro = new Tabuleiro.Tabuleiro(8, 8);

        ColocarPecas();
        Turno = 1;
        JogadorDaVez = Cor.Branca;
        Terminada = false;
    }

    public void ExecutarMovimentoNoTabuleiro(Posicao origem, Posicao destino)
    {
        Peca p = Tabuleiro.RetirarPeca(origem);
        p.IncrementarQtdMovimentos();
        Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
        Tabuleiro.ColocarPeca(p, destino);
        if (pecaCapturada != null)
        {
            PecasCapturadas.Add(pecaCapturada);
        }
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

    public HashSet<Peca> PecasCapturadasFiltradasPorCor(Cor cor)
    {
        IEnumerable<Peca> aux = PecasCapturadas.Where(p => p.Cor == cor);
        return aux.ToHashSet();
    }

    public HashSet<Peca> PecasEmJogoFiltradasPorCor(Cor cor)
    {

        PecasEmJogo.ExceptWith(PecasCapturadasFiltradasPorCor(cor));

        IEnumerable<Peca> aux = PecasEmJogo.Where(p => p.Cor == cor);
        return aux.ToHashSet();
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
        if (!Tabuleiro.ObterPecaNaPosicao(origem).PodeMoverPara(destino))
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
        ColocarNovaPeca('c', 2, new Torre(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('d', 2, new Torre(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('e', 2, new Torre(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('e', 1, new Torre(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('d', 1, new Rei(Cor.Branca, Tabuleiro));
        ColocarNovaPeca('c', 1, new Torre(Cor.Branca, Tabuleiro));

        ColocarNovaPeca('c', 8, new Torre(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('c', 7, new Torre(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('d', 7, new Torre(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('g', 8, new Torre(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('e', 8, new Torre(Cor.Preta, Tabuleiro));
        ColocarNovaPeca('d', 8, new Rei(Cor.Preta, Tabuleiro));
    }
}

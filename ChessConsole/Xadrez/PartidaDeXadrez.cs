using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Xadrez;
public class PartidaDeXadrez {

    public Tabuleiro.Tabuleiro Tabuleiro { get; private set; }
    private int Turno;
    private Cor CorJogadorDaVez;
    public bool Terminada { get; set; }

    public PartidaDeXadrez() {
        Tabuleiro = new Tabuleiro.Tabuleiro(8, 8);
        Turno = 1;
        CorJogadorDaVez = Cor.BRANCA;
        ColocarPecas();
        Terminada = false;
    }

    public void ExecutarMovimento(Posicao origem, Posicao destino) {
        Peca p = Tabuleiro.RetirarPeca(origem);
        p.IncrementarQtdMovimentos();

        Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
        Tabuleiro.ColocarPeca(p, destino);
    }

    private void ColocarPecas() {
        Tabuleiro.ColocarPeca(new Torre(Cor.BRANCA, Tabuleiro), new PosicaoXadrez('c', 2).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.BRANCA, Tabuleiro), new PosicaoXadrez('d', 2).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.BRANCA, Tabuleiro), new PosicaoXadrez('e', 2).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.BRANCA, Tabuleiro), new PosicaoXadrez('e', 1).ToPosicao());
        Tabuleiro.ColocarPeca(new Rei(Cor.BRANCA, Tabuleiro), new PosicaoXadrez('d', 1).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.BRANCA, Tabuleiro), new PosicaoXadrez('c', 1).ToPosicao());

        Tabuleiro.ColocarPeca(new Torre(Cor.PRETA, Tabuleiro), new PosicaoXadrez('c', 8).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.PRETA, Tabuleiro), new PosicaoXadrez('c', 7).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.PRETA, Tabuleiro), new PosicaoXadrez('d', 7).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.PRETA, Tabuleiro), new PosicaoXadrez('g', 8).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.PRETA, Tabuleiro), new PosicaoXadrez('e', 8).ToPosicao());
        Tabuleiro.ColocarPeca(new Torre(Cor.PRETA, Tabuleiro), new PosicaoXadrez('e', 7).ToPosicao());
        Tabuleiro.ColocarPeca(new Rei(Cor.PRETA, Tabuleiro), new PosicaoXadrez('d', 8).ToPosicao());
    }
}

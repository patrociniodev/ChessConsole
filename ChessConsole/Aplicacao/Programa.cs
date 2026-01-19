using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;
using Xadrez;

namespace Aplicacao {
    public class Programa {
        static void Main(string[] args) {

            try {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada) {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.Tabuleiro);

                    Console.WriteLine();
                    Console.WriteLine();

                    Console.Write("Posição de origem: ");
                    Posicao posicaoOrigem = Tela.LerPosicaoXadrez().ToPosicao();

                    Console.Write("Posição de destino: ");
                    Posicao posicaoDestino = Tela.LerPosicaoXadrez().ToPosicao();

                    partida.ExecutarMovimento(posicaoOrigem, posicaoDestino);
                }
            }
            catch (TabuleiroException e) {
                Console.WriteLine($"Ocorreu um erro: {e.Message}");
            }
        }
    }
}

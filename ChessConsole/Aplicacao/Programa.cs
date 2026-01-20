using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;
using Xadrez;

namespace Aplicacao
{
    public class Programa
    {
        static void Main(string[] args)
        {

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao posicaoOrigem = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoOrigem(posicaoOrigem);

                        bool[,] posicoesPossiveisOrigem = partida.Tabuleiro.ObterPecaNaPosicao(posicaoOrigem).MovimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.Tabuleiro, posicoesPossiveisOrigem);

                        Console.WriteLine();
                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao posicaoDestino = Tela.LerPosicaoXadrez().ToPosicao();
                        partida.ValidarPosicaoDestino(posicaoOrigem, posicaoDestino);

                        partida.RealizarJogada(posicaoOrigem, posicaoDestino);
                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine($"Ocorreu um erro: {e.Message}\n\nPressione ENTER para voltar para a partida.");
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine($"Ocorreu um erro: {e.Message}");
            }
        }
    }
}

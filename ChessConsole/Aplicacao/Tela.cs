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
    public class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro.Tabuleiro tabuleiro)
        {
            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                //8,7,6,5,4,3,2,1
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    ImprimirPeca(tabuleiro.ObterPecaNaPosicao(i, j));
                }
                Console.WriteLine();

            }
            //a,b,c,d,e,f,g,h
            Console.Write(" " + " " + "a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro.Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {
            ConsoleColor corDeFundoOriginal = Console.BackgroundColor;
            ConsoleColor novaCorDeFundo = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.Linhas; i++)
            {
                //8,7,6,5,4,3,2,1 - linhas
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = novaCorDeFundo;
                    }
                    else
                    {
                        Console.BackgroundColor = corDeFundoOriginal;
                    }

                    ImprimirPeca(tabuleiro.ObterPecaNaPosicao(i, j));
                    Console.BackgroundColor = corDeFundoOriginal;
                }
                Console.WriteLine();

            }
            //a,b,c,d,e,f,g,h - colunas
            Console.Write(" " + " " + "a b c d e f g h");

            Console.BackgroundColor = corDeFundoOriginal;
        }

        public static void ImprimirPeca(Peca p)
        {

            if (p == null)
            {
                Console.Write("-" + " ");
            }
            else
            {
                if (p.Cor == Cor.Branca)
                {
                    Console.Write(p);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(p);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string inputString = Console.ReadLine().ToLower();
            char caracterePos = inputString.First();
            int numeroPos = int.Parse(inputString.Substring(1, 1));

            return new PosicaoXadrez(caracterePos, numeroPos);
        }

        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            Tela.ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            Console.WriteLine();

            ImprimirCapturadas(partida);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"Turno: {partida.Turno}");
            Console.WriteLine($"Aguardando jogada: {partida.JogadorDaVez.ToString()}");
        }



        public static void ImprimirCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadasFiltradasPorCor(Cor.Branca));


            Console.WriteLine(" ");
            Console.Write("Pretas: ");

            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.PecasCapturadasFiltradasPorCor(Cor.Preta));

            Console.ForegroundColor = aux;
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach(Peca p in conjunto)
            {
                Console.Write(p + " ");
            }
            Console.Write("]");
        }
    }
}

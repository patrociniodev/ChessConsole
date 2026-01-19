using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace Aplicacao {
    public class Tela {
        public static void ImprimirTabuleiro(Tabuleiro.Tabuleiro tabuleiro) {
            for (int i = 0; i < tabuleiro.Linhas; i++) {
                //8,7,6,5,4,3,2,1
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Colunas; j++) {
                    if (tabuleiro.ObterPecaPorPosicao(i, j) == null) {
                        Console.Write("-" + " ");
                    }
                    else {
                        ImprimirPeca(tabuleiro.ObterPecaPorPosicao(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();

            }
            //a,b,c,d,e,f,g,h
            Console.Write(" " + " " + "a b c d e f g h");
        }

        public static void ImprimirPeca(Peca p) {
            if (p.Cor == Cor.BRANCA) {
                Console.Write(p);
            }
            else {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(p);
                Console.ForegroundColor = aux;
            }

        }
    }
}

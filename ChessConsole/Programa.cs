using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace ChessConsole
{
    public class Programa
    {
        static void Main(string[] args)
        {
            Posicao posicao = new(2,6);

            Tabuleiro.Tabuleiro tabuleiro = new(8,8);
            Tela.ImprimirTabuleiro(tabuleiro);
        }
    }
}

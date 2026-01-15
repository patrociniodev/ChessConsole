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

                Posicao posicao = new(2,6);

                Tabuleiro.Tabuleiro tab = new(8,8);

                tab.ColocarPeca(new Torre(Cor.PRETA,tab),new Posicao(0,0));
                tab.ColocarPeca(new Cavalo(Cor.PRETA,tab),new Posicao(0,0));
                tab.ColocarPeca(new Torre(Cor.PRETA,tab),new Posicao(1,3));
                tab.ColocarPeca(new Rei(Cor.PRETA,tab),new Posicao(2,4));

                Tela.ImprimirTabuleiro(tab);
            } catch(TabuleiroException e)
            {
                Console.WriteLine($"Ocorreu um erro: {e.Message}");
            }
        }
    }
}

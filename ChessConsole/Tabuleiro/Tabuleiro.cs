using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    public class Tabuleiro
    {

        public int Linhas { get; set; }
        public int Colunas { get; set; }
        public Peca[,] Pecas {get; private set;}

        public Tabuleiro(int linhas,int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[linhas,colunas];
        }
    }
}

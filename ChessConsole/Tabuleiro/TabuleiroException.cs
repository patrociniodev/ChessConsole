using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tabuleiro
{
    public class TabuleiroException : Exception
    {

        public TabuleiroException(string message) : base(message)
        {

        }
    }
}

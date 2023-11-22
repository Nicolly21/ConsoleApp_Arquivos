using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uteis
{
    class Program
    {
        static void Main(string[] args)
        {
            string texto = "Texto com acentuação e caracteres especiais: áéíóúãõºª";
            Console.WriteLine(Util.RemoverAcentos(texto));
        }
    }
}

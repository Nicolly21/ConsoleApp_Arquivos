using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uteis
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string texto = "João Pestana";
                string nomeArquivo = "014_cadastrodependentes_202312.txt";

                var nomeArquivoOriginal = nomeArquivo.Split('.')[0];
                var extensao = Path.GetExtension(nomeArquivo);
                string[] partesNomeArquivo = nomeArquivoOriginal.Split('_');
                var codEmpresa = partesNomeArquivo[0];
                var identificador = DateTime.Now.ToString("yyyyMMddHHmmss");
                var subCategoria = partesNomeArquivo.Count() == 4 ? String.Format("{0}_{1}", partesNomeArquivo[1], partesNomeArquivo[2]) : partesNomeArquivo[1];
                string nomeArquivoDif = string.Format($"{partesNomeArquivo[1]}Dif");
                string result = nomeArquivo.Replace(partesNomeArquivo[1], nomeArquivoDif);

                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }
    }
}

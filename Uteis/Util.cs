using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uteis
{
    public class Util
    {
        public static void ValidarData()
        {
            string dataString = "25/05/1990";

            try
            {
                DateTime data = DateTime.ParseExact(dataString, "dd/MM/yyyy", null);
                DateTime dataFormatada = new DateTime(1900, 1, 1);

                if (data != DateTime.MinValue && data != new DateTime(1900, 1, 1))
                {
                    // Verificar se a data é menor que a data atual
                    DateTime dataAtual = DateTime.Now;
                    if (data < dataAtual)
                    {
                        Console.WriteLine(data);
                    }
                }

            }
            catch (FormatException)
            {
                Console.WriteLine("A string não está no formato correto (DD/MM/AAAA).");
            }
        }
        public static string RemoverAcentos(string texto)
        {
            if (!string.IsNullOrEmpty(texto))
            {

                Dictionary<char, char> substituicoes = new Dictionary<char, char>
                    {
                        { 'ç', 'c' }, { 'Ç', 'C' }, { 'á', 'a' }, { 'é', 'e' }, { 'í', 'i' }, { 'ó', 'o' }, { 'ú', 'u' }, { 'ý', 'y' },
                        { 'Á', 'A' }, { 'É', 'E' }, { 'Í', 'I' }, { 'Ó', 'O' }, { 'Ú', 'U' }, { 'Ý', 'Y' }, { 'à', 'a' }, { 'è', 'e' },
                        { 'ì', 'i' }, { 'ò', 'o' }, { 'ù', 'u' }, { 'À', 'A' }, { 'È', 'E' }, { 'Ì', 'I' }, { 'Ò', 'O' }, { 'Ù', 'U' },
                        { 'ã', 'a' }, { 'õ', 'o' }, { 'ñ', 'n' }, { 'ä', 'a' }, { 'ë', 'e' }, { 'ï', 'i' }, { 'ö', 'o' }, { 'ü', 'u' },
                        { 'ÿ', 'y' }, { 'Ä', 'A' }, { 'Ë', 'E' }, { 'Ï', 'I' }, { 'Ö', 'O' }, { 'Ü', 'U' }, { 'Ã', 'A' }, { 'Õ', 'O' },
                        { 'Ñ', 'N' }, { 'â', 'a' }, { 'ê', 'e' }, { 'î', 'i' }, { 'ô', 'o' }, { 'û', 'u' }, { 'Â', 'A' }, { 'Ê', 'E' },
                        { 'Î', 'I' }, { 'Ô', 'O' }, { 'Û', 'U' }
                    };

                StringBuilder sb = new StringBuilder();

                foreach (char c in texto)
                {
                    if (substituicoes.ContainsKey(c))
                    {
                        sb.Append(substituicoes[c]);
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }

                return sb.ToString();
            }

            return texto;
        }

    }

}

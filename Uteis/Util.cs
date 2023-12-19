using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uteis
{
    public class Util
    {
        // Este método é responsável por enviar mensagem para o serviço de mensageria
        //public async Task SendMessagesAsync(string archiveJson, string queueName)
        //{
        //    try
        //    {
        //        queueClient = new QueueClient(ServiceBusConnectionString, queueName);

        //        await Task.Run(() =>
        //        {
        //            int countRetry = 0;

        //            if (string.IsNullOrEmpty(archiveJson))
        //            {
        //                throw new ArgumentNullException("A string da mensagem a ser enviada para a fila no Service Bus não pode ser null ou vazia.");
        //            }
        //            var message = new Message(Encoding.UTF8.GetBytes(archiveJson))
        //            {
        //                MessageId = DateTime.Now.Ticks.ToString() + Guid.NewGuid().ToString()
        //            };

        //            Logger.Log($"Enviando mensagem para Service Bus");

        //            Task taskEnvioMensagem = Task.Run(() => queueClient.SendAsync(message));
        //            taskEnvioMensagem.Wait();

        //            do
        //            {
        //                if (!taskEnvioMensagem.IsCompleted)
        //                {
        //                    taskEnvioMensagem = Task.Run(() => queueClient.SendAsync(message));
        //                    taskEnvioMensagem.Wait();
        //                    countRetry++;
        //                }
        //            }
        //            while (!taskEnvioMensagem.IsCompleted && countRetry <= 2); //Tenta enviar a mensagem para a fila 3x

        //            if (taskEnvioMensagem.IsFaulted || taskEnvioMensagem.IsCanceled || !taskEnvioMensagem.IsCompleted)
        //            {
        //                Logger.Log("Todas as tentativas de enviar a mensagem para a fila falhou.");
        //            }

        //            Logger.Log("Mensagem enviada com sucesso!");
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        var mensagem = ex.ToMensagems();
        //        Logger.LogDetalhes("[ServiceBus.SendMessagesAsync] - Exception", mensagem);

        //    }
        //}

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
                        { 'Î', 'I' }, { 'Ô', 'O' }, { 'Û', 'U' },
                        //Caracteres especiais são substituidos por espaço em branco
                        { 'ª', ' ' }, { '°', ' ' }, { '¹', ' ' }, { '²', ' ' }, { '³', ' ' },
                        { '£', ' ' }, { '¢', ' ' }, { '¬', ' ' }, { 'º', ' ' }, { '¨', ' ' },
                        { '\'', ' ' }, { '#', ' ' }, { '!', ' ' }, { '$', ' ' }, { '%', ' ' },
                        { '*', ' ' }, { '<', ' ' }, { '>', ' ' }, { '?', ' ' }, { '[', ' ' },
                        { ']', ' ' }, { '{', ' ' }, { '}', ' ' }, { '=', ' ' }, { '+', ' ' },
                        { '§', ' ' }, { '´', ' ' }, { '`', ' ' }, { '^', ' ' }, { '~', ' ' },
                        { '«', ' ' }, { '‡', ' ' }, { '"', ' ' }
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

        public static string CompareFilesNovo(string filePath1, string filePath2)
        {
            try
            {
                string[] file1Lines = File.ReadAllLines(filePath1);
                string[] file2Lines = File.ReadAllLines(filePath2);

                var differences = file1Lines.Except(file2Lines, StringComparer.OrdinalIgnoreCase);

                int qtdLinesDifference = differences.Count();

                string linesChanged = string.Join("\r\n", differences);

                return linesChanged;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

    }

}

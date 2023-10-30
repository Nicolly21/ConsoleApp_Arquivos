using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TratamentoExcecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (response.Content != null && response.IsSuccessStatusCode)
            {
                Console.WriteLine("TESTE");
            }
            var resp = ExcecaoComFor();

        }

        static int ExcecaoComFor()
        {
            int maxTentativas = 3;

            for (int tentativa = 1; tentativa <= maxTentativas; tentativa++)
            {
                try
                {
                    // Realize a chamada ao serviço aqui
                    // Se ocorrer uma exceção, ela será capturada pelo catch
                    // Caso contrário, a execução continuará normalmente
                    // Exemplo de chamada fictícia:
                    // int resultado = Servico.FazerChamada();

                    // Se a chamada ao serviço for bem-sucedida, saia do loop
                    // Caso contrário, simule uma exceção (substitua por sua lógica real)
                    if (tentativa < maxTentativas)
                    {
                        throw new Exception("Simulação de erro na chamada ao serviço");
                    }

                    Console.WriteLine("Chamada ao serviço bem-sucedida!");
                    break; // Saia do loop em caso de sucesso
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Tentativa {tentativa} falhou. Exceção: {ex.Message}");

                    if (tentativa == maxTentativas)
                    {
                        // Se todas as tentativas falharem, registre a exceção no console
                        Console.WriteLine("Todas as tentativas falharam. Registrando exceção no console.");
                        Console.WriteLine($"Detalhes da exceção: {ex.ToString()}");
                    }
                    else
                    {
                        Console.WriteLine("Tentando novamente...");
                    }
                }
            }
            return maxTentativas;
            // Outras instruções após o loop (se necessário)
        }

        static void ExcecaoComWhile()
        {
            
            int contador = 0;

            while (contador < 5)
            {
                try
                {
                    Console.WriteLine("Este é um loop while. Contador: " + contador);
                    throw new Exception("Simulação de erro na chamada ao serviço");
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"EXCEPTION: {ex.Message}");
                    continue;
                }
                finally
                {
                    contador++;
                }
            }

            Console.WriteLine("Loop while concluído!");
           
        }

        static int DivisaoPorZero()
        {
            try
            {
                var teste = 0;
                var resultado = 10 / teste;
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

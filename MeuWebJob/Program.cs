using CsvHelper;
using CsvHelper.Configuration;
using MeuWebJob.Classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;

namespace MeuWebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            var alunos = new List<Aluno>
            {
                new Aluno
                {
                    Nome = "João",
                    Idade = "25",
                    Escolaridade = "Graduação"
                },
                new Aluno
                {
                    Nome = "Maria",
                    Idade = "22",
                    Escolaridade = "Ensino Médio"
                }
            };
            //Testar usando csv
            #region Arquivo CSV
            AdicionarAlunoAoCSV(ConfigurationManager.AppSettings["AlunosCSV"], alunos);

            // Ler o arquivo CSV e obter os objetos Aluno
            List<Aluno> alunosResp = LerAlunosDoCSV(ConfigurationManager.AppSettings["AlunosCSV"]);
            #endregion

            #region Arquivo TXT
            //EscreverAlunosNoArquivo(ConfigurationManager.AppSettings["AlunosSalvos"], alunos);
            #endregion

            #region Arquivo JSON
            //string json = JsonConvert.SerializeObject(alunos, Formatting.Indented);
            //EscreverJSONEmAlunoTxT(json, ConfigurationManager.AppSettings["AlunosSalvos"]);
            //string resp = LerArquivoTexto(ConfigurationManager.AppSettings["AlunosSalvos"]);

            //if (!string.IsNullOrEmpty(resp))
            //{
            //    Desserializar o JSON em objetos Aluno
            //    List<Aluno> alunosResp = JsonConvert.DeserializeObject<List<Aluno>>(resp);

            //    Exibir os objetos Aluno
            //    foreach (var aluno in alunosResp)
            //    {
            //        Console.WriteLine($"Nome: {aluno.Nome}");
            //        Console.WriteLine($"Idade: {aluno.Idade}");
            //        Console.WriteLine($"Escolaridade: {aluno.Escolaridade}");
            //        Console.WriteLine(); Adicionar uma linha em branco para separar os registros
            //    }
            //}
            #endregion
        }

        static void EscreverJSONEmAlunoTxT(string json, string caminho)
        {
            try
            {
                File.AppendAllText(caminho, json);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao escrever no arquivo: {ex.Message}");
            }
        }

        static void EscreverAlunosNoArquivo(string caminhoArquivo, List<Aluno> alunos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(caminhoArquivo))
                {
                    foreach (var aluno in alunos)
                    {
                        sw.WriteLine($"Nome: {aluno.Nome}");
                        sw.WriteLine($"Idade: {aluno.Idade}");
                        sw.WriteLine($"Escolaridade: {aluno.Escolaridade}");
                        sw.WriteLine(); // Adicionar uma linha em branco para separar os registros
                    }
                }

                Console.WriteLine("Alunos foram escritos no arquivo com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao escrever no arquivo: {ex.Message}");
            }
        }

        static string LerArquivoTexto(string caminhoArquivo)
        {
            try
            {
                return System.IO.File.ReadAllText(caminhoArquivo);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao ler o arquivo: {ex.Message}");
                return null;
            }
        }
        static void AdicionarAlunoAoCSV(string caminhoArquivo, List<Aluno> alunos)
        {
            bool arquivoVazio = !ArquivoCSVContemRegistros(caminhoArquivo);

            if (arquivoVazio)
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = true // Desabilita a gravação dos cabeçalhos
                };

                using (var streamWriter = new StreamWriter(caminhoArquivo, true)) // O segundo parâmetro "true" permite a adição de novas linhas ao arquivo
                using (var csvWriter = new CsvWriter(streamWriter, config))
                {
                    csvWriter.WriteRecords(alunos);
                }
            }
            else
            {
                var config = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    HasHeaderRecord = false // Desabilita a gravação dos cabeçalhos
                };
                using (var streamWriter = new StreamWriter(caminhoArquivo, true)) // O segundo parâmetro "true" permite a adição de novas linhas ao arquivo
                using (var csvWriter = new CsvWriter(streamWriter, config))
                {
                    csvWriter.WriteRecords(alunos);
                }
            }
        }

        static bool ArquivoCSVContemRegistros(string caminhoArquivo)
        {
            try
            {
                using (var reader = new StreamReader(caminhoArquivo))
                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    return csv.GetRecords<object>().Any();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao verificar o arquivo CSV: {ex.Message}");
                return false; // Em caso de erro, assumimos que o arquivo não contém registros
            }
        }

        static List<Aluno> LerAlunosDoCSV(string caminhoArquivo)
        {
            using (var reader = new StreamReader(caminhoArquivo))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                return csv.GetRecords<Aluno>().ToList();
            }
        }
    }
}

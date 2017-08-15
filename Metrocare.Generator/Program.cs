using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Metrocare.Generator.Connections;
using Metrocare.Generator.Infrastructure;
using Metrocare.Generator.Models;

namespace Metrocare.Generator
{
    public class Program
    {
        private const int MILLISECONDS = 500;
        
        public static void Main(string[] args) 
        {
            WriteHeader();

            TimeSleep(MILLISECONDS);

            StartProcess();

            TimeSleep(MILLISECONDS);

            WriteToConsole("fim do processamento...");
        }

        private static void StartProcess()
        {
            var buildCommonDto = new BuilderCommonDto();
            var buildController = new BuilderController();
            WriteToConsole(buildCommonDto.BuildBaseDto());
            TimeSleep(MILLISECONDS);

            // classes dto's
            var objDictionary = new TableToClass().GetTableMapper();
            foreach (KeyValuePair<String, ModelConfig> itemDictionary in objDictionary)
            {
               var TableName = itemDictionary.Key;
               var TableModelConfig = itemDictionary.Value;
               
               WriteToConsole(buildCommonDto.BuildClassDto(TableName, TableModelConfig));
               TimeSleep(MILLISECONDS);

               if (TableModelConfig.CreateController) { WriteToConsole(buildController.BuildController(TableModelConfig)); }
                
               TimeSleep(MILLISECONDS);
            }

            WriteToConsole("Geração finalizada...");
            ReadFromConsole();
        }

        #region "Métodos de Prompt"

        /// <summary>
        /// Escreve cabecalho no prompt.
        /// </summary>
        private static void WriteHeader()
        {
            Console.Title = typeof(Program).Name;
            Console.ForegroundColor = ConsoleColor.Yellow;

            var ConsoleCopyRight = new StringBuilder();

            Console.WriteLine("#***********************************************************");
            Console.WriteLine("# Console: Gerador de DTO's para aplicações. ");
            Console.WriteLine("#***********************************************************");

            WriteToConsole(ConsoleCopyRight.ToString());
        }

        /// <summary>
        /// Tempo de espera em milesegundos.
        /// </summary>
        /// <param name="Milliseconds"></param>
        private static void TimeSleep(int Milliseconds)
        {
            var StopWatch = Stopwatch.StartNew();
            Thread.Sleep(Milliseconds);
            StopWatch.Stop();
        }

        /// <summary>
        /// Escreve texto no prompt.
        /// </summary>
        /// <param name="message"></param>
        private static void WriteToConsole(string message)
        {
            if (message.Length > 0) { Console.WriteLine("prompt: " + message); }
        }

        /// <summary>
        /// Quebra linha no prompt.
        /// </summary>
        private static void WriteEnterLine()
        {
            Console.WriteLine(String.Empty);
            Console.ReadLine();
        }

        /// <summary>
        /// Le dados do console.
        /// </summary>
        private static string ReadFromConsole()
        {
            return (Console.ReadLine());
        }

        #endregion 

    }
}

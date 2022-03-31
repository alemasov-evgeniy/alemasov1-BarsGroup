using System;
using System.Collections.Generic;
using System.IO;

namespace Обобщение
{
    interface ILogger
    {
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message, Exception ex);
    }
    internal class LocalFileLogger<T> : ILogger
    {
        private readonly string pFile;
        private string GenericTypeName => typeof(T).Name;

        public LocalFileLogger(string pFile)
        {
            this.pFile = pFile;
        }
        public void LogError(string message, Exception ex)
        {
            Print($"[Error] : [{GenericTypeName}] : {message}. {ex.Message}");
        }
        public void LogInfo(string message)
        {
            Print($"[Info]: [{GenericTypeName}] : {message}");
        }
        public void LogWarning(string message)
        {
            Print($"[Warning] : [{GenericTypeName}] : {message}");
        }

        private void Print(string message)
        {
            using (StreamWriter w = new StreamWriter(pFile, true))
            {
                w.WriteLine(message);
            }
        }
                
    }
    class Program
    {
        static void Main(string[] args)
        {
            Exception ex = new Exception();
            LocalFileLogger<string> localFileString = new LocalFileLogger<string>("text.txt");
            LocalFileLogger<int> localFileInt = new LocalFileLogger<int>("text.txt");
            localFileString.LogError("Вызван метод LogError", ex);
            localFileString.LogInfo("Вызван метод LogInfo");
            localFileString.LogWarning("Вызван метод LogWarning");
            localFileInt.LogError("Вызван метод LogError", ex);
            localFileInt.LogInfo("Вызван метод LogInfo");
            localFileInt.LogWarning("Вызван метод LogWarning");
            Console.WriteLine("Информация успешно записана в файл text.txt");
            Console.ReadKey();
        }
    }
}

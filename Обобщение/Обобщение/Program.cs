using System;
using System.Collections.Generic;
using System.IO;
using NLog;

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
            LocalFileLogger<string> localFile = new LocalFileLogger<string>("text.txt");
            localFile.LogError("Вызван метод LogError", ex);
            localFile.LogInfo("Вызван метод LogInfo");
            localFile.LogWarning("Вызван метод LogWarning");
            //Console.ReadKey();
        }
    }
}

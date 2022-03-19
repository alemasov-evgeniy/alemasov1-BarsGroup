using System;

namespace События
{
    class Program
    {
        static void Main(string[] args)
        {
            Symbol symbol = new Symbol();
            symbol.OnKeyPressed += PrintSymbol;
            symbol.Run();
            Console.ReadKey();
        }

        private static void PrintSymbol(object sender, char e)
        {
            Console.WriteLine($"\nВведен символ {e}");
        }
    }

    public class Symbol
    {
        public event EventHandler<char> OnKeyPressed;
        public void Run()
        {
            Console.Write("Введите символ: ");
            char s = Console.ReadKey().KeyChar;
            while (s != 'c' & s != 'C')
            {
                OnKeyPressed?.Invoke(this, s);
                Console.Write("\nВведите символ: ");
                s = Console.ReadKey().KeyChar;
            }
            Console.WriteLine("\nЗавершение работы программы.");
        }
         
    }
}

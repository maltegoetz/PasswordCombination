using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCombination
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welchem Schema soll das Passwort entsprechen?");
            Console.WriteLine("a) 3-stellig, 2 Groß- und/oder Kleinbuchstaben (je 1x), 1 Sonderzeichen");
            Console.WriteLine("b) 5-stellig, 4 Groß- und/oder Kleinbuchstaben, 1 Sonderzeichen");
            Console.WriteLine("c) 5-stellig, 3 Groß- und/oder Kleinbuchstaben, 2 Sonderzeichen (je 1x)");
            Console.Write("Schema: ");
            var input = Console.ReadLine();
            switch (input.First())
            {
                case 'a':
                    PrintResult(new Chars3x());
                    break;
                case 'b':
                    PrintResult(new Chars5x());
                    break;
                case 'c':
                    PrintResult(new Chars5x2());
                    break;
                case 'x':
                    Environment.Exit(0);
                    break;

            }
            Main(null);
        }
        static void PrintResult(PasswordCalculatorBase calculator)
        {
            var count = calculator.Calculate();
            Console.WriteLine($"Gesamtzahl Passwörter: {count}");
            Console.WriteLine("Passwörter werden in Textdatei geschrieben...");
            
            Console.WriteLine("Abgeschlossen");
        }
    }
}

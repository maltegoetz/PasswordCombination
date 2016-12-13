using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCombination
{
    
    abstract class PasswordCalculatorBase
    {
        protected abstract int Length
        {
            get;
        }
        protected abstract List<char> SpecialChars
        {
            get;
        }
        
        private readonly List<char> _capsChars = new List<char>() { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly List<char> _lowerChars = new List<char>() { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };

        private int _count = 0;
        public int Calculate()
        {
            var psswds = new List<string>[Length];
            _count = 0;

            for (int i = 0; i < Length; i++)
            {
                psswds[i] = new List<string>();
            }

            WriteToFile(psswds[0], false);

            foreach (char c in SpecialChars)
            {
                psswds[0].Add(c.ToString());
            }
            foreach (char c in _capsChars)
            {
                psswds[0].Add(c.ToString());
            }
            foreach (char c in _lowerChars)
            {
                psswds[0].Add(c.ToString());
            }
            Console.WriteLine("1. Stelle berechnet.");
            
            for (int i = 0; i < Length - 1; i++)
            {
                foreach (string s in psswds[i])
                {
                    foreach (char c in SpecialChars)
                    {
                        if (IsSpecialAllowed(s, c))
                            psswds[i + 1].Add(s + c.ToString());
                    }
                    foreach (char c in _capsChars)
                    {
                        if (IsRegularAllowed(s, c))
                            psswds[i + 1].Add(s + c.ToString());
                    }
                    foreach (char c in _lowerChars)
                    {
                        if (IsRegularAllowed(s, c))
                            psswds[i + 1].Add(s + c.ToString());
                    }
                    CheckForWrite(i, psswds, true);
                }
                CheckForWrite(i, psswds, true, true);
                Console.WriteLine($"{i+2}. Stelle berechnet.");
            }

            return _count;
        }
        private void CheckForWrite(int i, List<string>[] psswds, bool append, bool isFinal = false)
        {
            if (i >= Length - 2 && (psswds[i+1].Count > 1000000 || isFinal) )
            {
                WriteToFile(psswds[i + 1], append);
                _count += psswds[i + 1].Count;
                psswds[i + 1].Clear();
            }
        }
        private void WriteToFile(List<string> psswds, bool append)
        {
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"C:\Users\malte\psswds.txt", append))
            //{
            //    foreach (string psswd in psswds)
            //    {
            //        file.WriteLine(psswd);
            //    }
            //}
        }
        protected abstract bool IsSpecialAllowed(string s, char c);
        protected abstract bool IsRegularAllowed(string s, char c);
    }
}

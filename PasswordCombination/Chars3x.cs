using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCombination
{
    /// <summary>
    /// 3-stelliges Passwort
    /// 2 Groß- und/oder Kleinbuchstaben (je nur einmal)
    /// 1 Sonderzeichen (§,$,%,&,?,+,#,!)
    /// </summary>
    class Chars3x : PasswordCalculatorBase
    {
        protected override int Length
        {
            get
            {
                return 3;
            }
        }

        protected override List<char> SpecialChars
        {
            get
            {
                return new List<char>() { '§', '$', '%', '&', '?', '+', '#', '!' };
            }
        }
        protected override bool IsSpecialAllowed(string s, char c)
        {
            return s.IndexOfAny(SpecialChars.ToArray()) == -1;
        }

        protected override bool IsRegularAllowed(string s, char c)
        {
            return !(s.Contains(c)) && !((s.Length >= Length-1) && (s.IndexOfAny(SpecialChars.ToArray()) == -1));
        }
    }
}

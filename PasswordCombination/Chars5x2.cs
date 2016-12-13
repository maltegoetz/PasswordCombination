using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCombination
{
    class Chars5x2 : PasswordCalculatorBase
    {

        protected override int Length
        {
            get
            {
                return 5;
            }
        }

        protected override List<char> SpecialChars
        {
            get
            {
                return new List<char>() { '§', '$', '%', '&', '?', '+', '#', '!', '-', ';', ':' };
            }
        }
        
        protected override bool IsSpecialAllowed(string s, char c)
        {
            if (s.Contains(c))
                return false;
            var pos = s.IndexOfAny(SpecialChars.ToArray());
            if(pos != -1)
            {
                var pos2 = s.LastIndexOfAny(SpecialChars.ToArray());
                if(pos != pos2)
                {
                    return false;
                }
            }
            return true;
        }

        protected override bool IsRegularAllowed(string s, char c)
        {
            var charsremaining = Length - s.Length;
            if (charsremaining > 2) return true;

            var pos1 = s.IndexOfAny(SpecialChars.ToArray());
            if (charsremaining == 2)
            {
                if(pos1 == -1)
                {
                    return false;
                }
                return true;
            }

            var pos2 = s.LastIndexOfAny(SpecialChars.ToArray());
            if(pos1 != pos2)
            {
                return true;
            }
            
            return false;
        }
    }
}

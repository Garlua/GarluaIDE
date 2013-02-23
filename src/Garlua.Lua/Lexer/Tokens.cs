using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garlua.Lua.Lexer
{
    public class TokenDefinition
    {
        public Regex Regex;
        public String Type;

        public TokenDefinition(String type, Regex regex)
        {
            this.Type = type;
            this.Regex = regex;
        }
    }

    class StringTokenDefinition
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlua.Lua.Lexer
{
    public class Token : IToken
    {
        public String Content { get; set; }
        public String Type { get; set; }

        public Token(String Type, String Content)
        {
            this.Content = Content;
            this.Type = Type;
        }
    }
}

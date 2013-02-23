using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garlua.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Lua.Lexer.Lexer Lexer = new Lua.Lexer.Lexer();
            Lexer.AddTokenDefinition(new Lua.Lexer.TokenDefinition("Dot", new Regex(@"(^[\.])")));
            Lexer.AddTokenDefinition(new Lua.Lexer.TokenDefinition("String", new Regex("(^[a-zA-Z0-9]+)")));
            Lexer.AddTokenDefinition(new Lua.Lexer.TokenDefinition("Word", new Regex(@"(^\w+)")));
            Lexer.AddTokenDefinition(new Lua.Lexer.TokenDefinition("Whitespace", new Regex(@"(^[\s]+)")));

            String Content = System.IO.File.ReadAllText(@"F:\Programming\CSharp\GarrysModEditor\resources\test.lua");

            List<Lua.Lexer.IToken> Tokens = Lexer.Tokenize(Content);

            foreach (Lua.Lexer.Token Token in Tokens)
            {
                Console.WriteLine(Token.Type + " => " + Token.Content);
            }
        }
    }
}

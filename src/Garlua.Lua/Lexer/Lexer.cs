using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Garlua.Lua.Lexer
{
    public class Lexer
    {
        /// <summary>
        /// Available tokens
        /// </summary>
        List<TokenDefinition> TokenDefinitions = new List<TokenDefinition>();

        /// <summary>
        /// Add a new definition
        /// </summary>
        /// <param name="Token"></param>
        public void AddTokenDefinition(TokenDefinition Token)
        {
            this.TokenDefinitions.Add(Token);
        }

        /// <summary>
        /// Convert a string to tokens
        /// </summary>
        /// <param name="Content"></param>
        /// <returns></returns>
        public List<IToken> Tokenize(String Content)
        {
            List<IToken> Tokens = new List<IToken>();

            Content = Content
                .Replace("\n", " ")
                .Replace("\r", "")
                .Replace("\t", "");

            int Offset = 0;

            while (Offset <= Content.Length)
            {
                String Remaining = Content.Substring(Offset);

                Boolean Matched = false;

                foreach (TokenDefinition tokenDefinition in TokenDefinitions)
                {
                    Match Match = tokenDefinition.Regex.Match(Remaining);

                    if (Match.Success)
                    {
                        Tokens.Add(new Token(tokenDefinition.Type, Match.Value));
                        Offset += Match.Length;
                        Matched = true;
                        break;
                    }
                }

                if (!Matched)
                {
                    Offset++;
                }
            }

            return Tokens;
        }
    }
}

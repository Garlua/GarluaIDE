using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garlua.Lua.Lexer
{
    public interface IToken
    {
         String Content { get; }
    }
}

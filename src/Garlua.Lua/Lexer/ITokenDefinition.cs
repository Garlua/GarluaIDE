using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Garlua.Lua.Lexer
{
    interface ITokenDefinition
    {
        Regex Regex { get; }
        String Type { get; }
    }
}

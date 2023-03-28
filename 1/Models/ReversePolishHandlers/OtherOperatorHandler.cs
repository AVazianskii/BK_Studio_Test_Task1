using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class OtherOperatorHandler : BaseHandler
    {
        public override object Handle(string symbol, Stack<string> Operations, List<string> CharList)
        {
            // Pапоминаем любые другие операнды в стеке операций и выходим из цепочки обработки
            Operations.Push(symbol);
            return null;
        }
    }
}

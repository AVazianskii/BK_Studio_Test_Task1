using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class OperandHandler : BaseHandler
    {
        public override object Handle(string symbol, Stack<string> Operations, List<string> CharList)
        {
            // Проверяем, является ли прочитанный символ числом
            // Если является, то запоминаем его в коллеккции и выходим из цепочки обработки
            if (Double.TryParse(symbol, out double result))
            {
                CharList.Add(symbol);

                return null;
            }
            else
            {
                return base.Handle(symbol, Operations, CharList);
            }        
        }
    }
}

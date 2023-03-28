using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{ 
    internal class CalcOperandHandler : BaseHandler
    {
        public override object Handle(string symbol, Stack<double> PolishMathResult)
        {
            // Проверяем, является ли прочитанный символ числом
            // Если является, то запоминаем его в стеке вычислений и выходим из цепочки обработки
            if (Double.TryParse(symbol, out double result))
            {
                PolishMathResult.Push(result);
                return null;
            }
            else
            {
                return base.Handle(symbol, PolishMathResult);
            }
        }
    }
}

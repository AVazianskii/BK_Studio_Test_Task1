using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class CalcSqrHandler : BaseHandler
    {
        public override object Handle(string symbol, Stack<double> PolishMathResult)
        {
            // Проверяем, является ли прочитанный символ операция извлечения квадратного корня
            // Если является, то запоминаем его в стеке вычислений и выходим из цепочки обработки
            if (symbol == "\u221A")
            {
                double num_1 = PolishMathResult.Pop();
                PolishMathResult.Push(Math.Sqrt(num_1));

                return null;
            }
            else
            {
                return base.Handle(symbol, PolishMathResult);
            }
        }
    }
}

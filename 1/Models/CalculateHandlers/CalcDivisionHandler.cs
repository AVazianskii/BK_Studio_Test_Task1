using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class CalcDivisionHandler : BaseHandler
    {
        public override object Handle(string symbol, Stack<double> PolishMathResult)
        {
            // Проверяем, является ли прочитанный символ операцией деления
            // Если является, то запоминаем его в стеке вычислений и выходим из цепочки обработки
            if (symbol == "/")
            {
                double num_1 = PolishMathResult.Pop();
                double num_2 = PolishMathResult.Pop();
                PolishMathResult.Push(num_2 / num_1);

                return null;
            }
            else
            {
                return base.Handle(symbol, PolishMathResult);
            }
        }
    }
}

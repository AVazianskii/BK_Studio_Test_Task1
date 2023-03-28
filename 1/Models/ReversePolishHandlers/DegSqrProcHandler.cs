﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class DegSqrProcHandler : BaseHandler
    {
        public override object Handle(string symbol, Stack<string> Operations, List<string> CharList)
        {
            // Проверяем, является ли прочитанный символ операцией возведения в степень, извлечения корня или вычисление процента
            // Если является, то запоминаем его в стеке операций и выходим из цепочки обработки
            if (symbol == "^" || symbol == "\u221A" || symbol == "%")
            {
                if (Operations.Count > 0)
                {
                    if (Operations.Peek() == "^" || Operations.Peek() == "\u221A" || Operations.Peek() == "%")
                    {
                        while (Operations.Count > 0)
                        {
                            if (Operations.Peek() != "+" && Operations.Peek() != "-" && Operations.Peek() != "(")
                            {
                                CharList.Add(Operations.Pop());
                            }
                            else { break; }
                        }
                    }
                }
                Operations.Push(symbol);
                return null;
            }
            // В противном случае переходим к следующему звену цепочки
            else
            {
                return base.Handle(symbol, Operations, CharList);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class RightBracketHandler : BaseHandler
    {
        public override object Handle(string symbol, Stack<string> Operations, List<string> CharList)
        {
            // Проверяем, является ли прочитанный символ операцией возведения в степень, извлечения корня или вычисление процента
            // Если является, то запоминаем его в стеке операций и выходим из цепочки обработки
            if (symbol == ")")
            {
                if (Operations.Contains("("))
                {
                    while (Operations.Count > 0)
                    {
                        if (Operations.Peek() != "(")
                        {
                            CharList.Add(Operations.Pop());
                        }
                        else { break; }
                    }
                    if (Operations.Peek() == "(")
                    {
                        Operations.Pop();
                    }
                }
                else
                {
                    throw new Exception("Несогласованное количество скобок в выражении!");
                }
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

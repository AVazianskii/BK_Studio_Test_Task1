using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal interface IHandler
    {
        // объявляем метод для построения цепочки обработчиков
        IHandler SetNext(IHandler handler);
        // объявляем метод для обработки операции
        object Handle(string symbol, Stack<string> Operations, List<string> CharList);
        object Handle(string symbol, Stack<double> PolishMathResult);
    }
}

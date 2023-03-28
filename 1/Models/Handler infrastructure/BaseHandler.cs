using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    internal class BaseHandler : IHandler
    {
        private IHandler _nextHandler;
        public IHandler SetNext(IHandler handler)
        {
            this._nextHandler = handler;
            return handler;
        }
        public virtual object Handle(string symbol, Stack<string> Operations, List<string> CharList)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(symbol, Operations, CharList);
            }
            else
            {
                return null;
            }
        }
        public virtual object Handle(string symbol, Stack<double> PolishMathResult)
        {
            if (this._nextHandler != null)
            {
                return this._nextHandler.Handle(symbol, PolishMathResult);
            }
            else
            {
                return null;
            }
        }
    }
}

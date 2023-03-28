using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1
{
    public class PolishProcess
    {
        private Stack<string> _operations;
        private Stack<double> _polishMathResult;
        private string reversedText;
        private List<string> CharList;
        private string [] text;

        private OperandHandler operandHandler;
        private PlusMinusHandler plusMinusHandler;
        private MulDivHandler mulDivHandler;
        private DegSqrProcHandler degSqrProcHandler;
        private RightBracketHandler rightBracketHandler;
        private OtherOperatorHandler otherOperatorHandler;

        private CalcOperandHandler calcOperandHandler;
        private CalcSqrHandler calcSqrHandler;
        private CalcProcHandler calcProcHandler;
        private CalcAddHandler calcAddHandler;
        private CalcSubstractHandler calcSubstractHandler;
        private CalcMultiplyHandler calcMultiplyHandler;
        private CalcDivisionHandler calcDivisionHandler;
        private CalcDegreeHandler CalcDegreeHandler;
        


        public string TransformToPolish(ref string input_text)
        {
            reversedText = "";
            try
            {
                text = input_text.Split(' ');
                foreach (string letter in text)
                {
                    // анализируем каждый элемент изначального выражения в цепочке
                    operandHandler.Handle(letter, _operations, CharList);
                }

                // Переносим оставшиеся символы операций из стэка в коллекцию
                while (_operations.Count > 0)
                {
                    CharList.Add(_operations.Pop());
                }
                // преобразуем полученную коллекцию символов с строковую переменную для отображения            
                foreach (string element in CharList)
                {
                    reversedText = reversedText + element + " ";
                }

                _operations.Clear();
                _operations.TrimExcess();
                CharList.Clear();
                CharList.TrimExcess();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                _operations.Clear();
                _operations.TrimExcess();
                CharList.Clear();
                CharList.TrimExcess();
            }
            return reversedText;
        }
        public string CalculatePolish(ref string ReversedPolishText)
        {
            text = ReversedPolishText.Split(' ');
            foreach (string letter in text)
            {
                if (letter != "")
                {
                    calcOperandHandler.Handle(letter, _polishMathResult);
                }
            }

            string FinalValue = _polishMathResult.Pop().ToString();
            _polishMathResult.Clear();
            _polishMathResult.TrimExcess();
            return FinalValue;
        }


        public PolishProcess()
        {
            reversedText = "";
            _operations = new Stack<string>();
            _polishMathResult = new Stack<double>();
            CharList = new List<string>();


            operandHandler = new OperandHandler();
            plusMinusHandler = new PlusMinusHandler();
            mulDivHandler = new MulDivHandler();
            degSqrProcHandler = new DegSqrProcHandler();
            rightBracketHandler = new RightBracketHandler();
            otherOperatorHandler = new OtherOperatorHandler();

            // Конфигурируем цепочку обработки для формирования обратной польской записи
            operandHandler.
                SetNext(plusMinusHandler).
                SetNext(mulDivHandler).
                SetNext(degSqrProcHandler).
                SetNext(rightBracketHandler).
                SetNext(otherOperatorHandler);

            calcOperandHandler = new CalcOperandHandler();
            calcSqrHandler = new CalcSqrHandler();
            calcProcHandler = new CalcProcHandler();
            calcAddHandler = new CalcAddHandler();
            calcSubstractHandler = new CalcSubstractHandler();
            calcMultiplyHandler = new CalcMultiplyHandler();
            calcDivisionHandler = new CalcDivisionHandler();
            CalcDegreeHandler = new CalcDegreeHandler();

            // Конфигурируем цепочку обработки для вычисления по обратной польской записи
            calcOperandHandler.
                SetNext(calcSqrHandler).
                SetNext(calcProcHandler).
                SetNext(calcAddHandler).
                SetNext(calcSubstractHandler).
                SetNext(calcMultiplyHandler).
                SetNext(calcDivisionHandler).
                SetNext(CalcDegreeHandler);
        }
    }
}

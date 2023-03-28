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
        


        public string TransformToPolish(ref string input_text)
        {
            reversedText = "";
            try
            {
                text = input_text.Split(' ');
                foreach (string letter in text)
                {
                    if (Double.TryParse(letter.ToString(), out double result))
                    {
                        CharList.Add(letter);
                    }
                    else
                    {
                        if (letter == "*" || letter == "/")
                        {
                            if (_operations.Count > 0)
                            {
                                if (_operations.Peek() == "^" || _operations.Peek() == "\u221A" || _operations.Peek() == "%")
                                {
                                    while (_operations.Count > 0)
                                    {
                                        if (_operations.Peek() != "+" && _operations.Peek() != "-" && _operations.Peek() != "(")
                                        {
                                            CharList.Add(_operations.Pop());
                                        }
                                        else { break; }
                                    }
                                }
                                else if (_operations.Peek() == "*" || _operations.Peek() == "/")
                                {
                                    while (_operations.Count > 0)
                                    {
                                        if (_operations.Peek() != "+" && _operations.Peek() != "-" && _operations.Peek() != "(")
                                        {
                                            CharList.Add(_operations.Pop());
                                        }
                                        else { break; }
                                    }
                                }
                            }
                            _operations.Push(letter);
                        }
                        else if (letter == "^" || letter == "\u221A" || letter == "%")
                        {
                            if (_operations.Count > 0)
                            {
                                if (_operations.Peek() == "^" || _operations.Peek() == "\u221A" || letter == "%")
                                {
                                    while (_operations.Count > 0)
                                    {
                                        if (_operations.Peek() != "+" && _operations.Peek() != "-" && _operations.Peek() != "(")
                                        {
                                            CharList.Add(_operations.Pop());
                                        }
                                        else { break; }
                                    }
                                }
                            }
                            _operations.Push(letter);
                        }
                        else if (letter == "+" || letter == "-")
                        {
                            if (_operations.Count > 0)
                            {
                                if ((_operations.Peek() == "^" || _operations.Peek() == "\u221A" || letter == "%") ||
                                    (_operations.Peek() == "*" || _operations.Peek() == "/") ||
                                    (_operations.Peek() == "+" || _operations.Peek() == "-"))
                                {
                                    while (_operations.Count > 0)
                                    {
                                        if (_operations.Peek() != "(")
                                        {
                                            CharList.Add(_operations.Pop());
                                        }
                                        else { break; }
                                    }
                                }
                            }
                            _operations.Push(letter);
                        }
                        else if (letter == ")")
                        {
                            if (_operations.Contains("("))
                            {
                                while (_operations.Count > 0)
                                {
                                    if (_operations.Peek() != "(")
                                    {
                                        CharList.Add(_operations.Pop());
                                    }
                                    else { break; }
                                }
                                if (_operations.Peek() == "(")
                                {
                                    _operations.Pop();
                                }
                            }
                            else
                            {
                                throw new Exception("Несогласованное количество скобок в выражении!");
                            }
                        }
                        else
                        {
                            _operations.Push(letter);
                        }
                    }
                    
                }
                // Переносим все символы операций из стэка в коллекцию
                while (_operations.Count > 0)
                {
                    CharList.Add(_operations.Pop());
                }
                // преобразуем полученную коллекцию символов с строковую переменную для отображения            
                foreach (string element in CharList)
                {
                    if (CharList.IndexOf(element) == CharList.Capacity - 1)
                    {
                        reversedText = reversedText + element;
                    }
                    else 
                    {
                        reversedText = reversedText + element + " ";
                    }
                    
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
                    if (Double.TryParse(letter.ToString(), out double result))
                    {
                        _polishMathResult.Push(result);
                    }
                    else
                    {
                        double num_1 = _polishMathResult.Pop();
                        if (letter == "\u221A")
                        {
                            _polishMathResult.Push(Math.Sqrt(num_1));
                        }
                        else if (letter == "%")
                        {
                            _polishMathResult.Push(num_1 * 0.01);
                        }
                        else
                        {
                            double num_2 = _polishMathResult.Pop();
                            if (letter == "+")
                            {
                                _polishMathResult.Push(num_1 + num_2);
                            }
                            else if (letter == "-")
                            {
                                _polishMathResult.Push(num_2 - num_1);
                            }
                            else if (letter == "*")
                            {
                                _polishMathResult.Push(num_1 * num_2);
                            }
                            else if (letter == "/")
                            {
                                _polishMathResult.Push(num_2 / num_1);
                            }
                            else if (letter == "^")
                            {
                                _polishMathResult.Push(Math.Pow(num_2, num_1));
                            }
                        }
                    }
                }
            }
            
            string FinalValue = _polishMathResult.Pop().ToString();
            _polishMathResult.Clear();
            _polishMathResult.TrimExcess();
            return FinalValue; 
        }


        public PolishProcess()
        {
            //text = "";
            reversedText = "";
            _operations = new Stack<string>();
            _polishMathResult = new Stack<double>();
            CharList = new List<string>();
                
        }
    }
}

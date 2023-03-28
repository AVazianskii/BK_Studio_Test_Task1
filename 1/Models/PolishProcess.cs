using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _1
{
    public class PolishProcess
    {
        private Stack<char> _operations;
        private Stack<int> _polishMathResult;
        private string reversedText;
        private List<char> CharList;
        


        public string TransformToPolish(ref string text)
        {
            reversedText = "";
            try
            {
                foreach (char letter in text.ToCharArray())
                {
                    if (letter != ' ')
                    {
                        if (Int32.TryParse(letter.ToString(), out int result))
                        {
                            CharList.Add(letter);
                        }
                        else
                        {
                            if (letter == '*' || letter == '/')
                            {
                                if (_operations.Count > 0)
                                {
                                    if (_operations.Peek() == '^' || _operations.Peek() == '\u221A')
                                    {
                                        while (_operations.Count > 0)
                                        {
                                            if (_operations.Peek() != '+' && _operations.Peek() != '-' && _operations.Peek() != '(')
                                            {
                                                CharList.Add(_operations.Pop());
                                            }
                                            else { break; }
                                        }
                                    }
                                    else if (_operations.Peek() == '*' || _operations.Peek() == '/')
                                    {
                                        while (_operations.Count > 0)
                                        {
                                            if (_operations.Peek() != '+' && _operations.Peek() != '-' && _operations.Peek() != '(')
                                            {
                                                CharList.Add(_operations.Pop());
                                            }
                                            else { break; }
                                        }
                                    }
                                }
                                _operations.Push(letter);
                            }
                            else if (letter == '^' || letter == '\u221A')
                            {
                                if (_operations.Count > 0)
                                {
                                    if (_operations.Peek() == '^' || _operations.Peek() == '\u221A')
                                    {
                                        while (_operations.Count > 0)
                                        {
                                            if (_operations.Peek() != '+' && _operations.Peek() != '-' && _operations.Peek() != '(' )
                                            {
                                                CharList.Add(_operations.Pop());
                                            }
                                            else { break; }
                                        }
                                    }
                                }
                                _operations.Push(letter);
                            }
                            else if (letter == '+' || letter == '-')
                            {
                                if (_operations.Count > 0)
                                {
                                    if ((_operations.Peek() == '^' || _operations.Peek() == '\u221A') ||
                                        (_operations.Peek() == '*' || _operations.Peek() == '/') ||
                                        (_operations.Peek() == '+' || _operations.Peek() == '-'))
                                    {
                                        while (_operations.Count > 0)
                                        {
                                            if (_operations.Peek() != '(')
                                            {
                                                CharList.Add(_operations.Pop());
                                            }
                                            else { break; }
                                        }
                                    }
                                }
                                _operations.Push(letter);
                            }
                            else if (letter == ')')
                            {
                                if (_operations.Contains('('))
                                {
                                    while (_operations.Count > 0)
                                    {
                                        if (_operations.Peek() != '(')
                                        {
                                            CharList.Add(_operations.Pop());
                                        }
                                        else { break; }
                                    }
                                    if (_operations.Peek() == '(')
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
                }
                // Переносим все символы операций из стэка в коллекцию
                while (_operations.Count > 0)
                {
                    CharList.Add(_operations.Pop());
                }
                // преобразуем полученную коллекцию символов с строковую переменную для отображения            
                foreach (char element in CharList)
                {
                    reversedText = reversedText + element;
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
            foreach (char letter in ReversedPolishText.ToCharArray())
            {
                if (Int32.TryParse(letter.ToString(), out int result))
                {
                   _polishMathResult.Push(result);
                }
                else
                {
                    int num_1 = _polishMathResult.Pop();
                    if (letter == '\u221A')
                    {
                        _polishMathResult.Push(Convert.ToInt32(Math.Sqrt(num_1)));
                    }
                    else
                    {
                        int num_2 = _polishMathResult.Pop();
                        if (letter == '+')
                        {
                            _polishMathResult.Push(num_1 + num_2);
                        }
                        else if (letter == '-')
                        {
                            _polishMathResult.Push(num_2 - num_1);
                        }
                        else if (letter == '*')
                        {
                            _polishMathResult.Push(num_1 * num_2);
                        }
                        else if (letter == '/')
                        {
                            _polishMathResult.Push(num_2 / num_1);
                        }
                        else if (letter == '^')
                        {
                            _polishMathResult.Push(Convert.ToInt32(Math.Pow(num_2, num_1)));
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
            reversedText = "";
            _operations = new Stack<char>();
            _polishMathResult = new Stack<int>();
            CharList = new List<char>();
            
        }



        /*
        private int Add(int letter_1, int letter_2)
        {
            return Convert.ToChar(Convert.ToInt32(letter_1) + Convert.ToInt32(letter_2));
        }
        private int Substract(int letter_1, int letter_2)
        {
            return Convert.ToChar(Convert.ToInt32(letter_1) - Convert.ToInt32(letter_2));
        }
        private int Multiply(int letter_1, int letter_2)
        {
            return Convert.ToChar(Convert.ToInt32(letter_1) * Convert.ToInt32(letter_2));
        }
        private int Divide(int letter_1, int letter_2)
        {
            return Convert.ToChar(Convert.ToInt32(letter_1) / Convert.ToInt32(letter_2));
        }
        */
    }
}

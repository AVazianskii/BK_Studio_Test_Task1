using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{
    public class CalculatorViewModel : Base_ViewModel
    {
        private string inputText,
                       result,
                       reversePolishText;
        private PolishProcess polishProcess;
        private byte [] square_sign;



        public Command Addition { get; private set; }
        public Command Substraction { get; private set; }
        public Command Multiplication { get; private set; }
        public Command Division { get; private set; }
        public Command Write_0 { get; private set; }
        public Command Write_1 { get; private set; }
        public Command Write_2 { get; private set; }
        public Command Write_3 { get; private set; }
        public Command Write_4 { get; private set; }
        public Command Write_5 { get; private set; }
        public Command Write_6 { get; private set; }
        public Command Write_7 { get; private set; }
        public Command Write_8 { get; private set; }
        public Command Write_9 { get; private set; }
        public Command ClearOne { get; private set; }
        public Command ClearAll { get; private set; }
        public Command Calculate { get; private set; }
        public Command Write_LBracket { get; private set; }
        public Command Write_RBracket { get; private set; }
        public Command Write_degree { get; private set; }
        public Command Write_square { get; private set; }
        public Command Write_percent { get; private set; }
        public Command Write_point { get; private set; }
        public string InputText
        {
            get { return inputText; }
            set 
            { 
                inputText = value; 
                OnPropertyChanged("InputText");               
            }
        }
        public string Result
        {
            get { return result; }
            set { result = value; OnPropertyChanged("Result"); }
        }
        public string ReversePolishText
        {
            get { return reversePolishText; }
            set { reversePolishText = value; OnPropertyChanged("ReversePolishText"); }
        }



        public CalculatorViewModel()
        {
            inputText = "";
            square_sign = new byte [2]{ 0x22, 0x1A };
            Addition = new Command(o => _Addition());
            Substraction = new Command(o => _Substraction());
            Multiplication = new Command(o => _Multiplication());
            Division = new Command(o => _Division());
            Calculate = new Command(o => _Calculate());

            ClearOne = new Command(o => _ClearOne(), o => InputText.Length > 0);
            ClearAll = new Command(o => _ClearAll(), o => InputText.Length > 0);

            Write_0 = new Command(o => Write_number(0));
            Write_1 = new Command(o => Write_number(1));
            Write_2 = new Command(o => Write_number(2));
            Write_3 = new Command(o => Write_number(3));
            Write_4 = new Command(o => Write_number(4));
            Write_5 = new Command(o => Write_number(5));
            Write_6 = new Command(o => Write_number(6));
            Write_7 = new Command(o => Write_number(7));
            Write_8 = new Command(o => Write_number(8));
            Write_9 = new Command(o => Write_number(9));
            Write_LBracket = new Command(o => Write_symbol("( "));
            Write_RBracket = new Command(o => Write_symbol(" )"));
            Write_degree = new Command(o => Write_symbol("^"));
            Write_square = new Command(o => Write_symbol("\u221A")); 
            Write_percent = new Command(o => Write_symbol("%"));
            Write_point = new Command(o => Write_symbol(","));

            polishProcess = new PolishProcess();
        }



        private void _Addition()
        {
            InputText = InputText + " " + "+" + " ";
        }            
        private void _Substraction()
        {
            InputText = InputText + " " + "-" + " ";
        }
        private void _Multiplication()
        {
            InputText = InputText + " " + "*" + " ";
        }
        private void _Division()
        {
            InputText = InputText + " " + "/" + " ";
        }
        private void Write_number(int number)
        {
            InputText = InputText + number.ToString();
        }
        private void Write_symbol(string symbol)
        {
            InputText = InputText + symbol;
        }
        private void _ClearOne()
        {
            InputText = InputText.TrimEnd(InputText.Last());
        }
        private void _ClearAll()
        {
            InputText = "";
            ReversePolishText = "";
            Result = "";
        }
        private void _Calculate()
        {
            ReversePolishText = polishProcess.TransformToPolish(ref inputText);

            Result = polishProcess.CalculatePolish(ref reversePolishText);
        }
    }
}

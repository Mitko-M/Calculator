using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Windows.Globalization.NumberFormatting;

namespace Calculator
{
    public class Calculator
    {
        private string input;

        public Calculator()
        {
            
        }

        public Calculator(string _input)
        {
            input = _input;
        }

        public string Calculate()
        {
            string result = "";

            var calculatorInput = input
                .Split(" ", System.StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var listWithNumbers = new List<double>();
            var listWithArithmeticActions = new List<string>();

            foreach (var number in calculatorInput)
            {
                double output;

                if (double.TryParse(number, NumberStyles.Float, CultureInfo.InvariantCulture, out output))
                {
                    listWithNumbers.Add(output);
                }
                else
                {
                    listWithArithmeticActions.Add(number);
                }
            }

            while (listWithArithmeticActions.Count > 0 && listWithNumbers.Count > 1)
            {
                if (listWithArithmeticActions.Contains("%"))
                {
                    int index = listWithArithmeticActions.IndexOf("%");
                    listWithArithmeticActions.RemoveAt(index);

                    double num1 = listWithNumbers[index];
                    double num2 = 1;
                    if (index < listWithNumbers.Count - 1)
                    {
                        num2 = listWithNumbers[index + 1];
                        listWithNumbers.RemoveAt(index + 1);
                    }

                    listWithNumbers[index] = (0.01 * num1) * num2;
                }
                else if (listWithArithmeticActions.Contains("*"))
                {
                    int index = listWithArithmeticActions.IndexOf("*");
                    listWithArithmeticActions.RemoveAt(index);

                    double num1 = listWithNumbers[index];
                    double num2 = listWithNumbers[index + 1];
                    listWithNumbers.RemoveAt(index + 1);

                    listWithNumbers[index] = num1 * num2;
                }
                else if (listWithArithmeticActions.Contains("/"))
                {
                    int index = listWithArithmeticActions.IndexOf("/");
                    listWithArithmeticActions.RemoveAt(index);

                    double num1 = listWithNumbers[index];
                    double num2 = listWithNumbers[index + 1];
                    listWithNumbers.RemoveAt(index + 1);

                    if (num2 == 0)
                    {
                        return "You can't divide by zero!";
                    }
                    else
                    {
                        listWithNumbers[index] = num1 / num2;
                    }
                }
                else if (listWithArithmeticActions.Contains("-"))
                {
                    int index = listWithArithmeticActions.IndexOf("-");
                    listWithArithmeticActions.RemoveAt(index);

                    double num1 = listWithNumbers[index];
                    double num2 = listWithNumbers[index + 1];
                    listWithNumbers.RemoveAt(index + 1);

                    listWithNumbers[index] = num1 - num2;
                }
                else
                {
                    int index = listWithArithmeticActions.IndexOf("+");
                    listWithArithmeticActions.RemoveAt(index);

                    double num1 = listWithNumbers[index];
                    double num2 = listWithNumbers[index + 1];
                    listWithNumbers.RemoveAt(index + 1);

                    listWithNumbers[index] = num1 + num2;
                }
            }

            if (listWithNumbers[0] > double.MaxValue)
            {
                result = "The number is too large!";
            }
            else
            {
                result = $"={listWithNumbers[0]}";
            }

            return result;
        }
    }
}

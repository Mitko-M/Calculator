using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Media.MediaProperties;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Calculator
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private string[] actions = { "/", "-", "+", "*" };

        public MainWindow()
        {
            this.InitializeComponent();
        }

        //KEYBOARD ACTIONS

        //arithmetics and others
        private void DeleteBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }
        
        private void DivideBtn_Click_Witk_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void MultiplyBtn_Click_Witk_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void MinusBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void PlusBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void DecimalBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void RemoveBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void EqualsBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }


        //numbers
        private void ZeroBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void OneBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void TwoBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void ThreeBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void FourBtn_Click_Witk_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void FiveBtn_Click_Witk_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void SixBtn_Click_Witk_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void SeventBtn_Click_Witk_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void EightBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }

        private void NineBtn_Click_With_Key(object sender, KeyboardAcceleratorInvokedEventArgs e)
        {

        }


        //MOUSE ACTIONS

        //arithmetics and others
        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            outputTextBlock.Text = "0";
        }

        private void NegateBtn_Click(object sender, RoutedEventArgs e)
        {
            if (outputTextBlock.Text != "0")
            {
                string outputText = outputTextBlock.Text;

                if (outputText.Contains('/') ||
                    outputText.Contains('*') ||
                    outputText.Contains('+') ||
                    outputText.Contains('-') &&
                    outputText.Contains(' '))
                {
                    var temp = outputText
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();

                    int lastNumIndex = temp.Length - 1;

                    if (!actions.Contains(temp[lastNumIndex]))
                    {
                        if (double.Parse(temp[lastNumIndex]) > 0)
                        {
                            temp[lastNumIndex] = $"-{temp[lastNumIndex]}";
                        }
                        else
                        {
                            temp[lastNumIndex] = temp[lastNumIndex].Remove(0, 1);
                        }

                        outputTextBlock.Text = String.Join(" ", temp);
                    }
                }
                else
                {
                    if (double.Parse(outputText) > 0)
                    {
                        outputTextBlock.Text = $"-{outputText}";
                    }
                    else
                    {
                        outputTextBlock.Text = outputText.Remove(0, 1);
                    }
                }
            }
        }

        private void DecimalBtn_Clicked(object sender, RoutedEventArgs e)
        {
            if (!outputTextBlock.Text.EndsWith(' '))
            {
                if (outputTextBlock.Text.EndsWith('.'))
                {

                }
                else
                {
                    outputTextBlock.Text += ".";
                }
            }
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (outputTextBlock.Text.Contains("=") ||
                Char.IsLetter(outputTextBlock.Text[0]))
            {
                outputTextBlock.Text = "0";
            }
            else if (outputTextBlock.Text != "")
            {
                var temp = outputTextBlock.Text
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

                int lastIndex = temp.Length - 1;

                temp[lastIndex] = temp[lastIndex].Remove(temp[lastIndex].Length - 1, 1);

                if (temp[0] == "")
                {
                    outputTextBlock.Text = "0";
                }
                else
                {
                    outputTextBlock.Text = String.Join(" ", temp);
                }
            }
            else
            {
                outputTextBlock.Text = "0";
            }
        }

        private void EqualsBtn_Click(object sender, RoutedEventArgs e)
        {
            if (outputTextBlock.Text != "0")
            {
                if (Char.IsDigit(outputTextBlock.Text[0]) || outputTextBlock.Text[0] == '-')
                {
                    Calculator calc = new Calculator(outputTextBlock.Text);

                    outputTextBlock.Text = calc.Calculate();
                }
                else
                {
                    outputTextBlock.Text = "0";
                }
            }
        }

        private void ArithmeticBtn_Click(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            string content = btn.Content.ToString();

            if (outputTextBlock.Text.EndsWith(" "))
            {

            }
            else
            {
                outputTextBlock.Text += $" {content} ";
            }
        }


        //numbers
        private void NumberBtn_Clicked(object sender, RoutedEventArgs e)
        {
            var btn = (Button)sender;
            string content = btn.Content.ToString();

            double result;

            if (double.TryParse(content, out result))
            {
                if (outputTextBlock.Text == "0")
                {
                    outputTextBlock.Text = content;
                }
                else
                {
                    outputTextBlock.Text += content;
                }
            }
        }
    }
}

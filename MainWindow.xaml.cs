using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace praktich1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentInput = string.Empty;
        private double result = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string buttonText = button.Content.ToString();

            if (currentInput.Length == 0 || (currentInput.Length > 0 && currentInput.EndsWith(" ")))
            {
                if (buttonText == "-")
                {
                    currentInput += buttonText;
                    textBlock.Text = currentInput;
                }
                else
                {
                    currentInput += buttonText;
                    textBlock.Text = currentInput;
                }
            }
            else
            {
                currentInput += buttonText;
                textBlock.Text = currentInput;
            }
        }
        private void OperatorButtonClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentInput += " " + button.Content.ToString() + " ";
            textBlock.Text = currentInput;
        }
        private void EqualsButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                result = EvaluateExpression(currentInput);
                textBlock.Text = result.ToString();
                currentInput = result.ToString();
            }
            catch (Exception)
            {
                textBlock.Text = "Ошибка";
                currentInput = string.Empty;
            }
        }
        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            textBlock.Text = string.Empty;
            currentInput = string.Empty;
            result = 0;
        }
        private double EvaluateExpression(string expression)
        {
            string[] operands = expression.Split(' ');
            double operand1 = Convert.ToDouble(operands[0]);
            double operand2 = Convert.ToDouble(operands[2]);
            char operation = Convert.ToChar(operands[1]);

            switch (operation)
            {
                case '+':
                    return operand1 + operand2;
                case '-':
                    return operand1 - operand2;
                case '*':
                    return operand1 * operand2;
                case '/':
                    if (operand2 != 0)
                        return operand1 / operand2;
                    else
                        throw new DivideByZeroException("Деление на 0 невозможно");
                default:
                    throw new InvalidOperationException("Неизвестная операция");
            }
        }
    }
}

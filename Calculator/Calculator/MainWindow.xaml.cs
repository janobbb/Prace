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

namespace Calculator
{
    public partial class MainWindow : Window
    {

        private double result = 0;
        private string currentOperator = "";
        private bool isNewEntry = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Ta opcja jeszcze nie działa");
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string operatorSymbol = button.Content.ToString(); //Przykładowo "/" lub "X"

            if (!string.IsNullOrEmpty(currentOperator)) //Sprawdzenie czy istnieje możliwość przeprowadzenia operacji
            {
                Calculate();
            }

            result = double.Parse(displayBox.Text); 
            currentOperator = operatorSymbol;
            isNewEntry = true; //Wyczyszczenie wcześniej wprowadzonych danych
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Content.ToString();

            if (isNewEntry)
            {
                displayBox.Text = number;
                isNewEntry = false;
            }
            else
            {
                if (number == "," && displayBox.Text.Contains(",")) //Sprawdzenie czy liczba nie zaczyna się od ','
                {
                    return; 
                }
                displayBox.Text += number;
            }
            displayBox.Text = displayBox.Text.TrimStart('0'); //Blokowanie możliwości wprowadzenia liczb takich jak 0123
            displayBox.Text = displayBox.Text.TrimStart(','); //Blokowanie możliwości wprowadzenia liczb takich jak ,123

            //W kalkulatorze nie zostało uwzględnione rozpoczynanie liczb takich jak 0,1
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            Calculate();
            currentOperator = "";
        }

        private void Calculate()
        {
            double secondNumber = double.Parse(displayBox.Text);

            switch (currentOperator)
            {
                case "+":
                    result += secondNumber;
                    break;
                case "-":
                    result -= secondNumber;
                    break;
                case "X":
                    result *= secondNumber;
                    break;
                case "/":
                    result /= secondNumber;
                    break;
                case "x^2":
                    result = Math.Pow(result,2);
                    break;
                case "(sqrt)x":
                    result = Math.Sqrt(result);
                    break;
            }

            displayBox.Text = result.ToString();
            isNewEntry = true;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            displayBox.Text = "";
            result = 0;
            currentOperator = "";
            isNewEntry = true;
        }

        private void UndoButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(displayBox.Text))
            {
                displayBox.Text = displayBox.Text.Remove(displayBox.Text.Length - 1); //Usuwanie liczb od ostatniego indeksu
            }
        }

        private void InvertButton_Click(object sender, RoutedEventArgs e)
        {

            if (!string.IsNullOrEmpty(displayBox.Text))
            {
                displayBox.Text = (1 / double.Parse(displayBox.Text)).ToString(); //Odwrócenie liczby (np. z 10 na 0,1)
            }
        }
    }
}

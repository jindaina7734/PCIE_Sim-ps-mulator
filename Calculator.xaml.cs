using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;

namespace LoginApp
{
    public partial class Calculator : Window
    {
        string DecimalSeparator => CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator;
        private double _currentValue = 0;
        private string _currentOperation = string.Empty;
        private bool _isNewEntry = true;

        public Calculator()
        {
            InitializeComponent();
            btnPoint.Content = DecimalSeparator;
        }

        private void btnPoint_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text.Contains(this.DecimalSeparator))
                return;
            numberClick(sender, e);
        }

        private void numberClick(object sender, RoutedEventArgs e)
        {
            if (_isNewEntry)
            {
                txtInput.Text = "";
                _isNewEntry = false;
            }

            txtInput.Text = $"{txtInput.Text}{((Button)sender).Content}";
            txtEquation.Text = $"{txtEquation.Text}{((Button)sender).Content}";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (txtInput.Text == "0")
                return;

            txtInput.Text = txtInput.Text.Substring(0, txtInput.Text.Length - 1);
            if (txtInput.Text == "")
                txtInput.Text = "0";
        }

        private void btnClearEntry_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
            txtEquation.Text = "";
        }

        private void btnClearAll_Click(object sender, RoutedEventArgs e)
        {
            txtInput.Text = "0";
            txtEquation.Text = "";
            _currentValue = 0;
            _currentOperation = string.Empty;
        }

        private void OperationClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtInput.Text, out double newValue))
            {
                if (!string.IsNullOrEmpty(_currentOperation))
                {
                    Calculate(newValue);
                }
                else
                {
                    _currentValue = newValue;
                }

                _currentOperation = ((Button)sender).Content.ToString();
                txtEquation.Text = $"{txtEquation.Text} {_currentOperation} ";
                _isNewEntry = true;
            }
        }

        private void btnEquals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtInput.Text, out double newValue))
            {
                Calculate(newValue);
                _currentOperation = string.Empty;
                _isNewEntry = true;
                txtEquation.Text = $"{txtEquation.Text} = {txtInput.Text}";
            }
        }

        private void Calculate(double newValue)
        {
            switch (_currentOperation)
            {
                case "+":
                    _currentValue += newValue;
                    break;
                case "-":
                    _currentValue -= newValue;
                    break;
                case "*":
                    _currentValue *= newValue;
                    break;
                case "/":
                    if (newValue != 0)
                        _currentValue /= newValue;
                    else
                        MessageBox.Show("Cannot divide by zero");
                    break;
            }

            txtInput.Text = _currentValue.ToString();
        }
    }
}

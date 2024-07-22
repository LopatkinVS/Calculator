using Calculator.Data.Interfaces;
using System.Text.RegularExpressions;

namespace Calculator.Data.Repositories
{
    public class CalculateNumberRepository : ICalculateNumberRepository
    {
        private const string numberChars = "0123456789.";
        private const string operatorChars = "^*/+-";

        public double CalculateString(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                throw new ArgumentException("Пустое выражение недопустимо", nameof(expression));

            CheckBrackets(expression);

            return EvaluateBrackets(expression);
        }

        private double EvaluateBrackets(string expression)
        {
            string tempExpression = expression;
            while (tempExpression.Contains('('))
            {
                int bracketStart = tempExpression.IndexOf('(') + 1;
                int bracketEnd = IndexOfRightBracket(tempExpression, bracketStart);
                string bracket = tempExpression.Substring(bracketStart, bracketEnd - bracketStart);
                tempExpression = tempExpression.Replace("(" + bracket + ")", EvaluateBrackets(bracket).ToString());
            }

            return Evaluate(tempExpression);
        }

        private int IndexOfRightBracket(string expression, int start)
        {
            int c = 1;
            for (int i = start; i < expression.Length; i++)
            {
                switch (expression[i])
                {
                    case '(': c++; break;
                    case ')': c--; break;
                }
                if (c == 0) return i;
            }
            return -1;
        }

        private void CheckBrackets(string expression)
        {
            int i = 0;
            foreach (char c in expression)
            {
                switch (c)
                {
                    case '(': i++; break;
                    case ')': i--; break;
                }
                if (i < 0)
                    throw new ArgumentException("Не хватает '('", nameof(expression));
            }
            if (i > 0)
                throw new ArgumentException("Не хватает ')'", nameof(expression));
        }

        private double Evaluate(string expression)
        {
            string normalExpression = expression.Replace(" ", "");
            List<char> operators = new List<char>();
            List<double> numbers = new List<double>();

            int index = 0;
            while (index < normalExpression.Length)
            {

                if (char.IsDigit(normalExpression[index]) || normalExpression[index] == '.')
                {
                    int start = index;
                    while (index < normalExpression.Length && (char.IsDigit(normalExpression[index]) || normalExpression[index] == '.'))
                    {
                        index++;
                    }
                    string numberString = normalExpression.Substring(start, index - start);
                    if (double.TryParse(numberString, out double number))
                    {
                        numbers.Add(number);
                    }
                    else
                    {
                        throw new FormatException($"Неверный формат ввода: {numberString}");
                    }
                }

                else if (operatorChars.Contains(normalExpression[index]))
                {
                    if (operators.Count == numbers.Count)
                    {
                        throw new ArgumentException($"Неверный синтаксис в выражении: два оператора подряд {index + 1}", nameof(expression));
                    }
                    operators.Add(normalExpression[index]);
                    index++;
                }
                else
                {
                    throw new ArgumentException($"Не тот символ: {normalExpression[index]}", nameof(expression));
                }
            }

            if (operators.Count + 1 != numbers.Count)
                throw new ArgumentException($"Неверный синтаксис в выражении '{expression}'", nameof(expression));

            foreach (char o in operatorChars)
            {
                for (int i = 0; i < operators.Count; i++)
                {
                    if (operators[i] == o)
                    {
                        double result = Calculate(numbers[i], numbers[i + 1], o);
                        numbers[i] = result;
                        numbers.RemoveAt(i + 1);
                        operators.RemoveAt(i);
                        i--;
                    }
                }
            }
            return numbers[0];
        }


        private double Calculate(double left, double right, char oper)
        {
            switch (oper)
            {
                case '+': return left + right;
                case '-': return left - right;
                case '*': return left * right;
                case '/': return left / right;
                case '^': return Math.Pow(left, right);
                default: throw new ArgumentException("Неподдерживаемый оператор", nameof(oper));
            }
        }
    }
}

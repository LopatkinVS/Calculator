namespace Calculator.CustomException
{
    public class NumberLessThanZeroException : Exception
    {
        public NumberLessThanZeroException() { }

        public NumberLessThanZeroException(string message) : base(message) { }
        
        public NumberLessThanZeroException(string message , Exception inner) : base(message, inner) { }
    }
}

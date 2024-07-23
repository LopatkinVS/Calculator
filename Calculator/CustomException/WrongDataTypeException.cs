namespace Calculator.CustomException
{
    public class WrongDataTypeException : Exception
    {
        public WrongDataTypeException() { }

        public WrongDataTypeException(string message) : base(message) { }

        public WrongDataTypeException(string message, Exception inner) : base(message, inner) { }
    }
}

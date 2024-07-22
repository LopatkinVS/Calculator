namespace Calculator.Data.Interfaces
{
    public interface ICalculateNumberRepository
    {
        double CalculateSum(double firstTerm, double secondTerm);
        double CalculateSubtraction(double initialNumber, double substractionNumber);
        double CalculateMultiplication(double firstMultipiler, double secondMultipilier);
        double CalculateDivision(double Dividend, double Divider);
        double CalculatePow(double intialNumber, double power);
        double CalculateSquareRoot(double initialNumber);
    }
}

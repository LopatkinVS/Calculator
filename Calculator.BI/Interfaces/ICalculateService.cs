namespace Calculator.BI.Interfaces
{
    public interface ICalculateService
    {
        double CalculateSum(double firstTerm, double secondTerm);
        double CalculateSubtraction(double initialNumber, double substractionNumber);
        double CalculateMultiplication(double firstMultipiler, double secondMultipilier);
        double CalculateDivision(double dividend, double divider);
        double CalculatePow(double intialNumber, double power);
        double CalculateSquareRoot(double initialNumber);
    }
}

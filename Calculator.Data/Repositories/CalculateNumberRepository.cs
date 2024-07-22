using Calculator.Data.Interfaces;

namespace Calculator.Data.Repositories
{
    public class CalculateNumberRepository : ICalculateNumberRepository
    {
        public double CalculateSum(double firstTerm, double secondTerm)
        {
            return firstTerm + secondTerm;
        }

        public double CalculateSubtraction(double initialNumber, double substractionNumber)
        {
            return initialNumber - substractionNumber;
        }

        public double CalculateMultiplication(double firstMultipiler, double secondMultipilier)
        {
            return firstMultipiler * secondMultipilier;
        }

        public double CalculateDivision(double Dividend, double Divider)
        {
            return Dividend / Divider;
        }

        public double CalculatePow(double intialNumber, double power)
        {
            return Math.Pow(intialNumber, power);
        }

        public double CalculateSquareRoot(double initialNumber)
        {
            return Math.Sqrt(initialNumber);
        }
    }
}

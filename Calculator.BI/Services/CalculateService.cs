using Calculator.BI.Interfaces;
using Calculator.Data.Interfaces;

namespace Calculator.BI.Services
{
    public class CalculateService : ICalculateService
    {
        private readonly ICalculateNumberRepository _calculateNumberRepository;

        public CalculateService(ICalculateNumberRepository calculateNumberRepository)
        {
            _calculateNumberRepository = calculateNumberRepository;
        }

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

        public double CalculateDivision(double dividend, double divider)
        {
            return dividend / divider;
        }

        public double CalculatePow(double intialNumber, double power)
        {
            return Math.Pow(intialNumber, power);
        }

        public double CalculateSquareRoot(double initialNumber, double rootDegree)
        {
            return Math.Pow(initialNumber, 1.0 / rootDegree);
        }

        public double CalculateExpression(string expression)
        {
            return _calculateNumberRepository.CalculateString(expression);
        }
    }
}

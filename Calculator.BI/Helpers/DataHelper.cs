namespace Calculator.BI.Helpers
{
    public static class DataHelper
    {
        public static bool CheckDivisionByZero(double divider)
        {
            return divider == 0;
        }

        public static bool CheackNumberLessThanZeroInRoot(double initialNumber, double rootDegree)
        {
            return rootDegree % 2 == 0 && initialNumber < 0;
        }
    }
}

using NewMortgageCalculator;

namespace NewMortgageCalculatorTest
{
    [TestClass]
    public class MortgageCalculatorTest
    {
        [TestMethod]
        public void MonthlyPayment()
        {
            int loanAmount = 25000;
            float loanRate = 5f;
            int months = 60;

            double expected = 471.78;

            var m = new MortgageCalculator();
            var actual = m.MonthlyPayment(loanAmount, loanRate, months);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void InterestPayment()
        {
            float previousBalance = 24528.22f;
            float loanRate = 3.75f;

            double expected = 76.65;

            var m = new MortgageCalculator();
            var actual = m.InterestPayment(loanRate, previousBalance);
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]

        public void PrincipalPayment()
        {
            float monthlyPayment = 471.78f;
            float interestPayment = 76.65f;

            double expected = 395.13;

            var m = new MortgageCalculator();
            var actual = m.PrincipalPayment(monthlyPayment, interestPayment);
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]

        public void RemainingBalance()
        {
            float previousBalance = 24528.22f;
            float principalPayment = 395.13f;

            double expected = 24133.09;

            var m = new MortgageCalculator();
            var actual = m.RemainingBalance(previousBalance, principalPayment);
            Assert.AreEqual(expected, actual);
        }
    }
}
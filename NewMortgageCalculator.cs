using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;



namespace NewMortgageCalculator
{
    public class MortgageCalculator
    {

        public double MonthlyPayment(int loanAmount, float loanRate, int months)
        {
            double numerator = (loanAmount) * (loanRate / 1200);
            double denominator = (1 - Math.Pow((1 + loanRate / 1200), -(months)));
            return Math.Round((numerator / denominator), 2);
        }

        public double InterestPayment(float loanRate, float previousBalance) =>
            Math.Round((previousBalance * loanRate / 1200), 2);


        public double PrincipalPayment(float monthlyPayment, float interestPayment) =>
           Math.Round((monthlyPayment - interestPayment), 2);


        public double RemainingBalance(float previousBalance, float principalPayment)
        {
            return Math.Round((previousBalance - principalPayment), 2);
        }
    }
}

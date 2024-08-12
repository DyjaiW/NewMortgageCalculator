using System.ComponentModel.DataAnnotations.Schema;
using Spectre;
using Spectre.Console;
using NewMortgageCalculator;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NuGet;


class Program
{
    static void Main(string[] args)
    {
        // Input values
        Console.Write("Enter loan amount: ");
        double loanAmount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter annual interest rate (in %): ");
        double annualInterestRate = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter loan term (in years): ");
        int loanTermYears = Convert.ToInt32(Console.ReadLine());

        // Calculations
        double monthlyInterestRate = annualInterestRate / 100 / 12;
        int totalPayments = loanTermYears * 12;
        double monthlyPayment = loanAmount * monthlyInterestRate / (1 - Math.Pow(1 + monthlyInterestRate, -totalPayments));

        // Create a table
        var table = new Table();
        table.AddColumn("Month");
        table.AddColumn("Payment");
        table.AddColumn("Interest");
        table.AddColumn("Principal");
        table.AddColumn("Balance");

        double balance = loanAmount;

        for (int month = 1; month <= totalPayments; month++)
        {
            double interest = balance * monthlyInterestRate;
            double principal = monthlyPayment - interest;
            balance -= principal;

            // Add a row to the table
            table.AddRow(
                month.ToString(),
                monthlyPayment.ToString("C"),
                interest.ToString("C"),
                principal.ToString("C"),
                balance.ToString("C")
            );
        }

        // Render the table
        AnsiConsole.Write(table);
    }
}
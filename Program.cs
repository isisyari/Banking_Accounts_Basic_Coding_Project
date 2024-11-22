// See https://aka.ms/new-console-template for more information
using System;
using System.IO.Pipelines;

using System;

public class Program
{
    public static void IsAccount(out bool isSavings, out bool isCheckings, out bool isBusiness)
    {
        isSavings = false;
        isCheckings = false;
        isBusiness = false;

        Console.WriteLine("Enter Account Type (Checkings/Savings/Business): ");
        string accountType = Console.ReadLine()?.ToLower() ?? "";

        while (accountType != "checkings" && accountType != "savings" && accountType != "business")
        {
            Console.WriteLine("Please enter Checkings, Savings, or Business:");
            accountType = Console.ReadLine()?.ToLower() ?? "";
        }

        switch (accountType)
        {
            case "checkings":
                isCheckings = true;
                break;
            case "savings":
                isSavings = true;
                break;
            case "business":
                isBusiness = true;
                break;
        }
    }

    public static void SavingsAccount(double totalSavings, double time)
    {
        if (time == 12)
        {
            double result = totalSavings + (totalSavings * 0.2);  // 20% bonus for 12 months
            Console.WriteLine($"Savings Account Balance after 12 months: {result}");
        }
        else
        {
            Console.WriteLine("This method is only applicable for 12 months.");
        }
    }

    public static void CheckingsAccount(double totalCheckings, double time)
    {
        if (time < 0)
        {
            Console.WriteLine("Time cannot be negative");
            return;
        }
        if (time == 12)
        {
            double result = totalCheckings - 10; // Fee of $10 for 12 months
            Console.WriteLine($"Checkings Account Balance after 12 months: {result}");
        }
        else
        {
            Console.WriteLine("This method is only applicable for 12 months.");
        }
    }

    // Business account logic
    public static void BusinessAccount(double totalBusiness, double time)
    {
        if (time < 0)
        {
            Console.WriteLine("Time cannot be negative");
            return;
        }

        if (time == 12)
        {
            double result = totalBusiness + (0.1 * totalBusiness); // 10% bonus for business account
            Console.WriteLine($"Business Account Balance after 12 months with bonus: {result}");
        }
        else
        {
            double monthlyFee = 20 * time;  // Monthly fee of $20
            double result = totalBusiness - monthlyFee;
            Console.WriteLine($"Balance after {time} months of fees: {result}");
        }
    }

  
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter total amount: ");
        if (double.TryParse(Console.ReadLine(), out double total))
        {
            Console.WriteLine("Enter time (months): ");
            if (double.TryParse(Console.ReadLine(), out double time))
            {
                bool isSavings, isCheckings, isBusiness;

                // Determine the account type
                IsAccount(out isSavings, out isCheckings, out isBusiness);

                // Call appropriate method based on account type
                if (isSavings)
                {
                    SavingsAccount(total, time);
                }
                else if (isCheckings)
                {
                    CheckingsAccount(total, time);
                }
                else if (isBusiness)
                {
                    BusinessAccount(total, time);
                }
            }
            else
            {
                Console.WriteLine("Invalid time input");
            }
        }
        else
        {
            Console.WriteLine("Invalid amount input");
        }
    }
}


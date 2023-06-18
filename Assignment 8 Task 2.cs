using System;

public struct Currency
{
    public string Name { get; }
    public decimal Amount { get; }

    public Currency(string name, decimal amount)
    {
        Name = name;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{Amount} {Name}";
    }
}

public partial class BankAccount
{
    private readonly string bankName;

    public string AccountNumber { get; set; }
    public string AccountHolderName { get; set; }
    public Currency Balance { get; private set; }

    public BankAccount(string bankName, string accountNumber, string accountHolderName, Currency balance)
    {
        this.bankName = bankName;
        AccountNumber = accountNumber;
        AccountHolderName = accountHolderName;
        Balance = balance;
    }

    public void Deposit(Currency amount)
    {
        Balance = new Currency(Balance.Name, Balance.Amount + amount.Amount);
        Console.WriteLine($"Deposited: {amount.Amount} {amount.Name}");
    }

    public void Withdraw(Currency amount)
    {
        if (Balance.Amount >= amount.Amount)
        {
            Balance = new Currency(Balance.Name, Balance.Amount - amount.Amount);
            Console.WriteLine($"Withdrawn: {amount.Amount} {amount.Name}");
        }
        else
        {
            Console.WriteLine("Not enough balance");
        }
    }

    public void BalanceCheck()
    {
        Console.WriteLine($"Account Number: {AccountNumber}");
        Console.WriteLine($"Account Holder: {AccountHolderName}");
        Console.WriteLine($"Balance: {Balance.Amount} {Balance.Name}");
    }
}

public partial class BankAccount
{
    public void TransferFunds(BankAccount target, Currency amount)
    {
        if (Balance.Amount >= amount.Amount)
        {
            Withdraw(amount);
            target.Deposit(amount);
            Console.WriteLine($"Transferred: {amount.Amount} {amount.Name} to Account Number: {target.AccountNumber}");
        }
        else
        {
            Console.WriteLine("Not enough balance.");
        }
    }
}

public class Program
{
    static void Main()
    {
        
        BankAccount account1 = new BankAccount("TBC Bank", "7777777", "Jaba Agulashvili", new Currency("GEL", 1000));
        BankAccount account2 = new BankAccount("TBC BANK", "9999999", "Agulashvili Jaba", new Currency("GEL", 500));

        
        account1.Deposit(new Currency("GEL", 500));
        account1.Withdraw(new Currency("GEL", 200));
        account1.BalanceCheck();

        account2.Deposit(new Currency("GEL", 100));
        account2.TransferFunds(account1, new Currency("GEL", 300));
        account2.BalanceCheck();

        account1.BalanceCheck();
    }
}

// See https://aka.ms/new-console-template for more information
using Mini_Banking_System;

try
{

    Console.WriteLine("Mini Banking System\n");

    ITransactionLogger logger = new ConsoleTransactionLogger();
    BankService bankService = new BankService(logger);
    BankAccount savingsAccount = new SavingsAccount("SA-1001", "Amit");
    BankAccount checkingAccount = new CheckingAccount("CA-2001", "Sorta");

    bankService.AddBankAccount(savingsAccount);
    bankService.AddBankAccount(checkingAccount);

    bankService.Deposit("SA-1001", 500);
    bankService.Withdraw("SA-1001", 300);
    bankService.Withdraw("CA-2001", 2000);

    bankService.PrintAllSummary();

    Console.ReadKey();

}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Operation failed: {ex.Message}");
}

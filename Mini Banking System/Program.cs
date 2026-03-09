// See https://aka.ms/new-console-template for more information
using Mini_Banking_System;

Console.WriteLine("Mini Banking System\n");

SavingsAccount savingsAccount1 = new SavingsAccount();
CheckingAccount checkingAccount = new CheckingAccount();

savingsAccount1.DisplayAccountInfo();
checkingAccount.DisplayAccountInfo();
Console.ReadKey();

# Mini-Banking-System
Mini Banking System (OOP C#)

Goal: Build a small banking system in C# using Inheritance, Method Overriding, Abstract
Classes, and Interfaces.

1) Story / Context
A bank is building a small internal system to manage different account types. All accounts share
common details (AccountNumber, HolderName, Balance), but rules differ by account type. The
system must support deposits, withdrawals (rules vary per account), interest for savings, and a
simple transaction logging capability.
2) Core Requirements
2.1 Abstract Class: BankAccount
Create an abstract base class that defines what every bank account is.
Common State (properties):
• AccountNumber (string)
• HolderName (string)
• Balance (decimal)
Common Methods:
• Deposit(decimal amount) (implemented in base class)
• Withdraw(decimal amount) (abstract — must be implemented by child classes)
• GetAccountSummary() (virtual — can be overridden by child classes)
Rules (keep simple — no exception handling required):
• Deposit amount must be > 0
• Withdraw amount must be > 0
• Balance should never go negative unless the account type allows it
2.2 Inheritance + Method Overriding: Account Types
A) SavingsAccount : BankAccount
• Cannot withdraw if it makes balance negative
• Has InterestRate (decimal)
• Has ApplyMonthlyInterest() method

• Overrides GetAccountSummary() to include interest rate
B) CheckingAccount : BankAccount
• Allows overdraft up to OverdraftLimit (decimal)
• Overrides Withdraw() to support overdraft rules
• Overrides GetAccountSummary() to include overdraft limit
2.3 Interface: Transaction Logging Capability
Create an interface:
• ITransactionLogger
• Method: void Log(string message);
Implement a simple logger:
• ConsoleTransactionLogger : ITransactionLogger
• Logs messages to the console.
2.4 BankService Class (Uses interface + accounts)
Create a BankService that coordinates accounts and logging.
Responsibilities:
• Holds a list of accounts: List<BankAccount>
• Receives an ITransactionLogger via constructor injection
• Provides methods to add accounts and perform transactions
Required Methods:
• AddAccount(BankAccount account)
• Deposit(string accountNumber, decimal amount)
• Withdraw(string accountNumber, decimal amount)
• PrintAllSummaries()
3) Program Execution Requirements (Main)
In Program.Main (separate Program class), your program must:
• Create one SavingsAccount and one CheckingAccount
• Add them to BankService
• Perform at least 2 deposits and 2 withdrawals
• Print account summaries at the end
• Print log messages for each action using ITransactionLogger

4) Expected Output Example
[LOG] Added account: SA-1001 (Amit)
[LOG] Added account: CA-2001 (Sara)
[LOG] Deposit 500 into SA-1001. Balance=1500
[LOG] Withdraw 300 from SA-1001. Balance=1200
[LOG] Withdraw 2000 from CA-2001. Balance=-500 (Overdraft used)
---- ACCOUNT SUMMARIES ----
SavingsAccount SA-1001 | Holder=Amit | Balance=1200 | Rate=0.05
CheckingAccount CA-2001 | Holder=Sara | Balance=-500 |
OverdraftLimit=1000

5) Design Notes / Constraints
Must use:
• abstract class BankAccount
• override Withdraw() in SavingsAccount and CheckingAccount
• virtual GetAccountSummary() overridden in both derived classes
• interface ITransactionLogger
• BankService uses ITransactionLogger and List<BankAccount>
Must NOT:
• Put business rules inside Main
• Use if-account-is-SavingsAccount checks in BankService (design smell)
• Use public fields (use properties)
6) Optional Extensions (If time allows)
• Add LoanAccount with different withdrawal rules
• Add IInterestBearing interface for accounts that support interest
• Add Transfer(fromAccount, toAccount, amount) in BankService

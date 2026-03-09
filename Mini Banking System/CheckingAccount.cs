using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Banking_System
{
    public class CheckingAccount : BankAccount
    {
        public decimal OverdraftLimit { get; set; }
        public override decimal Withdraw(decimal amount)
        {
            decimal totalAmount = OverdraftLimit + this.Balance;
            if (totalAmount < amount)
            {
                throw new ArgumentException("Withdrawal exceeds overdraft limit");
            }
            else
            {
                return this.Balance - amount;
            }
        }

        public override void DisplayAccountInfo()
        {
            base.DisplayAccountInfo();
            Console.WriteLine($"Overdraft limit of ${OverdraftLimit}");
        }
    }
}

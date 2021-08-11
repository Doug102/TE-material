using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
     public class CreditCardAccount : IAccountable

    {
        
        public string AccountHolderName { get; }
        public string AccountNumber { get; }
        public int Debt
        {
            get
            {
               return Balance *  -1;
            }
            set
            {
                Balance = value;
            }
        }

        public int Balance { get; private set; }
        


        public CreditCardAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            Debt = 0;
        }
        public int Pay(int amountToPay)
        {

            Balance = Debt + amountToPay;
            return Balance;
        }
        public int Charge(int amountToCharge)
        {
            Balance = Debt - amountToCharge;
            return Balance;
        }
        
    }
}

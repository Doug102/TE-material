using System;
using System.Collections.Generic;
using System.Text;

namespace BankTellerExercise
{
    public class BankCustomer
    {
        private List<IAccountable> accountList = new List<IAccountable>();
        private int accountSum = 0;

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVip
        {

            get
            {

                 
                foreach (IAccountable account in accountList)
                {
                    accountSum += account.Balance;
                }
                if (accountSum >= 25000)
                {
                    return true;
                }
                else
                {
                   return false;
                }
            }
          
        }
     
        public void AddAccount(IAccountable newAccount)
        {
            accountList.Add(newAccount);

        }
        public IAccountable[] GetAccounts()
        {
            return accountList.ToArray();

        }




    }
}

namespace BankTellerExercise.Classes
{
    public class SavingsAccount : BankAccount
    {

        public SavingsAccount(string accountHolderName, string accountNumber) : base(accountHolderName, accountNumber)
        {

        }
        public SavingsAccount(string accountHolderName, string accountNumber, decimal balance) : base(accountHolderName, accountNumber, balance)
        {

        }


        public override decimal Withdraw(decimal amountToWithdraw)
        {
            
            if (amountToWithdraw > Balance)
            {
                return Balance;
            }
            else if (Balance < 150M && Balance - amountToWithdraw < 2)
            {
                return Balance;
            }

            else if (Balance - amountToWithdraw < 150M)
            {
                
                return base.Withdraw(amountToWithdraw + 2M);
            }
            else
            {
                
                return base.Withdraw(amountToWithdraw);
                

            }

        }

    }
}

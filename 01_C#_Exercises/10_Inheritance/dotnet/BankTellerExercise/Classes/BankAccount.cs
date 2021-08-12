namespace BankTellerExercise.Classes
{
    public class BankAccount
    {
        public string AccountHolderName { get; private set; }
        public string AccountNumber { get; set; }
        public decimal Balance { get; private set; }

        public BankAccount(string accountHolderName, string accountNumber)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            Balance = 0M;
        }
        public BankAccount(string accountHolderName, string accountNumber, decimal balance)
        {
            AccountHolderName = accountHolderName;
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public decimal Deposit(decimal amountToDeposit)
        {
            Balance += amountToDeposit;
            return Balance;
        }
        public virtual decimal Withdraw(decimal amountToWithdraw)
        {
            Balance -= amountToWithdraw;
            return Balance;
        }

    }
}

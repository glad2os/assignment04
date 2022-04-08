namespace assignment04.Account 
{

    public class VisaAccount : Account
    {
        private double creditLimit;
        private static double INTEREST_RATE = 0.1995;
        private const int Month = 12;

        public VisaAccount(double balance = 0, double creditLimit = 1200) : base("VS-", balance)
        {
            this.creditLimit = creditLimit;
        }

        public void DoPayment(double amount, Person person)
        {
            base.Deposit(amount, person);
        }


        public void DoPurchase(double amount, Person person)
        {
            if (!this.IsUser(person.Name)) throw new AccountException(AccountException.ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
            if (!person.IsAuthenticated) throw new AccountException(AccountException.ExceptionEnum.USER_NOT_LOGGED_IN);
            if (amount > this.Balance) throw new AccountException(AccountException.ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
            this.Deposit(-amount, person);
        }

        public void PrepareMonthlyStatement()
        {
            double interest = LowestBalance * (INTEREST_RATE / Month);
            this.Balance -= interest;
            this.transactions.Clear();
        }
        public void Withdraw(double amount, Person person)
        {

        }
    }
}
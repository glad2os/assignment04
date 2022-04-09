namespace assignment04.Account 
{

    public class CheckingAccount : Account
    {
        private static double COST_PER_TRANSACTION = 0.05;
        private static double INTEREST_RATE = 0.005;
        private const int MONTH = 12;
        private bool hasOverdraft;

        public CheckingAccount(double balance = 0, bool hasOverdraft = false) : base("CK-", balance)
        {
            this.hasOverdraft = hasOverdraft;
        }

        public void Withdraw(double amount, Person person)
        {
            foreach (var item in base.users)
            {
                if (person.Name != item.Name)
                {
                    throw new AccountException(ExceptionEnum.NAME_NOT_ASSOCIATED_WITH_ACCOUNT);
                }
                else if (person.IsAuthenticated == false)
                {
                    throw new AccountException(ExceptionEnum.USER_NOT_LOGGED_IN);
                }
                else if (amount > CreditLimit)
                {
                    throw new AccountException(ExceptionEnum.CREDIT_LIMIT_HAS_BEEN_EXCEEDED);
                }
                else
                {
                    base.Deposit(-amount, person);
                }
            }
        }

        public void Deposit(double amount, Person person)
        {
            base.Deposit(amount, person);
            base.OnTransactionOccur(amount, person);
        }
        public override void PrepareMonthlyReport()
        {
            double interests;
            interests = INTEREST_RATE * LowestBalance / 12;
            Balance = Balance - interests;
            transactions.Clear();
        }
    }
}
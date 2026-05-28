namespace WebApplicationAws.src.Domain.Accounts
{
    public class Account
    {
        private Guid guid;
        private Money money;

        public Account(Guid guid, string ownerName, Money money)
        {
            this.guid = guid;
            OwnerName = ownerName;
            this.money = money;
        }

        public Guid Id { get; set; }
        public string OwnerName { get; set; }
        public decimal Balance { get; set; }

        public void Deposit(decimal amount) => Balance += amount;
        public void Withdraw(decimal amount)
        {
            if (Balance < amount) throw new InvalidOperationException("Insufficient funds");
            Balance -= amount;
        }
    }
}

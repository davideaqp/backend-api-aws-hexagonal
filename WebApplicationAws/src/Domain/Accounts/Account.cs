namespace WebApplicationAws.src.Domain.Accounts
{
    public class Account
    {
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

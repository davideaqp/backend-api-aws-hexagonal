namespace WebApplicationAws.src.Domain.Transactions
{
    public class Transaction
    {
        public Guid Id { get; private set; }
        public Guid AccountId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime Date { get; private set; }
        public string Type { get; private set; }

        // Constructor parametrizado (para crear nuevas transacciones)
        public Transaction(Guid accountId, decimal amount, DateTime date, string type)
        {
            Id = Guid.NewGuid();
            AccountId = accountId;
            Amount = amount;
            Date = date;
            Type = type;
        }
    }
}

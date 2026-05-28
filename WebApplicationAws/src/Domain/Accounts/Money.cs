namespace WebApplicationAws.src.Domain.Accounts
{
    public record Money(decimal Amount)
    {
        public Money Add(Money other) => new Money(Amount + other.Amount);

        public Money Subtract(Money other) => new Money(Amount - other.Amount);

        public bool IsLessThan(Money other) => Amount < other.Amount;

        public bool IsGreaterOrEqual(Money other) => Amount >= other.Amount;

        public override string ToString() => Amount.ToString("C");
    }
}

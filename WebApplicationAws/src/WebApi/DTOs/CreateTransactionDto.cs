namespace WebApplicationAws.src.WebApi.DTOs
{
    public class CreateTransactionDto
    {
        public Guid AccountId { get; set; } 
        public decimal Amount { get; set; } 
        public DateTime Date { get; set; }  
        public string Type { get; set; } 
    }
}

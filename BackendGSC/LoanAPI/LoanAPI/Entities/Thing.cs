namespace LoadApi.Entities
{
    public class Thing : EntityBase
    {
        public string Description { get; set; } = string.Empty;

        public List<Loan>? Loans { get; set; }

        public Category? Category { get; set; }

        public int CategoryId { get; set; }
    }
}

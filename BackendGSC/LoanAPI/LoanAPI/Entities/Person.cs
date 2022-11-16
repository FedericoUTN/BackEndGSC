namespace LoadApi.Entities
{
    public class Person : EntityBase
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public Address? Address { get; set; }

        public int AddressId { get; set; }

        public List<Loan>? Loans { get; set; }
    }
}

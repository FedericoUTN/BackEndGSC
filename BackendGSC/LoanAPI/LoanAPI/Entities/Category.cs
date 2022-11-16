namespace LoadApi.Entities
{
    public class Category : EntityBase
    {
        public string Description{ get; set; } = string.Empty;

        public List<Thing>? Things { get; set; }
    }
}

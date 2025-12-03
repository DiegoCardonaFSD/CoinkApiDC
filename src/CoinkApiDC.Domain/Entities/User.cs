namespace CoinkApiDC.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
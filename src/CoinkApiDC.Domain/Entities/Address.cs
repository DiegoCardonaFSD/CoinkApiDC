namespace CoinkApiDC.Domain.Entities
{
    public class Address
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }

        public int CityId { get; set; }
        public City? City { get; set; }

        public string Street { get; set; } = string.Empty;
    }
}

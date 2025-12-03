namespace CoinkApiDC.Models
{
    public class Address
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public required  User User { get; set; }

        public int CityId { get; set; }
        public required  City City { get; set; }

        public string Street { get; set; } = string.Empty;
    }
}

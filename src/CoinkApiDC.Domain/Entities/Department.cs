namespace CoinkApiDC.Domain.Entities
{
    public class Department
    {
        public int Id { get; set; }

        public int CountryId { get; set; }
        public Country? Country { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
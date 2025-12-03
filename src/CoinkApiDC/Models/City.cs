namespace CoinkApiDC.Models
{
    public class City
    {
        public int Id { get; set; }

        public int DepartmentId { get; set; }
        public required Department Department { get; set; }

        public string Name { get; set; } = string.Empty;

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
using System.ComponentModel.DataAnnotations;

namespace CoinkApiDC.Application.DTOs
{
    public class CreateUserRequest
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        [Phone(ErrorMessage = "Invalid phone number")]
        public required string Phone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(200)]
        public required string Address { get; set; }

        [Required(ErrorMessage = "CityId is required")]
        public required int CityId { get; set; }

        [Required(ErrorMessage = "DepartmentId is required")]
        public required int DepartmentId { get; set; }

        [Required(ErrorMessage = "CountryId is required")]
        public required int CountryId { get; set; }
    }
}

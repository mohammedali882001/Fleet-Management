using System.ComponentModel.DataAnnotations;

namespace AnasProject.DTOS
{
    public class DriverDTO
    {
        [Required]
        [MaxLength(25)]
        [MinLength(2)]
        public string DriverName { get; set; }

        [Required]
        [PhoneNumberValidation]
        public string PhoneNumber { get; set; }
    }
}

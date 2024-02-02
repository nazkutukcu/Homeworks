using System.ComponentModel.DataAnnotations;

namespace Homework1.API.Models.DTOs
{
    public class UserSaveDtoRequest
    {
        // dto is designed to avoid unnecessary data transfer, client must only provide required fields.

        [StringLength(10,MinimumLength =3, ErrorMessage = "user name must be between 3 and 10 characters!")]
        [Required(ErrorMessage = "user name cannot be empty!")]
        public string Name { get; set; } = null!;

        [StringLength(10, MinimumLength = 3, ErrorMessage = "user surname must be between 3 and 10 characters!")]
        [Required(ErrorMessage = "user surname cannot be empty!")]
        public string Surname { get; set; } = null!;

        [Range(18,64,ErrorMessage = "user age must be between 18 and 64!")]
        [Required(ErrorMessage = "user age cannot be empty!")]
        public int? Age { get; set; } 
    }
}

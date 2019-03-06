using System.ComponentModel.DataAnnotations;

namespace DatingApp.API.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        public string Username {get; set;}
        [Required]
        [StringLength(10, MinimumLength = 6,ErrorMessage = "Tou must specify password between 4 and 8 character")]
        public string Password {get; set;}
    }
}
using System.ComponentModel.DataAnnotations;

namespace dotNetRestApi.Domain.Models.DTOs
{
    public class SigInDTO
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}

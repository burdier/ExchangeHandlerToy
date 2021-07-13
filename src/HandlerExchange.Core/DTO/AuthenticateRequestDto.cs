using System.ComponentModel.DataAnnotations;

namespace HandlerExchange.Core.DTO
{
    public class AuthenticateRequestDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }      
    }
}
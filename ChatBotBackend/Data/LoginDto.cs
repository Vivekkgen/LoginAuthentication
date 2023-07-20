using System.ComponentModel.DataAnnotations;

namespace ChatBotBackend.Data
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string EmployeeEmail { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "Your Password is limited to {2} to {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}

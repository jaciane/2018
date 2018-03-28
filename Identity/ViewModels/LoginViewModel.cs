using System.ComponentModel.DataAnnotations;

namespace Identity.Model
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "O campo E-mail não está em um formato válido")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Manter conectado?")]
        public bool RememberMe { get; set; }
    }
}